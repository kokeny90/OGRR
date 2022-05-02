using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.Configuration;
using System.Configuration;

public partial class Admin_Admin : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                SqlDataSourceUsers.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                SqlDataSourceUserName.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                SqlDataSourceMenu.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                SqlDataSourceMenuTop.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                CheckBoxListTopMenu.DataSource = SqlDataSourceMenuTop;
                DropDownListUser.DataBind();
                DropDownListUser.Items.Insert(0, new ListItem("All", "0"));
                userdata.Visible = false;
                Session["UserSQL"]= "SELECT * FROM [Users] ORDER BY [UserId] DESC ";
                SqlDataSourceUsers.SelectCommand = Session["UserSQL"].ToString();
                GridViewUsers.DataSource = SqlDataSourceUsers;
                GridViewUsers.DataBind();
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

    }

    protected void GridViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewUsers.EditIndex = e.NewEditIndex;
        frissit();
    }


    protected void GridViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewUsers.EditIndex = -1;
        frissit();

    }

    protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label LabelUserIdEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("LabelUserIdEdit") as Label);
        TextBox TextBoxUsernameEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("TextBoxUsernameEdit") as TextBox);
        TextBox TextBoxPasswordEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("TextBoxPasswordEdit") as TextBox);
        TextBox TextBoxEmailEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("TextBoxEmailEdit") as TextBox);
        TextBox TextBoxSignatureEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("TextBoxSignatureEdit") as TextBox);
        TextBox TextBoxNevEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("TextBoxNevEdit") as TextBox);
        TextBox TextBoxCegIDEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("TextBoxCegIDEdit") as TextBox);
        CheckBox CheckBoxTorolveEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("CheckBoxTorolveEdit") as CheckBox);
        CheckBox CheckBoxPasswordChangeEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("CheckBoxPasswordChangeEdit") as CheckBox);
        TextBox TextBoxHomePageEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("TextBoxHomePageEdit") as TextBox);
        CheckBox CheckBoxactiveEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("CheckBoxactiveEdit") as CheckBox);
       
        string sql = "UPDATE[dbo].[Users] SET[Username] ='" + TextBoxUsernameEdit.Text.ToString() + "',[Password] ='" + TextBoxPasswordEdit.Text.ToString() + "',[Email] ='" + TextBoxEmailEdit.Text.ToString() + "',[Signature] ='" + TextBoxSignatureEdit.Text.ToString() + "',[Nev] ='" + TextBoxNevEdit.Text.ToString() + "',[CegID] = " + (string.IsNullOrEmpty(TextBoxCegIDEdit.Text.ToString()) ? 0 : int.Parse(TextBoxCegIDEdit.Text.ToString())).ToString()    + ",[torolve] = " + (CheckBoxTorolveEdit.Checked? 1:0 ).ToString()  + ",[PasswordChange] =" + (CheckBoxPasswordChangeEdit.Checked ? 1 : 0).ToString()   + ",[HomePage] =" + (string.IsNullOrEmpty(TextBoxHomePageEdit.Text.ToString()) ? 0 : int.Parse(TextBoxHomePageEdit.Text.ToString())).ToString()   + ",[active] =" + (CheckBoxactiveEdit.Checked ? 1 : 0).ToString() + "WHERE [UserId] =" + LabelUserIdEdit.Text.ToString() + ";";
        Functions.Exec(sql, "", Session["login"].ToString(), "");
        GridViewUsers.EditIndex = -1;
        frissit();
    }
    protected void ImageButtonAdd_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TextBoxUsername = (GridViewUsers.FooterRow.FindControl("TextBoxUsername") as TextBox);
        TextBoxUsername.Visible = true;
        TextBox TextBoxPassword = (GridViewUsers.FooterRow.FindControl("TextBoxPassword") as TextBox);
        TextBoxPassword.Visible = true;
        TextBox TextBoxEmail = (GridViewUsers.FooterRow.FindControl("TextBoxEmail") as TextBox);
        TextBoxEmail.Visible = true;
        TextBox TextBoxCreatedDate = (GridViewUsers.FooterRow.FindControl("TextBoxCreatedDate") as TextBox);
        TextBoxCreatedDate.Visible = true;
        TextBox TextBoxSignature = (GridViewUsers.FooterRow.FindControl("TextBoxSignature") as TextBox);
        TextBoxSignature.Visible = true;
        TextBox TextBoxNev = (GridViewUsers.FooterRow.FindControl("TextBoxNev") as TextBox);
        TextBoxNev.Visible = true;
        TextBox TextBoxCegID = (GridViewUsers.FooterRow.FindControl("TextBoxCegID") as TextBox);
        TextBoxCegID.Visible = true;
        CheckBox CheckBoxtorolve = (GridViewUsers.FooterRow.FindControl("CheckBoxtorolve") as CheckBox);
        CheckBoxtorolve.Visible = true;
        CheckBox CheckBoxPasswordChange = (GridViewUsers.FooterRow.FindControl("CheckBoxPasswordChange") as CheckBox);
        CheckBoxPasswordChange.Visible = true;
        TextBox TextBoxHomePage = (GridViewUsers.FooterRow.FindControl("TextBoxHomePage") as TextBox);
        TextBoxHomePage.Visible = true;
        CheckBox CheckBoxactive = (GridViewUsers.FooterRow.FindControl("CheckBoxactive") as CheckBox);
        CheckBoxactive.Visible = true;

        ImageButton ImageButtonCancel = (GridViewUsers.FooterRow.FindControl("ImageButtonCancel") as ImageButton);
        ImageButtonCancel.Visible = true;
        ImageButton ImageButtonOK = (GridViewUsers.FooterRow.FindControl("ImageButtonOK") as ImageButton);
        ImageButtonOK.Visible = true;
        ImageButton ImageButtonAdd = (GridViewUsers.FooterRow.FindControl("ImageButtonAdd") as ImageButton);
        ImageButtonAdd.Visible = false;
    }
    protected void ImageButtonCancel_Click(object sender, ImageClickEventArgs e)
    {

        TextBox TextBoxUsername = (GridViewUsers.FooterRow.FindControl("TextBoxUsername") as TextBox);
        TextBoxUsername.Visible = false;
        TextBox TextBoxPassword = (GridViewUsers.FooterRow.FindControl("TextBoxPassword") as TextBox);
        TextBoxPassword.Visible = false;
        TextBox TextBoxEmail = (GridViewUsers.FooterRow.FindControl("TextBoxEmail") as TextBox);
        TextBoxEmail.Visible = false;
        TextBox TextBoxCreatedDate = (GridViewUsers.FooterRow.FindControl("TextBoxCreatedDate") as TextBox);
        TextBoxCreatedDate.Visible = false;
        TextBox TextBoxSignature = (GridViewUsers.FooterRow.FindControl("TextBoxSignature") as TextBox);
        TextBoxSignature.Visible = false;
        TextBox TextBoxNev = (GridViewUsers.FooterRow.FindControl("TextBoxNev") as TextBox);
        TextBoxNev.Visible = false;
        TextBox TextBoxCegID = (GridViewUsers.FooterRow.FindControl("TextBoxCegID") as TextBox);
        TextBoxCegID.Visible = false;
        CheckBox CheckBoxtorolve = (GridViewUsers.FooterRow.FindControl("CheckBoxtorolve") as CheckBox);
        CheckBoxtorolve.Visible = false;
        CheckBox CheckBoxPasswordChange = (GridViewUsers.FooterRow.FindControl("CheckBoxPasswordChange") as CheckBox);
        CheckBoxPasswordChange.Visible = false;
        TextBox TextBoxHomePage = (GridViewUsers.FooterRow.FindControl("TextBoxHomePage") as TextBox);
        TextBoxHomePage.Visible = false;

        CheckBox CheckBoxactive = (GridViewUsers.FooterRow.FindControl("CheckBoxactive") as CheckBox);
        CheckBoxactive.Visible = true;





        ImageButton ImageButtonCancel = (GridViewUsers.FooterRow.FindControl("ImageButtonCancel") as ImageButton);
        ImageButtonCancel.Visible = false;
        ImageButton ImageButtonOK = (GridViewUsers.FooterRow.FindControl("ImageButtonOK") as ImageButton);
        ImageButtonOK.Visible = false;
        ImageButton ImageButtonAdd = (GridViewUsers.FooterRow.FindControl("ImageButtonAdd") as ImageButton);
        ImageButtonAdd.Visible = true;

    }
    protected void ImageButtonOK_Click(object sender, ImageClickEventArgs e)
    {
        TextBox TextBoxUsername = (GridViewUsers.FooterRow.FindControl("TextBoxUsername") as TextBox);
        TextBox TextBoxPassword = (GridViewUsers.FooterRow.FindControl("TextBoxPassword") as TextBox);
        TextBox TextBoxEmail = (GridViewUsers.FooterRow.FindControl("TextBoxEmail") as TextBox);
        TextBox TextBoxSignature = (GridViewUsers.FooterRow.FindControl("TextBoxSignature") as TextBox);
        TextBox TextBoxNev = (GridViewUsers.FooterRow.FindControl("TextBoxNev") as TextBox);
        TextBox TextBoxCegID = (GridViewUsers.FooterRow.FindControl("TextBoxCegID") as TextBox);
        CheckBox CheckBoxtorolve = (GridViewUsers.FooterRow.FindControl("CheckBoxtorolve") as CheckBox);
        CheckBox CheckBoxPasswordChange = (GridViewUsers.FooterRow.FindControl("CheckBoxPasswordChange") as CheckBox);
        TextBox TextBoxHomePage = (GridViewUsers.FooterRow.FindControl("TextBoxHomePage") as TextBox);
        CheckBox CheckBoxactive = (GridViewUsers.FooterRow.FindControl("CheckBoxactive") as CheckBox);




        String query = "INSERT INTO  [dbo].[Users]([Username],[Password],[Email],[CreatedDate],[Signature],[Nev],[CegID],[torolve],[PasswordChange],[HomePage],[active]) VALUES (@Username,@Password, @Email, @CreatedDate,@Signature,@Nev,@CegID,@torolve,@PasswordChange,@HomePage,@active)";
        using (SqlConnection connection = new SqlConnection(Functions.ConnectionString(Session["login"].ToString())))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Username", SqlDbType.VarChar).Value = TextBoxUsername.Text.Trim();
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = TextBoxPassword.Text.Trim();
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = TextBoxEmail.Text.Trim();
                command.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value =
                command.Parameters.Add("@Signature", SqlDbType.Text).Value = TextBoxSignature.Text.Trim();
                command.Parameters.Add("@Nev", SqlDbType.VarChar).Value = TextBoxPassword.Text.Trim();
                command.Parameters.Add("@CegID", SqlDbType.Int).Value = TextBoxPassword.Text.Trim();
                command.Parameters.Add("@torolve", SqlDbType.Binary).Value = TextBoxPassword.Text.Trim();
                command.Parameters.Add("@PasswordChange", SqlDbType.Binary).Value = TextBoxPassword.Text.Trim();
                command.Parameters.Add("@HomePage", SqlDbType.Int).Value = TextBoxPassword.Text.Trim();
                command.Parameters.Add("@active", SqlDbType.Binary).Value = TextBoxPassword.Text.Trim();





                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


    }

    protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;text-align: center;");
        }

        if (e.Row.RowType == DataControlRowType.DataRow && userdata.Visible)
        {
            Label LabelLabelUsername = e.Row.FindControl("LabelUsername") as Label;
            Label LabelPassword = e.Row.FindControl("LabelPassword") as Label;
            Label LabelEmail = e.Row.FindControl("LabelEmail") as Label;
            Label LabelNev = e.Row.FindControl("LabelNev") as Label;
            tb_email.Text = LabelEmail.Text.ToString();
            tb_nev.Text = LabelNev.Text.ToString();
            txtPassword.Text = LabelPassword.Text.ToString();
            txtConfirmPassword.Text = LabelPassword.Text.ToString();
            tb_felhasznalonev.Text = LabelLabelUsername.Text.ToString();

        }



    }

    protected void ButtonMailSettings_Click(object sender, EventArgs e)
    {
        MailSettings.Visible = true;
        UsersSettings.Visible = false;
        DatabaseSettings.Visible = false;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            con.Open();
            string cmdString = "SELECT * from [MailSetting];";
            SqlDataReader dr = Functions.ExecQuery(con, cmdString);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TextBoxMailAddress.Text = dr["MailAddress"].ToString();
                    TextBoxPort.Text = dr["Port"].ToString();
                    TextBoxPassword.Text = dr["Password"].ToString();
                    TextBoxHost.Text = dr["Host"].ToString();

                }
            }
            con.Close();
        }
    }
    protected void ButtonMailSettingsSave_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            string query = "UPDATE  dbo.[MailSetting] SET MailAddress='" + TextBoxMailAddress.Text.ToString() + "',Port=" + TextBoxPort.Text.ToString().Trim() + ",Password = '" + TextBoxPassword.Text + "',Host='" + TextBoxHost.Text + "'";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close(); ;

            }
        }
        MailSettings.Visible = false;
        ButtonUsersSettings.Visible = false;
        DatabaseSettings.Visible = false;
        TextBoxMailAddress.Text = "";
        TextBoxPort.Text = "";
        TextBoxPassword.Text = "";
        TextBoxHost.Text = "";
    }

    protected void ButtonDatabaseCreat_Click(object sender, EventArgs e)
    {
        string folderPath = HostingEnvironment.MapPath("~//App_Data//");

        var filename = folderPath + @"DB//testdb.mdf";



        if (!System.IO.File.Exists(filename))
        {

            string sqlConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '" + folderPath + @"DB\Database.mdf'; Integrated Security = True";

            string script = File.ReadAllText(folderPath + @"//script.sql");

            SqlConnection conn = new SqlConnection(sqlConnectionString);
            //Server server = new Server(new ServerConnection(conn));
            //server.ConnectionContext.ExecuteNonQuery(script);
        }


    }

    protected void ButtonTestMail_Click(object sender, EventArgs e)
    {

        Functions.EMailKuld("teszt e-mail", "teszt e-mail", TextBoxMailAddress.Text.ToString());

    }

    protected void ButtonUsersSettings_Click(object sender, EventArgs e)
    {
        MailSettings.Visible = false;
        UsersSettings.Visible = true;
        DatabaseSettings.Visible = false;
    }

    protected void ButtonDatabaseSettings_Click(object sender, EventArgs e)
    {
        MailSettings.Visible = false;
        UsersSettings.Visible = false;
        DatabaseSettings.Visible = true;
        TextBoxConnectionString.Text = Functions.ConnectionString(User.Identity.Name).ToString();
    }
    protected void CheckBoxListUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        string where = "";

        foreach (ListItem item in CheckBoxListTopMenu.Items)
        {
            if (item.Selected)
            {

                where += "ParentmenuId =" + item.Value.ToString();
                where += " or ";
            }
        }
        if (where != "")
        {
            CheckBoxListMenu.Items.Clear();
            where = where.Remove(where.Length - 3, 3);
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT MenuId, Name FROM TPageNames where " + where;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Name"].ToString();
                            item.Value = sdr["MenuId"].ToString();
                            item.Selected = true;
                            CheckBoxListMenu.Items.Add(item);
                        }
                    }
                    con.Close();
                }
            }

        }
        else
        {
            CheckBoxListMenu.Items.Clear();
        }
    }



    protected void DropDownListUser_SelectedIndexChanged(object sender, EventArgs e)
    {

        string user = DropDownListUser.SelectedItem.ToString(); 
        if (DropDownListUser.SelectedValue.ToString() == "0")
        {
            userdata.Visible = false;
            Session["UserSQL"]  = "SELECT * FROM [Users] ORDER BY [UserId] DESC ";



        }
        else
        {
            userdata.Visible = true;
            Session["UserSQL"]  = "SELECT * FROM [Users] where Username='" + user.ToString() + "' ORDER BY [UserId] DESC";       
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT dbo.TPageNames.ParentmenuId, dbo.TPageNames.Name, dbo.TPageNames.MenuId, dbo.Users.Username, dbo.Users.Nev, dbo.Users.Email, dbo.Users.Password  FROM dbo.Users INNER JOIN dbo.SwitchPageNames ON dbo.Users.UserId = dbo.SwitchPageNames.UserId INNER JOIN dbo.TPageNames ON dbo.SwitchPageNames.MenuId = dbo.TPageNames.MenuId WHERE(dbo.Users.Username = N'" + user.ToString() + "')";
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {              
                        while (sdr.Read())
                        {
                            if (sdr["ParentmenuId"].ToString()!="0")
                            {
                                ListItem item = new ListItem();
                                item.Text = sdr["Name"].ToString();
                                item.Value = sdr["MenuId"].ToString();
                                item.Selected = true;
                                CheckBoxListMenu.Items.Add(item);
                            }
                        
                        }
                    
                    }
                }
                con.Close();
            }




        }


        frissit();



    }
    protected void frissit()
    {
        SqlDataSourceUsers.ConnectionString = Functions.ConnectionString(User.Identity.Name);
        SqlDataSourceUsers.SelectCommand = Session["UserSQL"].ToString();
        GridViewUsers.DataSource = SqlDataSourceUsers;
        GridViewUsers.DataBind();




    }

 

    protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label LabelUserIdEdit = (GridViewUsers.Rows[e.RowIndex].FindControl("LabelUserId") as Label);
        string sql = "DELETE FROM [Users] WHERE [UserId] = " + LabelUserIdEdit.Text.ToString() + "; ";

        Functions.Exec(sql, "", Session["login"].ToString(), "");
        GridViewUsers.EditIndex = -1;
        frissit();
    }

    protected void ButtonDatabseSave_Click(object sender, EventArgs e)
    {
        Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
        var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
        section.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString = TextBoxConnectionString.Text.ToString();
        configuration.Save();
        configuration = WebConfigurationManager.OpenWebConfiguration("~");
        section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
        section.ConnectionStrings["TestConnectionString"].ConnectionString = TextBoxTestConnectionString.Text.ToString();
        configuration.Save();
    }
}
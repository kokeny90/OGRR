using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class UserCreat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            string blab = User.Identity.Name.ToString();
            blab = blab.ToLower().Trim();
            switch (blab)
            {
                case "sghucontrollinguser":

                    //   txtUsername.Text = "SGHU";
                    break;
                case "rbhmcontrollinguser":
                    //   txtUsername.Text = "RBHM";
                    break;
                case "mcpcontrollinguser":
                    // txtUsername.Text = "MCP";
                    break;
                case "jk89mc":
                    // txtUsername.Text = "MCP";
                    break;
                default:
                    Response.Redirect("OnlineGepjarmuRegisztraciosRendszer.aspx");
                    ButtonFelhsznalo.Visible = false;
                    ButtonRaktar.Visible = false;
                    LabelNev.Text = "Raktár név";
                    PanelAll.Visible = true;
                    masodiksor.Visible = true;
                    harmadiksor.Visible = true;
                    negyediksor.Visible = true;
                    break;
            }
            DropDownList2.Items.Insert(0, "' * Kérlek válassz egyet! *'");
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
    int userId = 0;
    protected void OnChangingPassword(object sender, LoginCancelEventArgs e)
    {
        if (!ChangePassword1.CurrentPassword.Equals(ChangePassword1.NewPassword, StringComparison.CurrentCultureIgnoreCase))
        {
            int rowsAffected = 0;
            string query = "UPDATE [Users] SET [Password] = @NewPassword WHERE [Username] = @Username AND [Password] = @CurrentPassword";
            string constr = ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@Username", DropDownList2.SelectedItem.ToString().Trim());
                        cmd.Parameters.AddWithValue("@CurrentPassword", ChangePassword1.CurrentPassword);
                        cmd.Parameters.AddWithValue("@NewPassword", ChangePassword1.NewPassword);
                        cmd.Connection = con;
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                if (rowsAffected > 0)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Password has been changed successfully.";
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "Password does not match with our database records.";
                }
            }
            ChangePassword1.Visible = false;
        }
        else
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "Old Password and New Password must not be equal.";
        }

        e.Cancel = true;
    }




    protected void RegisterUser(object sender, EventArgs e)
    {
        SqlDataReader dataReader;
        string query = "";
        string MAXPortak = "";

        if (LabelFejlec.Text.Trim() != "Porta Módositása")
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        string blab = User.Identity.Name.ToString().ToLower().Substring(0, 3);

                        switch (blab)
                        {
                            case "sgh":
                                cmd.Parameters.AddWithValue("@CegID", SqlDbType.Int).Value = 382;
                                break;
                            case "rbh":
                                cmd.Parameters.AddWithValue("@CegID", SqlDbType.Int).Value = 2;
                                break;
                            case "mcp":
                                cmd.Parameters.AddWithValue("@CegID", SqlDbType.Int).Value = 383;
                                break;
                            default:
                                cmd.Parameters.AddWithValue("@CegID", SqlDbType.Int).Value = DBNull.Value;
                                break;
                        }
                        if (LabelFejlec.Text.Trim() == "Porta Regisztrációja:")
                        {
                            cmd.Parameters.AddWithValue("@Emailellenorzes", SqlDbType.Bit).Value = 0;
                            cmd.Parameters.AddWithValue("@PasswordChange", SqlDbType.Bit).Value = 0;
                        }

                        else
                        {
                            cmd.Parameters.AddWithValue("@Emailellenorzes", SqlDbType.Bit).Value = 1;
                            cmd.Parameters.AddWithValue("@PasswordChange", SqlDbType.Bit).Value = 1;
                        }

                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }

            }
            string message = string.Empty;
            switch (userId)
            {
                case -1:
                    message = "Username already exists.Please choose a different username.";
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful. Activation email has been sent.";
                    SendActivationEmail(userId);
                    txtUsername.Text = "";




                    break;
            }
            LabelHibaKi.Text = message;
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            //  Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
        else
        {
            int portaID = int.Parse(DropDownList2.SelectedValue);
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {



                query = "DELETE FROM [RBHM_LOG-T].[dbo].[KapcsoloCegek] WHERE PortaID=@USerID;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@USerID", SqlDbType.Int).Value = portaID;
                    con.Open();
                    dataReader = command.ExecuteReader();
                    con.Close();
                }
                query = "DELETE FROM [RBHM_LOG-T].[dbo].[KapcsoloMitszallit] WHERE PortaID=@USerID;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@USerID", SqlDbType.Int).Value = portaID;
                    con.Open();
                    dataReader = command.ExecuteReader();
                    con.Close();
                }
                query = "DELETE FROM [RBHM_LOG-T].[dbo].[KapcsoloGepjarmuvek] WHERE PortaID=@USerID;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@USerID", SqlDbType.Int).Value = portaID;
                    con.Open();
                    dataReader = command.ExecuteReader();
                    con.Close();
                }
                query = "DELETE FROM [RBHM_LOG-T].[dbo].[KapcsoloTransportesrs] WHERE PortaID=@USerID;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@USerID", SqlDbType.Int).Value = portaID;
                    con.Open();
                    dataReader = command.ExecuteReader();
                    con.Close();
                }



            }



        }
        ///
        ///PORTAK///
        ///
        if (masodiksor.Visible == true)
        {
            int portaID = 0;
            if (DropDownList2.Visible == true)
            {
                portaID = int.Parse(DropDownList2.SelectedValue);
            }


            int be1 = 0;
            int be2 = 0;
            MAXPortak = portaID.ToString();

            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {
                if (LabelFejlec.Text.Trim() != "Porta Módositása")
                {
                    query = "INSERT INTO [RBHM_LOG-T].[dbo].[TPortak] ( USerID) VALUES (@USerID)";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.Add("@USerID", SqlDbType.Int).Value = int.Parse(userId.ToString());
                        con.Open();
                        dataReader = command.ExecuteReader();
                        con.Close();
                    }

                    query = "SELECT MAX(ID) FROM [dbo].[TPortak]";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();
                        dataReader = command.ExecuteReader();
                    }
                    if (dataReader.Read())
                    {
                        if (dataReader[0] != DBNull.Value)
                        {
                            MAXPortak = dataReader[0].ToString();
                        }
                    }

                    con.Close();
                }

                ///
                /// Lokáció(k):///
                ///
                else
                {
                    MAXPortak = portaID.ToString();
                }
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    query = "INSERT INTO [RBHM_LOG-T].[dbo].[KapcsoloCegek] ( PortaID, CegID ) VALUES (@PortaID,@CegID)";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        if (item.Selected)
                        {
                            command.Parameters.Add("@PortaID", SqlDbType.Int).Value = int.Parse(MAXPortak.ToString());
                            command.Parameters.Add("@CegID", SqlDbType.Int).Value = int.Parse(item.Value);
                            con.Open();
                            dataReader = command.ExecuteReader();
                            con.Close();
                        }
                    }
                }
                ///
                /// Gépjármű(k):///
                ///
                foreach (ListItem item in CheckBoxList2.Items)
                {
                    query = "INSERT INTO [RBHM_LOG-T].[dbo].[KapcsoloGepjarmuvek] ( PortaID, GepjarmuID ) VALUES (@PortaID,@GepjarmuID)";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        if (item.Selected)
                        {
                            command.Parameters.Add("@PortaID", SqlDbType.Int).Value = int.Parse(MAXPortak.ToString());
                            command.Parameters.Add("@GepjarmuID", SqlDbType.Int).Value = int.Parse(item.Value);
                            con.Open();
                            dataReader = command.ExecuteReader();
                            con.Close();
                        }
                    }
                }
                ////
                //Szállítmányozó(k):
                ////  

                foreach (GridViewRow row in GridView1.Rows)
                {
                    be1 = 0;
                    be2 = 0;
                    query = "INSERT INTO [RBHM_LOG-T].[dbo].[KapcsoloTransportesrs] ( PortaID, TransportesID, Fővállalkozó, Alvállalkozó ) VALUES (@PortaID,@TransportesID,@Fovallalkozo,@Alvallalkozo)";
                    CheckBox chk = row.Cells[2].FindControl("CheckBox1") as CheckBox;
                    CheckBox chk2 = row.Cells[3].FindControl("CheckBox2") as CheckBox;
                    if ((chk != null && chk.Checked) || (chk2 != null && chk2.Checked))
                    {
                        if (chk.Checked) be1 = 1;
                        if (chk2.Checked) be2 = 1;
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@PortaID", SqlDbType.Int).Value = int.Parse(MAXPortak.ToString());
                            command.Parameters.Add("@TransportesID", SqlDbType.Int).Value = int.Parse(row.Cells[0].Text);
                            command.Parameters.Add("@Fovallalkozo", SqlDbType.Bit).Value = Convert.ToBoolean(be1);
                            command.Parameters.Add("@Alvallalkozo", SqlDbType.Bit).Value = Convert.ToBoolean(be2);
                            con.Open();
                            command.ExecuteReader();
                            con.Close();
                        }
                    }
                }

                ///
                /// Mitszallit:///
                ///
                foreach (ListItem item in CheckBoxList3.Items)
                {
                    query = "INSERT INTO [RBHM_LOG-T].[dbo].[KapcsoloMitszallit] ( PortaID, MitszalitID ) VALUES (@PortaID,@MitszalitID)";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        if (item.Selected)
                        {
                            command.Parameters.Add("@PortaID", SqlDbType.Int).Value = int.Parse(MAXPortak.ToString());
                            command.Parameters.Add("@MitszalitID", SqlDbType.Int).Value = int.Parse(item.Value);
                            con.Open();
                            dataReader = command.ExecuteReader();
                            con.Close();
                        }
                    }
                }
            }
        }


    }

    private void SendActivationEmail(int userId)
    {

        string activationCode = Guid.NewGuid().ToString();
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        using (MailMessage mm = new MailMessage("no-reply@bosch.com", txtEmail.Text))
        {
            mm.Subject = "Account Activation";
            string body = "Hello " + txtUsername.Text.Trim() + ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("UserCreat.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("rb-smtp-int.bosch.com");
            smtpClient.Send(mm);


        }




    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        if (Panel1.Visible == true) Panel1.Visible = false; else Panel1.Visible = true;
    }
    protected void ButtonFelhsznalo_Click(object sender, EventArgs e)
    {
        LabelHibaKi.Text = "";
        //string blab = User.Identity.Name.ToString();
        //blab = blab.ToLower().Trim();
        //txtUsername.Enabled = false;
        //switch (blab)
        //{
        //    case "sghucontrollinguser":
        //        txtUsername.Text = "SGHU";
        //        break;
        //    case "rbhmcontrollinguser":
        //        txtUsername.Text = "RBHM";
        //        break;
        //    case "mcpcontrollinguser":
        //        txtUsername.Text = "MCP";
        //        break;
        //    default:
        //        ButtonFelhsznalo.Visible = false;
        //        ButtonRaktar.Visible = false;
        //        LabelNev.Text = "Raktár név";
        //        PanelAll.Visible = true;
        //        masodiksor.Visible = true;
        //        harmadiksor.Visible = true;
        //        negyediksor.Visible = true;
        //        break;
        //}
        //SqlDataReader dataReader;
        //string query;
        //query = "select RIGHT(username,4) from [dbo].[Users] where username LIKE  @bemenoadat order by UserId DESC ;";
        //using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        //{
        //    using (SqlCommand command = new SqlCommand(query, con))
        //    {
        //        command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = txtUsername.Text + "%";
        //        con.Open();
        //        dataReader = command.ExecuteReader();
        //    }
        //    if (dataReader.Read())
        //    {
        //        if (dataReader[0] != DBNull.Value)
        //        {
        //            int someInt = int.Parse(dataReader[0].ToString()) + 1;
        //            txtUsername.Text = txtUsername.Text.Trim() + DateTime.Now.Year.ToString() + someInt.ToString(new string('0', 4));
        //        }
        //    }
        //    else
        //    {
        //        txtUsername.Text = txtUsername.Text.Trim() + DateTime.Now.Year.ToString() + "0001";
        //    }
        //}
        jelszo.Visible = true;
        jelszo2.Visible = true;








        regijelszo.Visible = false;
        Button7.Visible = false;
        PanelAll.Visible = true;
        nulladiksor1.Visible = true;
        nulladiksor2.Visible = true;
        nulladiksor3.Visible = true;
        nulladiksor4.Visible = true;
        txtUsername.Visible = true;
        txtPassword.Visible = true;
        txtConfirmPassword.Visible = true;
        txtEmail.Visible = true;
        gombsor.Visible = true;
        LabelFejlec.Text = "Felhasználó Regisztrációja";
        elsosor.Visible = false;
        LabelNev.Text = "Felhasználó név";
        masodiksor.Visible = false;
        harmadiksor.Visible = false;
        negyediksor.Visible = false;
        otodiksor.Visible = false;
        Button5.Text = "Felhasználó Felvétele";
    }
    protected void ButtonRaktar_Click(object sender, EventArgs e)
    {
        LabelHibaKi.Text = "";
        txtUsername.Text = null;

        jelszo.Visible = true;
        jelszo2.Visible = true;
        LabelFejlec.Text = "Porta Regisztrációja:";
        regijelszo.Visible = false;
        nulladiksor1.Visible = true;
        nulladiksor2.Visible = true;
        nulladiksor3.Visible = true;
        nulladiksor4.Visible = true;
        txtUsername.Visible = true;
        txtPassword.Visible = true;
        txtConfirmPassword.Visible = true;
        txtEmail.Visible = true;
        elsosor.Visible = false;
        gombsor.Visible = true;
        LabelNev.Text = "Porta név:";
        PanelAll.Visible = true;
        masodiksor.Visible = true;
        harmadiksor.Visible = true;
        negyediksor.Visible = true;
        otodiksor.Visible = true;
        Button5.Text = "Porta Felvétele:";
        Button7.Visible = false;
    }
    protected void ButtonFelhsznalo0_Click(object sender, EventArgs e)
    {
        LabelHibaKi.Text = "";
        DropDownList2.DataSourceID = "Users";
        DropDownList2.DataValueField = "UserId";
        DropDownList2.DataTextField = "Username";



        LabelFejlec.Text = "Felhasználó Modositása";
        PanelAll.Visible = true;
        gombsor.Visible = false;
        Button7.Visible = true;
        regijelszo.Visible = false;
        nulladiksor1.Visible = false;
        nulladiksor2.Visible = false;
        nulladiksor3.Visible = false;
        nulladiksor4.Visible = false;
        txtUsername.Visible = false;
        txtPassword.Visible = false;
        txtConfirmPassword.Visible = false;
        txtEmail.Visible = false;
        DropDownList2.DataSourceID = "Users";
        elsosor.Visible = true;
        LabelNev.Text = "Felhasználó név";
        masodiksor.Visible = false;
        harmadiksor.Visible = false;
        negyediksor.Visible = false;
        otodiksor.Visible = false;
        string blab = User.Identity.Name.ToString().ToLower().Substring(0, 3);

        switch (blab)
        {
            case "sgh":
                Users.FilterExpression = @"(CegID='382'or CegID ='0') and not (Username like '%Controlling%') ";
                break;
            case "rbh":
                Users.FilterExpression = @"(CegID='2' or CegID ='0') and not (Username like '%Controlling%') ";
                break;
            case "mcp":
                Users.FilterExpression = @"(CegID='383' or CegID ='0') and  not (Username like '%Controlling%') ";
                break;
            default:
                Users.FilterExpression = null;
                break;
        }


















        Button5.Text = "Felhasználó Modositása";
        Button5.CausesValidation = false;
    }
    protected void ButtonRaktar0_Click(object sender, EventArgs e)
    {
        LabelHibaKi.Text = "";
        jelszo.Visible = false;
        jelszo2.Visible = false;
        PanelAll.Visible = true;
        gombsor.Visible = false;
        Button7.Visible = true;
        nulladiksor1.Visible = false;
        regijelszo.Visible = false;
        nulladiksor2.Visible = false;
        nulladiksor3.Visible = false;
        nulladiksor4.Visible = false;
        txtUsername.Visible = false;
        txtPassword.Visible = false;
        txtConfirmPassword.Visible = false;
        txtEmail.Visible = false;
        LabelFejlec.Text = "Porta Módositása";
        DropDownList2.DataSourceID = "SqlDataSourceRaktarak";
        DropDownList2.DataTextField = "Username";
        DropDownList2.DataValueField = "ID";
        elsosor.Visible = true;
        LabelNev.Text = "Raktár név";
        masodiksor.Visible = false;
        harmadiksor.Visible = false;
        negyediksor.Visible = false;
        otodiksor.Visible = false;



        string blab = User.Identity.Name.ToString().ToLower().Substring(0, 3);

        switch (blab)
        {
            case "sgh":
                Users.FilterExpression = @"CegID='382' and not (Username like '%Controlling%') ";
                break;
            case "rbh":
                Users.FilterExpression = @"CegID='2' and not (Username like '%Controlling%') ";
                break;
            case "mcp":
                Users.FilterExpression = @"CegID='383' and not (Username like '%Controlling%') ";
                break;
            default:
                Users.FilterExpression = null;
                break;
        }













        Button5.Text = "Porta Módositása";
        Button5.CausesValidation = false;

    }
    protected void ButtonLokacio_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        SqlDataReader dataReader;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = "INSERT INTO [RBHM_LOG-T].[dbo].[cegek] ( cegnev, orszag, iranyitoszam,varos, cim ) VALUES (@cegnev,@orszag,@iranyitoszam,@varos,@cim)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                if (TextBoxcegnev.Text.Trim() == null || TextBoxcegnev.Text.Trim() == "") command.Parameters.Add("@cegnev", SqlDbType.Text).Value = DBNull.Value; else command.Parameters.Add("@cegnev", SqlDbType.Text).Value = TextBoxcegnev.Text.Trim();
                command.Parameters.Add("@orszag", SqlDbType.Int).Value = int.Parse(DropDownListOrszag.SelectedIndex.ToString());
                if (TextBoxIranyitoszam.Text.Trim() == null || TextBoxIranyitoszam.Text.Trim() == "") command.Parameters.Add("@iranyitoszam", SqlDbType.Int).Value = DBNull.Value; else command.Parameters.Add("@iranyitoszam", SqlDbType.Int).Value = int.Parse(TextBoxIranyitoszam.Text.Trim());
                if (TextBoxVaros.Text.Trim() == null || TextBoxVaros.Text.Trim() == "") command.Parameters.Add("@varos", SqlDbType.Text).Value = DBNull.Value; else command.Parameters.Add("@varos", SqlDbType.Text).Value = TextBoxVaros.Text.Trim();
                if (TextBoxCim.Text.Trim() == null || TextBoxCim.Text.Trim() == "") command.Parameters.Add("@cim", SqlDbType.Text).Value = DBNull.Value; else command.Parameters.Add("@cim", SqlDbType.Text).Value = TextBoxCim.Text.Trim();
                con.Open();
                dataReader = command.ExecuteReader();
            }
        }
        Panel1.Visible = false;
        CheckBoxList1.DataBind();
        TextBoxcegnev.Text = "";
        TextBoxIranyitoszam.Text = "";
        TextBoxVaros.Text = "";
        TextBoxCim.Text = "";
        DropDownListOrszag.SelectedIndex = 0;
    }
    protected void ButtonTipus_Click(object sender, EventArgs e)
    {
        SqlDataReader dataReader;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = "INSERT INTO [RBHM_LOG-T].[dbo].[gepjarmuvekcsoportositasa] ( kategoria, gepjarmufajtai ) VALUES (@kategoria,@gepjarmufajtai)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                if (TextBoxkategoria.Text.Trim() == null || TextBoxkategoria.Text.Trim() == "") command.Parameters.Add("@kategoria", SqlDbType.Text).Value = DBNull.Value; else command.Parameters.Add("@kategoria", SqlDbType.Text).Value = TextBoxkategoria.Text.Trim();
                if (TextBoxgepjarmufajtai.Text.Trim() == null || TextBoxgepjarmufajtai.Text.Trim() == "") command.Parameters.Add("@gepjarmufajtai", SqlDbType.Int).Value = DBNull.Value; else command.Parameters.Add("@gepjarmufajtai", SqlDbType.Text).Value = TextBoxgepjarmufajtai.Text.Trim();
                con.Open();
                dataReader = command.ExecuteReader();
                con.Close();
            }
        }

        TextBoxkategoria.Text = "";
        TextBoxgepjarmufajtai.Text = "";
        CheckBoxList2.DataBind();
        SqlDataSource2.DataBind();
        Panel1.Visible = false;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        if (Panel2.Visible == true) Panel2.Visible = false; else Panel2.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = false;
        if (Panel3.Visible == true) Panel3.Visible = false; else Panel3.Visible = true;
    }
    protected void ButtonMitszallit_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        if (Panel4.Visible == true) Panel4.Visible = false; else Panel4.Visible = true;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlDataReader dataReader;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = "INSERT INTO [RBHM_LOG-T].[dbo].[mitszallit] ( megnevezes ) VALUES (@megnevezes)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                if (TextBoxMegnevezes.Text.Trim() == null || TextBoxMegnevezes.Text.Trim() == "") command.Parameters.Add("@megnevezes", SqlDbType.Text).Value = DBNull.Value; else command.Parameters.Add("@megnevezes", SqlDbType.Text).Value = TextBoxMegnevezes.Text.Trim();
                con.Open();
                dataReader = command.ExecuteReader();
                con.Close();
            }
        }
        TextBoxMegnevezes.Text = "";
        SqlDataSource2.DataBind();
        Panel4.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = "INSERT INTO [RBHM_LOG-T].[dbo].[Transportes]( transporter_name, transporter_email, post_code, city, address, country, transporter_contact_name, transporter_contact_name3, transporter_contact_phone, transporter_contact2_name, transporter_contact3_phone, transporter_contact2_phone) VALUES(@transporter_name, @transporter_email, @post_code, @city, @address, @country, @transporter1_contact_name, @transporter_contact3_name, @transporter1_contact_phone, @transporter_contact2_name, @transporter_contact3_phone, @transporter_contact2_phone )";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                if (TextBoxTransporterName.Text.Trim() == null || TextBoxTransporterName.Text.Trim() == "") command.Parameters.Add("@transporter_name", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter_name", SqlDbType.VarChar).Value = TextBoxTransporterName.Text.Trim();
                if (TextBoxTransporterEmail.Text.Trim() == null || TextBoxTransporterEmail.Text.Trim() == "") command.Parameters.Add("@transporter_email", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter_email", SqlDbType.VarChar).Value = TextBoxTransporterEmail.Text.Trim();
                if (TextBoxpostcode.Text.Trim() == null || TextBoxpostcode.Text.Trim() == "") command.Parameters.Add("@post_code", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@post_code", SqlDbType.VarChar).Value = TextBoxpostcode.Text.Trim();
                if (TextBoxCity.Text.Trim() == null || TextBoxCity.Text.Trim() == "") command.Parameters.Add("@city", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@city", SqlDbType.VarChar).Value = TextBoxCity.Text.Trim();
                if (TextBoxAddress.Text.Trim() == null || TextBoxAddress.Text.Trim() == "") command.Parameters.Add("@address", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@address", SqlDbType.VarChar).Value = TextBoxAddress.Text.Trim();
                command.Parameters.Add("@country", SqlDbType.Int).Value = int.Parse(DropDownListTransporterOrszag.SelectedIndex.ToString());

                if (TextBoxS1.Visible == true)
                {
                    if (TextBoxS1.Text.Trim() == null || TextBoxS1.Text.Trim() == "") command.Parameters.Add("@transporter1_contact_name", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter1_contact_name", SqlDbType.VarChar).Value = TextBoxS1.Text.Trim();
                    if (TextBox9.Text.Trim() == null || TextBox9.Text.Trim() == "") command.Parameters.Add("@transporter1_contact_phone", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter1_contact_phone", SqlDbType.VarChar).Value = TextBox9.Text.Trim();


                }
                else
                {
                    command.Parameters.Add("@transporter1_contact_name", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@transporter1_contact_phone", SqlDbType.VarChar).Value = DBNull.Value;
                }
                if (TextBoxS2.Visible == true)
                {
                    if (TextBoxS2.Text.Trim() == null || TextBoxS2.Text.Trim() == "") command.Parameters.Add("@transporter_contact2_name", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter_contact2_name", SqlDbType.VarChar).Value = TextBoxS2.Text.Trim();
                    if (TextBox10.Text.Trim() == null || TextBox10.Text.Trim() == "") command.Parameters.Add("@transporter_contact2_phone", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter_contact2_phone", SqlDbType.VarChar).Value = TextBox10.Text.Trim();


                }
                else
                {
                    command.Parameters.Add("@transporter_contact2_name", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@transporter_contact2_phone", SqlDbType.VarChar).Value = DBNull.Value;
                }
                if (TextBoxS1.Visible == true)
                {
                    if (TextBoxS3.Text.Trim() == null || TextBoxS3.Text.Trim() == "") command.Parameters.Add("@transporter_contact3_name", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter_contact3_name", SqlDbType.VarChar).Value = TextBoxS3.Text.Trim();
                    if (TextBox11.Text.Trim() == null || TextBox11.Text.Trim() == "") command.Parameters.Add("@transporter_contact3_phone", SqlDbType.VarChar).Value = DBNull.Value; else command.Parameters.Add("@transporter_contact3_phone", SqlDbType.VarChar).Value = TextBox11.Text.Trim();
                }
                else
                {
                    command.Parameters.Add("@transporter_contact3_name", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@transporter_contact3_phone", SqlDbType.VarChar).Value = DBNull.Value;
                }

                con.Open();
                command.ExecuteReader();

            }
            con.Close();
        }


        TextBoxTransporterName.Text = "";
        TextBoxTransporterEmail.Text = "";
        TextBoxpostcode.Text = "";
        TextBoxCity.Text = "";
        TextBoxAddress.Text = "";
        TextBoxS1.Text = "";
        TextBoxS2.Text = "";
        TextBoxS3.Text = "";
        TextBoxS3.Text = "";
        TextBox10.Text = "";
        TextBoxS3.Text = "";
        TextBox11.Text = "";


        Panel3.Visible = false;
        GridView1.DataBind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ButtonJelszo.Text = "Change " + DropDownList2.SelectedItem.ToString().Trim() + " Password";


        string query = "";
        Td1.Visible = true;
        if (LabelFejlec.Text == "Felhasználó Modositása")
        {

            regijelszo.Visible = false;
            nulladiksor2.Visible = false;
            nulladiksor3.Visible = false;
            nulladiksor4.Visible = false;
            txtUsername.Visible = false;
            txtPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            txtEmail.Visible = false;
            Button7.Visible = true;
            Button7.Text = "Felhasználó Törlése";
            Button5.Visible = false;
            gombsor.Visible = true;
        }
        else
        {
            Button5.Visible = true;
            gombsor.Visible = false;
            regijelszo.Visible = true;
            nulladiksor2.Visible = true;
            nulladiksor3.Visible = true;
            nulladiksor4.Visible = true;
            txtUsername.Visible = true;
            txtPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            txtEmail.Visible = true;
        }

        if (LabelFejlec.Text == "Porta Módositása")
        {
            PanelAll.Visible = true;
            gombsor.Visible = true;
            elsosor.Visible = true;
            masodiksor.Visible = true;
            harmadiksor.Visible = true;
            negyediksor.Visible = true;
            otodiksor.Visible = true;

            //Lokáció(k):
            query = "SELECT [cegnev] FROM [RBHM_LOG-T].[dbo].[Porta All]  WHERE (Username = @bemenoadat) GROUP BY cegnev";
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {
                using (DataTable dt = new DataTable())
                {

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = DropDownList2.SelectedItem.Text;
                        con.Open();
                        dt.Load(command.ExecuteReader());
                        con.Close();
                    }
                    CheckBoxList1.DataBind();
                    foreach (DataRow dtRow in dt.Rows)
                    {

                        foreach (ListItem item in CheckBoxList1.Items)
                        {
                            if (item.Text == dtRow[0].ToString())
                            {
                                item.Selected = true;
                            }
                            else if (item.Selected == false)
                            {
                                item.Selected = false;
                            }

                        }


                    }
                }
                //Gépjármű tipusa:
                query = "SELECT [gepjarmufajtai] FROM [RBHM_LOG-T].[dbo].[Porta All]  WHERE (Username = @bemenoadat) GROUP BY gepjarmufajtai";
                using (DataTable dt = new DataTable())
                {

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = DropDownList2.SelectedItem.Text;
                        con.Open();
                        dt.Load(command.ExecuteReader());
                        con.Close();
                    }
                    CheckBoxList2.DataBind();
                    foreach (DataRow dtRow in dt.Rows)
                    {

                        foreach (ListItem item in CheckBoxList2.Items)
                        {
                            if (item.Text == dtRow[0].ToString())
                            {
                                item.Selected = true;
                            }
                            else if (item.Selected == false)
                            {
                                item.Selected = false;
                            }

                        }


                    }
                }
                //Szállítmányozó(k):


                GridView1.DataSourceID = null;

                query = "SELECT dbo.Transportes.transporter_name,dbo.Transportes.ID,dbo.KapcsoloTransportesrs.Fővállalkozó, dbo.KapcsoloTransportesrs.Alvállalkozó FROM dbo.Transportes LEFT OUTER JOIN dbo.KapcsoloTransportesrs ON dbo.Transportes.ID = dbo.KapcsoloTransportesrs.TransportesID AND dbo.KapcsoloTransportesrs.PortaID = @bemenoadat ORDER BY dbo.Transportes.transporter_name";
                using (DataTable dt = new DataTable())
                {

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.Add("@bemenoadat", SqlDbType.Int).Value = DropDownList2.SelectedValue;
                        con.Open();
                        dt.Load(command.ExecuteReader());
                        con.Close();
                    }
                    GridView1.DataSource = dt;

                    GridView1.DataBind();




                }
                //       //foreach (DataRow dtRow in dt.Rows)
                //       //{
                //       //    foreach (GridViewRow row in GridView1.Rows)
                //       //    {
                //       //        CheckBox chk = (CheckBox)row.Cells[2].FindControl("CheckBox1") as CheckBox;
                //       //        CheckBox chk2 = (CheckBox)row.Cells[3].FindControl("CheckBox2") as CheckBox;
                //       //        try
                //       //        {
                //       //            if (int.Parse(row.Cells[0].Text.ToString().Trim()) == int.Parse(dtRow[0].ToString().Trim()))
                //       //            {
                //       //                if (Convert.ToBoolean(dtRow[2].ToString())) chk.Checked = true; else chk.Checked = false;
                //       //                if (Convert.ToBoolean(dtRow[3].ToString())) chk2.Checked = true; else chk.Checked = false;
                //       //                break;
                //       //            }
                //       //            //else if (chk.Checked == false || chk2.Checked == false)
                //       //            //{
                //       //            //    chk.Checked = false;
                //       //            //    chk.Checked = false;
                //       //            //}
                //       //        }
                //       //        catch (Exception)
                //       //        {


                //       //        }



                //       //    }




                //       //}
                //  }
                //Mitszállíthat(k):
                query = "SELECT megnevezes FROM [RBHM_LOG-T].[dbo].[Porta All] WHERE (Username = @bemenoadat) GROUP BY megnevezes;";
                using (DataTable dt = new DataTable())
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = DropDownList2.SelectedItem.Text;
                        con.Open();
                        dt.Load(command.ExecuteReader());
                        con.Close();
                    }
                    CheckBoxList3.DataBind();
                    foreach (DataRow dtRow in dt.Rows)
                    {

                        foreach (ListItem item in CheckBoxList3.Items)
                        {
                            if (item.Text == dtRow[0].ToString())
                            {
                                item.Selected = true;
                            }
                            else if (item.Selected == false)
                            {
                                item.Selected = false;
                            }

                        }


                    }
                }




            }
        }
        else
        {
            //using (DataTable dt = new DataTable())
            //{
            //    dt = ((DataView)Users.Select(DataSourceSelectArguments.Empty)).Table;
            //    foreach (DataRow dtRow in dt.Rows)
            //    {
            //        if (dtRow[0].ToString() == DropDownList2.Text)
            //        {
            //            foreach (DataColumn dc in dt.Columns)
            //            {
            //                txtUsername.Text = dtRow[1].ToString();
            //                txtPassword.Text = dtRow[2].ToString();
            //                txtConfirmPassword.Text = dtRow[2].ToString();
            //                txtEmail.Text = dtRow[3].ToString();
            //            }
            //        }
            //    }
            //}
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string toemail = "";
        string query;
        string Username = User.Identity.Name.ToString();
        Username = Username.ToLower().Trim();


        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            query = "SELECT Email FROM [RBHM_LOG-T].[dbo].[Users] where [RBHM_LOG-T].[dbo].[Users].[UserId]=@id";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = DropDownList2.Text;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                {
                    try
                    {
                        while (reader.Read())
                        {
                            toemail = reader[0].ToString();
                        }

                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                }





            }
        }
        

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            if (LabelFejlec.Text == "Felhasználó Modositása")
            {
                query = "update [RBHM_LOG-T].[dbo].[Users] set [torolve]=1 where [RBHM_LOG-T].[dbo].[Users].[UserId]=@id";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = DropDownList2.Text;
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

                query = "SELECT Email FROM [RBHM_LOG-T].[dbo].[Users] where [RBHM_LOG-T].[dbo].[Users].[UserId]=@id";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = DropDownList2.Text;
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                toemail =toemail  + "," + reader[0].ToString();
                            }

                        }
                        finally
                        {
                            // Always call Close when done reading.
                            reader.Close();
                        }
                    }


                }
            }




















            else
            {
                //query = "SELECT UserId, ID FROM dbo.TPortak WHERE (ID = @PortaID)";
                query = "update [RBHM_LOG-T].[dbo].[Users] set [torolve]=1 where [RBHM_LOG-T].[dbo].[Users].[UserId]= (SELECT UserId FROM dbo.TPortak WHERE (ID = @PortaID))";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@PortaID", SqlDbType.VarChar).Value = DropDownList2.Text;
                    con.Open();
                    //dataReader = command.ExecuteReader();

                    //if (dataReader.Read())
                    //{
                    //    if (dataReader[0] != DBNull.Value)
                    //    {
                    //        command.Parameters.Add("@id", SqlDbType.VarChar).Value = dataReader[0].ToString();
                    //    }
                    //}

                    //con.Close();
                    //con.Open();
                    //query = "update [RBHM_LOG-T].[dbo].[Users] set [torolve]=1 where [RBHM_LOG-T].[dbo].[Users].[UserId]=@id";
                    command.ExecuteNonQuery();
                    con.Close();

                }







            }
        }


        using (MailMessage mm = new MailMessage("no-reply@bosch.com", toemail.ToString()))
        {
            mm.Subject = "Account Canceled";
            string body = "Hello " + txtUsername.Text.Trim() + ",";
            body += "<br /><br />I inform you that this account is canceled!";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("rb-smtp-int.bosch.com");
            smtpClient.Send(mm);


        }






        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        int k = 0;

        foreach (Control cnt in PlaceHolder1.Controls)
        {
            if (cnt is TextBox)
            {
                k = k + 1;
                TextBox actualtextbox = (TextBox)cnt;
                if (actualtextbox.Visible == false)
                {
                    actualtextbox.Visible = true;
                    break;
                }
            }
        }
        foreach (Control cnt in PlaceHolder2.Controls)
        {
            if (cnt is TextBox)
            {
                k = k + 1;
                TextBox actualtextbox = (TextBox)cnt;
                if (actualtextbox.Visible == false)
                {
                    actualtextbox.Visible = true;
                    break;
                }
            }
        }
    }
    protected void ButtonJelszo_Click(object sender, EventArgs e)
    {
        ChangePassword1.Visible = true;
        ChangePassword1.ChangePasswordTitleText = "Change " + DropDownList2.SelectedItem.ToString().Trim() + " Password";
    }

}
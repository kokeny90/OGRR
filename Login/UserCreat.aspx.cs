using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.UI.WebControls;

public partial class UserCreat : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataSourceMenu.ConnectionString = Functions.ConnectionString(User.Identity.Name);
            SqlDataSourceMenuTop.ConnectionString = Functions.ConnectionString(User.Identity.Name);


              
        }
    }

    private void addgroups(int userId)
    {
        string constr = Functions.ConnectionString(User.Identity.Name);



        foreach (ListItem item in CheckBoxListMenu.Items)
        {
            if (item.Selected)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Users] SET [HomePage]=@MenuId  WHERE UserId=@UserId"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@MenuId", item.Value);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            break;
        }
















        foreach (ListItem item in CheckBoxListTopMenu.Items)
        {
            if (item.Selected)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[SwitchPageNames] ([MenuId],[UserId]) VALUES(@MenuId,@UserId)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@MenuId", item.Value);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
        }
        foreach (ListItem item in CheckBoxListMenu.Items)
        {
            if (item.Selected)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[SwitchPageNames] ([MenuId],[UserId]) VALUES(@MenuId,@UserId)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@MenuId", item.Value);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
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
        string constr = Functions.ConnectionString(User.Identity.Name);
        using (SqlConnection con = new SqlConnection(constr))
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

        string body = String.Join(
        Environment.NewLine,
        @"<html><head></head><body>
        <table  border=1 cellpadding=0 width='100%' style = 'width:100.0%;mso-cellspacing:1.5pt;border:none;border-bottom:solid #777777 1.0pt; mso-border-bottom-alt:solid #777777 .75pt;mso-yfti-tbllook:1184;mso-padding-bottom-alt: 7.5pt'>
        <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes'>
        <td style='border:none;padding:.75pt .75pt 7.5pt .75pt'>
        <h2 style='margin:0cm;margin-bottom:.0001pt'>
        <span  style = 'mso-fareast-font-family:'Times New Roman';font-weight:normal'> Online Gépjármű Regisztrációs Rendszer </span >
        <img width=93 height=28 src='Your%20Incident%20INC0032099%20has%20been%20resolved_files/image001.png'  align = right v: shapes = '_x0000_s1026'>
        <span style='mso-fareast-font-family:'Times New Roman';font-weight:normal'></span >
        </h2>   
        </td>
         </tr>
        </table>
        Hello" + tb_nev.Text.Trim() + @",
        <br/><br />Please click the following link to activate your account
        <br/><a href = '" + Request.Url.AbsoluteUri.Replace("UserCreat.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + @"'>Click here to activate your account.</a>
        < br/><br/>Thanks</body></html>");
        Functions.EMailKuld("Felhasználó Fiók Aktiválás", body, tb_email.Text);
    }






    protected void bt_useradd_Click(object sender, EventArgs e)
    {
        int userId = 0;
        string constr = Functions.ConnectionString(User.Identity.Name);
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Insert_User"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", tb_felhasznalonev.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", tb_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@CegID", SqlDbType.Int).Value = 0;
                    cmd.Parameters.AddWithValue("@Emailellenorzes", SqlDbType.Bit).Value = 0;
                    cmd.Parameters.AddWithValue("@PasswordChange", SqlDbType.Bit).Value = 1;
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            string message = string.Empty;
            switch (userId)
            {
                case -1:
                    message = Resources.Resource.usernamealreadyexistspleasechooseadifferentusername.ToString();
                    break;
                case -2:
                    message = Resources.Resource.suppliedemailaddresshasalreadybeenused.ToString();
                    break;
                default:
                    message = Resources.Resource.registrationsuccessful_activationemailhasbeensent.ToString();
                    addgroups(userId);
                    SendActivationEmail(userId);
                    Response.AddHeader("REFRESH", "2;URL=" + Request.Url.AbsoluteUri.Replace("Login/UserCreat.aspx", "Login.aspx"));
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }

    }
    protected void tb_felhasznalonev_TextChanged(object sender, EventArgs e)
    {
        //ActiveDirectory ad = new ActiveDirectory(tb_felhasznalonev.Text);
        //tb_nev.Text = ad.PName;
        //tb_email.Text = ad.PEmail;
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
}
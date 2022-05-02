using System;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;

public partial class ForgotPasswordCS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("Label1")).Text = "Elfelejtett jelszó";
    }

    protected void SendEmail(object sender, EventArgs e)
    {
        string username = string.Empty;
        string password = string.Empty;
        string constr = ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Username, [Password],[PasswordChange] FROM Users WHERE Email = @Email and Username = @Username "))
            {
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Username", TextUserName.Text.Trim());
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        if (Convert.ToBoolean(sdr["PasswordChange"].ToString()))
                        {
                            username = sdr["Username"].ToString();
                            password = sdr["Password"].ToString();
                        }
                        else
                        {
                            con.Close();
                            lblMessage.Text = "Jelszó cím módositás nem lehetséges!";
                        }

                    }

                }
                con.Close();
            }
        }
        if (!string.IsNullOrEmpty(password))
        {
            using (MailMessage mm = new MailMessage("no-reply@bosch.com", txtEmail.Text))
            {
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br/><br /><a href = 'http://mc0vm011.sg.lan/www/SGHU_LOG-T/Login.aspx'> Login Page </a><br/><br/> Thank You.", username, password);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "sender@gmail.com";
                NetworkCred.Password = "<Password>";
                SmtpClient smtpClient = new SmtpClient("rb-smtp-int.bosch.com");
                smtpClient.Send(mm);
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Password has been sent to your email address.";
            }
        }
        else
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "This email address does not match our records.";
        }
    }
}
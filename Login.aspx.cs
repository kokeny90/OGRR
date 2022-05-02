using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;
public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                if (User.Identity.Name.ToString() == "ecporta" || User.Identity.Name.ToString() == "boschporta")
                {
                    ((Menu)Master.FindControl("menu")).Visible = false;
                    Response.Redirect("OnlineGepjarmuRegisztraciosRendszer.aspx");
                }
                else if (User.Identity.Name.ToString() == "Admin")
                {
                    ((Menu)Master.FindControl("menu")).Visible = true;
                    Response.Redirect("/Admin/Admin.aspx");
                }
                else
                {
                    ((Menu)Master.FindControl("menu")).Visible = true;
                    Response.Redirect("order.aspx");
                }



((Label)Master.FindControl("Label1")).Text = "Bejelentkezés";
                if (string.IsNullOrEmpty(User.Identity.Name.ToString()))
                {
                    Session["login"] = "TESZTUSER";
                }
                else
                {

                }
            }

            else
            {

                FormsAuthentication.SignOut();
                Response.Redirect("~/Login.aspx");
            }

        }
        else
        {

            // if (string.IsNullOrEmpty(Session["login2"].ToString()))
            // {

            // }
            // else
            // {
            //}
            ((Menu)Master.FindControl("menu")).Visible = false;
            ((Label)Master.FindControl("Label1")).Text = "Bejelentkezés";
        }
    }
    protected void ValidateUser(object sender, AuthenticateEventArgs e)
    {

        int userId = 0;
        using (SqlConnection con =   new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            using (SqlCommand cmd = new SqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                cmd.Parameters.AddWithValue("@Password", Login1.Password);
                cmd.Connection = con;
                con.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            switch (userId)
            {
                case -1:
                    Login1.FailureText = "Username and/or password is incorrect.";
                    break;
                case -2:
                    Login1.FailureText = "Account has not been activated.";
                    break;
                default:
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                    Session["login"] = Login1.UserName;
                    belepes();
                    break;
            }
        }
    }
    protected void belepes()
    {
        if (User.Identity.Name.ToString() == "ecporta" || User.Identity.Name.ToString() == "boschporta" || string.IsNullOrEmpty(User.Identity.Name.ToString()) || User.Identity.Name.ToString() == "logicon" || User.Identity.Name.ToString() == "ttporta" || User.Identity.Name.ToString() == "sghufoporta")
        {
            ((Menu)Master.FindControl("menu")).Visible = false;
            Response.Redirect("~/OnlineGepjarmuRegisztraciosRendszer.aspx");
        }
        else if (User.Identity.Name.ToString() == "Admin")
        {
            ((Menu)Master.FindControl("menu")).Visible = true;
            Response.Redirect("~Admin/Admin.aspx");
        }
        else
        {
            ((Menu)Master.FindControl("menu")).Visible = true;
            Response.Redirect("~/order.aspx");
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Master.FindControl("Label1")).Text = "Jelszó Csere";
    }

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
                        cmd.Parameters.AddWithValue("@Username", this.Page.User.Identity.Name);
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
        }
        else
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "Old Password and New Password must not be equal.";
        }

        e.Cancel = true;
    }

}
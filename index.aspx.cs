using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class kezdolap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string blab = User.Identity.Name.ToString().ToLower();
        if (blab != "kk87mc" && blab != "cl82mc" && blab != "ora1mc"  && blab != "za85mc")
        {
                Response.Redirect("OnlineGepjarmuRegisztraciosRendszer.aspx");
        }
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void But_Kereses_Click(object sender, EventArgs e)
    {
        Response.Redirect("Form_Kereses.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("order.aspx");
    }
}

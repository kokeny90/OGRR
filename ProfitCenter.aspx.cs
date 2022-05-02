using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfitCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                SqlDataSource1.ConnectionString = Functions.ConnectionString(User.Identity.Name);

            }
        }
    }
}
using System;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{ 
    protected override void OnLoad(EventArgs e) 
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                string sql = "SELECT [TPageNames].MenuId FROM dbo.Users INNER JOIN dbo.SwitchPageNames ON dbo.Users.UserId = dbo.SwitchPageNames.UserId INNER JOIN dbo.TPageNames ON dbo.SwitchPageNames.MenuId = dbo.TPageNames.MenuId WHERE (dbo.Users.Username = '" + User.Identity.Name + "') AND (dbo.TPageNames.PageName = '" + pageName + "')";
                Session["SecurityLevelID"] = Functions.ExecScalar(sql, User.Identity.Name);
                Session["login"] = User.Identity.Name.ToString().ToLower().Trim();
            }

            base.OnLoad(e);
        }
    }
}



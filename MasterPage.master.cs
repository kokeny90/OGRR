using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class MasterPage : System.Web.UI.MasterPage
{
    //private static string _cs = "Data Source=SGMSCSQL01.sg.lan;Initial Catalog=SGHU_LOG-T;Persist Security Info=True;User ID=SGHU_LOG-T_user;Password=mdfKgH63nH";
    private static string _csTest = "Data Source=mc-logp01.sg.lan;Initial Catalog=SGHU_LOG_52_test;Persist Security Info=True;User ID=LOG_52_USER;Password=tqi5mQr2vX";


    string[] stringArray = new string[40];
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["_cs"] = _csTest;
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Session["login"] = System.Web.HttpContext.Current.User.Identity.Name;
                string CS = Functions.ConnectionString(Session["login"].ToString());
                using (SqlConnection con = new SqlConnection(CS))
                {
                    try
                    {
                        //DataTable dt = this.GetData(0);
                        //PopulateMenu(dt, 0, null);

                              
                 
                        //if (dt.Rows.Count <= 1)
                        //{
                        //    menu.Visible = false;
                        //    manu2.Visible = false;
                        //}
                        //else
                        //{
                        //    PopulateMenu(dt, 0, null);
                        //}                   
                        //string value = Session["first"] as string;
                        //if (String.IsNullOrEmpty(value))
                        //{
                        //    Session["first"] = "";
                        //}
                        //if (string.IsNullOrEmpty(Session["first"].ToString()))
                        //{                            Session["first"] =Functions.ExecScalar("SELECT dbo.TPageNames.PageName FROM dbo.Users INNER JOIN dbo.TPageNames ON dbo.Users.HomePage = dbo.TPageNames.MenuId WHERE (dbo.Users.Username = '" + Session["login"].ToString() + "')", Session["login"].ToString());
                        //    if (System.IO.Path.GetFileName(Request.Url.AbsolutePath) != Session["first"].ToString())
                        //    {
                        //        Response.Redirect("~/" + Session["first"].ToString());
                        //    }
                        //} 
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
            else
            {
                menu.Visible = false;
                manu2.Visible = false;
            }

        }
    }

    private void PopulateMenu(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
    {
        string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
        foreach (DataRow row in dt.Rows)
        {
            MenuItem menuItem = new MenuItem
            {
                Value = row["MenuId"].ToString(),
                Text = row["Title"].ToString(),
                NavigateUrl = row["Url"].ToString(),
                Selected = row["Url"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
            };
            if (parentMenuId == 0)
            {
                menu.Items.Add(menuItem);
                DataTable dtChild = this.GetData(int.Parse(menuItem.Value));
                PopulateMenu(dtChild, int.Parse(menuItem.Value), menuItem);
            }
            else
            {

                parentMenuItem.ChildItems.Add(menuItem);
                //DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
                //DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);

            }
        }
    }

    private DataTable GetData(int parentMenuId)
    {

        string cmdString = "SELECT PageName,TPageNames.MenuId,ParentmenuId,Title,Description,Url FROM dbo.Users INNER JOIN dbo.SwitchPageNames ON dbo.Users.UserId = dbo.SwitchPageNames.UserId INNER JOIN dbo.TPageNames ON dbo.SwitchPageNames.MenuId = dbo.TPageNames.MenuId WHERE ParentMenuId = @ParentMenuId and  (dbo.Users.Username = '" + Session["login"].ToString() + "')";
        string a = Session["login"].ToString();
        if (Session["login"].ToString() == "Admin")
        {
            cmdString = "SELECT PageName, MenuId, ParentmenuId, Title, Description, Url FROM dbo.TPageNames WHERE(ParentmenuId = @ParentMenuId)";
        }
        string constr = Functions.ConnectionString(Session["login"].ToString());
        using (SqlConnection con = new SqlConnection(constr))
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(cmdString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Parameters.AddWithValue("@ParentMenuId", parentMenuId);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Login.aspx");
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    //protected void Button1_Click1(object sender, EventArgs e)
    //{
    //    Response.Redirect("UserCreat.aspx");
    //}
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("OnlineGepjarmuRegisztraciosRendszer.aspx");
    //}
    //protected void Button4_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ChangePassword.aspx");
    //}
    //protected void But_Kereses_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Form_Kereses.aspx");
    //}
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Delivery_Commission/NewDeliveryCommission.aspx");
    //}

    //protected void Button4_Click1(object sender, EventArgs e)
    //{
    //    Response.Redirect("Delivery_Commission/new2.aspx");
    //}

    //protected void ButtonProfitCenter_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ProfitCenter.aspx");
    //}
    #region Language selection
    protected void ImageButtonEN_Click(object sender, ImageClickEventArgs e)
    {
        Functions.Language("en", Server, Request, Response);
    }

    protected void ImageButtonHU_Click(object sender, ImageClickEventArgs e)
    {
        Functions.Language("hu", Server, Request, Response);
    }

    protected void ImageButtonDE_Click(object sender, ImageClickEventArgs e)
    {
        Functions.Language("de", Server, Request, Response);
    }
    #endregion

  
}

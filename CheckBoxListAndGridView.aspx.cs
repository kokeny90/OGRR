using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckBoxListAndGridView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView gr = (GridView)Page.Master.FindControl("GridView1");
        SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");

       
        if (!IsPostBack)
        {

     

        }




    }



    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        //using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["
        //"].ConnectionString))
        //{

        //    string query = "SELECT * FROM [RBHM_LOG-T].[dbo].[mitszallit]";
        //    using (SqlCommand command = new SqlCommand(query, con))
        //    {

        //        SqlCommand cmd = new SqlCommand();

        //        String sqlText = "SELECT * FROM [RBHM_LOG-T].[dbo].[mitszallit]";
        //        String sqlFilterText = "";
        //        int index = 0;
        //        foreach (ListItem item in CheckBoxList1.Items)
        //        {
        //            index += 1;
        //            if (item.Selected)
        //            {
        //                String paramName = "@param" + index.ToString().Trim();
        //                SqlParameter param = new SqlParameter(paramName, SqlDbType.UniqueIdentifier);
        //                param.Value = new Guid(item.Value.Trim());
        //                cmd.Parameters.Add(param);

        //                sqlFilterText += " NationalityID = " + paramName + " or ";
        //            }
        //        }

        //if (!String.IsNullOrEmpty(sqlFilterText))
        //{
        //    sqlText += " Where " + sqlFilterText.Substring(0, sqlFilterText.Length - 3);
        //}
        //cmd.CommandText = sqlText;

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable tbl = new DataTable();
        //adapter.Fill(tbl);
        //GridView1.DataSource = tbl;
        //GridView1.DataBind();
        //    }
        //}
    }



    string username = WebConfigurationManager.AppSettings["Username"];
    protected void Button1_Click1(object sender, EventArgs e)
    {


    } } 
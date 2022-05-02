using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Tawammar.CustomControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataFilter1.DataSource = SqlDataSource1;
        DataFilter1.DataColumns = GridView1.Columns;
        DataFilter1.FilterSessionID = "test.aspx";
        DataFilter1.OnFilterAdded += new DataFilter.RefreshDataGridView(DataFilter1_OnFilterAdded);
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataFilter1.BeginFilter();
            DataFilter1.AddNewFilter("CName", "LIKE", "Dav");
        }
    }

    void DataFilter1_OnFilterAdded()
    {
        try
        {
            DataFilter1.FilterSessionID = "test.aspx";
            DataFilter1.FilterDataSource();
            GridView1.DataBind();

        }
        catch(Exception e)
        {
        }
    }
}

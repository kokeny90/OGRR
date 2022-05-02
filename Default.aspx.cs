using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FunctionTest test = new FunctionTest();
        test.Eql_Test_Null();
        string subPath = "ImagesPath"; // your code goes here
        bool IsExists = System.IO.Directory.Exists(Server.MapPath(subPath));
        if (!IsExists)
            System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int I = 1;
        if (I < I + 1)
        {

        }
    }

    protected void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ComboBox1_ItemInserted(object sender, AjaxControlToolkit.ComboBoxItemInsertEventArgs e)
    {

    }
}
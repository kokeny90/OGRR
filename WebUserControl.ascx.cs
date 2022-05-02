using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class WebUserControl : System.Web.UI.UserControl
{
    public enum DateFormat { LongD, ShortD }
    private DateFormat format;
    public DateFormat Format { get { return format; } set { format = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        string important1 = Global.ImportantData;
        Button6.Text = "Clear Filter from '" + BEoszlop + "'";
        Panel1.Visible = false;
        if (!IsPostBack)
        {


            Global.ImportantData = null;


            //using (SqlConnection conn = new SqlConnection())
            //{
            //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString;
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.CommandText = "select * FROM [RBHM_LOG-T].[dbo].[tabla] GROUP BY " + myIntValue + " ;";
            //        cmd.Connection = conn;
            //        conn.Open();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            int i = 0;
            //            while (sdr.Read())
            //            {

            //                ListItem item = new ListItem();
            //                item.Text = sdr[intbe].ToString();
            //                item.Value = i.ToString();

            //                DropDownList1.Items.Add(item);
            //                i = i + 1;
            //            }
            //        }
            //        conn.Close();
            //    }
            //}


        }

        else if (important1 != null)
        {

            //string buff = "";
            //SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");
            //rp.FilterExpression = important1;
            //DataSourceSelectArguments args = new DataSourceSelectArguments();
            //DataView view = (DataView)rp.Select(args);
            //DataTable dt = view.ToTable();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    Regex regex = new Regex(@"^.*" + dt.Rows[i][myIntValue].ToString() + ".*$");
            //    Match match = regex.Match(buff);
            //    if (!match.Success)
            //    {
            //        buff = buff + dt.Rows[i][myIntValue].ToString();
            //        ListItem item = new ListItem();
            //        item.Text = dt.Rows[i][0].ToString();
            //        item.Value = dt.Rows[i][0].ToString();
            //        regex = new Regex(@"^.*" + myIntValue + "<>" + item.Text + ".*$");
            //        match = regex.Match(important1);
            //        if (match.Success)
            //        {
            //            item.Selected = false;
            //        }
            //        else
            //        {
            //            item.Selected = true;
            //        }

            //        DropDownList1.Items.Add(item);
            //    }
            //}

        }

    }
    private string BeDROPText;
    private string BeDROPValue;
    private string oszlop;
    //private int userAge;
    //private string userCountry;

    //public string UserName
    //{
    //    get { return userName; }
    //    set { userName = value; }
    //}

    //public int UserAge
    //{
    //    get { return userAge; }
    //    set { userAge = value; }
    //}
    public string BEoszlop { get; set; }

    public string DROPText
    {
        get { return BeDROPText; }
        set { BeDROPText = value; }
    }
    public string DROPValue
    {
        get { return BeDROPValue; }
        set { BeDROPValue = value; }
    }




    public void adatokbe(string be1, string be2, bool ertek)
    {
        //string[] columnValues = be1.Split(';');

        //        if (columnValues.Length > 1)
        //        {
        //            for (int ii = 0; ii < columnValues.Length; ii++)
        //            {
        //                Regex r = new Regex("^([0]?[1-9]|[1|2][0-9]|[3][0|1])[/]([0]?[1-9]|[1][0-2])[/]([0-9]{4}|[0-9]{2})$");

        //                if (r.IsMatch(columnValues[ii].Trim()))
        //                {
        //                    DateTime dt = new DateTime();
        //                    string day = columnValues[ii].Trim().Split(new char[] { '/' })[0].ToString();
        //                    string month = columnValues[ii].Trim().Split(new char[] { '/' })[1].ToString();
        //                    string year = columnValues[ii].Trim().Split(new char[] { '/' })[2].ToString();

        //                    string ds = month + "/" + day + "/" + year;


        //                    dt = DateTime.Parse(ds);

        //                }
        //                if (ii == 0)
        //                {
        //                    be1 = "#" + be1.ToString() + "# OR ";
        //                    be1 = " '" + columnValues[ii].Trim() + "' )";
        //                }

        //            }





        //        }





        string bentbe1 = be1.Trim();
        if (bentbe1 != "")
        {
            ListItem item = new ListItem();
            ListItem item2 = new ListItem();
            item2.Text = be1;
            item2.Value = be2;

            //item.Text = be1;
            //item.Value = be2;
            //item.Selected = false;
            //     DropDownList1.Items.Add(item);
            item2.Selected = ertek;
            CheckBoxList1.Items.Add(item2);
        }


    }

    public void kipipal()
    {
        for (int i = 1; i < CheckBoxList1.Items.Count; i++)
        {

            CheckBoxList1.Items[i].Selected = true;
        }
    }



    public bool tartalmaza(string be2)
    {
        if (be2.Trim().ToString() == "")
        {
            return false;
        }
        foreach (ListItem li in CheckBoxList1.Items)
        {
            if (li.Text.Trim().ToString() == be2.Trim().ToString())
            {
                return true;
            }
        }
        return false;

    }

    protected void CheckBoxList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //CheckBoxList list = (CheckBoxList)sender;
        //string[] control = Request.Form.Get("__EVENTTARGET").Split('$');
        //int idx = control.Length - 1;
        //string sel = list.Items[Int32.Parse(control[idx])].Value;
        //int i = Int32.Parse(control[5]);
        //string str = CheckBoxList1.Items[i].Text;
        //if (CheckBoxList1.Items[i].Selected)
        //{
        //    GridView gr = (GridView)Page.Master.FindControl("GridView1");
        //    SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");

        //    rp.FilterExpression = rp.FilterExpression.ToString() + myIntValue + "=" + str;
        //    gr.DataBind();


        //}
        //else
        //{
        //    GridView gr = (GridView)Page.Master.FindControl("GridView1");
        //    SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");


        //    rp.FilterExpression = rp.FilterExpression.ToString() + myIntValue + "<>" + str;
        //    gr.DataBind();


        //}






    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        //int index = 0;
        //foreach (ListItem item in DropDownList1.Items)
        //{
        //    index += 1;
        //    if (item.Selected)
        //    {

        //        //GridView gr = (GridView)Page.Master.FindControl("GridView1");
        //        //SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");

        //        //rp.FilterExpression = rp.FilterExpression.ToString() + myIntValue + "=" + item.Text;
        //        //gr.DataBind();


        //    }
        //    else
        //    {
        //        GridView gr = (GridView)Page.Master.FindControl("GridView1");
        //        SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");
        //        string important1 = Global.ImportantData;

        //        if (important1 != null)
        //        {
        //            rp.FilterExpression = important1 + " and " + myIntValue + "<>" + item.Text;
        //        }
        //        else
        //        {
        //            rp.FilterExpression = myIntValue + "<>" + item.Text;

        //        }
        //        Global.ImportantData = rp.FilterExpression.ToString();
        //        gr.DataBind();



        //    }

        //}
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string important1 = Global.ImportantData;
        //GridView gr = (GridView)Page.Master.FindControl("GridView1");
        //SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");

        //if (important1 != null)
        //{
        //    rp.FilterExpression = important1 + " and " + BEoszlop + "<>" + DropDownList1.SelectedItem;
        //}
        //else
        //{
        //    rp.FilterExpression = BEoszlop + " = " + DropDownList1.SelectedItem;

        //}

        //gr.DataBind();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        GridView gr = (GridView)Page.Master.FindControl("GridView1");



        if (Panel1.Visible == true)
        {
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
        }

    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string important1 = Global.ImportantData;
        GridView gr = (GridView)Page.Master.FindControl("GridView1");
        SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");

        if (important1 != null)
        {
            rp.FilterExpression = important1 + " and " + BEoszlop + "<>" + TextBox1.Text;
        }
        else
        {
            rp.FilterExpression = BEoszlop + " = " + TextBox1.Text;

        }

        gr.DataBind();



    }
    List<string> list = new List<string>();
    public void szuro(GridView gr)
    {
        for (int j = 0; j < gr.Columns.Count; j++)
        {
            WebUserControl myControl1 = (WebUserControl)LoadControl("WebUserControl.ascx");
            myControl1.ID = "ezemegaz" + j.ToString();
            myControl1.BEoszlop = gr.HeaderRow.Cells[j].Text;


            for (int i = 0; i < gr.Rows.Count; i++)
            {


                if (!myControl1.tartalmaza(gr.Rows[i].Cells[j].Text.ToString().Trim()))
                {


                    myControl1.adatokbe(gr.Rows[i].Cells[j].Text.ToString().Trim(), i.ToString().Trim(), true);


                }

            }



            gr.HeaderRow.Cells[j].Controls.Add(myControl1);
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (Button4.Text == "Jelölőnégyzet lista szürő")
        {
            szovegszuro.Visible = false;
            CheckBoxList1.Visible = true;
            Button4.Text = "Szövegszürő";
            Button5.Visible = true;
        }
        else
        {
            szovegszuro.Visible = true;
            CheckBoxList1.Visible = false;
            Button4.Text = "Jelölőnégyzet lista szürő";
            Button5.Visible = false;
        }


        Panel1.Visible = true;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected == false)
            {
                for (i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    CheckBoxList1.Items[i].Selected = true;
                }
                Panel1.Visible = true;
                return;


            }



        }


        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            CheckBoxList1.Items[i].Selected = false;
        }


        Panel1.Visible = true;






    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView gr = (GridView)Page.Master.FindControl("GridView1");
        SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");
        int index = 0;
        int nyeretes = 0;
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                nyeretes++;
            }

        }
        if (nyeretes > (CheckBoxList1.Items.Count - nyeretes))
        {

        }

        foreach (ListItem item in CheckBoxList1.Items)
        {
            string columnValues = System.Net.WebUtility.HtmlDecode(item.Text);
            string important1 = Global.ImportantData;

            if (important1 == "")
            {
                important1 = null;
            }
            index += 1;

            if (item.Selected)
            {
                if (nyeretes < (CheckBoxList1.Items.Count - nyeretes))
                {


                    if (important1 != null)
                    {
                        Global.ImportantData = important1 + " or [" + BEoszlop + "]='" + columnValues + "'";

                    }
                    else
                    {
                        Global.ImportantData = "[" + BEoszlop + "]='" + columnValues + "'";

                    }



                }



            }
            else if(nyeretes > (CheckBoxList1.Items.Count - nyeretes))
            {

                if (important1 != null)
                {



                    Global.ImportantData = important1 + " and [" + BEoszlop + "]<>'" + columnValues + "'";

                }
                else
                {


                    Global.ImportantData = "[" + BEoszlop + "]<>'" + columnValues + "'";


                }


                list.Add(item.Text);

            }

        }
        rp.FilterExpression = Global.ImportantData;
        Global.ImportantData = rp.FilterExpression.ToString();
        gr.DataBind();
        szuro(gr);
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        GridView gr = (GridView)Page.Master.FindControl("GridView1");
        SqlDataSource rp = (SqlDataSource)Page.Master.FindControl("SqlDataSource1");
        string input = Global.ImportantData;
        string output = Regex.Replace(input, @"(and..|\A.)" + BEoszlop + ".*(')", " ").ToString().Trim();

        Global.ImportantData = output;
        rp.FilterExpression = Global.ImportantData;
        Global.ImportantData = rp.FilterExpression.ToString();
        gr.DataBind();
        szuro(gr);
        Button5.Visible = true;
    }


}
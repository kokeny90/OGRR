using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using System.Net.Mail;
using System.Text;

public partial class KamionKezelo_MRTable : System.Web.UI.Page
{
    
 private static string _csTest = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|DB\Database.mdf;Integrated Security = True";
    //private static string _csTest = "Data Source=SGMSCSQL01.sg.lan;Initial Catalog=SGHU_LOG-T;Persist Security Info=True;User ID=SGHU_LOG-T_user;Password=mdfKgH63nH";
    //private static string _csTest = "Data Source=mc-logp01.sg.lan;Initial Catalog=SGHU_LOG_52_test;Persist Security Info=True;User ID=LOG_52_USER;Password=tqi5mQr2vX";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                Session["MRCircle"] = "";
                Session["HeaderMR"] = "0";
                Session["HeaderMRKör"] = "0";
                Session["HeaderReception"] = "0";
                Session["MRKör"] = "";
                Session["MR"] = "";
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(1053);
                //TextBoxMRDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                if (Session["filterMR"] != null)
                {
                    MILK.FilterExpression = Session["filterMR"].ToString();
                }
            }
        }
    }

    protected void MRCircle(string mrwher)
    {
        try
        {
            LabelError.Text = "";
            string CS = _csTest;
            using (SqlConnection con = new SqlConnection(CS))
            {

                string datumwhere = "";     //aktuallis dátum
                string datumwhere2 = "";    //aktuallis 2.dátum
                if (string.IsNullOrEmpty(TextBoxMRDate.Text.ToString().Trim()))
                {
                    if (DropDownListMRDate.SelectedValue.ToString() == "0")
                    {
                        datumwhere2 = DropDownListMRYear.SelectedValue.ToString();
                    }

                    else if (DropDownListMRDate.SelectedValue.ToString() != "-1")
                    {
                        datumwhere = DropDownListMRYear.SelectedValue.ToString() + "-" + DropDownListMRDate.SelectedValue.ToString();
                        string nextmonth = (int.Parse(DropDownListMRDate.SelectedValue.ToString()) + 1).ToString();
                        if (nextmonth.Length == 1)
                        {
                            datumwhere2 = DropDownListMRYear.SelectedValue.ToString() + "-0" + nextmonth;
                        }
                        else
                        {
                            datumwhere2 = DropDownListMRYear.SelectedValue.ToString() + "-" + nextmonth;
                        }

                    }
                    else
                    {
                        LabelError.Text = "Kérlek válasz dátumot!";
                        return;
                    }
                }
                else
                {
                    datumwhere = TextBoxMRDate.Text.ToString().Trim();
                    datumwhere2 = DateTime.ParseExact(datumwhere, "yyyy-mm-dd", CultureInfo.InvariantCulture).AddDays(1).ToString("yyyy-mm-dd");
                    LabelError.Text = "";
                }

                con.Open();

                string cmdString = "SELECT 'MR' + CONVERT(varchar(2), dbo.Milkruns.ID) AS MR, dbo.MilkRunTimeTable.InDate as InDateTime, dbo.MilkRunTimeTable.OutDate as OutDateTime, dbo.Users.Username AS Reception FROM dbo.MilkRunTimeTable LEFT OUTER JOIN dbo.Users ON dbo.MilkRunTimeTable.receptionID = dbo.Users.UserId RIGHT OUTER JOIN dbo.Milkruns ON dbo.MilkRunTimeTable.TrackingNumberID = dbo.Milkruns.ID WHERE(dbo.Users.Username IS NOT NULL) and " + mrwher + " ORDER BY dbo.Milkruns.ID, dbo.MilkRunTimeTable.ID";
                SqlDataReader dr = Functions.ExecQuery(con, cmdString);
                if (dr.HasRows)// a MilkRun tábla feltöltése
                {
                    string MR = "";
                    DataTable dtedtelso = new DataTable();
                    DataTable dtmasodik = new DataTable();

                    DataTable dt = new DataTable();
                    DataTable dt2 = new DataTable();
                    dt.Columns.Add("MR", typeof(string));
                    dt2.Columns.Add("MR", typeof(string));

                    int oldrows = 0;
                    int actualrow = 0;
                    MR = "";
                    string Reception = "";
                    //A dt(MR menetrend) tábla feltöltése
                    while (dr.Read())
                    {

                        if (MR == dr["MR"].ToString())
                        {
                            actualrow = ++actualrow;
                            actualrow = Feltolt(oldrows, actualrow, dr, dt, MR, Reception, dt2);
                            Reception = dr["Reception"].ToString();
                        }
                        else
                        {
                            MR = dr["MR"].ToString();
                            oldrows = dt.Rows.Count;
                            actualrow = Feltolt(oldrows, actualrow, dr, dt, MR, Reception, dt2);
                            Reception = dr["Reception"].ToString();
                        }



                    }

                    con.Close();
                    dt.Columns.Add("Date", typeof(string));
                    dt2.Columns.Add("Date", typeof(string));
                    dt.DefaultView.Sort = "[" + dt.Columns[1].ColumnName.ToString() + "] asc";

                    //Az MR tábla rendezése a megfellő formátumba + eltollás
                    dt = dt.DefaultView.ToTable();
                    if (Session["MRCircle"].ToString() == "alapanyag")
                    {
                        for (int i = 1; i < 4; i++)
                        {
                            DataRow drow121 = dt.NewRow();
                            for (int k = 1 + i * 2; k < 9; k++)
                            {
                                drow121[k] = dt.Rows[dt.Rows.Count - i][k];
                                dt.Rows[dt.Rows.Count - i][k] = "";
                            }
                            drow121[0] = dt.Rows[dt.Rows.Count - i][0];
                            dt.Rows.InsertAt(drow121, 0);
                        }
                    }
                    else if (Session["MRCircle"].ToString() == "Kesztermek")                   
                    {
                        for (int i = 1; i < 2; i++)
                        {
                            DataRow drow121 = dt.NewRow();
                            for (int k = 4; k < 9; k++)
                            {
                                drow121[k] = dt.Rows[dt.Rows.Count - i][k];
                                dt.Rows[dt.Rows.Count - i][k] = "";
                            }
                            drow121[0] = dt.Rows[dt.Rows.Count - i][0];
                            dt.Rows.InsertAt(drow121, 0);
                        }
                    }





                    //string firstdate = Functions.ExecScalar("", "_csTest");


                    double[] buffIn = new double[3];
                    buffIn[0] = double.MaxValue;
                    double[] buffOut = new double[3];
                    buffOut[0] = double.MaxValue;
                    DateTime databasIndate = DateTime.Now;
                    DateTime databasOutdate = DateTime.Now;
                    DateTime date2 = DateTime.MaxValue;
                    DateTime date = DateTime.MaxValue;
                    int rowsshift = 0;


                    cmdString = "SELECT top 1 MilkRunMovement.InDate FROM MilkRunMovement LEFT OUTER JOIN Users ON MilkRunMovement.receptionID = Users.UserId RIGHT OUTER JOIN Milkruns ON MilkRunMovement.TrackingNumberID = Milkruns.ID where Username is not null  and cast(InDate as date) like '%" + datumwhere + "%' and (Milkruns.ID = '1' OR Milkruns.ID = '2' OR Milkruns.ID = '3')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(cmdString, con);

                    if (cmd.ExecuteScalar() != null)
                    {

                        foreach (DataRow drow in dt.Rows)
                        {
                            DataRow drow2 = dt2.NewRow();
                            drow2["MR"] = drow[0].ToString();
                            drow2["Date"] = ((DateTime)cmd.ExecuteScalar()).ToString("yyyy-MM-dd");
                            dt2.Rows.Add(drow2);
                        }
                    }

                    con.Close();






                    con.Open();
                    cmdString = "SELECT 'MR' + CONVERT(varchar(2), Milkruns.ID) AS MR, convert(varchar,MilkRunMovement.InDate, 8) as InDateTime , convert(varchar,MilkRunMovement.OutDate , 8) as OutDateTime ,MilkRunMovement.InDate, Users.Username AS Reception, dbo.Users.UserId,dbo.Users.UserId FROM MilkRunMovement LEFT OUTER JOIN Users ON MilkRunMovement.receptionID = Users.UserId RIGHT OUTER JOIN Milkruns ON MilkRunMovement.TrackingNumberID = Milkruns.ID where Username is not null  and cast(InDate as date) like '%" + datumwhere + "%' and " + mrwher;
                    dr = Functions.ExecQuery(con, cmdString);
                    while (dr.Read())  //Időpontok feltöltése 
                    {




                        buffIn[0] = double.MaxValue;
                        buffOut[0] = double.MaxValue;
                        databasIndate = DateTime.MinValue;
                        databasOutdate = DateTime.MaxValue;
                        if (!string.IsNullOrEmpty(dr["IndateTime"].ToString()))
                        {

                            if (Math.Abs((databasIndate - date2).TotalSeconds) <= 600)
                            {
                                continue;
                            }
                            databasIndate = DateTime.ParseExact(dr["IndateTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                            date2 = DateTime.Parse(dr["Indate"].ToString());
                        }



                        if (!string.IsNullOrEmpty(dr["OutdateTime"].ToString()))
                        {
                            databasOutdate = DateTime.ParseExact(dr["OutdateTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                        if (date == DateTime.MaxValue)
                        {
                            date = date2;
                        }

                        if (date.ToString("yyyy-MM-dd") != date2.ToString("yyyy-MM-dd"))
                        {

                            rowsshift = dt2.Rows.Count + 1;
                            DataRow drow2 = dt2.NewRow();
                            drow2["MR"] = "";
                            drow2["Date"] = "";
                            dt2.Rows.Add(drow2);


                            foreach (DataRow drow in dt.Rows)
                            {
                                drow2 = dt2.NewRow();
                                drow2["MR"] = drow[0].ToString();
                                drow2["Date"] = date2.ToString("yyyy-MM-dd");
                                dt2.Rows.Add(drow2);
                            }

                            date = DateTime.MaxValue;
                            buffIn[0] = double.MaxValue;
                            buffIn[1] = 0;
                            buffIn[2] = 0;
                            buffOut[0] = double.MaxValue;
                            buffOut[1] = 0;
                            buffOut[2] = 0;
                            databasIndate = DateTime.Now;
                            databasOutdate = DateTime.Now;
                            date2 = DateTime.MaxValue;
                            databasIndate = DateTime.MaxValue;
                            databasOutdate = DateTime.MaxValue;

                        }

                        if (!string.IsNullOrEmpty(dr["IndateTime"].ToString()))
                        {
                            date = DateTime.Parse(dr["Indate"].ToString());
                        }



                        foreach (DataRow drow in dt.Rows)
                        {
                            if (drow[0].ToString() == dr["MR"].ToString()) //A megfelelő MR megkeresése
                            {
                                foreach (DataColumn dcolumn in dt.Columns)//A legközelebbi idő pont megkeresése
                                {
                                    if (dcolumn.ColumnName.ToString().ToLower().Contains(dr["Reception"].ToString().ToLower()) && dcolumn.ColumnName.ToString().ToLower().Contains("érkezés2"))
                                    {
                                        if (!string.IsNullOrEmpty(drow[dcolumn].ToString()) && !string.IsNullOrEmpty(drow[dt.Columns.IndexOf(dcolumn) + 1].ToString()))
                                        {
                                            DateTime datatableIndate = DateTime.ParseExact(drow[dcolumn].ToString(), "HH:mm", CultureInfo.InvariantCulture);
                                            DateTime datatableOutdate = DateTime.ParseExact(drow[dt.Columns.IndexOf(dcolumn) + 1].ToString(), "HH:mm", CultureInfo.InvariantCulture);
                                            if (buffIn[0] >= Math.Abs((datatableIndate - databasIndate).TotalSeconds) && (databasIndate != DateTime.MaxValue))
                                            {
                                                buffIn[0] = Math.Abs(((datatableIndate - databasIndate).TotalSeconds));
                                                buffIn[1] = dt.Rows.IndexOf(drow) + rowsshift;
                                                buffIn[2] = dt.Columns.IndexOf(dcolumn);
                                            }
                                            if (buffOut[0] >= Math.Abs((datatableOutdate - databasOutdate).TotalSeconds) && (databasOutdate != DateTime.MaxValue))
                                            {
                                                buffOut[0] = Math.Abs(((datatableOutdate - databasOutdate).TotalSeconds));
                                                buffOut[1] = dt.Rows.IndexOf(drow) + rowsshift;
                                                buffOut[2] = dt.Columns.IndexOf(dcolumn) + 2;
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        if (buffIn[0] != double.MaxValue)
                        {
                            if (buffIn[0] < 300)
                            {
                                dt2.Rows[Convert.ToInt32(buffIn[1].ToString())][Convert.ToInt32(buffIn[2].ToString())] = databasIndate.ToString("HH:mm");
                            }
                            else
                            {
                                dt2.Rows[Convert.ToInt32(buffIn[1].ToString())][Convert.ToInt32(buffIn[2].ToString())] = databasIndate.ToString("HH:mm");
                            }
                        }
                        else
                        {
                            //  dt2.Rows[Convert.ToInt32(buffIn[1].ToString())][Convert.ToInt32(buffIn[2].ToString())] = "";
                        }



                        if (buffOut[0] != double.MaxValue)
                        {
                            if (buffOut[0] < 300)
                            {
                                dt2.Rows[Convert.ToInt32(buffOut[1].ToString())][Convert.ToInt32(buffOut[2].ToString())] = databasOutdate.ToString("HH:mm");
                            }
                            else
                            {
                                dt2.Rows[Convert.ToInt32(buffOut[1].ToString())][Convert.ToInt32(buffOut[2].ToString())] = databasOutdate.ToString("HH:mm");
                            }
                        }
                        else
                        {
                            //dt2.Rows[Convert.ToInt32(buffOut[1].ToString())][Convert.ToInt32(buffOut[2].ToString())] = "";
                        }


                        buffIn[0] = double.MaxValue;
                        buffOut[0] = double.MaxValue;

                    }

                    int j = 0;
                    for (int i = 1; i < dt2.Columns.Count - 1; i += 2)
                    {
                        foreach (DataRow dtRow in dt2.Rows)
                        {
                            if (!string.IsNullOrEmpty(dtRow[0].ToString()))
                            {
                                dtRow[i] = dt.Rows[j][i].ToString();
                                if (j == dt.Rows.Count - 1)
                                {
                                    j = 0;
                                }
                                else
                                {
                                    j++;
                                }
                            }

                        }
                    }



                    if (CheckBoxTimetable.Checked)
                    {
                        GridView2.Visible = true;
                        GridView2.DataSource = dt2;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
        }



        catch (Exception ex)
        {
            string hiba = "";
            hiba = "Hiba a szkennelés közben. szkennelés:" + "<br/>" + "Message :" + ex.Message + "<br/>" + "StackTrace :" + ex.StackTrace + "" + "<br/>" + "Date :" + DateTime.Now.ToString() + "<br/>" + "Exception: " + ex.ToString();
            Emailkuld("Hiba " + Session["login"].ToString(), hiba);

        }



        finally
        {

        }

    }
    public static void Emailkuld(string subject, string body)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("system.OGRR@seg-automotive.com", "KAMIONKEZELŐ");
            mailMessage.To.Add("external.Jozsef.Kokeny@SEG-automotive.com");
            mailMessage.Subject = subject;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Body = "<b><span style='font-size:60.0pt;font-family:\"Titillium Web\";color:#009164'>Online Gépjármű Regisztrációs Rendszer</span></b><b><span style='font-size:60.0pt;font-family:Wingdings;mso-bidi-font-family:Titillium Web;color:#009164'>*</span></b><br/><div style='border:none;border-bottom:dotted #729ABD 1.5pt;padding:0cm 0cm 0cm 0cm;margin-left:11.25pt;margin-top:11.25pt;margin-right:11.25pt;margin-bottom:11.25pt'><p class=MsoNormal style='mso-line-height-alt:.75pt'><span style='font-size:1.0pt;color:white'>&nbsp;</span></p></div><br/>";
            mailMessage.Body += body;
            mailMessage.Body += "<br/><br/>Üdvözlettel / Best regards<div style='border:none;border-top:solid #295D89 1.0pt;mso-border-top-alt:solid #295D89 .75pt;padding:0cm 0cm 0cm 0cm'><span style='font-size:7.0pt'>Kérjük, ne válaszoljon erre az automatikusan generált levélre! / Please do not reply to this automatically generated e-mail.</span>";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.sg.lan");
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            string a = ex.Message;

        }
    }

    public static int Feltolt(int oldrows, int actualrow, SqlDataReader dr, DataTable dt, string MR, string Reception, DataTable dt2)
        {
            if (Reception == dr["Reception"].ToString())
            {

                if (actualrow > dt.Rows.Count - 1)
                {
                    DataRow drow = dt.NewRow();
                    drow["MR"] = MR;
                    drow[dr["Reception"].ToString() + " érkezés"] = dr["InDateTime"].ToString().Substring(0, 5);
                    drow[dr["Reception"].ToString() + " indulás"] = dr["OutDateTime"].ToString().Substring(0, 5);
                    drow[dr["Reception"].ToString() + " érkezés2"] = dr["InDateTime"].ToString().Substring(0, 5);
                    drow[dr["Reception"].ToString() + " indulás2"] = dr["OutDateTime"].ToString().Substring(0, 5);
                    dt.Rows.Add(drow);
                }
                else
                {
                    dt.Rows[actualrow][dr["Reception"].ToString() + " érkezés"] = dr["InDateTime"].ToString().Substring(0, 5);
                    dt.Rows[actualrow][dr["Reception"].ToString() + " indulás"] = dr["OutDateTime"].ToString().Substring(0, 5);
                    dt.Rows[actualrow][dr["Reception"].ToString() + " érkezés2"] = dr["InDateTime"].ToString().Substring(0, 5);
                    dt.Rows[actualrow][dr["Reception"].ToString() + " indulás2"] = dr["OutDateTime"].ToString().Substring(0, 5);
                }

            }
            else
            {
                actualrow = oldrows;
                DataColumnCollection columns = dt.Columns;
                if (!columns.Contains(dr["Reception"].ToString() + " érkezés"))
                {
                    dt.Columns.Add(dr["Reception"].ToString() + " érkezés", typeof(string));
                    dt.Columns.Add(dr["Reception"].ToString() + " érkezés2", typeof(string));
                    dt2.Columns.Add(dr["Reception"].ToString() + " érkezés", typeof(string));
                    dt2.Columns.Add(dr["Reception"].ToString() + " érkezés2", typeof(string));
                }
                if (!columns.Contains(dr["Reception"].ToString() + " indulás"))
                {
                    dt.Columns.Add(dr["Reception"].ToString() + " indulás", typeof(string));
                    dt.Columns.Add(dr["Reception"].ToString() + " indulás2", typeof(string));
                    dt2.Columns.Add(dr["Reception"].ToString() + " indulás", typeof(string));
                    dt2.Columns.Add(dr["Reception"].ToString() + " indulás2", typeof(string));
                }
                if (actualrow > dt.Rows.Count - 1)
                {
                    DataRow drow = dt.NewRow();
                    drow["MR"] = MR;
                    drow[dr["Reception"].ToString() + " érkezés"] = dr["InDateTime"].ToString().Substring(0, 5);
                    drow[dr["Reception"].ToString() + " indulás"] = dr["OutDateTime"].ToString().Substring(0, 5);
                    drow[dr["Reception"].ToString() + " érkezés2"] = dr["InDateTime"].ToString().Substring(0, 5);
                    drow[dr["Reception"].ToString() + " indulás2"] = dr["OutDateTime"].ToString().Substring(0, 5);
                    dt.Rows.Add(drow);
                    actualrow = actualrow + 1;
                }
                else
                {

                    dt.Rows[actualrow][dr["Reception"].ToString() + " érkezés"] = dr["InDateTime"].ToString().Substring(0, 5);
                    dt.Rows[actualrow][dr["Reception"].ToString() + " indulás"] = dr["OutDateTime"].ToString().Substring(0, 5);
                    dt.Rows[actualrow][dr["Reception"].ToString() + " érkezés2"] = dr["InDateTime"].ToString().Substring(0, 5);
                    dt.Rows[actualrow][dr["Reception"].ToString() + " indulás2"] = dr["OutDateTime"].ToString().Substring(0, 5);
                }

            }

            return actualrow;


        }
        protected void DropDownListHeaderReception_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList DropDownListGrid = GridViewMilk.HeaderRow.FindControl("DropDownListHeaderReception") as DropDownList;
            if (DropDownListGrid.SelectedIndex.ToString() != "0")
            {
                Session["HeaderReception"] = DropDownListGrid.SelectedItem.Text.ToString();
            }
            reSQLFilterExpr();
        }

        protected void ImageButtonUpd_Click1(object sender, ImageClickEventArgs e)
        {
            MILK.FilterExpression = "";
            GridViewMilk.DataBind();
        }
        protected void frissitMilk(string mrwher)
        {
            string datumwhere = "";
            if (string.IsNullOrEmpty(TextBoxMRDate.Text.ToString().Trim()))
            {

                if (DropDownListMRDate.SelectedValue.ToString() != "-1")
                {
                    datumwhere = DropDownListMRYear.SelectedValue.ToString() + "-" + DropDownListMRDate.SelectedValue.ToString();
                    string nextmonth = (int.Parse(DropDownListMRDate.SelectedValue.ToString()) + 1).ToString();

                }
                else
                {
                    LabelError.Text = "Kérlek válasz dátumot!";
                    return;
                }
            }
            else
            {
                datumwhere = TextBoxMRDate.Text.ToString().Trim();
                LabelError.Text = "";
            }

            MILK.ConnectionString = _csTest;
            MILK.SelectCommand = "SELECT MilkRunMovement.plombaszam, Milkruns.TrackingNumber, Milkruns.TrailerNumber, Milkruns.DriverName, MilkRunMovement.InDate, MilkRunMovement.OutDate,MilkRunMovement.InPalette,MilkRunMovement.OutPalette, Users.Username AS Reception, 'MR' + CONVERT (varchar(2), Milkruns.ID) AS MR FROM MilkRunMovement LEFT OUTER JOIN Users ON MilkRunMovement.receptionID = Users.UserId RIGHT OUTER JOIN Milkruns ON MilkRunMovement.TrackingNumberID = Milkruns.ID where cast(InDate as date) like '%" + datumwhere + "%' and " + mrwher + " ORDER BY MilkRunMovement.ID DESC";
            GridViewMilk.DataSource = MILK;
            GridViewMilk.DataBind();
        }
        protected void SQLFilterExpr(string mezo, string op, string ertek)
        {
            if (!String.IsNullOrEmpty(ertek) && ertek != "%%")
            {
                if (String.IsNullOrEmpty(MILK.FilterExpression.ToString()))
                {
                    MILK.FilterExpression = mezo + " " + op + " '" + ertek + "'";
                }
                else
                {
                    if (Session["filterMR"].ToString().Contains(mezo) && !String.IsNullOrEmpty(ertek))
                    {
                        MILK.FilterExpression = Session["filter"].ToString();
                    }
                    else
                    {
                        MILK.FilterExpression += " AND " + mezo + " " + op + " '" + ertek + "'";
                    }
                }
                Session["filterMR"] = MILK.FilterExpression.ToString();
            }
            else
            {
                Session["filterMR"] = "";
                MILK.FilterExpression = "";
            }

        }

        protected void reSQLFilterExpr()
        {
            SQLFilterExpr("", "", "");

            if (Session["HeaderMR"].ToString() != "0")
            {
                SQLFilterExpr("[MR]", "=", Session["HeaderMR"].ToString());

            }

            if (Session["HeaderMRKör"].ToString() != "0")
            {
                SQLFilterExpr("[LabelMRKör]", "=", Session["HeaderMRKör"].ToString());

            }

            if (Session["HeaderReception"].ToString() != "0")
            {
                SQLFilterExpr("[Reception]", "=", Session["HeaderReception"].ToString());

            }

            if (Session["filterMR"] != null)
            {
                MILK.FilterExpression = Session["filterMR"].ToString();
            }
            GridViewMilk.DataBind();
            //frissitMilk();
        }
        protected void DropDownListHeaderMR_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList DropDownListGrid = GridViewMilk.HeaderRow.FindControl("DropDownListHeaderMR") as DropDownList;
            if (DropDownListGrid.SelectedIndex.ToString() != "0")
            {
                Session["HeaderMR"] = DropDownListGrid.SelectedItem.Text.ToString();
            }
            reSQLFilterExpr();
        }

        protected void DropDownListHeaderMRKör_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList DropDownListGrid = GridViewMilk.HeaderRow.FindControl("DropDownListHeaderMRKör") as DropDownList;
            if (DropDownListGrid.SelectedIndex.ToString() != "0")
            {
                Session["HeaderMRKör"] = DropDownListGrid.Text.ToString();
            }
            reSQLFilterExpr();
        }

        protected void frissitGridViewMilk()
        {
            string sqlwhere = "and 1=1";

            if (!String.IsNullOrEmpty(Session["MR"].ToString()))
            {
                sqlwhere = " and  CONVERT(VARCHAR(25), Plannedpickup, 126) LIKE '%" + Session["MR"].ToString() + "%' ";
            }

            if (!String.IsNullOrEmpty(Session["MRKör"].ToString()))
            {
                sqlwhere = " and  CONVERT(VARCHAR(25), Actualpickup, 126) LIKE '%" + Session["MRKör"].ToString() + "%' ";
            }

            SqlDataSourceSGHUORDER.SelectCommand = "SELECT Milkruns.TrackingNumber, Milkruns.TrailerNumber, Milkruns.DriverName, MilkRunMovement.InDate, MilkRunMovement.OutDate, Users.Username AS Reception, 'MR' + CONVERT (varchar(2), Milkruns.ID) AS MR, DATEDIFF(mi, dbo.MilkRunMovement.indate, dbo.MilkRunMovement.OutDate) AS [Perc Eltérés] FROM MilkRunMovement LEFT OUTER JOIN Users ON MilkRunMovement.receptionID = Users.UserId RIGHT OUTER JOIN Milkruns ON MilkRunMovement.TrackingNumberID = Milkruns.ID ORDER BY MilkRunMovement.ID where " + sqlwhere;
            GridViewMilk.DataSource = SqlDataSourceSGHUORDER;
            GridViewMilk.DataBind();

        }
        protected void GridViewMilk_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LabelOrderID = e.Row.FindControl("LabelMR") as Label;
                Label LabelOrderMRkör = e.Row.FindControl("LabelMRKör") as Label;
                Label LabelPercElteres = e.Row.FindControl("LabelPercElteres") as Label;
                if (LabelOrderID.Text == "MR1" || LabelOrderID.Text == "MR2" || LabelOrderID.Text == "MR3")
                {
                    LabelOrderMRkör.Text = "Alapanyag";
                }
                else if (LabelOrderID.Text == "MR4" || LabelOrderID.Text == "MR5" || LabelOrderID.Text == "MR6")
                {
                    LabelOrderMRkör.Text = "Késztermék";
                }
                else
                {
                    LabelOrderMRkör.Text = "Logicon mosós";
                }
                //if (!string.IsNullOrEmpty(LabelPercElteres.Text.ToString().Trim()))
                //{
                //    if (int.Parse(LabelPercElteres.Text.ToString().Trim()) > 90)
                //    {
                //        e.Row.BackColor = System.Drawing.Color.FromName("Red");
                //    }
                //}

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                }



            }
        }

        protected void ButtonLogiconMosos_Click(object sender, EventArgs e)
        {
            DropDownListMR.Items.Clear();
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem(" * Kérlek válassz egyet! * ", "0"));
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK7", "7"));
            GridView2.Visible = false;
            GridViewPercent.Visible = false;
            GridViewMilk.Visible = false;
            if (CheckBoxList.Checked)
            {
                frissitMilk("Milkruns.ID = '7'");
                GridViewMilk.Visible = true;
            }
            else
            {
                MRCircle("Milkruns.ID = '7'");

            }
            Session["MRCircle"] = "mosos";
        }

        protected void ButtonKesztermek_Click(object sender, EventArgs e)
        {
            DropDownListMR.Items.Clear();
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem(" * Kérlek válassz egyet! * ", "0"));
            //DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("All", "-1"));
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK4", "4"));
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK5", "5"));
            GridView2.Visible = false;
            GridViewPercent.Visible = false;
            GridViewMilk.Visible = false;
            string datumwhere = datumkeres();
        Session["MRCircle"] = "Kesztermek";
        if (CheckBoxPercent.Checked)
            {
                LabelPercentMR.Text = Resources.Resource.finishedproduct;
                Percent("(Milkruns.ID = '4' OR Milkruns.ID = '5')", datumwhere, 10);
                percent.Visible = true;
            }
            if (CheckBoxList.Checked)
            {
                frissitMilk("(Milkruns.ID = '4' OR Milkruns.ID = '5')");
                GridViewMilk.Visible = true;
            }
            else
            {
                MRCircle("(Milkruns.ID = '4' OR Milkruns.ID = '5')");

            }

        }
        protected void Percent(string mrwher, string datumwhere, int alldate)
        {
            string CS = _csTest;
            using (SqlConnection con = new SqlConnection(CS))
            {

                string cmdString = "SELECT CONVERT(varchar,dbo.MilkRunMovement.InDate,120) AS InDATE, CONVERT(varchar,dbo.MilkRunMovement.OutDate,120) AS OutDATE, dbo.Users.Username AS Reception, 'MR' + CONVERT(varchar(2), dbo.Milkruns.ID) AS MR FROM dbo.MilkRunMovement LEFT OUTER JOIN dbo.Users ON dbo.MilkRunMovement.receptionID = dbo.Users.UserId RIGHT OUTER JOIN dbo.Milkruns ON dbo.MilkRunMovement.TrackingNumberID = dbo.Milkruns.ID WHERE (InDate IS NOT NULL) and  Username is not null  and cast(InDate as date) like '%" + datumwhere + "%' and " + mrwher + "  ORDER BY dbo.Milkruns.ID DESC, dbo.MilkRunMovement.ID DESC";
                //string cmdString = "SELECT CONVERT(varchar,dbo.MilkRunMovement.InDate,120) AS InDATE, CONVERT(varchar,dbo.MilkRunMovement.OutDate,120) AS OutDATE, dbo.Users.Username AS Reception, 'MR' + CONVERT(varchar(2), dbo.Milkruns.ID) AS MR FROM dbo.MilkRunMovement LEFT OUTER JOIN dbo.Users ON dbo.MilkRunMovement.receptionID = dbo.Users.UserId RIGHT OUTER JOIN dbo.Milkruns ON dbo.MilkRunMovement.TrackingNumberID = dbo.Milkruns.ID  ORDER BY dbo.Milkruns.ID DESC, dbo.MilkRunMovement.ID DESC";

                con.Open();
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Indate", typeof(string));
                dataTable.Columns.Add("OutDate", typeof(string));
                dataTable.Columns.Add("Reception", typeof(string));
                dataTable.Columns.Add("MR", typeof(string));
                dataTable.Columns.Add("Úton Töltött perc", typeof(string));



                SqlDataReader dr = Functions.ExecQuery(con, cmdString);
                if (dr.HasRows)
                {

                    string reception = "";
                    string MR = "";
                    DateTime datatableIndate = DateTime.MaxValue;
                    DateTime datatableOutdate = DateTime.MinValue;
                    Double uttontoltve = 0;
                    int i = 0;
                    int j = 0;
                    DataRow drow = dataTable.NewRow();
                    while (dr.Read())
                    {

                        if (reception == dr["Reception"].ToString())
                        {
                            datatableIndate = DateTime.Parse(dr["Indate"].ToString());
                            if (Math.Abs((datatableIndate - DateTime.Parse(dataTable.Rows[i - 1]["Indate"].ToString())).TotalSeconds) <= 600)
                            {
                                continue;
                            }
                            else
                            {
                                drow = dataTable.NewRow();
                                reception = dataTable.Rows[i - 1]["Reception"].ToString();

                                datatableOutdate = DateTime.MinValue;
                                drow["OutDate"] = datatableOutdate;
                                drow["Indate"] = datatableIndate;
                                drow["Reception"] = reception;
                                drow["MR"] = dataTable.Rows[i - 1]["MR"].ToString();
                                uttontoltve = (datatableIndate - datatableOutdate).TotalSeconds;
                                j++;
                                drow["Úton Töltött perc"] = "";
                                drow["OutDate"] = "Nem történt Szkennelés";


                                dataTable.Rows.Add(drow);
                                i = i + 1;
                            }

                        }
                        else
                        {


                            drow = dataTable.NewRow();
                            MR = dr["MR"].ToString();
                            reception = dr["Reception"].ToString();

                            drow["MR"] = MR;

                            if (!string.IsNullOrEmpty(dr["OutDate"].ToString()))
                            {
                                datatableOutdate = DateTime.Parse(dr["OutDate"].ToString());
                                drow["OutDate"] = dr["OutDate"].ToString();
                            }
                            else
                            {
                                datatableOutdate = DateTime.MinValue;
                                drow["OutDate"] = datatableOutdate;
                            }

                            uttontoltve = (datatableIndate - datatableOutdate).TotalSeconds;
                            if (uttontoltve >= 1200)
                            {
                                j++;
                            }
                            drow["Úton Töltött perc"] = Math.Round((uttontoltve / 60), 2).ToString();

                            if (!string.IsNullOrEmpty(dr["Indate"].ToString()))
                            {
                                datatableIndate = DateTime.Parse(dr["Indate"].ToString());
                                drow["Indate"] = dr["Indate"].ToString();
                            }
                            else
                            {
                                datatableIndate = DateTime.MaxValue;
                                drow["Indate"] = datatableIndate;
                            }

                            drow["Reception"] = reception;
                            if (datatableOutdate == DateTime.MinValue)
                            {
                                drow["Úton Töltött perc"] = "";
                                drow["OutDate"] = "Nem történt Szkennelés";
                            }
                            if (datatableIndate == DateTime.MaxValue)
                            {


                                drow["Úton Töltött perc"] = "";
                                drow["Indate"] = "Nem történt Szkennelés";
                            }
                            dataTable.Rows.Add(drow);
                            i = i + 1;
                        }

                    }
                    DataTable grid = new DataTable();
                    LabelPercentDate.Text = datumwhere.ToString();
                    LabelPercen.Text = Math.Round(((double)(i - j) / (double)i) * 100).ToString() + "%";
                    GridViewPercent.DataSource = dataTable;
                    GridViewPercent.DataBind();
                    GridViewPercent.Visible = true;
                }

                else
                {
                    LabelPercen.Text = "-";
                }
            }
        }
        protected void ButtonAlapanyag_Click(object sender, EventArgs e)
        {
            DropDownListMR.Items.Clear();
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem(" * Kérlek válassz egyet! * ", "0"));
            //DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("All", "-1"));
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK1", "1"));
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK2", "2"));
            DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK3", "3"));
            GridView2.Visible = false;
            GridViewPercent.Visible = false;
            GridViewMilk.Visible = false;
            Session["MRCircle"] = "alapanyag";
            string datumwhere = datumkeres();
            if (CheckBoxPercent.Checked)
            {
                Percent("(Milkruns.ID = '1' OR Milkruns.ID = '2' OR Milkruns.ID = '3')", datumwhere, 10);
                LabelPercentMR.Text = Resources.Resource.rawmaterial;
                percent.Visible = true;
            }
            if (CheckBoxList.Checked)
            {
                frissitMilk("(Milkruns.ID = '1' OR Milkruns.ID = '2' OR Milkruns.ID = '3')");
                GridViewMilk.Visible = true;
            }
            else
            {
                MRCircle("(Milkruns.ID = '1' OR Milkruns.ID = '2' OR Milkruns.ID = '3')");
            }





        }

        protected string datumkeres()
        {

            string datumwhere = "";

            if (string.IsNullOrEmpty(TextBoxMRDate.Text.ToString().Trim()))
            {

                if (DropDownListMRDate.SelectedValue.ToString() != "-1")
                {
                    datumwhere = DropDownListMRYear.SelectedValue.ToString() + "-" + DropDownListMRDate.SelectedValue.ToString();
                    string nextmonth = (int.Parse(DropDownListMRDate.SelectedValue.ToString()) + 1).ToString();

                }
                else
                {
                    LabelError.Text = "Kérlek válasz dátumot!";
                    return "";
                }
            }
            else
            {
                datumwhere = TextBoxMRDate.Text.ToString().Trim();
                LabelError.Text = "";
            }
            return datumwhere;

        }

        protected void DropDownListMR_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridViewPercent.Visible = false;
            GridViewMilk.Visible = false;
            string datumwhere = datumkeres();
            if (CheckBoxList.Checked)
            {

                frissitMilk("Milkruns.ID = '" + DropDownListMR.SelectedValue + "'");
                GridViewMilk.Visible = true;
            }
            if (CheckBoxPercent.Checked)
            {
                LabelPercentMR.Text = DropDownListMR.SelectedValue.ToString();
                Percent("(Milkruns.ID = '" + DropDownListMR.SelectedValue + "')", datumwhere, 10);
                percent.Visible = true;
            }

            else
            {
                MRCircle("Milkruns.ID = '" + DropDownListMR.SelectedValue + "'");
            }

        }

        protected void TextBoxMRDate_TextChanged(object sender, EventArgs e)
        {
            DropDownListMRDate.ClearSelection();
            DropDownListMRDate.Items.FindByValue("-1").Selected = true;

            DropDownListMR.ClearSelection();
            DropDownListMR.Items.FindByValue("0").Selected = true;


            GridView2.DataSource = null;
            GridView2.DataBind();

        }

        protected void DropDownListMRDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListMR.ClearSelection();
            DropDownListMR.Items.FindByValue("0").Selected = true;

            TextBoxMRDate.Text = "";

            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                e.Row.Cells[0].Text = "MR";
                e.Row.Cells[1].Text = "SGHU menetrend érkezés";
                e.Row.Cells[2].Text = "SGHU valós érkezés";
                e.Row.Cells[3].Text = "SGHU menetrend indulás";
                e.Row.Cells[4].Text = "SGHU valós indulás";
                e.Row.Cells[5].Text = "Raktár menetrend érkezés";
                e.Row.Cells[6].Text = "Raktár valós érkezés";
                e.Row.Cells[7].Text = "Raktár menetrend indulás";
                e.Row.Cells[8].Text = "Raktár valós indulás";

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    //if (e.Row.Cells[i].Text.Contains("R"))
                    //{
                    //    e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace("R", "");
                    //    e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("Red");
                    //}
                    e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridViewPercent.Visible = false;
            GridViewMilk.Visible = false;
            GridViewMilk.Visible = true;
            GridView2.Visible = false;

        }

        protected void CheckBoxTimetable_CheckedChanged(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridViewPercent.Visible = false;
            GridViewMilk.Visible = false;
            CheckBoxList.Checked = false;
            CheckBoxPercent.Checked = false;
            percent.Visible = false;
        }
        protected void CheckBoxPercent_CheckedChanged(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridViewPercent.Visible = false;
            GridViewMilk.Visible = false;
            CheckBoxList.Checked = false;
            CheckBoxTimetable.Checked = false;
            percent.Visible = false;
        }


        protected void CheckBoxList_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxTimetable.Checked = false;
            CheckBoxPercent.Checked = false;
            percent.Visible = false;
        }

        protected void ImageButtonExcel_Click(object sender, ImageClickEventArgs e)
        {
            GridView gr = null;
            string name = "";
            if (GridView2.Visible == true) { gr = GridView2; name = "MilkRunMovement"; }
            if (GridViewMilk.Visible == true) { gr = GridViewMilk; name = "MilkRunMovement"; }
            if (GridViewPercent.Visible == true) { gr = GridViewPercent; name = "MilkRunMovement"; }

            if (gr != null)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                "attachment;filename=" + name + ".xlsx");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gr.AllowPaging = false;

                //if (GridViewMilk.Visible == true)
                //{
                //    gr.Columns[0].Visible = false;
                //    DropDownList GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListHeaderMR");
                //    GridDrop.Visible = false;
                //    GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListHeaderMRKör");
                //    GridDrop.Visible = false;
                //    GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListHeaderReception");
                //    GridDrop.Visible = false;
                //}


                gr.RenderControl(hw);
                HttpContext.Current.Response.Charset = "utf-8";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void ButtonAll_Click(object sender, EventArgs e)
    {
        DropDownListMR.Items.Clear();
        DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem(" * Kérlek válassz egyet! * ", "0"));
        DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK1", "1"));
        DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK2", "2"));
        DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK3", "3"));
        DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK4", "4"));
        DropDownListMR.Items.Add(new System.Web.UI.WebControls.ListItem("MILK5", "5"));
        DropDownListMR.DataBind();
        string datumwhere = datumkeres();
        GridView2.Visible = false;
        GridViewPercent.Visible = false;
        GridViewMilk.Visible = false;
        Session["MRCircle"] = "all";
        if (CheckBoxList.Checked)
        {
            frissitMilk("1=1");
            GridViewMilk.Visible = true;
        }
        if (CheckBoxPercent.Checked)
        {
            Percent("1=1", datumwhere, 10);
            percent.Visible = true;
        }
        else
        {
            MRCircle("1=1");
        }


    }

    protected void GridViewPercent_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //Label LabelOrderID = e.Row.FindControl("LabelMR") as Label;
        //Label LabelOrderMRkör = e.Row.FindControl("LabelMRKör") as Label;
        //Label LabelPercElteres = e.Row.FindControl("LabelPercElteres") as Label;
        //if (LabelOrderID.Text == "MR1" || LabelOrderID.Text == "MR2" || LabelOrderID.Text == "MR3")
        //{
        //    LabelOrderMRkör.Text = "Alapanyag";
        //}           

        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;text-align: center;");
        }





    }
}



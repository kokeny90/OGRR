using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Form_Kereses : System.Web.UI.Page
{
    private static Random random = new Random();
    public string folderPath = HostingEnvironment.MapPath("~/Files/" + HttpContext.Current.User.Identity.Name.ToString().Trim().ToLower() + @"/");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            string cs = Functions.ConnectionString(User.Identity.Name);
            SqlDataSourceOrszagKod.ConnectionString = cs;
            SqlDataSource6.ConnectionString = cs;
            SqlDataSourceSGHUORDER.ConnectionString = cs;
            SqlDataSource3.ConnectionString = cs;
            SqlDataSourceColor.ConnectionString = cs;
            SqlDataSource2.ConnectionString = cs;
            SqlDataSource1.ConnectionString = cs;
            SqlDataSourceMonth.ConnectionString = cs;
            SqlDataSourcePercent.ConnectionString = cs;
            SqlDataSource4.ConnectionString = cs;
            SqlDataSourceFilterLSP.ConnectionString = cs;
            SqlDataSourceYear.ConnectionString = cs;
            SqlDataSourcePDF.ConnectionString = cs;

            if (!IsPostBack)
            {
                string a = User.Identity.Name;
                Session["login"] = User.Identity.Name.ToString();
                Session["filter"] = "";
                Session["filterMR"] = "";
                Session["plannedarrival"] = "";
                Session["filterpercen2"] = "";
                Session["drop"] = "-1";
                Session["Actualarrival"] = "";
                Session["Actualpickup"] = "";
                Session["Plannedpickup"] = "";

               
            }
            else
            {
                if (Session["filter"] != null)
                {

                    SqlDataSource1.FilterExpression = Session["filter"].ToString();
                }





            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void frissitPDF()
    {
        SqlDataSourcePDF.SelectCommand = "SELECT dbo.PDFiles.ID, dbo.PDFiles.name, dbo.PDFiles.type, dbo.PDFiles.data FROM dbo.PDFKapcsolo INNER JOIN dbo.PDFiles ON dbo.PDFKapcsolo.PDFFilesID = dbo.PDFiles.ID WHERE(dbo.PDFKapcsolo.OrderID = " + DropDownList1.Text + ");";
        GridViewPDF.DataSource = SqlDataSourcePDF;
       GridViewPDF.DataBind();
    }
    protected void frissit(string ev)
    {
        string sqlwhere = "and 1=1";

        if (!String.IsNullOrEmpty(Session["Plannedpickup"].ToString()))
        {
            sqlwhere = " and  CONVERT(VARCHAR(25), Plannedpickup, 126) LIKE '%" + Session["Actualarrival"].ToString() + "%' ";
        }

        if (!String.IsNullOrEmpty(Session["Actualpickup"].ToString()))
        {
            sqlwhere = " and  CONVERT(VARCHAR(25), Actualpickup, 126) LIKE '%" + Session["Actualarrival"].ToString() + "%' ";
        }

        if (!String.IsNullOrEmpty(Session["Actualarrival"].ToString()))
        {
            sqlwhere = " and  CONVERT(VARCHAR(25), Actualarrival, 126) LIKE '%" + Session["Actualarrival"].ToString() + "%' ";
        }


        if (!String.IsNullOrEmpty(Session["plannedarrival"].ToString()))
        {
            sqlwhere = " and  CONVERT(VARCHAR(25), Plannedarrival, 126) LIKE '%" + Session["plannedarrival"].ToString() + "%'   ";
        }
        SqlDataSourceSGHUORDER.SelectCommand = "SELECT * FROM dbo.VSGHUORDER where StartDate like '" + ev.ToString().Trim() + "%'" + sqlwhere + "ORDER BY OrderID DESC;";
        GridViewSGHUORDER.DataSource = SqlDataSourceSGHUORDER;
        GridViewSGHUORDER.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "")
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("Form_Kereses.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Login.aspx");
            }
        }
        else
        {
            SqlDataReader dataReader;
            String query = "SELECT dbo.SGHUOrder.*, dbo.LSP.Email, dbo.LSP.CC,  dbo.Users.Username FROM  dbo.SGHUOrder LEFT OUTER JOIN dbo.LSP ON dbo.SGHUOrder.Forwarder = dbo.LSP.ID LEFT OUTER JOIN dbo.Users ON dbo.SGHUOrder.receptionID = dbo.Users.UserId where OrderID=@OrderID;";
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@OrderID", SqlDbType.Int).Value = int.Parse(DropDownList1.Text);
                    con.Open();
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        RowResendmail.Visible = true;
                        LabelOrderNumber.Text = dataReader[0].ToString().Trim();
                        //   DropDownListProfitCenter.SelectedValue = dataReader[1].ToString().Trim();
                        TextBoxInfo.Value = dataReader[2].ToString();
                        LabelDate.Text = dataReader["StartDate"].ToString();
                        LabelPerson.Text = dataReader["Person"].ToString();
                        LabelComputer.Text = dataReader["Computer"].ToString();
                        TextBox8.Text = dataReader["Nyomonkovetesi"].ToString();
                        TextBox9.Text = dataReader["Konyvelesi"].ToString();
                        TextBox11.Text = dataReader["SzamlazottAr"].ToString();
                        TextBox10.Text = dataReader["Szamlaszam"].ToString();
                        TextBoxRequester.Text = dataReader["Igenylo"].ToString();
                        TextBoxTracking.Text = dataReader["TrackingNumber"].ToString();
                        txtEmail.Text = dataReader["Email"].ToString();
                        TextCC.Text = dataReader["CC"].ToString();
                        LabelReception3.Text = dataReader["Username"].ToString();
                        try
                        {
                            DropDownListFrom.DataBind();
                            DropDownListFrom.SelectedValue = dataReader["Honnan"].ToString();
                        }
                        catch (Exception)
                        { }

                        try
                        {
                            DropDownListTo.DataBind();
                            DropDownListFrom.SelectedValue = dataReader["Hova"].ToString();
                        }
                        catch (Exception)
                        { }
                        TextBoxPlannedPickUp.Text = dataReader["Plannedpickup"].ToString();
                        TextBoxActualpickup.Text = dataReader["Actualpickup"].ToString();
                        TextBoxPlannedarrival.Text = dataReader["Plannedarrival"].ToString();
                        LabelActualarrival.Text = dataReader["Actualarrival"].ToString();
                        TextBoxComment.Text = dataReader["Comment"].ToString();

                        try
                        {
                            DropDownList5.DataBind();
                            DropDownList5.SelectedValue = dataReader["Forwarder"].ToString();
                        }
                        catch (Exception)
                        { }
                        TextBoxService.Text = dataReader["Service"].ToString();

                        try
                        {
                            DropDownListProfitCenter.DataBind();
                            DropDownListProfitCenter.SelectedIndex = int.Parse(dataReader["ProfitCenter"].ToString());
                        }
                        catch (Exception)
                        { }
                        if (dataReader["Deleted"].ToString() == "1")
                        {
                            CheckBoxDeleted.Checked = true;
                        }
                        else
                        {
                            CheckBoxDeleted.Checked = false;
                        }
                        if (dataReader["Arrived"].ToString() == "1")
                        {
                            CheckBoxArrived.Checked = true;
                        }
                        else
                        {
                            CheckBoxArrived.Checked = false;
                        }
                        if (string.IsNullOrEmpty(dataReader["QRCodeID"].ToString().Trim()))
                        {
                            string QRCodeID = "";
                            using (SqlConnection con2 = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
                            {
                                QRCodeID = "SGHU" + DropDownList1.Text + RandomString(9 - DropDownList1.Text.Length);
                                query = "Update SGHUOrder SET QRCodeID=@QRCodeID where OrderID=@OrderID;";
                                using (SqlCommand command2 = new SqlCommand(query, con2))
                                {
                                    command2.Parameters.Add("@QRCodeID", SqlDbType.VarChar).Value = QRCodeID;
                                    command2.Parameters.Add("@OrderID", SqlDbType.Int).Value = int.Parse(DropDownList1.Text);
                                    con2.Open();
                                    command2.ExecuteNonQuery();
                                    con2.Close();
                                }
                            }
                            query = "SELECT Signature FROM Users where Username=@Person";
                            create_Qrcode("SGHU ORDER-" + DropDownList1.Text, User.Identity.Name.ToString().Trim(), QRCodeID);
                            PDFUpload(folderPath + "\\" + "QRCODE" + ".jpg", int.Parse(DropDownList1.Text));
                        }
                        else
                        {
                            TextBoxQRCodeID.Text = dataReader["QRCodeID"].ToString();
                        }
                    }
                    else
                    {
                        RowResendmail.Visible = false;
                    }
                    con.Close();
                }
            }
            frissitPDF();
            //frissit();
        }
    }
    public void PDFUpload(string filein, int orderid)
    {
        Byte[] bytes;
        int PDFFilesID = 0;
        using (FileStream file = new FileStream(filein, FileMode.Open, FileAccess.Read))
        {
            bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
        }
        string query;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            SqlDataReader dataReader;
            query = "insert into [dbo].[PDFiles] (Name,type,data)" + " values (@Name, @type, @Data)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Path.GetFileName(filein);
                command.Parameters.Add("@type", SqlDbType.VarChar).Value = Path.GetExtension(filein);
                command.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            query = "SELECT MAX(ID) AS PDFFilesID FROM dbo.PDFiles";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    PDFFilesID = int.Parse(dataReader[0].ToString());
                }
                con.Close(); ;
            }
            query = "insert into [dbo].[PDFKapcsolo] (PDFFilesID,OrderID)" + " values (@PDFFilesID, @OrderID)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@PDFFilesID", SqlDbType.Int).Value = PDFFilesID;
                command.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderid;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    public string create_Qrcode(string nr, string folderPath, String QRCodeText)
    {
        //first we create a bitmap store textbox1 content's QRcode
        Bitmap bt;
        string enCodeString = QRCodeText;
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(QRCodeText, QRCodeGenerator.ECCLevel.H);
        bt = qrCode.GetGraphic(6);
        //second we create a new bitmap store QRcode and textbox2 content
        Bitmap map = new Bitmap(180, 220);
        Graphics g = Graphics.FromImage(map);
        //clear the bitmap
        g.Clear(Color.White);
        //draw QRcode into the new bitmap
        g.DrawImage(bt, new PointF(-10, -10));
        //draw textbox2 content
        g.DrawString(QRCodeText, new Font("Times new roma", 14.0f, FontStyle.Bold), Brushes.Red, new PointF(0, 180));
        //save image        
        string fileName = Guid.NewGuid().ToString();
        string filename = "QRCODE" + ".jpg";
        Server.MapPath("~/" + User.Identity.Name.ToString().Trim().ToLower() + "/");
        string filepath = Server.MapPath(@"~\" + folderPath + "") + "\\" + filename;
        System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
        map.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
        fs.Close();
        //show image
        return filepath;
    }
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    protected void Submit(object sender, EventArgs e)
    {
        //      DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector7.Hour, TimeSelector7.Minute, TimeSelector7.Second, TimeSelector7.AmPm));
        //     ClientScript.RegisterStartupScript(this.GetType(), "time", "alert('Selected Time: " + time.ToString("hh:mm:ss tt") + "');", true);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlDataReader dataReader;
        String query = "Update SGHUOrder Set ProfitCenter=@ProfitCenter,Info=@Info,Nyomonkovetesi=@Nyomonkovetesi,Konyvelesi=@Konyvelesi,Szamlaszam=@Szamlaszam,SzamlazottAr=@SzamlazottAr,Olepdf=@Olepdf,Igenylo=@Igenylo WHERE OrderID=@OrderID";
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@ProfitCenter", SqlDbType.Int).Value = DBNull.Value;
                command.Parameters.Add("@Info", SqlDbType.NChar).Value = TextBoxInfo.InnerText.ToString();
                // command.Parameters.Add("@Computer", SqlDbType.NChar).Value = TextBoxComputer.Text.ToString();
                command.Parameters.Add("@Igenylo", SqlDbType.NChar).Value = TextBoxRequester.Text.ToString().Trim();
                command.Parameters.Add("@OrderID", SqlDbType.NChar).Value = DropDownList1.Text;
                command.Parameters.Add("@Nyomonkovetesi", SqlDbType.NChar).Value = TextBox8.Text;
                if (TextBox9.Text == "")
                {
                    command.Parameters.Add("@Konyvelesi", SqlDbType.Int).Value = 0;
                }
                else
                {
                    command.Parameters.Add("@Konyvelesi", SqlDbType.Int).Value = double.Parse(TextBox9.Text.ToString().Trim());
                }
                command.Parameters.Add("@Szamlaszam", SqlDbType.NChar).Value = TextBox10.Text.ToString().Trim();
                if (TextBox11.Text == "")
                {
                    command.Parameters.Add("@SzamlazottAr", SqlDbType.Decimal).Value = 0;
                }
                else
                {
                    command.Parameters.Add("@SzamlazottAr", SqlDbType.Decimal).Value = decimal.Parse(TextBox11.Text.ToString().Trim());
                }
                command.Parameters.Add("@Olepdf", SqlDbType.NChar).Value = DBNull.Value;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        int a = int.Parse(DropDownList1.Text);
        query = "Select * from SGHUOrder where OrderID=" + a;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    LabelOrderNumber.Text = dataReader[0].ToString().Trim();
                    DropDownListProfitCenter.SelectedValue = dataReader[1].ToString().Trim();
                    //     TextBoxInfo.Text = dataReader[2].ToString();
                    LabelDate.Text = dataReader[3].ToString();
                    LabelPerson.Text = dataReader[4].ToString();
                    LabelComputer.Text = dataReader[5].ToString();
                    TextBoxRequester.Text = dataReader[11].ToString();
                    TextBox8.Text = dataReader[6].ToString();
                    TextBox9.Text = dataReader[7].ToString();
                    TextBox10.Text = dataReader[9].ToString();
                    TextBox11.Text = dataReader[8].ToString();
                    //TextBox12.Text = dataReader[10].ToString();
                }
                con.Close();
            }
        }
    }
    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void creatfiles()
    {
        string bevitelomezo = TextBoxInfo.InnerText.ToString();
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            con.Open();
            string query = "SELECT dbo.PDFiles.ID, dbo.PDFiles.name, dbo.PDFiles.type, dbo.PDFiles.data FROM dbo.PDFKapcsolo INNER JOIN dbo.PDFiles ON dbo.PDFKapcsolo.PDFFilesID = dbo.PDFiles.ID WHERE(dbo.PDFKapcsolo.OrderID = " + DropDownList1.Text + ");";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] objContext = (byte[])reader["data"];
                        File.WriteAllBytes(folderPath + @"\" + reader["name"].ToString(), objContext);
                    }
                }
            }
            con.Close();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //string folderPath = @"\\Mc0vm011.sg.lan\sghu_log-t$\" + User.Identity.Name.ToString().Trim() + @"\";
        if (Directory.Exists(folderPath))
        {
            try
            {
                Directory.Delete(folderPath, true);
                Directory.CreateDirectory(folderPath);
            }
            catch (Exception)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(folderPath);
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }
        else
        {
            Directory.CreateDirectory(folderPath);
        }
        adatfeltoltes();
        creatfiles();
        string ProfitCenter = "";
        if (DropDownListProfitCenter.Text != "-2")
        {
            ProfitCenter = DropDownListProfitCenter.Text;
        }
        string script = "window.onload = function(){call_me(" + Functions.SendMailJavaScript(TextBoxInfo.InnerText.ToString().Trim(), txtEmail.Text.ToString().Trim(), TextCC.Text.ToString().Trim(), DropDownList1.Text, User.Identity.Name, LabelDate.ToString(), ProfitCenter, TextBoxAlairas.InnerText.ToString().Trim()) + ")};";
        Page.ClientScript.RegisterStartupScript(GetType(), "call_me", script, true);
    }
    public string FetchLinksFromSource(string htmlSource)
    {
        List<Uri> links = new List<Uri>();
        string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
        MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        int i = 0;
        foreach (Match m in matchesImgSrc)
        {
            string href = m.Groups[1].Value;
            string kiterjesztes = href.Substring(0, 14);
            kiterjesztes = kiterjesztes.Substring(11, kiterjesztes.Length - 11);
            var base64Data = Regex.Match(href, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            using (var stream = new MemoryStream(binData))
            {
                File.WriteAllBytes(folderPath + @"\yourfile" + i.ToString() + "." + kiterjesztes, binData);
            }
            htmlSource = htmlSource.Replace(href, "cid:" + @"yourfile" + i.ToString() + "." + kiterjesztes);
            htmlSource = htmlSource.Replace("<img src=\"", "<img src = '");
            htmlSource = htmlSource.Replace("\"", "'");
            // bevitelomezo = bevitelomezo + @" < img src = 'cid:QRCODE.jpg' height = 480 width = 360 >";
            i++;
        }
        return htmlSource;
    }
    public string qr_generator(string code)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.H);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 100;
        imgBarCode.Width = 100;
        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                File.WriteAllBytes(Server.MapPath("~/" + User.Identity.Name.ToString().Trim().ToLower() + "QRCODE.jpg"), byteImage);
                //     imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
        }
        return "QRCodes/" + code + ".png";
    }
    protected void TextBoxRequester_TextChanged(object sender, EventArgs e)
    {
    }
    protected void ImageButtonAdd_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void ImageButtonCancel_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void ImageButtonOK_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void GridViewSGHUORDER_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        bool locked = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("chb_Locked") as CheckBox).Checked;
        string query;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            string a = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxTrackingNumber") as TextBox).Text.ToString().Trim();
            query = "UPDATE [SGHUOrder] SET TrackingNumber=@TrackingNumber,Honnan=@Honnan,Hova=@Hova,Forwarder=@Forwarder,Service=@Service,Plannedpickup=@Plannedpickup,Actualpickup=@Actualpickup,Plannedarrival=@Plannedarrival,Comment=@Comment,ColorID=@ColorID,TrailerNumber=@TrailerNumber,Deleted=@Deleted  WHERE OrderID=@OrderID;";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("LabelEditOrderID") as Label).Text.ToString().Replace("SGHU ORDER-", "");
                command.Parameters.Add("@TrackingNumber", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxTrackingNumber") as TextBox).Text.ToString();
                command.Parameters.Add("@TrailerNumber", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxTrailerNumber") as TextBox).Text.ToString();
                command.Parameters.Add("@ColorID", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("DropDownListName") as DropDownList).SelectedItem.Value;
                command.Parameters.Add("@Honnan", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("DropDownListHonnan") as DropDownList).SelectedItem.Value;
                command.Parameters.Add("@Hova", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("DropDownListHova") as DropDownList).SelectedItem.Value;
                command.Parameters.Add("@Forwarder", SqlDbType.Int).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("DropDownListForwarder") as DropDownList).SelectedItem.Value;
                command.Parameters.Add("@Deleted", SqlDbType.Bit).Value = Convert.ToInt32(locked);
                command.Parameters.Add("@Service", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxService") as TextBox).Text.ToString();
                if (string.IsNullOrEmpty((GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxPlannedpickup") as TextBox).Text.ToString()))
                {
                    command.Parameters.Add("@Plannedpickup", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@Plannedpickup", SqlDbType.Date).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxPlannedpickup") as TextBox).Text.ToString();
                }
                if (string.IsNullOrEmpty((GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxActualpickup") as TextBox).Text.ToString()))
                {
                    command.Parameters.Add("@Actualpickup", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@Actualpickup", SqlDbType.Date).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxActualpickup") as TextBox).Text.ToString();
                }
                if (string.IsNullOrEmpty((GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxPlannedarrival") as TextBox).Text.ToString()))
                {
                    command.Parameters.Add("@Plannedarrival", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@Plannedarrival", SqlDbType.DateTime).Value = DateParse((GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxPlannedarrival") as TextBox).Text.ToString() + " " + (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxTime") as TextBox).Text.ToString());
                }
                command.Parameters.Add("@Comment", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("TextBoxComment") as TextBox).Text.ToString();
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        GridViewSGHUORDER.EditIndex = -1;
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    public static DateTime DateParse(string date)
    {
        date = date.Trim();
        if (!string.IsNullOrEmpty(date))
            return DateTime.Parse(date, new System.Globalization.CultureInfo("en-GB"));
        return new DateTime();
    }
    protected void adatfeltoltes()
    {
        string bevitelomezo = TextBoxInfo.InnerText.ToString();
        SqlDataReader dataReader;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            string mailBody = HttpUtility.HtmlDecode(bevitelomezo);
            mailBody = mailBody.Replace("'", @"""");
            mailBody = mailBody.Replace("\r", "");
            mailBody = mailBody.Replace("\n", "");
            string query = "Update SGHUOrder Set ProfitCenter=@ProfitCenter,Service=@Service,Forwarder=@Forwarder,Comment = @Comment,Actualpickup = @Actualpickup,Plannedarrival=@Plannedarrival,StartDate = @StartDate,Info=@Info,Nyomonkovetesi=@Nyomonkovetesi,Konyvelesi=@Konyvelesi,SzamlazottAr=@SzamlazottAr,Igenylo=@Igenylo,TrackingNumber=@TrackingNumber, Szamlaszam=@Szamlaszam,Honnan=@Honnan,Hova=@Hova,Plannedpickup=@Plannedpickup WHERE OrderID=@OrderID";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@OrderID", SqlDbType.NChar).Value = DropDownList1.Text;
                command.Parameters.Add("@ProfitCenter", SqlDbType.Int).Value = DropDownListProfitCenter.SelectedIndex;
                if (string.IsNullOrEmpty(mailBody.ToString().Trim())) { command.Parameters.Add("@Info", SqlDbType.NChar).Value = DBNull.Value; } else { command.Parameters.Add("@Info", SqlDbType.NChar).Value = mailBody.ToString().Trim(); }
                if (string.IsNullOrEmpty(TextBoxRequester.Text.ToString().Trim())) { command.Parameters.Add("@Igenylo", SqlDbType.NChar).Value = DBNull.Value; } else { command.Parameters.Add("@Igenylo", SqlDbType.NChar).Value = TextBoxRequester.Text.ToString().Trim(); }
                if (string.IsNullOrEmpty(TextBox8.Text.ToString().Trim())) { command.Parameters.Add("@Nyomonkovetesi", SqlDbType.NChar).Value = DBNull.Value; } else { command.Parameters.Add("@Nyomonkovetesi", SqlDbType.NChar).Value = TextBox8.Text; }
                if (string.IsNullOrEmpty(TextBox9.Text.Trim())) { command.Parameters.Add("@Konyvelesi", SqlDbType.Int).Value = DBNull.Value; } else { command.Parameters.Add("@Konyvelesi", SqlDbType.Int).Value = double.Parse(TextBox9.Text.ToString().Trim()); }
                if (string.IsNullOrEmpty(TextBox11.Text.Trim())) { command.Parameters.Add("@SzamlazottAr", SqlDbType.Decimal).Value = DBNull.Value; } else { command.Parameters.Add("@SzamlazottAr", SqlDbType.Decimal).Value = decimal.Parse(TextBox11.Text.ToString().Trim()); }
                if (string.IsNullOrEmpty(TextBox10.Text.Trim())) { command.Parameters.Add("@Szamlaszam", SqlDbType.NChar).Value = DBNull.Value; } else { command.Parameters.Add("@Szamlaszam", SqlDbType.NChar).Value = TextBox10.Text.ToString().Trim(); }
                if (string.IsNullOrEmpty(TextBox8.Text.ToString().Trim())) { command.Parameters.Add("@TrackingNumber", SqlDbType.VarChar).Value = DBNull.Value; } else { command.Parameters.Add("@TrackingNumber", SqlDbType.VarChar).Value = TextBox8.Text.ToString().Trim(); }
                command.Parameters.Add("@Honnan", SqlDbType.Int).Value = int.Parse(DropDownListFrom.SelectedValue);
                command.Parameters.Add("@Hova", SqlDbType.Int).Value = int.Parse(DropDownListTo.SelectedValue);
                if (string.IsNullOrEmpty(TextBoxPlannedPickUp.Text.ToString().Trim())) { command.Parameters.Add("@Plannedpickup", SqlDbType.Date).Value = DBNull.Value; } else { command.Parameters.Add("@Plannedpickup", SqlDbType.Date).Value = TextBoxPlannedPickUp.Text.ToString(); }
                if (string.IsNullOrEmpty(LabelDate.Text)) { command.Parameters.Add("@StartDate", SqlDbType.Date).Value = DBNull.Value; } else { command.Parameters.Add("@StartDate", SqlDbType.Date).Value = LabelDate.Text; }
                if (string.IsNullOrEmpty(TextBoxActualpickup.Text)) { command.Parameters.Add("@Actualpickup", SqlDbType.Date).Value = DBNull.Value; } else { command.Parameters.Add("@Actualpickup", SqlDbType.Date).Value = TextBoxActualpickup.Text; }
                if (string.IsNullOrEmpty(TextBoxPlannedarrival.Text)) { command.Parameters.Add("@Plannedarrival", SqlDbType.Date).Value = DBNull.Value; } else { command.Parameters.Add("@Plannedarrival", SqlDbType.Date).Value = TextBoxPlannedarrival.Text; }
                if (string.IsNullOrEmpty(TextBoxComment.Text)) { command.Parameters.Add("@Comment", SqlDbType.VarChar).Value = DBNull.Value; } else { command.Parameters.Add("@Comment", SqlDbType.VarChar).Value = TextBoxComment.Text; }
                command.Parameters.Add("@Forwarder", SqlDbType.Int).Value = DropDownList5.SelectedItem.Value;
                if (string.IsNullOrEmpty(TextBoxService.Text)) { command.Parameters.Add("@Service", SqlDbType.VarChar).Value = DBNull.Value; } else { command.Parameters.Add("@Service", SqlDbType.VarChar).Value = TextBoxService.Text; }
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            //string orderid = DropDownList1.Text;
            //string filePath = @"//Mc0vm011.sg.lan/sghu_log-t$/" + User.Identity.Name.ToString().Trim() + @"/";
            //query = "SELECT Signature FROM Users where Username=@Person";
            //using (SqlCommand command = new SqlCommand(query, con))
            //{
            //    command.Parameters.Add("@Person", SqlDbType.NChar).Value = User.Identity.Name;
            //    con.Open();
            //    dataReader = command.ExecuteReader();
            //    if (dataReader.Read())
            //    {
            //        bevitelomezo = FetchLinksFromSource(bevitelomezo.ToString());
            //        bevitelomezo = bevitelomezo + @"<img src = 'cid:QRCODE.jpg' height = 480 width = 360 >";
            //        bevitelomezo = bevitelomezo.Replace(@"\", @"/");
            //        mailBody = HttpUtility.HtmlDecode(bevitelomezo);
            //        ///   mailBody = "<html><head></head><body><p>Dear Sir or Madam,</p><p></p><p><strong>Order Number:</strong> SGHU ORDER-" + orderid + "</p><p><strong>Date and Time:</strong>" + TextBoxDate.Text + "</p><p><strong>Profit Center:</strong>" + ProfintcenterName + "</p><p><strong>Requester:</strong> " + TextBoxPerson.Text.ToString().Trim() + "  </p><p><strong>Information: </strong></p><p>&nbsp;</p><p>" + bevitelomezo.ToString() + "</p><p></p><p>&nbsp;</p><p><strong>The invoice has to contain the relevant SGHU order number.</strong></p>" + TextBoxAlairas.Value.ToString();
            //        mailBody = mailBody.Replace("'", @"""");
            //        mailBody = mailBody.Replace("\r", "");
            //        mailBody = mailBody.Replace("\n", "");
            //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Adatmentés megtörtént!" + "');", true);
            //        string parameters = "";
            //        parameters = "['" + txtEmail.Text.ToString().Trim() + "', ";
            //        parameters = parameters + "'" + mailBody + "', ";
            //        parameters = parameters + "'" + "Transport - [SGHU ORDER - " + orderid + "]" + "', ";
            //        parameters = parameters + "'" + TextCC.Text.ToString().Trim() + "', ";
            //        filePath = Server.MapPath("~/" + User.Identity.Name.ToString().Trim().ToLower() + "/");
            //        foreach (string file in Directory.GetFiles(filePath))
            //        {
            //            parameters = parameters + @"'http://" + User.Identity.Name.ToString().Trim() + "/" + Path.GetFileName(file) + "', ";
            //            parameters = parameters.Replace(@"\", @"/");
            //            //PDFUpload(file, int.Parse(orderid));
            //        }
            //        parameters = parameters.Remove(parameters.Length - 2);
            //        parameters = parameters + "]";
            //        parameters = HttpUtility.HtmlDecode(parameters);
            //        string script = "window.onload = function(){call_me(" + parameters + ")};";
            //        this.Page.ClientScript.RegisterStartupScript(GetType(), "call_me", script, true);
            //    }
            //    con.Close();
            //}
        }
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Adatmentés megtörtént!" + "');", true);
    }
    protected void GridViewSGHUORDER_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewSGHUORDER.EditIndex = e.NewEditIndex;
        Label LabelGrid = (GridViewSGHUORDER.Rows[GridViewSGHUORDER.EditIndex].FindControl("LabelHonnan") as Label);
        Session["LabelHonnan"] = LabelGrid.Text.ToString();
        LabelGrid = (GridViewSGHUORDER.Rows[GridViewSGHUORDER.EditIndex].FindControl("LabelHova") as Label);
        Session["LabelHova"] = LabelGrid.Text.ToString();
        LabelGrid = (GridViewSGHUORDER.Rows[GridViewSGHUORDER.EditIndex].FindControl("LabelForwarder") as Label);
        Session["LabelForwarder"] = LabelGrid.Text.ToString();
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void GridViewSGHUORDER_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewSGHUORDER.EditIndex = -1;
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void GridViewSGHUORDER_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string query;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            query = "UPDATE [SGHUOrder] SET Deleted=1 WHERE OrderID=@OrderID;";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = (GridViewSGHUORDER.Rows[e.RowIndex].FindControl("LabelOrderID") as Label).Text.ToString().Replace("SGHU ORDER-", "");
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        GridViewSGHUORDER.EditIndex = -1;
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void GridViewSGHUORDER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewSGHUORDER.PageIndex = e.NewPageIndex;
        try
        {
            if (!String.IsNullOrEmpty(Session["filter"].ToString()))
            {
                SqlDataSource1.FilterExpression = Session["filter"].ToString();
            }
        }
        catch { }
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void GridViewSGHUORDER_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    protected void GridViewSGHUORDER_DataBinding(object sender, EventArgs e)
    {
    }
    protected void GridViewSGHUORDER_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("style", "cursor:help;");
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == GridViewSGHUORDER.EditIndex)
        {
            DropDownList DropDownListGrid = (e.Row.FindControl("DropDownListHonnan") as DropDownList);
            DropDownListGrid.ClearSelection();
            DropDownListGrid.SelectedIndex = DropDownListGrid.Items.IndexOf(DropDownListGrid.Items.FindByText(Session["LabelHonnan"].ToString()));
            DropDownListGrid = (e.Row.FindControl("DropDownListHova") as DropDownList);
            //DropDownListGrid.ClearSelection();
            DropDownListGrid.SelectedIndex = DropDownListGrid.Items.IndexOf(DropDownListGrid.Items.FindByText(Session["LabelHova"].ToString()));
            DropDownListGrid = (e.Row.FindControl("DropDownListForwarder") as DropDownList);
            DropDownListGrid.ClearSelection();
            DropDownListGrid.SelectedIndex = DropDownListGrid.Items.IndexOf(DropDownListGrid.Items.FindByText(Session["LabelForwarder"].ToString()));
        }
        else
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LabelOrderID = e.Row.FindControl("LabelOrderID") as Label;
                if (int.Parse(LabelOrderID.Text.ToString().Substring(11, LabelOrderID.Text.Length - 11)) > 2595)
                {
                    Label LabelPlandArrive = e.Row.FindControl("LabelPlannedarrival") as Label;
                    //string strValue = ((HiddenField)e.Row.FindControl("HiddenField1")).Value;
                    //e.Row.BackColor = Color.FromName(strValue);
                    Label LabelActualarrival = e.Row.FindControl("LabelActualarrival") as Label;
                    string strValue = ((HiddenField)e.Row.FindControl("HiddenField1")).Value;
                    e.Row.BackColor = Color.FromName(strValue);
                    strValue = ((HiddenField)e.Row.FindControl("HiddenField2")).Value;
                    if (strValue == "True")
                    {
                        //Citrine
                        e.Row.BackColor = Color.FromArgb(228, 208, 10);
                        return;
                    }
                    if (!string.IsNullOrEmpty(LabelActualarrival.Text.ToString()))
                    {
                        if (string.IsNullOrEmpty(LabelPlandArrive.Text))
                        {
                            //close to Blue Gray 
                            e.Row.BackColor = Color.FromArgb(102, 153, 255);
                            return;
                        }
                        else
                        {
                            TimeSpan elteres = Convert.ToDateTime(LabelActualarrival.Text.ToString()) - Convert.ToDateTime(LabelPlandArrive.Text.ToString());
                            double PercElteres = elteres.TotalMinutes;
                            if (PercElteres >= -15 && PercElteres <= 15)
                            {
                                //close to Lime green
                                e.Row.BackColor = Color.FromArgb(51, 204, 51);
                            }
                            else
                            {
                                e.Row.BackColor = Color.FromName("Red");
                                return;
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(LabelPlandArrive.Text))
                    {
                        DateTime PlandArrivDate = Convert.ToDateTime(LabelPlandArrive.Text.ToString()).AddHours(+48);
                        DateTime d2 = DateTime.Now;
                        if (PlandArrivDate < d2)
                        {
                            e.Row.BackColor = Color.FromName("Red");
                            return;
                        }
                        else
                        {
                            e.Row.BackColor = Color.FromName("white");
                            return;
                        }
                    }
                    else
                    {
                        e.Row.BackColor = Color.FromName("white");
                        return;
                    }
                }
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        frissit(DropDownListEV.SelectedItem.Text.ToString());
        //TextBoxFilterCikkszam.Text = "";
        SqlDataSource1.FilterExpression = "";
        Session["filter"] = "";
        GridViewSGHUORDER.DataBind();
        // DropDownListFilterCikkszam.SelectedIndex = 0;
    }
    protected void SQLFilterExpr(string mezo, string op, string ertek, SqlDataSource sqladatforras)
    {
        if (!String.IsNullOrEmpty(ertek) && ertek != "%%")
        {
            if (String.IsNullOrEmpty(sqladatforras.FilterExpression.ToString()))
            {
                sqladatforras.FilterExpression = mezo + " " + op + " '" + ertek + "'";
            }
            else
            {
                if (Session["filter"].ToString().Contains(mezo) && !String.IsNullOrEmpty(ertek))
                {
                    if (ertek.Contains('%'))
                    {
                        string ciksz = String.Format(@"\b{0}\b", Functions.getBetween(Session["filter"].ToString(), mezo + " " + op + " '%", "%'"));
                        Session["filter"] = Regex.Replace(Session["filter"].ToString(), ciksz, ertek, RegexOptions.IgnoreCase);
                    }
                    else
                    {
                        string ciksz = String.Format(@"\b{0}\b", Functions.getBetween(Session["filter"].ToString(), mezo + " " + op + " '", "'"));
                        Session["filter"] = Regex.Replace(Session["filter"].ToString(), ciksz, ertek, RegexOptions.IgnoreCase);
                    }
                    sqladatforras.FilterExpression = Session["filter"].ToString();
                }
                else
                {
                    sqladatforras.FilterExpression += " AND " + mezo + " " + op + " '" + ertek + "'";
                }
            }
            Session["filter"] = sqladatforras.FilterExpression.ToString();
        }
        else
        {
            Session["filter"] = "";
            sqladatforras.FilterExpression = "";
        }
        GridViewSGHUORDER.DataBind();
    }
    protected void TextBoxFilterTrackingNumber_TextChanged1(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterTrackingNumber") as TextBox);
        SQLFilterExpr("[TrackingNumber]", "LIKE", "%" + TextBoxGrid.Text.ToString() + "%", SqlDataSourceSGHUORDER);
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void TextBoxFilterOrderNumber_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterOrderNumber") as TextBox);
        SQLFilterExpr("[OrderID]", "=", TextBoxGrid.Text.ToString(), SqlDataSourceSGHUORDER);
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void DropDownListFilterFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList DropDownListGrid = (GridViewSGHUORDER.HeaderRow.FindControl("DropDownListFilterFrom") as DropDownList);
        SQLFilterExpr("[Honnan]", "=", DropDownListGrid.SelectedItem.ToString(), SqlDataSourceSGHUORDER);
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void DropDownListFilterTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList DropDownListGrid = (GridViewSGHUORDER.HeaderRow.FindControl("DropDownListFilterTo") as DropDownList);
        SQLFilterExpr("[Hova]", "=", DropDownListGrid.SelectedItem.ToString(), SqlDataSourceSGHUORDER);
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void TextBoxFilterForvarder_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterForvarder") as TextBox);
        SQLFilterExpr("[Forwarder]", "LIKE", "%" + TextBoxGrid.Text.ToString() + "%", SqlDataSourceSGHUORDER);
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void DropDownListFilterService_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList DropDownListGrid = (GridViewSGHUORDER.HeaderRow.FindControl("DropDownListFilterService") as DropDownList);
        SQLFilterExpr("[Service]", "=", DropDownListGrid.SelectedItem.ToString(), SqlDataSourceSGHUORDER);
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void ImageButtonUpd_Click(object sender, ImageClickEventArgs e)
    {
        Session["filter"] = "";
        Session["plannedarrival"] = "";
        Session["Actualarrival"] = "";
        Session["Actualpickup"] = "";
        Session["Plannedpickup"] = "";
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label2.Visible = true;
        string filePath = FileUpload1.PostedFile.FileName;
        string filename1 = Path.GetFileName(filePath);
        string ext = Path.GetExtension(filename1);
        string type = String.Empty;
        if (!FileUpload1.HasFile)
        {
            //      Label2.Text = "Please Select File";
        }
        else
            if (FileUpload1.HasFile)
        {
            try
            {
                // Added by vithal wadje for Csharp-Corner contribution
                switch (ext)
                {
                    case ".pdf":
                        type = "application/pdf";
                        break;
                }
                if (type != String.Empty)
                {
                    Stream fs = FileUpload1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string query;
                    using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
                    {
                        query = "insert into [dbo].[PDFiles] (Name,type,data)" + " values (@Name, @type, @Data)";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = User.Identity.Name.Trim();
                            command.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                            command.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                            con.Open();
                            command.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    // Label2.ForeColor = System.Drawing.Color.Green;
                    //Label2.Text = "PDF File Uploaded successfully";
                }
                else
                {
                    //    Label2.ForeColor = System.Drawing.Color.Red;
                    //      Label2.Text = "Select Only PDF Files";
                }
            }
            catch (Exception ex)
            {
                //Label2.Text = "Error: " + ex.Message.ToString();
            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query;
        SqlDataReader dr;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            query = "select Name,type,data from [dbo].[PDFiles] where id=@id";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("id", GridViewPDF.SelectedRow.Cells[1].Text);
                con.Open();
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = dr["type"].ToString();
                    Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString());
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite((byte[])dr["data"]);
                    Response.End();
                }
                con.Close();
            }
        }
    }
    protected void TextBoxTime_TextChanged(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        GridViewRow row = textBox.NamingContainer as GridViewRow;
        Label GridText = row.FindControl("TextBoxHiba") as Label;
        String AllowedChars = @"(\d{2}):(\d{2})";
        if (!(Regex.IsMatch(textBox.Text, AllowedChars)))
        {
            GridText.Text = "Hiba nem megfelelő dátum formátum!";
            GridText.Visible = true;
            row.BackColor = Color.FromName("Yellow");
        }
        else
        {
            GridText.Text = "";
            GridText.Visible = false;
            row.BackColor = Color.FromName("White");
        }
    }
    protected void TextBoxFilterMinuteDifference_TextChanged(object sender, EventArgs e)
    {
    }
    protected void TextBoxFilterPlannedarrival_TextChanged(object sender, EventArgs e)
    {
    }
    protected void TextBoxPlannedarrivalFrom_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewPercent.HeaderRow.FindControl("TextBoxPlannedarrivalFrom") as TextBox);
        SQLFilterExpr("[Plannedarrival]", ">", TextBoxGrid.Text.ToString(), SqlDataSourcePercent);
        frissitGridViewPercent();
    }
    protected void frissitGridViewPercent()
    {
        SqlDataSourceSGHUORDER.SelectCommand = "SELECT * FROM dbo.VSGHUORDER ORDER BY OrderID DESC;";
        GridViewSGHUORDER.DataSource = SqlDataSourceSGHUORDER;
        GridViewSGHUORDER.DataBind();
    }
    protected void ImageButtonUpdGridViewPercent_Click(object sender, ImageClickEventArgs e)
    {
        frissitGridViewPercent();
        SqlDataSourcePercent.FilterExpression = "";
        Session["filter"] = "";
        GridViewPercent.DataBind();
        foreach (GridViewRow row in GridViewPercent.Rows)
        {
            row.Visible = true;
        }
        // DropDownListFilterCikkszam.SelectedIndex = 0;
    }
    protected void TextBoxPlannedarrivalTo_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewPercent.HeaderRow.FindControl("TextBoxPlannedarrivalTo") as TextBox);
        SQLFilterExpr("[Plannedarrival]", "<", TextBoxGrid.Text.ToString(), SqlDataSourcePercent);
        frissitGridViewPercent();
        TextBoxGrid.Text = TextBoxGrid.Text.ToString();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void ImageButtonExcel_Click(object sender, ImageClickEventArgs e)
    {
        GridView gr = null;
        string name = "";
        if (GridViewSGHUORDER.Visible == true) { gr = GridViewSGHUORDER; name = "SGHUORDER"; }
        if (GridViewPercent.Visible == true) { gr = GridViewPercent; name = "Percent"; }
        if (GridViewPercent2.Visible == true) { gr = GridViewPercent2; name = "Percent2"; }     
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=" + name + ".xlsx");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gr.AllowPaging = false;    



        if (GridViewPercent.Visible == true)
        {
            gr.Columns[0].Visible = false;
            DropDownList GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListPlannedarrival");
            GridDrop.Visible = false;
            GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListActualarrival");
            GridDrop.Visible = false;
            GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListFilterLSP");
            GridDrop.Visible = false;
            TextBox GridTextbox = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterMinuteDifference");
            GridTextbox.Visible = false;
        }
        if (GridViewSGHUORDER.Visible == true)
        {
            frissit(DropDownListEV.SelectedItem.Text.ToString());
            gr.Columns[0].Visible = false;
            TextBox GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterTrackingNumber");
            GridText.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterTrailerNumber");
            GridText.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterOrderNumber");
            GridText.Visible = false;
            DropDownList GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListFilterFrom");
            GridDrop.Visible = false;
            GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListFilterTo");
            GridDrop.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterForvarder");
            GridText.Visible = false;
            GridDrop = (DropDownList)gr.HeaderRow.FindControl("DropDownListFilterService");
            GridDrop.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterPlannedpickup");
            GridText.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterActualpickup");
            GridText.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterPlannedarriva");
            GridText.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterActualarrival");
            GridText.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterComment");
            GridText.Visible = false;
            GridText = (TextBox)gr.HeaderRow.FindControl("TextBoxFilterReceptionr");
            GridText.Visible = false;
            CheckBox GridCheck = (CheckBox)gr.HeaderRow.FindControl("CheckBox1");
            GridCheck.Visible = false;

        }
        gr.RenderControl(hw);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void DropDownListPlannedarrival_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drop = (DropDownList)sender;
        if (GridViewPercent.Rows.Count != 0)
        {
            foreach (GridViewRow row in GridViewPercent.Rows)
            {
                if (int.Parse(drop.SelectedValue) == 0)
                {
                    row.Visible = true;
                }
                else
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        Label LabelGrid = (row.FindControl("LabelPlannedarrival") as Label);
                        DateTime enteredDate = DateTime.Parse(LabelGrid.Text.ToString());
                        int month = enteredDate.Month;
                        if (int.Parse(drop.SelectedValue) != month)
                        {
                            row.Visible = false;
                        }
                        else
                        {
                            row.Visible = true;
                        }
                    }
                }
            }
        }
    }
    protected void DropDownListActualarrival_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drop = (DropDownList)sender;
        if (GridViewPercent.Rows.Count != 0)
        {
            foreach (GridViewRow row in GridViewPercent.Rows)
            {
                if (int.Parse(drop.SelectedValue) == 0)
                {
                    row.Visible = true;
                }
                else
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        Label LabelGrid = (row.FindControl("LabelActualarrival") as Label);
                        DateTime enteredDate = DateTime.Parse(LabelGrid.Text.ToString());
                        int month = enteredDate.Month;
                        if (int.Parse(drop.SelectedValue) != month)
                        {
                            row.Visible = false;
                        }
                        else
                        {
                            row.Visible = true;
                        }
                    }
                }
            }
        }
    }
    protected void DropDownListFilterLSP_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drop = (DropDownList)sender;
        if (GridViewPercent.Rows.Count != 0)
        {
            foreach (GridViewRow row in GridViewPercent.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label LabelGrid = (row.FindControl("LabelLSPName") as Label);
                    if ((drop.SelectedValue) != LabelGrid.Text.ToString())
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
        }
    }
    protected void TextBoxTrackingNumber_TextChanged(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        GridViewRow row = textBox.NamingContainer as GridViewRow;
        Label GridText = row.FindControl("TextBoxHiba") as Label;
        String AllowedChars = @"(^[a-zA-Z0-9]+$)";
        if (!(Regex.IsMatch(textBox.Text, AllowedChars)))
        {
            GridText.Text = "A rendszám nem megfelelő. Csak szöveg vagy szám lehet";
            GridText.Visible = true;
            row.BackColor = Color.FromName("Yellow");
        }
        else
        {
            GridText.Text = "";
            textBox.Text.ToString().Trim().ToUpper();
            GridText.Visible = false;
            row.BackColor = Color.FromName("White");
        }
    }
    protected void DropDownListMonthName_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridViewPercent2.Rows)
        {
            row.Visible = true;
            Session["drop"] = "-1";
            Percent2(true);
        }
        DropDownList drop = (DropDownList)sender;
        switch (drop.SelectedValue)
        {
            case "-1":
                Session["drop"] = "-1";
                Percent2(true);
                break;
            case "0":
                Session["drop"] = "0";
                Percent2(false);
                break;
            default:
                foreach (GridViewRow row in GridViewPercent2.Rows)
                {
                    Label text = (Label)row.FindControl("LabelMonthName");
                    if (text.Text.ToString() != drop.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
                break;
        }
    }
    protected void Percent2(bool month)
    {
        Session["filter"] = "";
        GridViewPercent2.Visible = true;
        GridViewPercent.Visible = false;
        GridViewSGHUORDER.Visible = false;
        string query;
        int keses = 0;
        Double osszes = 0;
        Double szazalek = 0;
        string akt = "";
        string kovetkezo = "";
        string monthname = "All Month";
        string LSPname = "";
        GridViewPercent.Visible = false;
        GridViewSGHUORDER.Visible = false;
        DataTable table = new DataTable();
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("MonthName", typeof(string));
        table.Columns.Add("Percent", typeof(string));
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            query = "SELECT  dbo.Month.MonthName, dbo.vpercentmonth.Name, dbo.vpercentmonth.OrderID, dbo.vpercentmonth.PlannedarrivalMonth, dbo.vpercentmonth.[Perc Eltérnés], dbo.vpercentmonth.Plannedarrival, dbo.vpercentmonth.Actualarrival FROM dbo.vpercentmonth INNER JOIN dbo.Month ON dbo.vpercentmonth.PlannedarrivalMonth = dbo.Month.ID where OrderID>2595 ORDER BY dbo.vpercentmonth.Name, dbo.Month.MonthName;";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                using (DataTable dt = new DataTable())
                {
                    con.Open();
                    using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        dt.Load(dr);
                        if (month)
                        {
                            kovetkezo = dt.Rows[1]["Name"].ToString() + dt.Rows[1]["MonthName"].ToString();
                        }
                        else
                        {
                            kovetkezo = dt.Rows[1]["Name"].ToString();
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            LSPname = dt.Rows[i]["Name"].ToString();
                            if (month)
                            {
                                monthname = dt.Rows[i]["MonthName"].ToString();
                                akt = dt.Rows[i]["Name"].ToString() + dt.Rows[i]["MonthName"].ToString();
                            }
                            else
                            {
                                akt = dt.Rows[i]["Name"].ToString();
                            }
                            if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                            {
                                DateTime d2 = DateTime.Now;
                                DateTime myDate = Convert.ToDateTime(dt.Rows[i][5].ToString()).AddHours(+48);
                                if (myDate < d2)
                                {
                                    keses++;
                                }
                            }
                            else
                            {
                                Int64 PercElteres = Int64.Parse(dt.Rows[i][4].ToString());
                                if (Int64.Parse(dt.Rows[i][4].ToString()) <= -15 || Int64.Parse(dt.Rows[i][4].ToString()) >= 15)
                                {
                                    keses++;
                                }

                            }
                            osszes++;
                            if (kovetkezo != akt)
                            {
                                szazalek = 100 - ((keses / osszes) * 100);
                                if (month)
                                {
                                    monthname = dt.Rows[i]["MonthName"].ToString();
                                    table.Rows.Add(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["MonthName"].ToString(), szazalek.ToString() + "%");
                                }
                                else
                                {
                                    table.Rows.Add(dt.Rows[i]["Name"].ToString(), monthname, szazalek.ToString() + "%");
                                }
                                osszes = 0;
                                keses = 0;
                            }
                            if ((i + 3) <= dt.Rows.Count)
                            {
                                if (month)
                                {
                                    monthname = dt.Rows[i + 2]["MonthName"].ToString();
                                    kovetkezo = dt.Rows[i + 2]["Name"].ToString() + dt.Rows[i + 2]["MonthName"].ToString();
                                }
                                else
                                {
                                    kovetkezo = dt.Rows[i + 2]["Name"].ToString();
                                }
                            }

                        }
                    }
                    szazalek = 100 - ((keses / osszes) * 100);
                    table.Rows.Add(LSPname, monthname, szazalek.ToString() + "%");
                    con.Close();
                    GridViewPercent2.DataSource = table;
                    GridViewPercent2.DataBind();
                }
            }
        }
    }
    protected void GridViewPercent2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            DropDownList drop = (DropDownList)e.Row.FindControl("DropDownListMonthName");
            drop.SelectedValue = Session["drop"].ToString();
            drop.DataBind();
        }
    }
    protected void GridViewPercent2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            DropDownList drop = (DropDownList)e.Row.FindControl("DropDownListMonthName");
            drop.SelectedValue = Session["drop"].ToString();
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drop = (DropDownList)sender;
        foreach (GridViewRow row in GridViewPercent2.Rows)
        {
            Label text = (Label)row.FindControl("LabelLSPName");
            if (text.Text.ToString() != drop.SelectedItem.ToString())
            {
                row.Visible = false;
            }
        }
    }
    protected void ImageButtonUpdGridViewPercent_Click1(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in GridViewPercent2.Rows)
        {
            row.Visible = true;
            Session["drop"] = "-1";
            Percent2(true);
        }
    }
    protected void DropDownListTables_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drop = (DropDownList)sender;
        switch (drop.SelectedValue)
        {
            case "1":

                GridViewPercent2.Visible = true;
                GridViewPercent.Visible = false;
                GridViewSGHUORDER.Visible = false;
                Percent2(true);
                excel.Visible = true;
                refresh.Visible = true;
                LabelTableName.Text = drop.SelectedItem.Text.ToString();
                Tr1.Visible = true;
                break;
            case "2":

                GridViewPercent2.Visible = false;
                GridViewPercent.Visible = true;
                GridViewSGHUORDER.Visible = false;
                excel.Visible = true;
                refresh.Visible = true;
                LabelTableName.Text = drop.SelectedItem.Text.ToString();
                Tr1.Visible = true;
                break;
            case "3":

                GridViewPercent2.Visible = false;
                GridViewPercent.Visible = false;
                GridViewSGHUORDER.Visible = true;
                //SQLFilterExpr("[EV]", ">", DropDownList4.SelectedValue.ToString().Trim(), SqlDataSourceSGHUORDER);
                excel.Visible = true;
                refresh.Visible = true;
                LabelTableName.Text = drop.SelectedItem.Text.ToString();
                Tr1.Visible = true;
                frissit(DropDownListEV.SelectedItem.Text.ToString());
                break;
        
            default:
                GridViewPercent2.Visible = false;
                GridViewPercent.Visible = false;
                GridViewSGHUORDER.Visible = false;
                excel.Visible = false;
                refresh.Visible = false;
                LabelTableName.Text = drop.SelectedItem.Text.ToString();
                Tr1.Visible = false;
                break;
        }
    }


    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataReader dataReader;
        if (DropDownList5.SelectedValue.Trim().ToString() == "-2")
        {
            TextBoxTransporter.Visible = true;
            DropDownList1.Visible = false;
            txtEmail.Text = "";
            ImageButtonFor.Visible = true;
        }
        else
        {
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
            {
                string query = "SELECT [Email] ,[CC] FROM [LSP] where id = @id ";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(DropDownList1.Text.ToString().Trim());
                    con.Open();
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtEmail.Text = dataReader[0].ToString();
                        TextCC.Text = dataReader[1].ToString();
                    }
                    else
                    {
                        txtEmail.Text = "";
                        txtEmail.Text = "";
                    }
                    con.Close();
                }
            }
            TextBoxTransporter.Visible = false;
            DropDownList1.Visible = true;
        }
        // TextBoxInfo.Visible = true;
        Button3.Visible = true;
    }
    protected void DropDownList5_TextChanged(object sender, EventArgs e)
    {
    }
    protected void DropDownListFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void DropDownListTo_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void DropDownListTo_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void TextBoxTrackingNumber_TextChanged1(object sender, EventArgs e)
    {
    }
    protected void TextBoxTrailerNumber_TextChanged(object sender, EventArgs e)
    {
    }
    protected void GridViewSGHUORDER_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ImageButtonFor_Click(object sender, ImageClickEventArgs e)
    {
        TextBoxTransporter.Visible = false;
        DropDownList1.Visible = true;
        ImageButtonFor.Visible = false;
        DropDownList1.DataBind();
    }
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        adatfeltoltes();
    }
    protected void GridViewPercent2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void TextBoxFilterReceptionr_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterReceptionr") as TextBox);
        SQLFilterExpr("[Reception]", "LIKE", "%" + TextBoxGrid.Text.ToString() + "%", SqlDataSourceSGHUORDER);
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }



    protected void TextBoxFilterComment_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBoxActualarrival_TextChanged(object sender, EventArgs e)
    {

    }


    protected void TextBoxFilterPlannedarriva_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterPlannedarriva") as TextBox);
        Session["plannedarrival"] = TextBoxGrid.Text.ToString().Replace(".", "-");
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }

    protected void TextBoxActualpickup_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBoxFilterPlannedpickup_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterPlannedpickup") as TextBox);
        Session["Plannedpickup"] = TextBoxGrid.Text.ToString().Replace(".", "-");
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }

    protected void TextBoxFilterActualpickup_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterActualpickup") as TextBox);
        Session["Actualpickup"] = TextBoxGrid.Text.ToString().Replace(".", "-");
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }

    protected void TextBoxFilterActualarrival_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewSGHUORDER.HeaderRow.FindControl("TextBoxFilterActualarrival") as TextBox);
        Session["Actualarrival"] = TextBoxGrid.Text.ToString().Replace(".", "-");
        frissit(DropDownListEV.SelectedItem.Text.ToString());
    }

















    protected void ImageButtonUpd_Click1(object sender, ImageClickEventArgs e)
    {

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using QRCoder;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web.Hosting;

public partial class ordernew : BasePage
{

    public bool isCalled = false;
    protected string initialHtml = @"<html><head></head><body>tesztszöveg</body></html>";
    public string folderPath = HostingEnvironment.MapPath("~//Files//" + HttpContext.Current.User.Identity.Name.ToString().Trim().ToLower() + @"//");
    private static Random random = new Random();

    protected void DownloadFile(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }
    protected void DeleteFile(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        File.Delete(filePath);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    public string GetVirtualPath(string physicalPath)
    {
        if (!physicalPath.StartsWith(HttpContext.Current.Request.PhysicalApplicationPath))
        {
            throw new InvalidOperationException("Physical path is not within the application root");
        }

        return "~/" + physicalPath.Substring(HttpContext.Current.Request.PhysicalApplicationPath.Length)
              .Replace("\\", "/");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            if (AjaxFileUpload1.IsInFileUploadPostBack)
            {
            }
            else
            {
                if (!IsPostBack)
                {
                    SqlDataSource2.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                    SqlDataSource1.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                    SqlDataSourceOrszag.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                    SqlDataSource1.ConnectionString = Functions.ConnectionString(User.Identity.Name);
       
                    string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                    String parentDirectory = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
           
                    Session["login"] = User.Identity.Name.ToString();
                    string sql = "SELECT dbo.Users.Username, dbo.TPageNames.PageName FROM dbo.Users INNER JOIN dbo.SwitchPageNames ON dbo.Users.UserId = dbo.SwitchPageNames.UserId INNER JOIN dbo.TPageNames ON dbo.SwitchPageNames.PageNameID = dbo.TPageNames.PageNameID WHERE (dbo.Users.Username = '" + Session["login"].ToString() + "') AND (dbo.TPageNames.PageName = '" + pageName + "')";
                    if (true)
                    // if (Functions.ExecScalar(sql, Session["login"].ToString()) != "0")
                    {
                        if (Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                            try
                            {
                                System.IO.Directory.Delete(folderPath, true);
                                System.IO.Directory.CreateDirectory(folderPath);
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
                        Session["feltoltve"] = "False";
                        Session["login"] = User.Identity.Name.ToString();
                        Session["random"] = RandomString(15);
                        //    TextBoxInfo.Text = initialHtml;
                        SqlDataReader dataReader;
                        String query = "SELECT Signature FROM Users where Username = @Username; ";
                        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(Session["login"].ToString())))
                        {
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                command.Parameters.Add("@Username", SqlDbType.VarChar).Value = User.Identity.Name.ToString();
                                con.Open();
                                dataReader = command.ExecuteReader();
                                if (dataReader.Read())
                                {
                                    TextBoxAlairas.Value = dataReader[0].ToString();
                                }
                                con.Close();
                            }
                        }
                        //String ecname = System.Environment.MachineName;
                        //string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                        //LabelMachineName.Text = computer_name[0].ToString();
                        if (TextBoxDate.Text == "")
                        {
                            TextBoxDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                        }
                ((Label)Master.FindControl("Label1")).Text = "SGHU Internal Transport Order Form";
                    }
                    else
                    {
                        Response.Redirect("~/" + Functions.ExecScalar("SELECT dbo.TPageNames.PageName FROM dbo.Users INNER JOIN dbo.TPageNames ON dbo.Users.HomePage = dbo.TPageNames.PageNameID WHERE (dbo.Users.Username = '" + Session["login"].ToString() + "')", Session["login"].ToString()));
                    }
                }
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

    }
    protected override void OnInitComplete(EventArgs e)
    {
        base.OnInitComplete(e);
        if (!IsPostBack)
        {
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlDataReader dataReader;
        string bevitelomezo = TextBoxInfo.InnerText.ToString();
        String query = "";
        string orderid = "";
        int orderidOriginal = 0;
        int Profintcenter = 0;
        int LSPID = 0;
        string ProfintcenterName = "";
        if (DropDownListProfitCenter.SelectedValue == "-2")
        {
            Profintcenter = 0;
            ProfintcenterName = "";
        }
        else
        {
            Profintcenter = int.Parse(DropDownListProfitCenter.Text.ToString().Trim());
            ProfintcenterName = DropDownListProfitCenter.SelectedItem.ToString().Trim();
        }


        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(Session["login"].ToString())))
        {
            query = "UPDATE  Users SET Signature=@Signature WHERE Username = @Username;";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@Username", SqlDbType.VarChar).Value = User.Identity.Name.ToString();
                command.Parameters.Add("@Signature", SqlDbType.VarChar).Value = TextBoxAlairas.Value;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            //LSP
            if (TextBoxTransporter.Visible == true)
            {
                query = "INSERT INTO LSP (Name,Email) VALUES (@transporter_name,@transporter_email);";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@transporter_name", SqlDbType.VarChar).Value = TextBoxTransporter.Text.ToString().Trim();
                    command.Parameters.Add("@transporter_email", SqlDbType.VarChar).Value = txtEmail.Text.ToString().Trim();
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                query = "UPDATE  LSP SET Email=@transporter_email,CC=@CC  WHERE Name = @transporter_name;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@transporter_email", SqlDbType.VarChar).Value = txtEmail.Text.ToString().Trim();
                    command.Parameters.Add("@CC", SqlDbType.VarChar).Value = TextCC.Text.ToString().Trim();
                    command.Parameters.Add("@transporter_name", SqlDbType.VarChar).Value = DropDownList1.SelectedItem.ToString();
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                LSPID = int.Parse(DropDownList1.SelectedValue.ToString());
            }
            //Profitcenter
            if (profitcentertabla.Visible == true)
            {
                query = "INSERT INTO ProfitCenter (ProfitCenter,Megnevezés) VALUES (@ProfitCenter,@Megnevezés);";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@ProfitCenter", SqlDbType.VarChar).Value = TextBoxProfitCenter.Text.ToString().Trim();
                    command.Parameters.Add("@Megnevezés", SqlDbType.VarChar).Value = TextBoxMegnevezes.Text.ToString().Trim();
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            query = "INSERT INTO SGHUOrder(ProfitCenter,Info,StartDate,Person,Computer,Igenylo,SzamlazottAr,Honnan,Hova,Forwarder) VALUES (@ProfitCenter,@Info,@StartDate,@Person,@Computer,@Igenylo,@SzamlazottAr,@Honnan,@Hova,@Forwarder)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@ProfitCenter", SqlDbType.Int).Value = Profintcenter;
                command.Parameters.Add("@Info", SqlDbType.NChar).Value = bevitelomezo.ToString();
                command.Parameters.Add("@StartDate", SqlDbType.Date).Value = TextBoxDate.Text.ToString().Trim();
                command.Parameters.Add("@Person", SqlDbType.NChar).Value = User.Identity.Name.ToString().Trim().ToLower();
                command.Parameters.Add("@Computer", SqlDbType.NChar).Value = LabelMachineName.Text.ToString().Trim();
                command.Parameters.Add("@Igenylo", SqlDbType.NChar).Value = TextBoxPerson.Text.ToString().Trim();
                command.Parameters.Add("@SzamlazottAr", SqlDbType.NChar).Value = 0;
                command.Parameters.Add("@Honnan", SqlDbType.Int).Value = DropDownListFrom.Text.ToString().Trim();
                command.Parameters.Add("@Hova", SqlDbType.Int).Value = DropDownListTo.Text.ToString().Trim();
                command.Parameters.Add("@Forwarder", SqlDbType.Int).Value = LSPID;

                if (string.IsNullOrEmpty(TextBoxPlannedPickUp.Text.ToString().Trim()))
                {
                    command.Parameters.Add("@Plannedpickup", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@Plannedpickup", SqlDbType.Date).Value = TextBoxPlannedPickUp.Text.ToString().Trim();

                }

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            query = "SELECT OrderID FROM SGHUOrder where Person=@Person ORDER BY OrderID DESC";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@Person", SqlDbType.NChar).Value = User.Identity.Name;
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    orderidOriginal = int.Parse(dataReader[0].ToString().Trim());
                    switch (dataReader[0].ToString().Length)
                    {
                        case 1:
                            orderid = "000" + dataReader[0].ToString();
                            break;
                        case 2:
                            orderid = "00" + dataReader[0].ToString();
                            break;
                        case 3:
                            orderid = "0" + dataReader[0].ToString();
                            break;
                        case 4:
                            orderid = dataReader[0].ToString();
                            break;
                    }
                }

                con.Close();
            }

            string QRCodeID = "SGHU" + orderid + RandomString(9 - orderid.Length);
            query = "Update SGHUOrder SET QRCodeID=@QRCodeID where OrderID=@OrderID;";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@QRCodeID", SqlDbType.VarChar).Value = QRCodeID;
                command.Parameters.Add("@OrderID", SqlDbType.Int).Value = int.Parse(orderid);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            query = "SELECT Signature FROM Users where Username=@Person";
            create_Qrcode("SGHU ORDER-" + orderid, QRCodeID.ToString().Trim());
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@Person", SqlDbType.NChar).Value = User.Identity.Name;
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {

                    bevitelomezo = FetchLinksFromSource(bevitelomezo.ToString());
                    bevitelomezo = bevitelomezo + @"<img src = 'cid:QRCODE.jpg' height = 480 width = 360 >";
                    bevitelomezo = bevitelomezo.Replace(@"\", @"/");
                    string mailBody = HttpUtility.HtmlDecode(bevitelomezo);
                    mailBody = "<html><head></head><body><p>Dear Sir or Madam,</p><p></p><p><strong>Order Number:</strong> SGHU ORDER-" + orderid + "</p><p><strong>Date and Time:</strong>" + TextBoxDate.Text + "</p><p><strong>Profit Center:</strong>" + ProfintcenterName + "</p><p><strong>Requester:</strong> " + TextBoxPerson.Text.ToString().Trim() + "  </p><p><strong>Information: </strong></p><p>&nbsp;</p><p>" + bevitelomezo.ToString() + "</p><p></p><p>&nbsp;</p><p><strong>The invoice has to contain the relevant SGHU order number.</strong></p>" + TextBoxAlairas.Value.ToString();
                    mailBody = mailBody.Replace("'", @"""");
                    mailBody = mailBody.Replace("\r", "");
                    mailBody = mailBody.Replace("\n", "");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Adatmentés megtörtént!" + "');", true);
                    string parameters = "";
                    parameters = "['" + txtEmail.Text.ToString().Trim() + "', ";
                    parameters = parameters + "'" + mailBody + "', ";
                    parameters = parameters + "'" + "Transport - [SGHU ORDER - " + orderid + "]" + "', ";
                    parameters = parameters + "'" + TextCC.Text.ToString().Trim() + "', ";
                    foreach (string file in Directory.GetFiles(folderPath))
                    {
                        parameters = parameters + @"'http://mc0vm011.sg.lan/www/SGHU_LOG-T/Files/" + User.Identity.Name.ToString().Trim() + "/" + Path.GetFileName(file) + "', ";
                        parameters = parameters.Replace(@"\", @"/");
                        PDFUpload(file, int.Parse(orderid));
                    }
                    parameters = parameters.Remove(parameters.Length - 2);
                    parameters = parameters + "]";
                    parameters = HttpUtility.HtmlDecode(parameters);
                    string script = "window.onload = function(){call_me(" + parameters + ")};";
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "call_me", script, true);
                }
                con.Close();
            }
        }
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
                File.WriteAllBytes(@"\\Mc0vm011.sg.lan\sghu_log-t$\" + User.Identity.Name.ToString().Trim().ToLower() + @"\yourfile" + i.ToString() + "." + kiterjesztes, binData);
            }

            htmlSource = htmlSource.Replace(href, "cid:" + @"yourfile" + i.ToString() + "." + kiterjesztes);
            htmlSource = htmlSource.Replace("<img src=\"", "<img src = '");
            htmlSource = htmlSource.Replace("\"", "'");



            // bevitelomezo = bevitelomezo + @" < img src = 'cid:QRCODE.jpg' height = 480 width = 360 >";
            i++;
        }
        return htmlSource;
    }
    protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        string filePathoriginal = folderPath + e.FileName;
        AjaxFileUpload1.SaveAs(filePathoriginal);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataReader dataReader;
        if (DropDownList1.SelectedValue.Trim().ToString() == "-2")
        {
            TextBoxTransporter.Visible = true;
            DropDownList1.Visible = false;
            txtEmail.Text = "";
            ImageButtonFor.Visible = true;
        }
        else
        {
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(Session["login"].ToString())))
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
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        //TextBoxInfo.Visible = true;
    }
    protected void DropDownListProfitCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListProfitCenter.SelectedValue == "-1")
        {
            profitcentertabla.Visible = true;
            DropDownListProfitCenter.Visible = false;
            ImageButtonProfitCenter.Visible = true;
        }
        else
        {
            profitcentertabla.Visible = false;
            DropDownListProfitCenter.Visible = true;
        }
    }
    protected void DropDownListProfitCenter_TextChanged(object sender, EventArgs e)
    {
    }
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
    }
    protected void ButtonAlairas_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "text", " Validate();", true);
    }



    protected void DropDownListFrom_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownListTo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public string create_Qrcode(string nr, String QRCodeText)
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
        string filepath = folderPath + "QRCODE" + ".jpg"; ;
        System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
        map.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
        fs.Close();
        //show image
        return filepath;
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
                File.WriteAllBytes(Server.MapPath("QRCodes/" + code + ".png"), byteImage);
                //     imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
        }
        return "QRCodes/" + code + ".png";
    }
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
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
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(Session["login"].ToString())))
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

    //protected void ButtonUploadAttachment_Click(object sender, EventArgs e)
    //{

    //    Label2.Visible = true;
    //    string filePath = FileUpload1.PostedFile.FileName;
    //    string filename1 = Path.GetFileName(filePath);
    //    string ext = Path.GetExtension(filename1);
    //    string type = String.Empty;
    //    if (!FileUpload1.HasFile)
    //    {
    //        Label2.Text = "Please Select File";
    //    }
    //    else
    //        if (FileUpload1.HasFile)
    //    {

    //        try
    //        {
    //            // Added by vithal wadje for Csharp-Corner contribution

    //            switch (ext)
    //            {
    //                case ".pdf":

    //                    type = "application/pdf";

    //                    break;
    //            }
    //            if (type != String.Empty)
    //            {
    //                Stream fs = FileUpload1.PostedFile.InputStream;
    //                BinaryReader br = new BinaryReader(fs);
    //                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
    //                string query;
    //                using (SqlConnection con = new SqlConnection(Functions.ConnectionString(Session["login"].ToString())))
    //                {
    //                    query = "insert into [dbo].[PDFilesTemporary] (ID,Name,type,data)" + " values (@ID, @Name, @type, @Data)";
    //                    using (SqlCommand command = new SqlCommand(query, con))
    //                    {
    //                        command.Parameters.Add("@ID", SqlDbType.VarChar).Value = Session["login"].ToString().Trim();
    //                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename1;
    //                        command.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
    //                        command.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
    //                        con.Open();
    //                        command.ExecuteNonQuery();
    //                        con.Close();
    //                    }
    //                }



    //                Label2.ForeColor = System.Drawing.Color.Green;
    //                Label2.Text = "PDF File Uploaded successfully";
    //                frissitPDF();

    //            }
    //            else
    //            {
    //                Label2.ForeColor = System.Drawing.Color.Red;
    //                Label2.Text = "Select Only PDF Files";
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Label2.Text = "Error: " + ex.Message.ToString();

    //        }


    //    }

    //}




    protected void ImageButtonFor_Click(object sender, ImageClickEventArgs e)
    {
        TextBoxTransporter.Visible = false;
        DropDownList1.Visible = true;
        ImageButtonFor.Visible = false;
        DropDownList1.DataBind();
    }



    protected void ImageButtonProfitCenter_Click(object sender, ImageClickEventArgs e)
    {
        profitcentertabla.Visible = false;
        DropDownListProfitCenter.Visible = true;
        ImageButtonProfitCenter.Visible = false;
        DropDownListProfitCenter.DataBind();
    }
}
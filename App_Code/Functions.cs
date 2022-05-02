using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
/// <summary>
/// Summary description for Functions
/// </summary>
public class Functions
{
    public Functions()
    {
        //
        // TODO: Add constructor logic here
        //
       
    }
    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        else
        {
            return "";
        }
    }

    public static void EMailKuld(string subject, string body, string to)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString("Admin")))
            {
                con.Open();
                string cmdString = "SELECT * from [MailSetting];";
                SqlDataReader dr = Functions.ExecQuery(con, cmdString);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new System.Net.Mail.MailAddress(dr["MailAddress"].ToString());
                        mailMessage.To.Add(new MailAddress(to));
                        mailMessage.Subject = subject;
                        mailMessage.BodyEncoding = Encoding.UTF8;
                        mailMessage.Body = "<b><span style='font-size:60.0pt;font-family:\"Titillium Web\";color:#009164'>Online Gépjármű Regisztrációs Rendszer</span></b><b><span style='font-size:60.0pt;font-family:Wingdings;mso-bidi-font-family:Titillium Web;color:#009164'>*</span></b><br/><div style='border:none;border-bottom:dotted #729ABD 1.5pt;padding:0cm 0cm 0cm 0cm;margin-left:11.25pt;margin-top:11.25pt;margin-right:11.25pt;margin-bottom:11.25pt'><p class=MsoNormal style='mso-line-height-alt:.75pt'><span style='font-size:1.0pt;color:white'>&nbsp;</span></p></div><br/>";
                        mailMessage.Body += body;
                        mailMessage.Body += "<br/><br/>Üdvözlettel / Best <div style='border:none;border-top:solid #295D89 1.0pt;mso-border-top-alt:solid #295D89 .75pt;padding:0cm 0cm 0cm 0cm'><span style='font-size:7.0pt'>Kérjük, ne válaszoljon erre az automatikusan generált levélre! / Please do not reply to this automatically generated e-mail.</span>";
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Port = int.Parse(dr["Port"].ToString());
                        smtp.EnableSsl = true;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(dr["MailAddress"].ToString(), dr["Password"].ToString());
                        smtp.Host = dr["Host"].ToString();
                        smtp.Send(mailMessage);

                        break;



                    }
                }
                con.Close();
            }

        }
        catch (Exception ex)
        {
            string a = ex.Message;

        }
    }


    public static void EMailKuld(string subject, string body, string to, List<string> cc)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("system.OGRR@seg-automotive.com", "KAMIONKEZELŐ");
            mailMessage.To.Add(to);
            foreach (string elem in cc)
            {
                mailMessage.CC.Add(elem);
            }

            mailMessage.Subject = subject;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Body = "<b><span style='font-size:60.0pt;font-family:\"Tahoma\",\"sans-serif\";color:#A8BAD2'>SHOPPING LIST SYSTEM </span></b><b><span style='font-size:60.0pt;font-family:Wingdings;mso-bidi-font-family:Tahoma;color:#6E8CB3'>*</span></b><br/><div style='border:none;border-bottom:dotted #729ABD 1.5pt;padding:0cm 0cm 0cm 0cm;margin-left:11.25pt;margin-top:11.25pt;margin-right:11.25pt;margin-bottom:11.25pt'><p class=MsoNormal style='mso-line-height-alt:.75pt'><span style='font-size:1.0pt;color:white'>&nbsp;</span></p></div><br/>";
            mailMessage.Body += body;
            mailMessage.Body += "<br/><br/>Üdvözlettel / Best regards<div style='border:none;border-top:solid #295D89 1.0pt;mso-border-top-alt:solid #295D89 .75pt;padding:0cm 0cm 0cm 0cm'><span style='font-size:7.0pt'>Kérjük, ne válaszoljon erre az automatikusan generált levélre! / Please do not answer to this automatically generated e-mail! </span>";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("rb-smtp-int.bosch.com");
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            string a = ex.Message;
        }
    }
    public static string Find_Cookie(HttpRequest inpRequest, string inpAzon)
    {
        string result = "";
        try
        {
            bool talalt = false;
            int i = 0;
            while (!talalt)
            {

                if (inpRequest.Cookies[i].Value != null)
                {
                    if (inpRequest.Cookies[i].Value.Length > 4)
                    {
                        if (inpRequest.Cookies[i].Value.Substring(0, 5) == inpAzon)
                        {
                            result = inpRequest.Cookies[i].Value.Substring(5, inpRequest.Cookies[i].Value.ToString().Length - 5);
                            talalt = true;
                        }
                    }
                }
                i++;
                if (i >= inpRequest.Cookies.Count)
                {
                    talalt = true;
                }
            }
        }
        catch (Exception ex)
        {
            //string uzi = "";
            //Functions.LogException(ex, "Functions.Find_Cookie", uzi);
        }
        return result;
    }
    public static void Exec(string inpSQL, string fg_nev, string inpUser, HttpServerUtility inpServer, string inpGyartosor)
    {
        string CS2 = ConnectionString(inpUser);

        using (SqlConnection con = new SqlConnection(CS2))
        {
            try
            {
                //SqlConnection con = new SqlConnection(CS2);
                con.Open();
                SqlCommand command2 = new SqlCommand(inpSQL, con);
                command2.ExecuteNonQuery();
                //}
                //catch (SqlException ex)
                //{
                //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
                //    LogException(ex, "Functions.Exec", uzi);
                //}
                //catch (Exception ex)
                //{
                //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
                //    LogException(ex, "Functions.Exec", uzi);
            }
            finally
            {
                con.Close();
            }
        }
    }
    public static void Exec(string inpSQL, string fg_nev, string inpUser, string inpGyartosor)
    {
        string CS2 = ConnectionString(inpUser);

        using (SqlConnection con = new SqlConnection(CS2))
        {
            try
            {
                //SqlConnection con = new SqlConnection(CS2);
                con.Open();
                SqlCommand command2 = new SqlCommand(inpSQL, con);
                command2.ExecuteNonQuery();
            }
            //catch (SqlException ex)
            //{
            //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
            //    LogException(ex, "Functions.Exec", uzi);
            //}
            //catch (Exception ex)
            //{
            //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
            //    LogException(ex, "Functions.Exec", uzi);
            //}
            finally
            {
                con.Close();
            }
        }
    }
    public static void MessageBox(Page Base_Page, string PMSG)
    {
        try
        {
            String cstext1 = "<script type=\"text/javascript\">" + "alert('" + PMSG + "');</" + "script>";
            Base_Page.RegisterStartupScript("MSG", cstext1);
        }
        catch (Exception ex)
        {
            //string uzi = "";
            //Functions.LogException(ex, "Functions.MessageBox", uzi);
        }
    }

    public static string ConnectionString(string inpUser)
    {
        string ki = "";
        try
        {
            inpUser = inpUser.ToLower();
            if (inpUser == "tesztuser" || inpUser == "tesztfelhasznalo" || inpUser == "tesztfelhasznalo22")
            {
                ki = ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString;
            }
            else
            {
                ki = ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString;

            }
        }
        catch (Exception ex)
        {
            string uzi = "\n\rFelhasznalo: " + inpUser;
            Functions.LogException(ex, "Functions.ConnectionString", uzi);
        }
        return ki;
    }
    /// <summary>
    /// Lefuttat egy lekérdező SQL utasítsát.
    /// </summary>
    /// <param name="inpSQL">Adja meg a futtatni kívánt sql utasítást.</param>
    /// <param name="fg_nev">Adja meg azt a metódust amlyikben éppen használja. Hibák logolásához szükséges.</param>
    /// <param name="inpUser">Adja meg a bejelentkezett felhasználó nevét.</param>
    /// <param name="inpServer">Server</param>
    /// <param name="inpTable">Adja meg azt a tábla nevet amelyiken a lekérdezést futtatni szeretné. Hibák logolásához szükséges.</param>
    /// <returns>Egy SqlDataReader objektum lesz az eredmény.</returns>
    public static SqlDataReader ExecQuery(SqlConnection con, string inpSQL, string fg_nev, string inpUser, HttpServerUtility inpServer, string inpTable, string inpGyartosor)
    {
        SqlDataReader dr;
        //try
        //{
        using (SqlCommand cmd2 = new SqlCommand(inpSQL, con))
        {
            dr = cmd2.ExecuteReader();
        }
        //}
        //catch (SqlException ex)
        //{
        //    SqlCommand cmd2 = new SqlCommand("SELECT * FROM " + inpTable, con);
        //    dr = cmd2.ExecuteReader();
        //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
        //    LogException(ex, "Functions.Exec", uzi);
        //}
        //catch (Exception ex)
        //{
        //    SqlCommand cmd2 = new SqlCommand("Select * from " + inpTable, con);
        //    dr = cmd2.ExecuteReader();
        //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
        //    LogException(ex, "Functions.ExecQuery", uzi);
        //}
        return dr;
    }

    public static SqlDataReader ExecQuery(SqlConnection con, string inpSQL)
    {
        SqlDataReader dr;
        //try
        //{
        using (SqlCommand cmd2 = new SqlCommand(inpSQL, con))
        {
            dr = cmd2.ExecuteReader();
        }
        //}
        //catch (SqlException ex)
        //{
        //    SqlCommand cmd2 = new SqlCommand("SELECT * FROM " + inpTable, con);
        //    dr = cmd2.ExecuteReader();
        //    string uzi = "SQL: " + inpSQL;
        //    LogException(ex, "Functions.Exec", uzi);
        //}
        //catch (Exception ex)
        //{
        //    SqlCommand cmd2 = new SqlCommand("Select * from " + inpTable, con);
        //    dr = cmd2.ExecuteReader();
        //    string uzi = "SQL: " + inpSQL;
        //    LogException(ex, "Functions.ExecQuery", uzi);
        //}
        return dr;
    }

    /// <summary>
    /// Lefuttat egy lekérdező SQL utasítsát.
    /// </summary>
    /// <param name="inpSQL">Adja meg a futtatni kívánt sql utasítást.</param>
    /// <param name="fg_nev">Adja meg azt a metódust amlyikben éppen használja. Hibák logolásához szükséges.</param>
    /// <param name="inpUser">Adja meg a bejelentkezett felhasználó nevét.</param>
    /// <param name="inpServer">Server</param>
    /// <returns>Egy szöveg típusú eredményt ad vissza.</returns>
    public static string ExecScalar(string inpSQL, string fg_nev, string inpUser, HttpServerUtility inpServer, string inpGyartosor)
    {
        string CS2 = ConnectionString(inpUser);
        string ki = "0";
        //SqlConnection con = new SqlConnection();

        using (SqlConnection con = new SqlConnection(CS2))
        {
            try
            {
                //con = new SqlConnection(CS2);
                SqlCommand cmd = new SqlCommand(inpSQL, con);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    ki = cmd.ExecuteScalar().ToString();
                }
            }
            //catch (SqlException ex)
            //{
            //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
            //    LogException(ex, "Functions.Exec", uzi);
            //}
            //catch (Exception ex)
            //{
            //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
            //    LogException(ex, "Functions.ExecScalar", uzi);
            //}
            finally
            {
                con.Close();
            }
        }
        return ki;
    }

    /// <summary>
    /// Lefuttat egy lekérdező SQL utasítsát.
    /// </summary>
    /// <param name="inpSQL">Adja meg a futtatni kívánt sql utasítást.</param>
    /// <param name="fg_nev">Adja meg azt a metódust amlyikben éppen használja. Hibák logolásához szükséges.</param>
    /// <param name="inpUser">Adja meg a bejelentkezett felhasználó nevét.</param>
    /// <param name="inpServer">Server</param>
    /// <returns>Egy szöveg típusú eredményt ad vissza.</returns>
    public static string ExecScalar(string inpSQL, string fg_nev, string inpUser, string inpGyartosor)
    {
        string CS2 = ConnectionString(inpUser);
        string ki = "0";
        //SqlConnection con = new SqlConnection();
        using (SqlConnection con = new SqlConnection(CS2))
        {
            try
            {
                //con = new SqlConnection(CS2);
                SqlCommand cmd = new SqlCommand(inpSQL, con);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    ki = cmd.ExecuteScalar().ToString();
                }
            }
            //catch (SqlException ex)
            //{
            //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
            //    LogException(ex, "Functions.Exec", uzi);
            //}
            //catch (Exception ex)
            //{
            //    string uzi = "User:" + inpUser + " \nGyártósor: " + inpGyartosor + " \nFunction: " + fg_nev + "\nSQL: " + inpSQL;
            //    LogException(ex, "Functions.ExecScalar", uzi);
            //}
            finally
            {
                con.Close();
            }
        }
        return ki;
    }
    public static bool cikkszam(string szo, bool hosszu)
    {
        try
        {
            return Regex.IsMatch(szo, @"[a-zA-Z0-9][a-zA-Z0-9][a-zA-Z0-9][a-zA-Z0-9]\.[a-zA-Z0-9][a-zA-Z0-9][a-zA-Z0-9]\.[a-zA-Z0-9][a-zA-Z0-9][a-zA-Z0-9]\-[a-zA-Z0-9][a-zA-Z0-9][a-zA-Z0-9](?!\S)"); // Remove all non valid chars
        }
        catch (Exception ex)
        {
            //string uzi = "\n\rszo: " + szo;
            //Functions.LogException(ex, "Functions.cikkszam", uzi);
            return false;
        }
    }
    /// <summary>
    /// 13 számjegyű cikkszámba beleteszi a pontokat és a kötőjelet
    /// </summary>
    /// <param name="cikkszam"></param>
    /// <returns></returns>
    public static string cikkszam_pontosit(string cikkszam)
    {
        string pontositott_csz = "";
        if (Functions.cikkszam(cikkszam, true))
        {
            pontositott_csz = cikkszam;
        }
        int hossz = cikkszam.Length;
        if (hossz == 10)
        {
            pontositott_csz = cikkszam.Substring(0, 4);
            pontositott_csz = pontositott_csz + ".";
            pontositott_csz = pontositott_csz + cikkszam.Substring(4, 3);
            pontositott_csz = pontositott_csz + ".";
            pontositott_csz = pontositott_csz + cikkszam.Substring(7, 3);
        }
        if (hossz == 13)
        {
            pontositott_csz = cikkszam.Substring(0, 4);
            pontositott_csz = pontositott_csz + ".";
            pontositott_csz = pontositott_csz + cikkszam.Substring(4, 3);
            pontositott_csz = pontositott_csz + ".";
            pontositott_csz = pontositott_csz + cikkszam.Substring(7, 3);
            pontositott_csz = pontositott_csz + "-";
            pontositott_csz = pontositott_csz + cikkszam.Substring(10, 3);
        }

        return pontositott_csz;
    }

    /// <summary>
    /// Lefuttat egy lekérdező SQL utasítsát.
    /// </summary>
    /// <param name="inpSQL">Adja meg a futtatni kívánt sql utasítást.</param>
    /// <param name="inpUser">Adja meg a bejelentkezett felhasználó nevét.</param>
    /// <returns>Egy szöveg típusú eredményt ad vissza.</returns>
    public static string ExecScalar(string inpSQL, string inpUser)
    {
        string CS2 = ConnectionString(inpUser);
        string ki = "0";

        using (SqlConnection con = new SqlConnection(CS2))
        {
            try
            {
                SqlCommand cmd = new SqlCommand(inpSQL, con);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    ki = cmd.ExecuteScalar().ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }
        return ki;
    }

    public static void Language(string lng, HttpServerUtility Server, HttpRequest Request, HttpResponse Response)
    {
        //Sets the cookie that is to be used by Global.asax
        HttpCookie cookie = new HttpCookie("CultureInfo");
        cookie.Value = lng;
        cookie.Expires = DateTime.Now.AddYears(50);
        Response.Cookies.Add(cookie);

        //Set the culture and reload for immediate effect.
        //Future effects are handled by Global.asax
        Thread.CurrentThread.CurrentCulture = new CultureInfo(lng);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(lng);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lng);

        Server.Transfer(Request.Path);
    }


    /// <summary>
    /// Lefuttat egy lekérdező SQL utasítsát.
    /// </summary>
    /// <param name="inpSQL">Adja meg a futtatni kívánt sql utasítást.</param>
    /// <param name="fg_nev">Adja meg azt a metódust amlyikben éppen használja. Hibák logolásához szükséges.</param>
    /// <param name="inpUser">Adja meg a bejelentkezett felhasználó nevét.</param>
    /// <param name="inpServer">Server</param>
    /// <returns>Egy szöveg típusú eredményt ad vissza.</returns>


    public static void LogException(Exception exc, string source, string message)
    {
        try
        {
            string logFile = "Error_log2.txt";
            logFile = HttpContext.Current.Server.MapPath(logFile);
            if (logFile.Contains("test"))
            {
                logFile = @"\\mc-appl06\shopping_list_test$\Error_log2.txt";
            }
            else
            {
                logFile = @"\\mc-appl06\shopping_list$\Error_log2.txt";
            }
            FileStream fs = new FileStream(logFile, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("********** {0} **********", DateTime.Now);
            sw.WriteLine();
            if (exc.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(exc.InnerException.GetType().BaseType.ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
            }
            sw.WriteLine("Exception Type: " + exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Message: " + message);
            sw.WriteLine();
            sw.Flush();
            sw.Close();
            fs.Close();
            //Functions.ExceptionMail("Exception Type: " + exc.GetType().ToString() + "<br/>" + "Exception: " + exc.Message + "<br/>" + "Source: " + source + "<br/>" + "Message: " + message);
        }
        catch (Exception ex)
        {
            string a = ex.Message;
        }
    }
    public static string FetchLinksFromSource(string htmlSource, string user)
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
                File.WriteAllBytes(@"\\Mc0vm011.sg.lan\sghu_log-t$\" + user.ToString().Trim().ToLower() + @"\yourfile" + i.ToString() + "." + kiterjesztes, binData);
            }

            htmlSource = htmlSource.Replace(href, "cid:" + @"yourfile" + i.ToString() + "." + kiterjesztes);
            htmlSource = htmlSource.Replace("<img src=\"", "<img src = '");
            htmlSource = htmlSource.Replace("\"", "'");



            // bevitelomezo = bevitelomezo + @" < img src = 'cid:QRCODE.jpg' height = 480 width = 360 >";
            i++;
        }
        return htmlSource;
    }
    public static string SendMailJavaScript(string body, string to, string cc, string orderid, string user, string Date, string ProfintcenterName, string Alairas)
    {
        try
        {
            string filePath = @"\\Mc0vm011.sg.lan\sghu_log-t$\" + user.ToString().Trim() + @"\";
            body = FetchLinksFromSource(body.ToString(), user);
            body = body + @"<img src = 'cid:QRCODE.jpg' height = 480 width = 360 >";
            body = body.Replace(@"\", @"/");
            string mailBody = "<html><head></head><body><p>Dear Sir or Madam,</p><p></p><p><strong>Order Number:</strong> SGHU ORDER-" + orderid + "</p><p><strong>Date and Time:</strong>" + Date.Trim() + "</p><p><strong>Profit Center:</strong>" + ProfintcenterName.Trim() + "</p><p><strong>Requester:</strong> " + user.ToString().Trim() + "  </p><p><strong>Information: </strong></p><p>&nbsp;</p><p>" + HttpUtility.HtmlDecode(body).ToString() + "</p><p></p><p>&nbsp;</p><p><strong>The invoice has to contain the relevant SGHU order number.</strong></p>" + Alairas.Trim();
            mailBody = mailBody.Replace("'", @"""");
            mailBody = mailBody.Replace("\r", "");
            mailBody = mailBody.Replace("\n", "");
            string parameters = "";
            parameters = "['" + to.ToString().Trim() + "', ";
            parameters = parameters + "'" + mailBody + "', ";
            parameters = parameters + "'" + "Transport - [SGHU ORDER - " + orderid + "]" + "', ";
            parameters = parameters + "'" + cc.ToString().Trim() + "', ";
            foreach (string file in Directory.GetFiles(filePath))
            {
                parameters = parameters + @"'http://mc0vm011.sg.lan/www/SGHU_LOG-T/Files/" + user.Trim().ToLower() + "/" + Path.GetFileName(file) + "', ";
                parameters = parameters.Replace(@"\", @"/");
                ///PDFUpload(file, int.Parse(orderid));
            }
            parameters = parameters.Remove(parameters.Length - 2);
            parameters = parameters + "]";
            parameters = HttpUtility.HtmlDecode(parameters);
            return parameters;
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }
}
using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Net.Mail;
using System.Text;

public partial class OnlineGepjarmuRegisztraciosRendszer : BasePage
{
    public string lokacio = "";
    public string alluserid = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                txt_szken.Focus();
                string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                Session["login"] = User.Identity.Name.ToString();
                Session["txt_szken"] = "";
                string sql = "SELECT dbo.Users.Username, dbo.TPageNames.PageName FROM dbo.Users INNER JOIN dbo.SwitchPageNames ON dbo.Users.UserId = dbo.SwitchPageNames.UserId INNER JOIN dbo.TPageNames ON dbo.SwitchPageNames.MenuId = dbo.TPageNames.MenuId WHERE (dbo.Users.Username = '" + User.Identity.Name + "') AND (dbo.TPageNames.PageName = '" + pageName + "')";
                if (Functions.ExecScalar(sql, User.Identity.Name) != "0")
                {
                    Session["login"] = User.Identity.Name.ToString().ToLower().Trim();
                    if (User.Identity.Name == "ecporta")
                    {
                        LabelLokacio.Text = "Európa Center Üzlet & Logisztikai Park";
                    }
                    else if (User.Identity.Name == "sghufoporta")
                    {
                        LabelLokacio.Text = "Starter Motors Generators";
                    }
                    else if (User.Identity.Name == "ttporta")
                    {
                        LabelLokacio.Text = "Tiszaújváros Transz Kft";
                    }
                    else if (User.Identity.Name == "logicon")
                    {
                        LabelLokacio.Text = "Logicon";
                    }
                    else if (User.Identity.Name == "segalogistics")
                    {
                        LabelLokacio.Text = "Sega Logistics Service";
                    }

                    else
                    {
                        LabelLokacio.Text = "-1";
                    }


                }
                else
                {
                    Response.Redirect("~/" + Functions.ExecScalar("SELECT dbo.TPageNames.PageName FROM dbo.Users INNER JOIN dbo.TPageNames ON dbo.Users.HomePage = dbo.TPageNames.MenuId WHERE (dbo.Users.Username = '" + User.Identity.Name + "')", User.Identity.Name));
                }
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

    }
    protected void txt_szken_TextChanged(object sender, EventArgs e)
    {
        try
        {
            beszallitosor.Visible = true;
            DropDownListIrany.Visible = true;
            RequiredFieldValidatorIrany.Enabled = true;
            irany.Visible = true;
            vamsor.Visible = true;
            txt_szken.Focus();
            if (DropDownListIrany.Items.Count == 2)
            {
                DropDownListIrany.Items.Insert(0, "Kérlek Válasz!");
                DropDownListIrany.DataBind();
            }
            DropDownListIrany.DataBind();
            DropDownListIrany.ClearSelection();
            TextBoxVontatoRendszam.Text = "";
            LabelFovalalkozo.Text = "Road 66 Kereskedelmi és Szállítmányozó Kft.";
            TextBoxDatum.Text = "";
            TextBoxIdopont.Text = "";
            TextBoxPotkocsiRendszam.Text = "";
            TextBoxSoforNeve.Text = "";
            lbl_uzi.Text = "";
            SqlDataReader dataReader;
            String query = "";

            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
            {
                Session["txt_szken"] = txt_szken.Text.ToString().ToUpper();
                switch (Session["txt_szken"].ToString().Substring(0, 2).ToUpper())
                {
                    case "SG":
                        LabelLokacioText.Text = "Lokáció(Hová érkezik):";
                        Fejresz.Text = "Bejövő";
                        LabelPalette.Text = "Bejövő Paletta szám:";
                        LabelDatum.Text = "Érkezés dátuma:";
                        LabelIdopont.Text = "Érkezés időpontja:"; ;

                        LabelFovalalkozo.Visible = false;


                        DropDownListIrany.Visible = false;
                        RequiredFieldValidatorIrany.Enabled = false;
                        irany.Visible = false;
                        lbl_uzi.Text = "Sikeres szkennelés. SGHU: " + txt_szken.Text;
                        query = "Select * From [dbo].[SGHUOrder] WHERE QRCodeID=@ID";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = txt_szken.Text.ToString();
                            con.Open();
                            dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                ButtonInsert.Visible = true;
                            }
                            else
                            {
                                lbl_uzi.Text = "Nem megfelelő QR kódazonosító kérlek, ellenőrizd újra!";
                                ButtonInsert.Visible = false;
                                return;
                            }
                            con.Close();
                        }
                        query = "Select * From [dbo].[SGHUOrder] WHERE QRCodeID=@ID and Arrived=1;";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = txt_szken.Text.ToString();
                            con.Open();
                            dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                lbl_uzi.Text = "Az " + txt_szken.Text + "  rendelés már beérkezett!";
                                ButtonInsert.Visible = false;
                                txt_szken.Text = "";
                                return;
                            }
                            else
                            {
                                ButtonInsert.Visible = true;
                                table1.Visible = true;
                            }
                            con.Close();
                        }
                        query = "SELECT dbo.SGHUOrder.OrderID, dbo.LSP.Name, dbo.SGHUOrder.Forwarder, dbo.LSP.ID,dbo.SGHUOrder.TrackingNumber FROM dbo.SGHUOrder LEFT OUTER JOIN dbo.LSP ON dbo.SGHUOrder.Forwarder = dbo.LSP.ID WHERE (QRCodeID = @ID) ORDER BY dbo.SGHUOrder.OrderID DESC";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = txt_szken.Text.ToString();
                            con.Open();
                            dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                LabelFovalalkozo.Text = dataReader[1].ToString().Trim();
                                TextBoxDatum.Text = DateTime.Today.ToString("yyyy.MM.dd");
                                TextBoxIdopont.Text = DateTime.Now.ToString("HH:mm");
                                TextBoxVontatoRendszam.Text = dataReader[4].ToString().Trim();
                            }
                            else
                            {
                                return;
                            }
                            TextBoxEgyediAzonosito.Text = txt_szken.Text.ToString();
                            con.Close();
                        }
                        query = "UPDATE  dbo.SGHUOrder SET Arrived=1, Actualarrival=@Actualarrival  WHERE (QRCodeID = @ID);";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = txt_szken.Text;
                            command.Parameters.Add("@Actualarrival", SqlDbType.DateTime).Value = DateParse(DateTime.Today.ToString("yyyy.MM.dd") + " " + DateTime.Now.ToString("HH:mm"));
                            con.Open();
                            command.ExecuteNonQuery();
                            con.Close(); ;

                        }
                        break;
                    case "MR":
                        beszallitosor.Visible = false;
                        DropDownListIrany.Visible = true;
                        vamsor.Visible = false;
                        table1.Visible = true;

                        int milkID = int.Parse(txt_szken.Text.ToString().Trim().ToUpper().Replace("MR", ""));
                        lbl_uzi.Text = "Sikeres szkennelés. MILK: " + txt_szken.Text;
                        query = "Select * From [dbo].[Milkruns] WHERE ID=@ID";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = milkID;
                            con.Open();
                            dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                ButtonInsert.Visible = true;
                            }
                            else
                            {
                                lbl_uzi.Text = "Nem megfelelő QR kódazonosító kérlek, ellenőrizd újra!";
                                ButtonInsert.Visible = false;
                                return;
                            }
                            con.Close();
                        }
                        query = "SELECT dbo.Milkruns.TrackingNumber, dbo.Milkruns.TrailerNumber, dbo.Milkruns.DriverName FROM dbo.MilkRunMovement RIGHT OUTER JOIN dbo.Milkruns ON dbo.MilkRunMovement.TrackingNumberID = dbo.Milkruns.ID WHERE(dbo.Milkruns.ID = @ID)";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.Add("@ID", SqlDbType.Int).Value = milkID;
                            con.Open();
                            dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                TextBoxVontatoRendszam.Text = dataReader[0].ToString().Trim();
                                LabelFovalalkozo.Text = "Road 66 Kereskedelmi és Szállítmányozó Kft.";
                                TextBoxDatum.Text = DateTime.Today.ToString("yyyy.MM.dd");
                                TextBoxIdopont.Text = DateTime.Now.ToString("HH:mm");
                                TextBoxPotkocsiRendszam.Text = dataReader[1].ToString().Trim();
                                TextBoxSoforNeve.Text = dataReader[2].ToString().Trim();
                            }
                            else
                            {
                                return;
                            }
                            TextBoxEgyediAzonosito.Text = txt_szken.Text.ToString();
                            con.Close();
                        }
                        break;
                    default:
                        lbl_uzi.Text = "Nem ismert QR Code";
                        table1.Visible = false;
                        break;
                }


            }
            txt_szken.Text = String.Empty;
        }
        catch (Exception ex)
        {
            lbl_uzi.ForeColor = System.Drawing.Color.Red;
            Emailkuld("Hiba " + Session["login"].ToString(), "Hiba a szkennelés közben. szkennelés: " + lbl_uzi.Text + "<br/>Exception: " + ex.ToString());
            txt_szken.Text = String.Empty;
        }

    }
    private void BindGrid()
    {

    }

    public string Feltoltes(string query, string insert, string be)
    {
        SqlDataReader dataReader;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = be;
                con.Open();
                dataReader = command.ExecuteReader();
            }
            if (dataReader.Read())
            {
                if (dataReader[0] != DBNull.Value)
                {
                    return dataReader[0].ToString();
                }
            }
            else if (insert == "")
            {
                return "0";
            }
        }
        string a = insert.Substring(9, insert.Length - 9);
        if (insert.Substring(0, 9) == "azonosito")
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {
                insert = insert.Substring(9, insert.Length - 9);
                insert = "insert into  dbo.Kamionkezelo(befele,vontatorendszam,lokacio,Azonosito,userid) values(" + insert + ");";
                using (SqlCommand command = new SqlCommand(insert, con))
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {
                a = a.Remove(0, 1);
                insert = "insert into  dbo.Kamionkezelo(befele,vontatorendszam,lokacio,Azonosito,userid) values(0" + a + ");";
                using (SqlCommand command = new SqlCommand(insert, con))
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(insert, con))
                {
                    command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = be;
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = be;
                con.Open();
                dataReader = command.ExecuteReader();
            }
            if (dataReader.Read())
            {
                return dataReader[0].ToString();
            }
        }
        return null;
    }



    protected void TextBoxEgyediAzonosito_TextChanged(object sender, EventArgs e)
    {
        if (TextBoxEgyediAzonosito.Text == "")
        {
            ButtonInsert.Visible = true;
            LabelHiba.Text = "";
            //if (Request.IsAuthenticated)
            //{
            //    Response.Redirect("Form_Kereses.aspx");
            //}
            //else
            //{
            //    FormsAuthentication.SignOut();
            //    Response.Redirect("~/Login.aspx");
            //}
        }
        else
        {
            //SqlDataReader dataReader;
            //String query = "";
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
            {

                //query = "Select * From [dbo].[SGHUOrder] WHERE QRCodeID=@ID";
                //using (SqlCommand command = new SqlCommand(query, con))
                //{
                //    command.Parameters.Add("@ID", SqlDbType.VarChar).Value = TextBoxEgyediAzonosito.Text.ToString();
                //    con.Open();
                //    dataReader = command.ExecuteReader();
                //    if (dataReader.Read())
                //    {
                //        LabelHiba.Text = "";
                //        ButtonInsert.Visible = true;

                //    }
                //    else
                //    {
                //        LabelHiba.Text = "Nem megfelelő QR kódazonosító kérlek, ellenőrizd újra!";
                //        ButtonInsert.Visible = false;
                //        return;
                //    }
                //    con.Close();
                //}
                //query = "Select * From [dbo].[SGHUOrder] WHERE QRCodeID=@ID and Arrived=1;";
                //using (SqlCommand command = new SqlCommand(query, con))
                //{
                //    command.Parameters.Add("@ID", SqlDbType.VarChar).Value = TextBoxEgyediAzonosito.Text.ToString();
                //    con.Open();
                //    dataReader = command.ExecuteReader();
                //    if (dataReader.Read())
                //    {
                //        LabelHiba.Text = "Az adott rendelés már beérkezett!";
                //        ButtonInsert.Visible = false;
                //        return;
                //    }
                //    else
                //    {
                //        LabelHiba.Text = "";
                //        ButtonInsert.Visible = true;
                //    }
                //    con.Close();
                //}
                //query = "SELECT dbo.SGHUOrder.OrderID, dbo.LSP.Name, dbo.SGHUOrder.Forwarder, dbo.LSP.ID,dbo.SGHUOrder.TrackingNumber FROM dbo.SGHUOrder LEFT OUTER JOIN dbo.LSP ON dbo.SGHUOrder.Forwarder = dbo.LSP.ID WHERE (QRCodeID = @ID) ORDER BY dbo.SGHUOrder.OrderID DESC";
                //using (SqlCommand command = new SqlCommand(query, con))
                //{
                //    command.Parameters.Add("@ID", SqlDbType.VarChar).Value = TextBoxEgyediAzonosito.Text.ToString();
                //    con.Open();
                //    dataReader = command.ExecuteReader();
                //    if (dataReader.Read())
                //    {
                //        LabelFovalalkozo.Text = dataReader[1].ToString().Trim();
                //        TextBoxDatum.Text = DateTime.Today.ToString("yyyy.MM.dd");
                //        TextBoxIdopont.Text = DateTime.Now.ToString("HH:mm");
                //        TextBoxVontatoRendszam.Text = dataReader[4].ToString().Trim();
                //    }
                //    else
                //    {
                //        return;
                //    }
                //    con.Close();
                //}

                //query = "UPDATE  dbo.SGHUOrder SET Arrived=1, Actualarrival=@Actualarrival  WHERE (QRCodeID = @ID);";
                //using (SqlCommand command = new SqlCommand(query, con))
                //{
                //    command.Parameters.Add("@ID", SqlDbType.VarChar).Value = TextBoxEgyediAzonosito.Text;
                //    command.Parameters.Add("@Actualarrival", SqlDbType.DateTime).Value = DateParse(DateTime.Today.ToString("yyyy.MM.dd") + " " + DateTime.Now.ToString("HH:mm"));
                //    con.Open();
                //    command.ExecuteNonQuery();
                //    con.Close(); ;

                //}

            }
        }

    }




    protected void TextBoxVontatoRendszam_TextChanged(object sender, EventArgs e)
    {
        TextBoxVontatoRendszam.Text = TextBoxVontatoRendszam.Text.ToString().Trim().ToUpper();
    }

    protected void TextBoxPotkocsiRendszam_TextChanged(object sender, EventArgs e)
    {
        TextBoxPotkocsiRendszam.Text = TextBoxPotkocsiRendszam.Text.ToString().Trim().ToUpper();
    }

    protected void ButtonInsert_Click(object sender, EventArgs e)
    {

        string script = "";
        try
        {
            if (string.IsNullOrEmpty(LabelHiba.Text.ToString().Trim()) && !string.IsNullOrEmpty(TextBoxEgyediAzonosito.Text))
            {
                using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
                {
                    string query;
                    string sql = "";
                    Session["login"] = User.Identity.Name.ToString().ToLower();
                    sql = "SELECT [UserId] FROM [dbo].[Users] where Username='" + User.Identity.Name + "'";
                    int userid = int.Parse(Functions.ExecScalar(sql, User.Identity.Name));
                    switch (Session["txt_szken"].ToString().Substring(0, 2).ToUpper())
                    {
                        case "SG":

                            query = " UPDATE [dbo].[SGHUOrder] SET TrackingNumber=@TrackingNumber,TrailerNumber=@TrailerNumber,receptionID=@receptionID, szalitolevelCMR=@szalitolevelCMR, kártyaszám=@kártyaszám, plombaszam=@plombaszam,kiszallitas=@kiszallitas   where QRCodeID=@ID ";
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                command.Parameters.Add("@ID", SqlDbType.VarChar).Value = TextBoxEgyediAzonosito.Text.ToString();
                                command.Parameters.Add("@TrackingNumber", SqlDbType.VarChar).Value = TextBoxVontatoRendszam.Text.ToString();
                                command.Parameters.Add("@TrailerNumber", SqlDbType.VarChar).Value = TextBoxPotkocsiRendszam.Text.ToString();
                                command.Parameters.Add("@receptionID", SqlDbType.VarChar).Value = int.Parse(Functions.ExecScalar(sql, User.Identity.Name));
                                command.Parameters.Add("@szalitolevelCMR", SqlDbType.VarChar).Value = TextBoxCMR.Text.ToString();
                                command.Parameters.Add("@kártyaszám", SqlDbType.VarChar).Value = TextBoxKartyaszam.Text.ToString();
                                command.Parameters.Add("@plombaszam", SqlDbType.VarChar).Value = TextBoxPlombaSzam.Text.ToString();
                                command.Parameters.Add("@kiszallitas", SqlDbType.Bit).Value = int.Parse(DropDownListKIBEszállítás.SelectedValue);
                                con.Open();
                                command.ExecuteNonQuery();
                                con.Close();
                            }
                            script = "alert(\"Adatmentés megtörtént!\"); ";
                            break;
                        case "MR":
                            int milkID = int.Parse(Session["txt_szken"].ToString().Trim().Replace("MR", ""));
                            if (DropDownListIrany.SelectedValue == "1")
                            {
                                sql = "INSERT INTO [MilkRunMovement]([TrackingNumberID],[InDate],[receptionID],[commentIN],[InPalette],[befele],[szalitolevelCMR],[kártyaszám],[plombaszam],[kiszallitas],[EgyediAzonositIn]) VALUES ('" + milkID + "',getdate(),'" + userid + "','" + TextBoxMegjegyzes.Text.ToString().Trim() + "','" + int.Parse(TextBoxPaletta.Text.Trim()) + "'," + int.Parse(DropDownListIrany.SelectedValue.ToString()) + ",'" + TextBoxCMR.Text.ToString() + "','" + TextBoxKartyaszam.Text.ToString() + "','" + TextBoxPlombaSzam.Text.ToString() + "'," + int.Parse(DropDownListKIBEszállítás.SelectedValue) + ",'" + TextBoxEgyediAzonosito.Text.ToString() + "');";
                            }
                            else
                            {
                                sql = "SELECT top 1 outdate  FROM [MilkRunMovement] where TrackingNumberID = '" + milkID + "' and receptionID='" + int.Parse(Functions.ExecScalar(sql, User.Identity.Name)) + "' order by id desc;";
                                string st = Functions.ExecScalar(sql, User.Identity.Name);
                                if (st == "0" || !string.IsNullOrEmpty(st))
                                {
                                    sql = "INSERT INTO [MilkRunMovement]([TrackingNumberID],[OutDate],[receptionID],[commentOUT],[OutPalette],[befele],[szalitolevelCMR],[kártyaszám],[plombaszam],[kiszallitas],[EgyediAzonositOut]) VALUES ('" + milkID + "',getdate(),'" + userid  + "','" + TextBoxMegjegyzes.Text.ToString().Trim() + "','" + int.Parse(TextBoxPaletta.Text.Trim()) + "'," + int.Parse(DropDownListIrany.SelectedValue.ToString()) + ",'" + TextBoxCMR.Text.ToString() + "','" + TextBoxKartyaszam.Text.ToString() + "','" + TextBoxPlombaSzam.Text.ToString() + "'," + int.Parse(DropDownListKIBEszállítás.SelectedValue) + ",'" + TextBoxEgyediAzonosito.Text.ToString() + "');";
                                }
                                else
                                {                                
                                    sql = "SELECT MAX([ID]) FROM[MilkRunMovement] where TrackingNumberID  = '" + milkID + "' and receptionID='" + userid + "';";
                                    st = Functions.ExecScalar(sql, User.Identity.Name);
                                    sql = "UPDATE [MilkRunMovement] SET [OutDate] = getdate(),EgyediAzonositOut='" + TextBoxEgyediAzonosito.Text.ToString() + "',OutPalette = '" + TextBoxPaletta.Text.Trim() + "',commentOUT = '" + TextBoxMegjegyzes.Text.ToString().Trim() + "' WHERE ID = " + st;
                                }
                            }



                            using (SqlCommand command = new SqlCommand(sql, con))
                            {
                                con.Open();
                                command.ExecuteNonQuery();
                                con.Close();
                            }
                            sql = "UPDATE [Milkruns] SET [TrackingNumber] ='" + TextBoxVontatoRendszam.Text.ToString() + "',  [TrailerNumber] ='" + TextBoxPotkocsiRendszam.Text.ToString() + "',[DriverName]='" + TextBoxSoforNeve.Text.ToString().Trim() + "' where ID='" + milkID + "';";
                            using (SqlCommand command = new SqlCommand(sql, con))
                            {
                                con.Open();
                                command.ExecuteNonQuery();
                                con.Close();
                            }
                            txt_szken.Text = String.Empty;
                            script = "alert(\"Adatmentés megtörtént!\"); ";
                            break;
                        default:
                            lbl_uzi.Text = "Nem ismert QR Code";
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string hiba = "";
            lbl_uzi.ForeColor = System.Drawing.Color.Red;
            lbl_uzi.Text = String.Empty;
            hiba = "Hiba a szkennelés közben. szkennelés:" + "<br/>" + "Message :" + ex.Message + "<br/>" + "StackTrace :" + ex.StackTrace + "" + "<br/>" + "Date :" + DateTime.Now.ToString() + "<br/>" + "Exception: " + ex.ToString();   
            Emailkuld("Hiba " +  Session["login"].ToString(),  hiba);
            txt_szken.Text = String.Empty;
        }
        finally
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            TextBoxVontatoRendszam.Text = "";
            TextBoxPotkocsiRendszam.Text = "";
            TextBoxDatum.Text = "";
            TextBoxIdopont.Text = "";
            LabelFovalalkozo.Text = "";
            TextBoxEgyediAzonosito.Text = "";
            TextBoxCMR.Text = "";
            TextBoxKartyaszam.Text = "";
            TextBoxPlombaSzam.Text = "";      
            txt_szken.Focus();
            table1.Visible = false;
            TextBoxMegjegyzes.Text = "";
            DropDownListIrany.Visible = true;
            RequiredFieldValidatorIrany.Enabled = true;
            TextBoxPaletta.Text = "";       
            irany.Visible = true;
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


    public static DateTime DateParse(string date)
    {
        date = date.Trim();
        if (!string.IsNullOrEmpty(date))
            return DateTime.Parse(date, new System.Globalization.CultureInfo("en-GB"));
        return new DateTime();
    }

    protected void DropDownListIrany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListIrany.SelectedValue == "1")
        {
            LabelLokacioText.Text = "Lokáció(Hová érkezik):";
            Fejresz.Text = "Bejövő";
            LabelPalette.Text = "Bejövő Paletta szám:";
            LabelDatum.Text = "Érkezés dátuma:";
            LabelIdopont.Text = "Érkezés időpontja:";
            // table1.Style.Add("background-color", "#33CC66");
            System.Web.UI.HtmlControls.HtmlGenericControl MasterBody = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("MasterBody");
            MasterBody.Attributes.Add("style", "background-color: #fce4d6");

        }
        else if (DropDownListIrany.SelectedValue == "2")
        {
            LabelLokacioText.Text = "Lokáció(Honnan indul):";
            Fejresz.Text = "Kimenő";
            LabelPalette.Text = "Kimenő Paletta szám:";
            LabelDatum.Text = "Távozás dátuma:";
            LabelIdopont.Text = "Távozás időpontja:";
            System.Web.UI.HtmlControls.HtmlGenericControl MasterBody = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("MasterBody");
            MasterBody.Attributes.Add("style", "background-color: #a3d89c");
        }
        if (DropDownListIrany.Items.Count == 3)
        {
            DropDownListIrany.Items.RemoveAt(0);
        }







    }



    protected void DropDownListKIBEszállítás_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListKIBEszállítás.Items.Count == 3)
        {
            DropDownListKIBEszállítás.Items.RemoveAt(0);
        }
    }


}


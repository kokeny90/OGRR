using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using Tawammar.CustomControls;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Drawing;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;


public partial class Start : System.Web.UI.Page
{
    public string lokacio = "";
    public string alluserid = "";
    protected void Page_Load(object sender, EventArgs e)
    {



        if (Request.IsAuthenticated)
        {


            tdBejovo.RowSpan = 4;
            td2.RowSpan = 4;
            string blab = User.Identity.Name.ToString().ToLower();
            ((Label)Master.FindControl("Label1")).Text = "Kamionkezelő";

            switch (blab)
            {
                case "mcp":
                    SqlDataSource5.FilterExpression = "Expr1 = 383 OR Expr1 = -1  ";
                    lokacio = "OR  userid = '188'  or ";
                    alluserid = "188";
                    Tábla.FilterExpression = lokacio.Substring(lokacio.Length - 20) + "[Expr1] = '-5' OR [Expr1] = '-4' OR [Expr1] = '-3'";
                    break;
                case "rbhm":
                    SqlDataSource5.FilterExpression = "Expr1 = 382 OR Expr1 = -1 OR Expr1 = 386 ";
                    lokacio = "AND  userid = '192' or ";
                    alluserid = "192";
                    Tábla.FilterExpression = lokacio.Substring(lokacio.Length - 20) + "[Expr1] = '-5' OR [Expr1] = '-4' OR [Expr1] = '-3'";
                    break;
                case "ecb":
                    SqlDataSource5.FilterExpression = "Expr1 = 385 OR Expr1 = -1 OR Expr1 = 386 ";
                    lokacio = "AND  userid = '189' or ";
                    alluserid = "189";
                    Tábla.FilterExpression = lokacio.Substring(lokacio.Length - 20) + "[Expr1] = '-5' OR [Expr1] = '-4' OR [Expr1] = '-3'";
                    break;
                case "tt":
                    SqlDataSource5.FilterExpression = "Expr1 = 379 OR Expr1 = -1 OR Expr1 = 386 ";
                    lokacio = "AND  userid = '190' or ";
                    alluserid = "190";
                    Tábla.FilterExpression = lokacio.Substring(lokacio.Length - 20) + "[Expr1] = '-5' OR [Expr1] = '-4' OR [Expr1] = '-3'";
                    break;
                case "logicon":
                    SqlDataSource5.FilterExpression = "Expr1 = 381 OR Expr1 = -1 OR Expr1 = 386 ";
                    lokacio = "AND  userid = '191' or ";
                    alluserid = "191";
                    Tábla.FilterExpression = lokacio.Substring(lokacio.Length - 20) + "[Expr1] = '-5' OR [Expr1] = '-4' OR [Expr1] = '-3'";
                    break;
                default:
                    alluserid = "";
                    btnExportExcel.Visible = true;
                    btnExportWord.Visible = true;
                    btnExportPDF.Visible = true;
                    Button4.Visible = true;
                    DataFilter1.Visible = true;

                    lokacio = "";
                    break;

            }




        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }


        DataFilter1.DataSource = Tábla;
        DataFilter1.DataColumns = GridView1.Columns;
        DataFilter1.Lokacio = lokacio;
        DataFilter1.FilterSessionID = "Start.aspx";
        DataFilter1.OnFilterAdded += new DataFilter.RefreshDataGridView(DataFilter1_OnFilterAdded);


        if (IsPostBack)
        {
            foreach (GridViewRow Row in GridView1.Rows)
            {

                if (Row.RowIndex == 1)
                {

                    Row.BackColor = System.Drawing.Color.FromName("#999999");
                    Row.HorizontalAlign = HorizontalAlign.Center;
                    Row.ForeColor = System.Drawing.Color.White;


                }


                if (Row.RowIndex > 1)
                {
                    Row.Cells[5].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[8].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[13].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[14].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[19].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[22].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[24].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                }

                if (Row.RowIndex == 1)
                {
                    Row.Cells[4].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[7].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[12].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[13].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[18].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[21].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[23].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                }


                if (Row.RowIndex < 1)
                {
                    Row.Cells[0].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[1].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[2].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[3].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[4].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[5].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                    Row.Cells[6].Style.Add("BORDER-RIGHT", "#000000 3px solid");
                }



                if (Row.RowIndex > 2)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        Row.Cells[i].BackColor = System.Drawing.Color.FromName("#f2dcdb");


                    }

                }

                if (Row.RowIndex == 2)
                {


                    for (int i = 0; i < 8; i++)
                    {
                        Row.Cells[i].BackColor = System.Drawing.Color.FromName("#00b0f0");
                    }
                    for (int i = 9; i < 10; i++)
                    {
                        Row.Cells[i].BackColor = System.Drawing.Color.FromName("#92d050");
                    }

                    for (int i = 20; i < 25; i++)
                    {
                        Row.Cells[i].BackColor = System.Drawing.Color.FromName("#92d050");
                    }
                    for (int i = 25; i < 28; i++)
                    {
                        Row.Cells[i].BackColor = System.Drawing.Color.FromName("#fabf8f");
                    }


                    Row.BackColor = System.Drawing.Color.FromName("#00B0F0");
                    Row.HorizontalAlign = HorizontalAlign.Center;
                    Row.ForeColor = System.Drawing.Color.White;
                }

                if (Row.RowIndex == 0)
                {

                    Row.BackColor = System.Drawing.Color.FromName("#0070c0");
                    Row.HorizontalAlign = HorizontalAlign.Center;
                    Row.ForeColor = System.Drawing.Color.White;
                    Row.Cells[5].BackColor = System.Drawing.Color.FromName("#00b050");
                    Row.Cells[6].BackColor = System.Drawing.Color.FromName("#00b050");
                    Row.Cells[7].BackColor = System.Drawing.Color.FromName("#e26b0a");
                }


            }
        }


        if (alluserid.Length != 0)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex > 2)
                {

                    CheckBox chk = row.Cells[27].Controls[0] as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
                row.Cells[27].Visible = false;
				 row.Cells[0].Text = row.Cells[0].Text.ToUpper();
                row.Cells[1].Text = row.Cells[0].Text.ToUpper();
            }

        }
        else
        {
            foreach (GridViewRow row in GridView1.Rows)
            {           
                row.Cells[27].Visible = true;
				 row.Cells[0].Text = row.Cells[0].Text.ToUpper();
                row.Cells[1].Text = row.Cells[0].Text.ToUpper();
            }
        }




       

    }


    void DataFilter1_OnFilterAdded()
    {
        try
        {
            DataFilter1.FilterSessionID = "Start.aspx";
            DataFilter1.FilterDataSource();
            GridView1.DataBind();

        }
        catch (Exception e)
        {
        }
    }
    protected void btnExportWord_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-word ";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        GridView1.DataBind();
        GridView1.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }


    private void BindGrid()
    {

        //using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {

        //        cmd.CommandText = "SELECT dbo.rendszamok.rendszam, dbo.rendszamok.alvallalkozo, dbo.Kamionkezelo.soforneve, dbo.Kamionkezelo.KÁRTYA, dbo.Kamionkezelo.ertkezettdatum,                        dbo.Kamionkezelo.behivasdatuma, dbo.Kamionkezelo.tavozasdatuma, dbo.Kamionkezelo.rampa, dbo.Kamionkezelo.mithozott, dbo.Kamionkezelo.palettabefele,                          dbo.Kamionkezelo.szalitolevelCMRbefele, dbo.Kamionkezelo.plombaszambefele, dbo.Kamionkezelo.tavozasmodja, dbo.Kamionkezelo.mitvisz,                           dbo.Kamionkezelo.palettaszamkifele, dbo.Kamionkezelo.szalitolevelCMRkifel, dbo.Kamionkezelo.Plombaszamkifel, dbo.Kamionkezelo.[ELLENŐRZÉST VÉGEZTE],                           dbo.Kamionkezelo.VÁMÁRUS, dbo.Kamionkezelo.MEGJEGYZÉS, dbo.Users.Username, dbo.Users.Email FROM            dbo.Kamionkezelo INNER JOIN                          dbo.rendszamok ON dbo.Kamionkezelo.vontatorendszam = dbo.rendszamok.id AND dbo.Kamionkezelo.potkocsirendszam = dbo.rendszamok.id INNER JOIN                          dbo.Users ON dbo.Kamionkezelo.USERID = dbo.Users.UserId LEFT OUTER JOIN                          dbo.Transportes ON dbo.Kamionkezelo.fovalalkozo = dbo.Transportes.transporter_id AND dbo.Kamionkezelo.alvalalkozó = dbo.Transportes.transporter_id AND                           dbo.rendszamok.alvallalkozo = dbo.Transportes.transporter_id                                 ";

        //        cmd.Connection = con;

        //        DataTable dt = new DataTable();
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            sda.Fill(dt);
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //    }
        //}
    }

    //protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    //GridView1.PageIndex = e.NewPageIndex;
    //    this.BindGrid();
    //}
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

    public string KamionkezeloID;


    int azonosito;

    protected void Button1_Click(object sender, EventArgs e)
    {

        int ures = 0;
        int i = 0;

        foreach (Control ctrl in PlaceHolder1.Controls)
        {

            if (ctrl is TextBox)
            {
                TextBox actualtextbox1 = (TextBox)ctrl;
                if (actualtextbox1.Text.ToString() != "")
                {
                    ures = 0;
                    break;
                }
                else
                {
                    ures = 1;
                    break;
                }
            }
            i = i + 1;

        }









        string query = "";
        int Soforneve = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxSoforNeve.Text.Trim()));
        int Utassneve = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxUtasNeve.Text.Trim()));
        int vontatorendszam = int.Parse(Feltoltes("SELECT id FROM dbo.rendszamok WHERE (rendszam = @bemenoadat);", "insert into  dbo.rendszamok(rendszam) values(@bemenoadat);", TextBoxVontatoRendszam.Text.Trim()));
        int potkocsirendszam = int.Parse(Feltoltes("SELECT id FROM dbo.rendszamok WHERE (rendszam = @bemenoadat);", "insert into  dbo.rendszamok(rendszam) values(@bemenoadat);", TextBoxPotkocsiRendszam.Text.Trim()));
        int ellenorzestvegezte = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxEllenorzestVegezte.Text.Trim()));
        int userid = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", User.Identity.Name.ToString().Trim()));

        int fovalalkozo;

        int lokacio = int.Parse(DropDownListLokacio.SelectedValue);



        int irany;

        if (TextBoxFovalalkozo.Visible == true)
        {

            fovalalkozo = int.Parse(Feltoltes("SELECT ID FROM dbo.Transportes WHERE (transporter_name = @bemenoadat)", "insert into  dbo.Transportes(transporter_name,fovallalkozo) values(@bemenoadat,1);", TextBoxFovalalkozo.Text.Trim()));

        }
        else
        {

            fovalalkozo = int.Parse(DropDownListFovalalkozo.SelectedValue);

        }
        int alvalakozo;
        if (TextBoxAllvalalkozo.Visible == true)
        {
            alvalakozo = int.Parse(Feltoltes("SELECT ID FROM dbo.Transportes WHERE (transporter_name = @bemenoadat)", "insert into  dbo.Transportes(transporter_name,fovallalkozo) values(@bemenoadat,0);", User.Identity.Name.ToString().Trim()));

        }
        else
        {
            alvalakozo = int.Parse(DropDownListAlvallalkozo.SelectedValue);
        }
        if (TextBoxIrany.Text == "Bejövő")
        {
            query = "INSERT INTO [RBHM_LOG-T].[dbo].[Kamionkezelo](vontatorendszam,potkocsirendszam,lokacio,befele,tomege,soforneve,utasneve,datum,behivasdatuma,rampa,fovalalkozo,alvalalkozó,beszallito,szalitolevelCMR,plombaszam,egyebbazonosito,vamaru,vamaruserult,ellenorzestvegezte,ellenorzesmodja,megjeygyzes,Azonosito,ures,elerhetoseg,userid) VALUES  (@vontatorendszam,@potkocsirendszam,@lokacio,@befele,@tomege,@soforneve,@utasneve,@datum,@behivasdatuma,@rampa,@fovallalkozo,@alvalalkozo,@beszallito,@szalitolevelCMR,@plombaszam,@egyebbazonosito,@vamaru,@vamaruserult,@ellenorzestvegezte,@ellenorzesmodja,@megjegyzes,@Azonosito,@ures,@elerhetoseg,@userid)";
            azonosito = int.Parse(Feltoltes("SELECT  TOP (1) PERCENT dbo.Kamionkezelo.Azonosito AS Expr1 FROM dbo.Kamionkezelo INNER JOIN dbo.rendszamok ON dbo.Kamionkezelo.vontatorendszam = dbo.rendszamok.id WHERE (dbo.Kamionkezelo.befele = 1) ORDER BY Expr1 DESC", "", TextBoxVontatoRendszam.Text.Trim())) + 1;
            irany = 1;
        }
        else
        {
            query = "update [RBHM_LOG-T].[dbo].[Kamionkezelo] set potkocsirendszam=@potkocsirendszam, lokacio=@lokacio, befele=@befele, tomege=@tomege, soforneve=@soforneve, utasneve=@utasneve, datum=@datum, behivasdatuma=@behivasdatuma, rampa=@rampa, fovalalkozo=@fovallalkozo, alvalalkozó=@alvalalkozo, beszallito=@beszallito, szalitolevelCMR=@szalitolevelCMR, ures=@ures, elerhetoseg=@elerhetoseg, userid=@userid where [RBHM_LOG-T].[dbo].[Kamionkezelo].Azonosito=@Azonosito and [RBHM_LOG-T].[dbo].[Kamionkezelo].[befele] = 0";
            azonosito = int.Parse(Feltoltes("SELECT  TOP (1) PERCENT dbo.Kamionkezelo.Azonosito AS Expr1 FROM dbo.Kamionkezelo INNER JOIN dbo.rendszamok ON dbo.Kamionkezelo.vontatorendszam = dbo.rendszamok.id WHERE (dbo.Kamionkezelo.befele = 1) ORDER BY Expr1 DESC", "", TextBoxVontatoRendszam.Text.Trim())) + 1;
            azonosito = int.Parse(Feltoltes("SELECT  dbo.Kamionkezelo.Azonosito AS Expr1 FROM dbo.Kamionkezelo INNER JOIN dbo.rendszamok ON dbo.Kamionkezelo.vontatorendszam = dbo.rendszamok.id WHERE (dbo.rendszamok.rendszam = @bemenoadat) AND (dbo.Kamionkezelo.befele = 1) ORDER BY Expr1 DESC", "azonosito1," + vontatorendszam + "," + lokacio + "," + azonosito + "," + alluserid, TextBoxVontatoRendszam.Text.Trim()));
            irany = 0;
        }


        //  az elso Sort feltoltes
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {

            using (SqlCommand command = new SqlCommand(query, con))
            {


                command.Parameters.Add("@vontatorendszam", SqlDbType.Int).Value = vontatorendszam;
                command.Parameters.Add("@potkocsirendszam", SqlDbType.Int).Value = potkocsirendszam;
                command.Parameters.Add("@lokacio", SqlDbType.Int).Value = lokacio;
                command.Parameters.Add("@befele", SqlDbType.Bit).Value = irany;
                double num;
                if (double.TryParse(TextBoxTomeg.Text.ToString(), out num))
                {
                    command.Parameters.Add("@tomege", SqlDbType.Int).Value = int.Parse(TextBoxTomeg.Text);
                }
                else
                {
                    command.Parameters.Add("@tomege", SqlDbType.Int).Value = DBNull.Value;
                }

                command.Parameters.Add("@soforneve", SqlDbType.Int).Value = Soforneve;
                command.Parameters.Add("@utasneve", SqlDbType.SmallInt).Value = Utassneve;
                command.Parameters.Add("@datum", SqlDbType.DateTime).Value = DateParse(TextBoxDatum.Text + " " + TextBoxIdopont.Text);
                if (TextBoxIrany.Text == "Bejövő")
                {
                    command.Parameters.Add("@behivasdatuma", SqlDbType.DateTime).Value = DateParse(TextBoxBehivasDatum.Text + " " + TextBoxBehivasIdopont.Text);
                }
                else
                {

                    command.Parameters.Add("@behivasdatuma", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (TextBoxRampa.Text == "")
                {
                    command.Parameters.Add("@rampa", SqlDbType.Float).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@rampa", SqlDbType.Float).Value = float.Parse(TextBoxRampa.Text);
                }
                if (Szallirtmanyozofovallakozo.Text == "Szállítmányozó (Fővállalkozó) Elérhetőség:")
                {
                    command.Parameters.Add("@fovallalkozo", SqlDbType.NChar).Value = DBNull.Value;
                    command.Parameters.Add("@elerhetoseg", SqlDbType.NChar).Value = fovalalkozo.ToString();
                }
                else
                {
                    command.Parameters.Add("@fovallalkozo", SqlDbType.NChar).Value = fovalalkozo.ToString();
                    command.Parameters.Add("@elerhetoseg", SqlDbType.NChar).Value = DBNull.Value;
                }




                if (alvalakozo.ToString() == "" || alvalakozo.ToString() == "-1")
                {
                    command.Parameters.Add("@alvalalkozo", SqlDbType.NChar).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@alvalalkozo", SqlDbType.NChar).Value = alvalakozo.ToString();
                }

                if (TextBoxBeszallito.Text == "")
                {
                    command.Parameters.Add("@beszallito", SqlDbType.NChar).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@beszallito", SqlDbType.NChar).Value = TextBoxBeszallito.Text.ToString();
                }

                command.Parameters.Add("@hanydarabottszallit", SqlDbType.Int).Value = alvalakozo;
                command.Parameters.Add("@szalitolevelCMR", SqlDbType.VarChar).Value = TextBox7.Text.ToString();
                command.Parameters.Add("@plombaszam", SqlDbType.VarChar).Value = TextBoxPlombaSzam.Text.ToString();
                command.Parameters.Add("@egyebbazonosito", SqlDbType.VarChar).Value = TextBox8.Text.ToString();


                if (DropDownListVamaru.Text == "1")
                {
                    command.Parameters.Add("@vamaru", SqlDbType.Bit).Value = 1;
                }
                else
                {
                    command.Parameters.Add("@vamaru", SqlDbType.Bit).Value = 0;
                }






                if (DropDownListVamaruSerult.SelectedValue == "1")
                {
                    command.Parameters.Add("@vamaruserult", SqlDbType.Bit).Value = 1;
                }
                else
                {
                    command.Parameters.Add("@vamaruserult", SqlDbType.Bit).Value = 0;
                }




                command.Parameters.Add("@ellenorzestvegezte", SqlDbType.NChar).Value = ellenorzestvegezte;
                command.Parameters.Add("@ellenorzesmodja", SqlDbType.NChar).Value = TextBoxEllenorzesModja.Text;
                command.Parameters.Add("@megjegyzes", SqlDbType.NChar).Value = TextBoxMegjegyzes.Text.ToString();
                command.Parameters.Add("@Azonosito", SqlDbType.Int).Value = azonosito;
                command.Parameters.Add("@ures", SqlDbType.Bit).Value = ures;
                command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;

                con.Open();
                command.ExecuteNonQuery();
                con.Close();


            }
            //a plusz sor feltoltes!


            if (TextBoxIrany.Text == "Bejövő")
            {

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@vontatorendszam", SqlDbType.Int).Value = vontatorendszam;
                    command.Parameters.Add("@potkocsirendszam", SqlDbType.Int).Value = DBNull.Value;
                    command.Parameters.Add("@lokacio", SqlDbType.Int).Value = lokacio;
                    command.Parameters.Add("@befele", SqlDbType.Bit).Value = 0;
                    command.Parameters.Add("@tomege", SqlDbType.Int).Value = DBNull.Value;
                    command.Parameters.Add("@soforneve", SqlDbType.Int).Value = DBNull.Value;
                    command.Parameters.Add("@utasneve", SqlDbType.SmallInt).Value = DBNull.Value;
                    command.Parameters.Add("@datum", SqlDbType.DateTime).Value = DBNull.Value;
                    command.Parameters.Add("@behivasdatuma", SqlDbType.DateTime).Value = DBNull.Value;
                    command.Parameters.Add("@rampa", SqlDbType.Float).Value = DBNull.Value;
                    command.Parameters.Add("@fovallalkozo", SqlDbType.NChar).Value = DBNull.Value;
                    command.Parameters.Add("@alvalalkozo", SqlDbType.Int).Value = DBNull.Value;
                    command.Parameters.Add("@beszallito", SqlDbType.NChar).Value = DBNull.Value;
                    command.Parameters.Add("@szalitolevelCMR", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@plombaszam", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@egyebbazonosito", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@vamaru", SqlDbType.Bit).Value = DBNull.Value;
                    command.Parameters.Add("@vamaruserult", SqlDbType.Bit).Value = DBNull.Value;
                    command.Parameters.Add("@ellenorzestvegezte", SqlDbType.NChar).Value = DBNull.Value;
                    command.Parameters.Add("@ellenorzesmodja", SqlDbType.NChar).Value = DBNull.Value;
                    command.Parameters.Add("@megjegyzes", SqlDbType.NChar).Value = DBNull.Value;
                    command.Parameters.Add("@Azonosito", SqlDbType.Int).Value = azonosito;
                    command.Parameters.Add("@ures", SqlDbType.Int).Value = DBNull.Value;
                    command.Parameters.Add("@elerhetoseg", SqlDbType.VarChar).Value = DBNull.Value;
                    command.Parameters.Add("@userid", SqlDbType.Int).Value = DBNull.Value;
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();


                }
            }




        }





        SqlDataReader dataReader;

        if (ures == 0)
        {




            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {

                query = "SELECT id, befele, lokacio FROM dbo.Kamionkezelo WHERE (befele = 1) AND (lokacio = " + lokacio + ") ORDER BY id DESC";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        KamionkezeloID = dataReader[0].ToString();
                    }

                }
            }





            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
            {
                i = 0;
                string[] stringArray = new string[10];
                string[] intArray = new string[10];
                foreach (Control ctrl in PlaceHolder1.Controls)
                {

                    if (ctrl is TextBox)
                    {
                        TextBox actualtextbox1 = (TextBox)ctrl;
                        if (actualtextbox1.Text.ToString() != "")
                        {

                            stringArray[i] = actualtextbox1.Text.ToString();
                            i = i + 1;
                        }
                    }

                }
                i = 0;

                foreach (Control cmb in PlaceHolder2.Controls)
                {

                    if (cmb is DropDownList)
                    {
                        if (cmb.Visible == true)
                        {
                            DropDownList cmbdrop = (DropDownList)cmb;
                            intArray[i] = cmbdrop.SelectedValue.ToString();
                            i = i + 1;
                        }

                    }
                    if (cmb is TextBox)
                    {
                        if (cmb.Visible == true)
                        {
                            TextBox textboxcmbr = (TextBox)cmb;
                            intArray[i] = Feltoltes("SELECT id,megnevezes  FROM [RBHM_LOG-T].[dbo].[mitszallit]   WHERE (megnevezes = @bemenoadat);", "insert into  [RBHM_LOG-T].[dbo].[mitszallit](megnevezes) values(@bemenoadat);", textboxcmbr.Text.Trim());
                            i = i + 1;
                        }

                    }


                }
                i = 0;
                foreach (string item in stringArray)
                {
                    try
                    {
                        int test = int.Parse(intArray[i]);
                        if (test != 0)
                        {


                            query = "INSERT INTO [RBHM_LOG-T].[dbo].[KamionkezeloMennyiseg](KamionkezeloID,hanydarabottszallit,mitszallit) VALUES  (@KamionkezeloID,@hanydarabottszallit,@mitszallit)";
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                command.Parameters.Add("@KamionkezeloID", SqlDbType.Int).Value = KamionkezeloID;
                                command.Parameters.Add("@hanydarabottszallit", SqlDbType.Int).Value = stringArray[i];
                                command.Parameters.Add("@mitszallit", SqlDbType.Int).Value = int.Parse(intArray[i]);
                                con.Open();
                                command.ExecuteNonQuery();
                                con.Close();

                            }
                        }
                        i = i + 1;
                    }
                    catch (Exception)
                    {
                        break;
                    }


                }




            }
        }



        GridView1.DataBind();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
        GridView1.DataBind();
        string script = "alert(\"Adatok mentése megtörtént!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);

    }




    public static DateTime DateParse(string date)
    {
        date = date.Trim();
        if (!string.IsNullOrEmpty(date))
            return DateTime.Parse(date, new System.Globalization.CultureInfo("en-GB"));
        return new DateTime();
    }
    protected void rendszamkeresbe(object sender)
    {
        string feltetel = "";
        if (alluserid != "")
        {
            feltetel = "[userid] ='" + alluserid + "' and";
        }


        Label4.Text = "A kamion már szerepel a telphelyen, adatai:";
        TextBox kontroll = (TextBox)sender;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = @"SELECT * FROM dbo.Kamionkezelo_BE INNER JOIN dbo.Kamionkezelo_KI ON dbo.Kamionkezelo_BE.Azonosito = dbo.Kamionkezelo_KI.Azonosito AND dbo.Kamionkezelo_BE.[VONTATÓ RENDSZÁMA] = dbo.Kamionkezelo_KI.[VONTATÓ RENDSZÁMA]  WHERE " + feltetel + "( dbo.Kamionkezelo_BE.[VONTATÓ RENDSZÁMA] = '" + kontroll.Text.ToString() + "') AND (dbo.Kamionkezelo_KI.[Érkezés/Távozás Dátuma] IS NULL) AND (dbo.Kamionkezelo_BE.[Érkezés/Távozás Dátuma] IS NOT NULL) and (dbo.Kamionkezelo_BE.[torolve] IS NULL)  ORDER BY dbo.Kamionkezelo_BE.[Érkezés/Távozás Dátuma] DESC";


            using (SqlCommand command = new SqlCommand(query, con))
            {
                SqlDataReader dataReader;
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {



                    LabelVontatoRendszam.Text = dataReader["VONTATÓ RENDSZÁMA"].ToString();
                    LabelPotkocsiRendszam.Text = dataReader["PÓTKOCSI RENDSZÁMA"].ToString();
                    LabelIrany.Text = "Befelé";
                    LabelSoforneve.Text = dataReader["Soför Neve"].ToString();
                    LabelUtasNeve.Text = dataReader["Utas Neve"].ToString();
                    LabelerkezesDatuma0.Text = dataReader[6].ToString().Substring(0, 10);
                    LabelerkezesIdopontja0.Text = dataReader[6].ToString().Substring(dataReader[6].ToString().Length - 8, 5);
                    Labelrampa.Text = dataReader["RÁMPA"].ToString();
                    LabelTomeg.Text = dataReader[17].ToString();
                    LabelFovalalkozo0.Text = dataReader[8].ToString();
                    LabelAlvalakozo0.Text = dataReader["FUVAROZÓ (Alvállalkozó)"].ToString();
                    //  LabelBeszallito0.Text = dataReader["BESZÁLLÍTÓ"].ToString();
                    CMRSzam.Text = dataReader["SZÁLLÍTÓLEVÉL / CMR"].ToString();
                    PlombaSzam.Text = dataReader["PLOMBA-SZÁM"].ToString();
                    Labelegyebb.Text = dataReader["SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ"].ToString();
                    LabelVAmjog.Text = dataReader["SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)"].ToString();
                    LabelVamSerult.Text = dataReader["VÁMZÁR SÉRÜLT-E (sérült / nem)"].ToString();
                    LabelEllenorzestVegezte.Text = dataReader["Ellenörzést Végezte"].ToString();
                    EllenorzesModjka.Text = dataReader["ELLENŐRZÉS MÓDJA"].ToString();
                    LabelMegjegyzes.Text = dataReader[22].ToString();
                    LabelLokaciokimeno.Text = dataReader["Lokáció"].ToString();
                    LabelLokaciokimeno.Text = dataReader["Lokáció"].ToString();
                    LabelBeszallito0.Text = dataReader["beszallito"].ToString();
                    SqlDataSource9.FilterExpression = "KamionkezeloID =" + dataReader["id"].ToString();

                    GridView2.Visible = true;
                    GridView2.DataBind();
                    return;
                }
                else
                {
                    Label4.Visible = false;
                    adat1.Visible = false;
                    adat2.Visible = false;
                    adat3.Visible = false;
                    adat4.Visible = false;
                    adat5.Visible = false;
                    adat7.Visible = false;
                    adat8.Visible = false;
                    adat9.Visible = false;
                    adat10.Visible = false;
                    adat11.Visible = false;

                    adat13.Visible = false;
                    adat14.Visible = false;
                    adat15.Visible = false;
                    adat16.Visible = false;
                    adat17.Visible = false;
                    adat18.Visible = false;

                    adat20.Visible = false;
                    adat21.Visible = false;
                    adat22.Visible = false;
                    adat22.Visible = false;
                    adat23.Visible = false;
                    adat24.Visible = false;
                    adat25.Visible = false;
                    adat26.Visible = false;
                    adat27.Visible = false;
                    adat28.Visible = false;

                }

            }

        }




    }

    protected void rendszamkereski(object sender)
    {
        string feltetel = "";
        if (alluserid != "")
        {
            feltetel = "[userid] ='" + alluserid + "' and";
        }



        Label4.Text = "Bentlővő kamion adatok:";
        TextBox kontroll = (TextBox)sender;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {

            string query = @"SELECT * FROM dbo.Kamionkezelo_BE INNER JOIN dbo.Kamionkezelo_KI ON dbo.Kamionkezelo_BE.Azonosito = dbo.Kamionkezelo_KI.Azonosito AND dbo.Kamionkezelo_BE.[VONTATÓ RENDSZÁMA] = dbo.Kamionkezelo_KI.[VONTATÓ RENDSZÁMA]  WHERE " + feltetel + "( dbo.Kamionkezelo_BE.[VONTATÓ RENDSZÁMA] = '" + kontroll.Text.ToString() + "') AND (dbo.Kamionkezelo_KI.[Érkezés/Távozás Dátuma] IS NULL) AND (dbo.Kamionkezelo_BE.[Érkezés/Távozás Dátuma] IS NOT NULL) and (dbo.Kamionkezelo_BE.[torolve] IS NULL)  ORDER BY dbo.Kamionkezelo_BE.[Érkezés/Távozás Dátuma] DESC";


            using (SqlCommand command = new SqlCommand(query, con))
            {
                SqlDataReader dataReader;
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {



                    LabelVontatoRendszam.Text = dataReader["VONTATÓ RENDSZÁMA"].ToString();
                    LabelPotkocsiRendszam.Text = dataReader["PÓTKOCSI RENDSZÁMA"].ToString();
                    LabelIrany.Text = "Befelé";
                    LabelSoforneve.Text = dataReader["Soför Neve"].ToString();
                    LabelUtasNeve.Text = dataReader["Utas Neve"].ToString();
                    LabelerkezesDatuma0.Text = dataReader[6].ToString().Substring(0, 10);
                    LabelerkezesIdopontja0.Text = dataReader[6].ToString().Substring(dataReader[6].ToString().Length - 8, 5);
                    Labelrampa.Text = dataReader["RÁMPA"].ToString();
                    LabelTomeg.Text = dataReader[17].ToString();
                    LabelFovalalkozo0.Text = dataReader[8].ToString();
                    LabelAlvalakozo0.Text = dataReader["FUVAROZÓ (Alvállalkozó)"].ToString();
                    //  LabelBeszallito0.Text = dataReader["BESZÁLLÍTÓ"].ToString();
                    CMRSzam.Text = dataReader["SZÁLLÍTÓLEVÉL / CMR"].ToString();
                    PlombaSzam.Text = dataReader["PLOMBA-SZÁM"].ToString();
                    Labelegyebb.Text = dataReader["SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ"].ToString();
                    LabelVAmjog.Text = dataReader["SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)"].ToString();
                    LabelVamSerult.Text = dataReader["VÁMZÁR SÉRÜLT-E (sérült / nem)"].ToString();
                    LabelEllenorzestVegezte.Text = dataReader["Ellenörzést Végezte"].ToString();
                    EllenorzesModjka.Text = dataReader["ELLENŐRZÉS MÓDJA"].ToString();
                    LabelMegjegyzes.Text = dataReader[22].ToString();
                    LabelLokaciokimeno.Text = dataReader["Lokáció"].ToString();
                    LabelLokaciokimeno.Text = dataReader["Lokáció"].ToString();
                    LabelBeszallito0.Text = dataReader["beszallito"].ToString();
                    SqlDataSource9.FilterExpression = "KamionkezeloID =" + dataReader["id"].ToString();

                    GridView2.Visible = true;
                    GridView2.DataBind();
                    return;
                }

            }

        }

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = @"SELECT * FROM dbo.Kamionkezelo_BE INNER JOIN dbo.Kamionkezelo_KI ON dbo.Kamionkezelo_BE.Azonosito = dbo.Kamionkezelo_KI.Azonosito AND dbo.Kamionkezelo_BE.[VONTATÓ RENDSZÁMA] = dbo.Kamionkezelo_KI.[VONTATÓ RENDSZÁMA] WHERE " + feltetel + "( dbo.Kamionkezelo_BE.[VONTATÓ RENDSZÁMA] = '" + kontroll.Text.ToString() + "') and (dbo.Kamionkezelo_BE.[Érkezés/Távozás Dátuma] IS not NULL) AND (dbo.Kamionkezelo_BE.[Érkezés/Távozás Dátuma] IS not NULL) ORDER BY dbo.Kamionkezelo_BE.[Érkezés/Távozás Dátuma]";




            using (SqlCommand command = new SqlCommand(query, con))
            {
                SqlDataReader dataReader;
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {

                    LabelVontatoRendszam.Text = "Ez a rendszám már távozott a telephelyről!";
                    LabelPotkocsiRendszam.Text = "";
                    LabelIrany.Text = "";
                    LabelSoforneve.Text = "";
                    LabelUtasNeve.Text = "";
                    LabelerkezesDatuma0.Text = "";
                    LabelerkezesIdopontja0.Text = "";
                    Labelrampa.Text = "";
                    LabelTomeg.Text = "";
                    LabelFovalalkozo0.Text = "";
                    LabelAlvalakozo0.Text = "";
                    CMRSzam.Text = "";
                    PlombaSzam.Text = "";
                    Labelegyebb.Text = "";
                    LabelVAmjog.Text = "";
                    LabelVamSerult.Text = "";
                    LabelEllenorzestVegezte.Text = "";
                    EllenorzesModjka.Text = "";
                    LabelMegjegyzes.Text = "";
                    LabelLokaciokimeno.Text = "";
                    LabelLokaciokimeno.Text = "";
                    LabelBeszallito0.Text = "";
                    return;
                }

                else
                {
                    LabelVontatoRendszam.Text = "Nincs ilyen kamion a telephelyen. Kérlek ellenőrizd a rendszámot!";
                    LabelPotkocsiRendszam.Text = "";
                    LabelIrany.Text = "";
                    LabelSoforneve.Text = "";
                    LabelUtasNeve.Text = "";
                    LabelerkezesDatuma0.Text = "";
                    LabelerkezesIdopontja0.Text = "";
                    Labelrampa.Text = "";
                    LabelTomeg.Text = "";
                    LabelFovalalkozo0.Text = "";
                    LabelAlvalakozo0.Text = "";
                    CMRSzam.Text = "";
                    PlombaSzam.Text = "";
                    Labelegyebb.Text = "";
                    LabelVAmjog.Text = "";
                    LabelVamSerult.Text = "";
                    LabelEllenorzestVegezte.Text = "";
                    EllenorzesModjka.Text = "";
                    LabelMegjegyzes.Text = "";
                    LabelLokaciokimeno.Text = "";
                    LabelLokaciokimeno.Text = "";
                    LabelBeszallito0.Text = "";
                    return;
                }


            }
        }








    }


















    protected void Button2_Click(object sender, EventArgs e)
    {

        TextBoxDatum.Text = DateTime.Today.ToString("yyyy.MM.dd");

    }

    protected void Button4_Click1(object sender, EventArgs e)
    {
        TextBoxBehivasDatum.Text = DateTime.Today.ToString("yyyy.MM.dd");
    }



    protected void idopont(object sender, EventArgs e)
    {
        TextBoxBehivasIdopont.Text = DateTime.Now.ToString("HH:mm");
    }

    protected void SqlDataSource5_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }



    protected void DropDownListIrany_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DropDownListIrany.SelectedValue == "2")
        //{
        //    LabelLokacio.Text = "Lokáció(Honnan indul)::";
        //    LabelDatum.Text = "Távozás dátuma:";
        //    LabelIdopont.Text = "Távozás Időpontja:";
        //    trBehivasDatuma.Visible = false;
        //    trBehivasidopontja.Visible = false;

        //    test.RowSpan = 2;
        //    Td1.RowSpan = 2;
        //    LabelCMR.Text = "Szállítólevél / CMR Száma(Befelé):";
        //    LabelPlomba.Text = "Plomba-szám (Kifelé)";
        //    LabelCMR.Text = "Szállítólevél / CMR (Kifelé):";



        //}
        //else
        //{
        //    LabelLokacio.Text = "Lokáció(Hová érkezik):";
        //    LabelIdopont.Text = "Érkezés Időpontja:";
        //    trBehivasDatuma.Visible = true;
        //    trBehivasidopontja.Visible = true;


        //    test.RowSpan = 4;
        //    Td1.RowSpan = 4;
        //    LabelCMR.Text = "Szállítólevél / CMR (Kifelé):";


        //    LabelCMR.Text = "Szállítólevél / CMR Száma(Befelé):";
        //    LabelPlomba.Text = "Plomba-szám (Befelé)";
        //}
    }
    protected void idopont2(object sender, EventArgs e)
    {
        TextBoxIdopont.Text = DateTime.Now.ToString("HH:mm");
    }
    protected void DropDownListVamaru_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListVamaru.SelectedValue == "1")
        {
            trvamaru.Visible = true;
            tdBejovo.RowSpan = 5;
            td2.RowSpan = 5;
        }
        else
        {
            trvamaru.Visible = false;
            tdBejovo.RowSpan = 4;
            td2.RowSpan = 4;
        }
    }

    protected void DropDownListFovalalkozo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListFovalalkozo.SelectedValue == "-2")
        {
            DropDownListFovalalkozo.Visible = false;
            TextBoxFovalalkozo.Visible = true;
        }
        if (DropDownListFovalalkozo.SelectedValue == "-3")
        {
            DropDownListFovalalkozo.Visible = false;
            TextBoxFovalalkozo.Visible = true;
            Szallirtmanyozofovallakozo.Text = "Szállítmányozó (Fővállalkozó) Elérhetőség:";
        }
    }
    protected void DropDownListAlvallalkozo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListAlvallalkozo.SelectedValue == "-2")
        {
            DropDownListAlvallalkozo.Visible = false;
            TextBoxAllvalalkozo.Visible = true;
        }
    }

    protected void Button11_Click1(object sender, EventArgs e)
    {






    }



    private List<string> ControlList
    {
        get
        {


            if (ViewState["controls"] == null)
            {
                ViewState["controls"] = new List<string>();
            }
            return (List<string>)ViewState["controls"];
        }
    }

    private int NextID
    {
        get
        {
            return ControlList.Count + 1;
        }


    }

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
    }

    protected override void LoadViewState(object savedState)
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString);
        //SqlCommand cmd = new SqlCommand("SELECT '- 1' AS Expr1, '  Kérlek válasz egyet!' AS Expr2 UNION ALL SELECT - 2 AS Expr1, ' Egyéb' AS Expr2 UNION ALL SELECT id, megnevezes FROM mitszallit ORDER BY Expr2", con);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);

        //DataTable dt = new DataTable();
        //da.Fill(dt);



        //base.LoadViewState(savedState);

        //TextBox textBox = PlaceHolder1.FindControl("TextBox1") as TextBox;

        //foreach (string txtID in ControlList)
        //{
        //    TextBox txt = new TextBox();
        //    txt.ID = txtID;
        //    PlaceHolder1.Controls.Add(txt);
        //    PlaceHolder1.Controls.Add(new LiteralControl("<br>"));
        //}

        //foreach (string txtID2 in ControlList)
        //{
        //    TextBox txt2 = new TextBox();
        //    txt2.ID = txtID2 + txtID2 + txtID2 + txtID2;
        //    txt2.Visible = false;
        //    PlaceHolder3.Controls.Add(txt2);
        //    PlaceHolder3.Controls.Add(new LiteralControl("<br>"));

        //}

        //int szam = PlaceHolder1.Controls.Count;

        //szam = szam - 2;




        //foreach (string dlID in ControlList)
        //{
        //    DropDownList dl = new DropDownList();
        //    dl.ID = dlID + dlID;
        //    dl.AutoPostBack = true;
        //    dl.CssClass = "bevitelimezo";
        //    dl.DataTextField = "Expr2";
        //    dl.DataValueField = "Expr1";
        //    // dl.SelectedIndex =
        //    dl.DataSource = dt;

        //    dl.SelectedIndexChanged += new EventHandler(Button11_Click);
        //    dl.DataBind();

        //    PlaceHolder2.Controls.Add(dl);
        //    PlaceHolder2.Controls.Add(new LiteralControl("<br>"));


        //}

    }

    protected void Button11_Click(object sender, EventArgs e)
    {



        //DropDownList cmb = (DropDownList)sender;
        //string selectedIndex = cmb.SelectedValue;
        //string tex = cmb.ID;
        //if (selectedIndex == "-2")
        //{

        //    TextBox textBox = PlaceHolder2.FindControl(cmb.ID + cmb.ID) as TextBox;
        //    textBox.Visible = true;
        //    cmb.Visible = false;


        //}



    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {

        Response.Clear();

        Response.Buffer = true;



        Response.AddHeader("content-disposition",

        "attachment;filename=GridViewExport.xls");

        Response.Charset = "";

        Response.ContentType = "application/vnd.ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);



        GridView1.AllowPaging = false;

        // GridView1.DataBind();



        //Change the Header Row back to whiteSystem.Drawing.Color.

        //  GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");



        //Apply style to Individual Cells

        //GridView1.HeaderRow.Cells[0].Style.Add("background-color", "green");

        //GridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");

        //GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");

        //GridView1.HeaderRow.Cells[3].Style.Add("background-color", "green");



        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            GridViewRow row = GridView1.Rows[i];





            //Apply text style to each Row

            row.Attributes.Add("class", "textmode");



            //Apply style to Individual Cells of Alternating Row

            if (i % 2 != 0)
            {

                row.Cells[0].Style.Add("background-color", "#C2D69B");

                row.Cells[1].Style.Add("background-color", "#C2D69B");

                row.Cells[2].Style.Add("background-color", "#C2D69B");

                row.Cells[3].Style.Add("background-color", "#C2D69B");

            }

        }

        GridView1.RenderControl(hw);



        //style to format numbers to string

        string style = @"<style> .textmode { mso-number-format:\@; } </style>";

        Response.Write(style);

        Response.Output.Write(sw.ToString());

        Response.Flush();

        Response.End();





        //DataSourceSelectArguments args = new DataSourceSelectArguments();
        //DataView view = (DataView)Tábla.Select(args);

        //using (DataTable dt = view.ToTable())
        //{



        //    var csv = new StringBuilder();
        //    for (int i = 0; i < dt.Columns.Count; i++)
        //    {
        //        csv.Append(dt.Columns[i].ColumnName);
        //        csv.Append(i == dt.Columns.Count - 1 ? "\n" : ";");
        //    }

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            csv.Append(row[i].ToString());
        //            csv.Append(i == dt.Columns.Count - 1 ? "\n" : ";");
        //        }
        //    }




        //    //Download the CSV file.
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
        //    Response.Charset = "";
        //    Response.ContentType = "application/text";
        //    Response.Output.Write(csv);
        //    Response.Flush();
        //    Response.End();
        //}

    }
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.AllowPaging = false;
        GridView1.DataBind();
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    protected void btnExportCSV_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";

        GridView1.AllowPaging = false;


        StringBuilder sb = new StringBuilder();
        for (int k = 0; k < GridView1.Columns.Count; k++)
        {
            //add separator
            sb.Append(GridView1.Columns[k].HeaderText + ',');
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int k = 0; k < GridView1.Columns.Count; k++)
            {
                //add separator
                sb.Append(GridView1.Rows[i].Cells[k].Text + ',');
            }
            //append new line
            sb.Append("\r\n");
        }
        Response.Output.Write(sb.ToString());
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {


        /* Verifies that the control is rendered */
    }


    protected void ButtonBefele_Click(object sender, EventArgs e)
    {
        Label4.Visible = false;
        adat1.Visible = false;
        adat2.Visible = false;
        adat3.Visible = false;
        adat4.Visible = false;
        adat5.Visible = false;
        adat7.Visible = false;
        adat8.Visible = false;
        adat9.Visible = false;
        adat10.Visible = false;
        adat11.Visible = false;
        adat13.Visible = false;
        adat14.Visible = false;
        adat15.Visible = false;
        adat16.Visible = false;
        adat17.Visible = false;
        adat18.Visible = false;
        adat20.Visible = false;
        adat21.Visible = false;
        adat22.Visible = false;
        adat23.Visible = false;
        adat24.Visible = false;
        adat25.Visible = false;
        adat26.Visible = false;
        adat27.Visible = false;
        adat28.Visible = false;

        LabelLokacio.Text = "Lokáció(Hová érkezik):";
        LabelIdopont.Text = "Érkezés Időpontja:";
        trBehivasDatuma.Visible = true;
        trBehivasidopontja.Visible = true;


        test.RowSpan = 4;
        Td1.RowSpan = 4;
        LabelCMR.Text = "Szállítólevél / CMR (Kifelé):";


        LabelCMR.Text = "Szállítólevél / CMR Száma(Befelé):";
        LabelPlomba.Text = "Plomba-szám (Befelé)";
















        System.Web.UI.HtmlControls.HtmlGenericControl MasterBody = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("MasterBody");
        MasterBody.Attributes.Add("style", "background-color: #fce4d6");
        UpdatePanel2.Visible = true;
        Button1.Visible = true;
        TextBoxIrany.Text = "Bejövő";


        Fejresz.Text = "Bejövő:";


    }
    protected void ButtonKifele_Click(object sender, EventArgs e)
    {
        Label4.Visible = false;
        adat1.Visible = false;
        adat2.Visible = false;
        adat3.Visible = false;
        adat4.Visible = false;
        adat5.Visible = false;
        adat7.Visible = false;
        adat8.Visible = false;
        adat9.Visible = false;
        adat10.Visible = false;
        adat11.Visible = false;
        adat13.Visible = false;
        adat14.Visible = false;
        adat15.Visible = false;
        adat16.Visible = false;
        adat17.Visible = false;
        adat18.Visible = false;
        adat20.Visible = false;
        adat21.Visible = false;
        adat22.Visible = false;
        adat23.Visible = false;
        adat24.Visible = false;
        adat25.Visible = false;
        adat26.Visible = false;
        adat27.Visible = false;
        adat28.Visible = false;
        System.Web.UI.HtmlControls.HtmlGenericControl MasterBody = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("MasterBody");
        MasterBody.Attributes.Add("style", "background-color: #a3d89c");
        UpdatePanel2.Visible = true;
        Button1.Visible = true;

        Fejresz.Text = "Kimenő:";
        TextBoxIrany.Text = "Kimenő";


        LabelLokacio.Text = "Lokáció(Honnan indul)::";
        LabelDatum.Text = "Távozás dátuma:";
        LabelIdopont.Text = "Távozás Időpontja:";
        trBehivasDatuma.Visible = false;
        trBehivasidopontja.Visible = false;

        test.RowSpan = 2;
        Td1.RowSpan = 2;
        LabelPlomba.Text = "Plomba-szám (Kifelé)";
        LabelCMR.Text = "Szállítólevél / CMR (Kifelé):";



    }
    protected void TextBoxVontatoRendszam_TextChanged(object sender, EventArgs e)
    {
        TextBoxVontatoRendszam.Text = TextBoxVontatoRendszam.Text.ToString().ToUpper();
        Label4.Visible = true;
        adat1.Visible = true;
        adat2.Visible = true;
        adat3.Visible = true;
        adat4.Visible = true;
        adat5.Visible = true;
        adat7.Visible = true;
        adat8.Visible = true;
        adat9.Visible = true;
        adat10.Visible = true;
        adat11.Visible = true;

        adat13.Visible = true;
        adat14.Visible = true;
        adat15.Visible = true;
        adat16.Visible = true;
        adat17.Visible = true;
        adat18.Visible = true;

        adat20.Visible = true;
        adat21.Visible = true;
        adat22.Visible = true;
        adat22.Visible = true;
        adat23.Visible = true;
        adat24.Visible = true;
        adat25.Visible = true;
        adat26.Visible = true;
        adat27.Visible = true;
        adat28.Visible = true;




        if (TextBoxIrany.Text == "Kimenő")
        {

            rendszamkereski(sender);



        }
        if (TextBoxIrany.Text == "Bejövő")
        {

            rendszamkeresbe(sender);
        }
        if (TextBoxVontatoRendszam.Text == "")
        {

            Label4.Visible = false;
            adat1.Visible = false;
            adat2.Visible = false;
            adat3.Visible = false;
            adat4.Visible = false;
            adat5.Visible = false;
            adat7.Visible = false;
            adat8.Visible = false;
            adat9.Visible = false;
            adat10.Visible = false;
            adat11.Visible = false;

            adat13.Visible = false;
            adat14.Visible = false;
            adat15.Visible = false;
            adat16.Visible = false;
            adat17.Visible = false;
            adat18.Visible = false;

            adat20.Visible = false;
            adat21.Visible = false;
            adat22.Visible = false;
            adat22.Visible = false;
            adat23.Visible = false;
            adat24.Visible = false;
            adat25.Visible = false;
            adat26.Visible = false;
            adat27.Visible = false;
            adat28.Visible = false;
        }



    }




    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowIndex == 0)
        {
            e.Row.Cells[0].ColumnSpan = 6;
            e.Row.Cells[1].ColumnSpan = 3;
            e.Row.Cells[2].ColumnSpan = 5;
            e.Row.Cells[3].ColumnSpan = 1;
            e.Row.Cells[4].ColumnSpan = 5;
            e.Row.Cells[5].ColumnSpan = 3;
            e.Row.Cells[6].ColumnSpan = 2;
            if (alluserid != "")
            {
                e.Row.Cells[7].ColumnSpan = 2;
            }
            else
            {
                e.Row.Cells[7].ColumnSpan = 3;
            }










            for (int i = 9; i < GridView1.Columns.Count; i++)
            {
                e.Row.Cells[i].Visible = false;

            }
        }


        if (e.Row.RowIndex == 1)
        {
            e.Row.Cells[0].ColumnSpan = 2;
        }

        if (e.Row.RowIndex == 1)
        {
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                e.Row.Cells[i].Text = "Információ";
            }
            e.Row.Cells[GridView1.Columns.Count - 1].Visible = false;


        }


    }
    string[] stringArray = new string[37];

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     



        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                stringArray[i] = GridView1.Columns[i].HeaderText;
            }

        }
        if (e.Row.RowIndex == 2)
        {
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                e.Row.Cells[i].Text = stringArray[i];

            }
        }



        if (e.Row.RowIndex == 0)
        {
            e.Row.Cells[0].Text = "BEÉRKEZŐ GÉPJÁRMŰ ADATAI";
            e.Row.Cells[1].Text = "IDŐPONTOK";
            e.Row.Cells[2].Text = "FUVARRA VONATKOZÓ ADATOK";
            e.Row.Cells[3].Text = "BEJÖVŐ DARABSZÁM ADATOK";
            e.Row.Cells[4].Text = "BEJÖVŐ SZÁLLÍTMÁNY AZONOSÍTÓK";
            e.Row.Cells[5].Text = "TÁVOZÁS";
            e.Row.Cells[6].Text = "KIMENŐ SZÁLLÍTMÁNY AZONOSÍTÓK";
            e.Row.Cells[7].Text = "EGYÉB ADATOK";
            e.Row.Cells[8].Text = "Törlés!";
            e.Row.BackColor = System.Drawing.Color.FromName("#0070c0");
            e.Row.HorizontalAlign = HorizontalAlign.Center;
            e.Row.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[5].BackColor = System.Drawing.Color.FromName("#00b050");
            e.Row.Cells[6].BackColor = System.Drawing.Color.FromName("#00b050");
            e.Row.Cells[7].BackColor = System.Drawing.Color.FromName("#e26b0a");
        }
        if (e.Row.RowIndex == 1)
        {
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                e.Row.Cells[i].Text = "Információ";
            }

            e.Row.BackColor = System.Drawing.Color.FromName("#999999");
            e.Row.HorizontalAlign = HorizontalAlign.Center;
            e.Row.ForeColor = System.Drawing.Color.White;

        }


        if (e.Row.RowIndex > 1)
        {
            e.Row.Cells[5].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[8].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[13].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[14].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[19].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[22].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[24].Style.Add("BORDER-RIGHT", "#000000 3px solid");
        }

        if (e.Row.RowIndex == 1)
        {
            e.Row.Cells[4].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[7].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[12].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[13].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[18].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[21].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[23].Style.Add("BORDER-RIGHT", "#000000 3px solid");
        }


        if (e.Row.RowIndex < 1)
        {
            e.Row.Cells[0].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[1].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[2].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[3].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[4].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[5].Style.Add("BORDER-RIGHT", "#000000 3px solid");
            e.Row.Cells[6].Style.Add("BORDER-RIGHT", "#000000 3px solid");
        }



        if (e.Row.RowIndex > 2)
        {
            for (int i = 6; i < 9; i++)
            {
                e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#f2dcdb");


            }
    for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                e.Row.Cells[i].CssClass = "nowrap";
            }
        }

        if (e.Row.RowIndex == 2)
        {
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                e.Row.Cells[i].Text = stringArray[i];

            }

            for (int i = 0; i < 8; i++)
            {
                e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#00b0f0");
            }
            for (int i = 9; i < 10; i++)
            {
                e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#92d050");
            }

            for (int i = 20; i < 25; i++)
            {
                e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#92d050");
            }
            for (int i = 25; i < 28; i++)
            {
                e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#fabf8f");
            }


            e.Row.BackColor = System.Drawing.Color.FromName("#00B0F0");
            e.Row.HorizontalAlign = HorizontalAlign.Center;
            e.Row.ForeColor = System.Drawing.Color.White;
        }
    }

    protected void torlogomb_Click1(object sender, EventArgs e)
    {

    }








    protected void Button3_Click1(object sender, EventArgs e)
    {
        foreach (Control cnt in PlaceHolder1.Controls)
        {
            if (cnt is TextBox)
            {
                TextBox actualtextbox1 = (TextBox)cnt;
                if (actualtextbox1.Visible == true)
                {

                    if (!Regex.IsMatch(actualtextbox1.Text.ToString().Trim(), @"^\d+$"))
                    {
                        LabelHiba.Text = "Csak szám lehet!";
                        return;
                    }
                    else
                    {
                        LabelHiba.Text = "";
                    }

                }
            }
        }

        foreach (Control cnt in PlaceHolder2.Controls)
        {
            if (cnt is DropDownList)
            {
                DropDownList actualtextbox1 = (DropDownList)cnt;
                if (actualtextbox1.Visible == true)
                {

                    if (actualtextbox1.SelectedIndex == 0)
                    {
                        LabelHiba.Text = "Kérlek válassz egyet a legördülőlistából.";
                        return;
                    }
                    else
                    {
                        LabelHiba.Text = "";
                    }

                }
            }
        }



        int k = 0;
        int proba = 0;
        foreach (Control cnt in PlaceHolder1.Controls)
        {
            if (cnt is TextBox)
            {
                k = k + 1;
                TextBox actualtextbox = (TextBox)cnt;
                if (actualtextbox.Visible == false)
                {
                    actualtextbox.Visible = true;
                    foreach (Control cnt2 in PlaceHolder2.Controls)
                    {
                        if (cnt2 is DropDownList)
                        {
                            proba = proba + 1;
                            if (proba == k)
                            {
                                DropDownList actualdbd = (DropDownList)cnt2;
                                if (actualdbd.Visible == false)
                                {
                                    actualdbd.Visible = true;
                                    return;
                                }
                            }

                        }

                    }

                }

            }

        }

    }
    protected void DropDownList11_SelectedIndexChanged(object sender, EventArgs e)
    {
        int k = 0;
        int proba = 0;
        DropDownList actualdbd = (DropDownList)sender;
        if (actualdbd.SelectedIndex == 1)
        {
            actualdbd.Visible = false;
            foreach (Control cnt2 in PlaceHolder1.Controls)
            {
                if (cnt2 is TextBox)
                {
                    TextBox actualdbd2 = (TextBox)cnt2;
                    if (actualdbd2.Visible == true)
                    {
                        k = k + 1;
                    }
                }

            }

            foreach (Control cnt2 in PlaceHolder2.Controls)
            {


                if (cnt2 is TextBox)
                {
                    proba = proba + 1;
                    if (k == proba)
                    {
                        TextBox actualdbd2 = (TextBox)cnt2;
                        if (actualdbd2.Visible == false)
                        {
                            actualdbd2.Visible = true;
                            return;
                        }
                    }

                }
            }

        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int index = Convert.ToInt32(e.RowIndex);

        index = Convert.ToInt32(GridView1.Rows[index].Cells[GridView1.Columns.Count - 1].Text.ToString());



        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = "update [RBHM_LOG-T].[dbo].[Kamionkezelo] set [torolve]=1 where [RBHM_LOG-T].[dbo].[Kamionkezelo].id=@id";

            using (SqlCommand command = new SqlCommand(query, con))
            {

                command.Parameters.Add("@id", SqlDbType.Int).Value = index;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();



            }
        }

        DataFilter1.DataSource = Tábla;
        DataFilter1.DataColumns = GridView1.Columns;
        DataFilter1.Lokacio = lokacio;
        DataFilter1.FilterSessionID = "Start.aspx";
        DataFilter1.OnFilterAdded += new DataFilter.RefreshDataGridView(DataFilter1_OnFilterAdded);
        GridView1.DataBind();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }
    protected void TextBoxPotkocsiRendszam_TextChanged(object sender, EventArgs e)
    {
        TextBoxPotkocsiRendszam.Text = TextBoxPotkocsiRendszam.Text.ToString().ToUpper();

    }



}






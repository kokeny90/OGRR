using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;



public partial class Start : System.Web.UI.Page
{
 


    protected void Page_Load(object sender, EventArgs e)
    {



     
        if (!this.IsPostBack)
        {
            GridView1.DataBind();
        }

    }

    protected void Search(object sender, EventArgs e)
    {
        this.BindGrid();
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
    public string Feltoltes(string query, string insert,   string be )
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
                return dataReader[0].ToString();
      
            }

        }
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


    protected void Button1_Click(object sender, EventArgs e)
    {
        
        
        int Soforneve = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxSoforNeve.Text.Trim()));
        int Utassneve = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxUtasNeve.Text.Trim()));
    
        int vontatorendszam = int.Parse(Feltoltes("SELECT id FROM dbo.rendszamok WHERE (rendszam = @bemenoadat);", "insert into  dbo.rendszamok(rendszam) values(@bemenoadat);", TextBoxVontatoRendszam.Text.Trim()));
        int potkocsirendszam = int.Parse(Feltoltes("SELECT id FROM dbo.rendszamok WHERE (rendszam = @bemenoadat);", "insert into  dbo.rendszamok(rendszam) values(@bemenoadat);", TextBoxPotkocsiRendszam.Text.Trim()));
        int ellenorzestvegezte = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxEllenorzestVegezte.Text.Trim()));

        int mitszallit;
        if (TextBoxMitszallit.Visible==true)
       {
           mitszallit = int.Parse(Feltoltes("SELECT id,megnevezes  FROM [RBHM_LOG-T].[dbo].[mitszallit]   WHERE (megnevezes = @bemenoadat);", "insert into  [RBHM_LOG-T].[dbo].[mitszallit](megnevezes) values(@bemenoadat);", TextBoxMitszallit.Text.Trim()));
  
        }
       else
	    {
            mitszallit = int.Parse(DropDownListMitSzallit.SelectedValue);
	    }
     

        int fovalalkozo;
        if (TextBoxFovalalkozo.Visible==true)
        {

            fovalalkozo = int.Parse(Feltoltes("SELECT ID FROM dbo.Transportes WHERE (transporter_name = @bemenoadat)", "insert into  dbo.Transportes(transporter_name,fovallalkozo) values(@bemenoadat,1);", TextBoxFovalalkozo.Text.Trim()));
      
        }
        else
        {

            fovalalkozo =int.Parse( DropDownListFovalalkozo.SelectedValue);
      
        }
        int alvalakozo;
        if (TextBoxAllvalalkozo.Visible==true)
        {
            alvalakozo = int.Parse(Feltoltes("SELECT ID FROM dbo.Transportes WHERE (transporter_name = @bemenoadat)", "insert into  dbo.Transportes(transporter_name,fovallalkozo) values(@bemenoadat,0);", User.Identity.Name.ToString().Trim()));
        
        }
        else
        {
            alvalakozo =int.Parse(DropDownListAlvallalkozo.SelectedValue);
        }


   
        int lokacio = 10;


        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = "INSERT INTO [RBHM_LOG-T].[dbo].[Kamionkezelo](vontatorendszam,potkocsirendszam,lokacio,befele,tomege,soforneve,utasneve,datum,behivasdatuma,rampa,fovalalkozo,alvalalkozó,beszallito,hanydarabottszallit,mitszallit,egyebbbszallitas,szalitolevelCMR,plombaszam,egyebbazonosito,vamaru,vamaruserult,ellenorzestvegezte,ellenorzesmodja,megjeygyzes) VALUES  (@vontatorendszam,@potkocsirendszam,@lokacio,@befele,@tomege,@soforneve,@utasneve,@datum,@behivasdatuma,@rampa,@fovallalkozo,@alvalalkozo,@beszallito,@hanydarabottszallit,@mitszallit,@egyebbbszallitas,@szalitolevelCMR,@plombaszam,@egyebbazonosito,@vamaru,@vamaruserult,@ellenorzestvegezte,@ellenorzesmodja,@megjegyzes)";

            using (SqlCommand command = new SqlCommand(query, con))
            {


                command.Parameters.Add("@vontatorendszam", SqlDbType.Int).Value = vontatorendszam;
                command.Parameters.Add("@potkocsirendszam", SqlDbType.Int).Value = potkocsirendszam;
                command.Parameters.Add("@lokacio", SqlDbType.Int).Value = lokacio;
                

                if (DropDownListIrany.SelectedValue == "2") 
                {
		            command.Parameters.Add("@befele", SqlDbType.Bit).Value = 0;
                }
                else
                {
                    command.Parameters.Add("@befele", SqlDbType.Bit).Value = 1;
                }



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


                    if (DropDownListIrany.SelectedValue == "1")
                    {
                        command.Parameters.Add("@behivasdatuma", SqlDbType.DateTime).Value = DateParse(TextBoxBehivasDatum.Text + " " + TextBoxBehivasIdopont.Text);
                    }
                    else
                    {

                        command.Parameters.Add("@behivasdatuma", SqlDbType.DateTime).Value = DBNull.Value;                      
                    }






                    command.Parameters.Add("@rampa", SqlDbType.Float).Value = float.Parse(TextBoxRampa.Text);
                    command.Parameters.Add("@fovallalkozo", SqlDbType.NChar).Value = fovalalkozo.ToString();
                    command.Parameters.Add("@alvalalkozo", SqlDbType.NChar).Value = alvalakozo.ToString();
                    command.Parameters.Add("@beszallito", SqlDbType.NChar).Value = TextBoxBeszallito.Text.ToString(); 
                    command.Parameters.Add("@hanydarabottszallit", SqlDbType.Int).Value = alvalakozo;
                    command.Parameters.Add("@mitszallit", SqlDbType.SmallInt).Value = mitszallit.ToString();
                    command.Parameters.Add("@egyebbbszallitas", SqlDbType.VarChar ).Value = TextBox2.Text.ToString();
                    command.Parameters.Add("@szalitolevelCMR", SqlDbType.VarChar).Value = alvalakozo.ToString();
                    command.Parameters.Add("@plombaszam", SqlDbType.VarChar).Value = alvalakozo.ToString();
                    command.Parameters.Add("@egyebbazonosito", SqlDbType.VarChar).Value = alvalakozo.ToString();


                if (DropDownListVamaru.Text=="1")
	            {
		            command.Parameters.Add("@vamaru", SqlDbType.Bit).Value =1;  
	            }
                else
	            {
                    command.Parameters.Add("@vamaru", SqlDbType.Bit).Value =0;
	            }


      



                if (DropDownListVamaruSerult.SelectedValue=="1")
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
       


                con.Open();
                command.ExecuteNonQuery();
                con.Close();


            }
        }

        GridView1.DataBind(); 
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
        GridView1.DataBind();
}




    public static DateTime DateParse(string date)
    {
        date = date.Trim();
        if (!string.IsNullOrEmpty(date))
            return DateTime.Parse(date, new System.Globalization.CultureInfo("en-GB"));
        return new DateTime();
    }









  
    protected void Button2_Click(object sender, EventArgs e)
    {

        TextBoxDatum.Text = DateTime.Today.ToString("yyyy.MM.dd");

    }

    protected void Button4_Click1(object sender, EventArgs e)
    {
        TextBoxBehivasDatum.Text = DateTime.Today.ToString("yyyy.MM.dd");
    }
   
  
    protected void Button6_Click(object sender, EventArgs e)
    {
        DropDownListFovalalkozo.Visible = false;
        TextBoxFovalalkozo.Visible = true;
        Button6.Visible = false;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        DropDownListAlvallalkozo.Visible = false;
        TextBoxAllvalalkozo.Visible = true;
        Button7.Visible = false;
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
        if (DropDownListIrany.SelectedValue == "2")
        {
            LabelLokacio.Text = "Lokáció(Honnan indul)::";
            LabelDatum.Text = "Távozás dátuma (Kötelező):";
            LabelIdopont.Text = "Távozás Időpontja:";
            trBehivasDatuma.Visible = false;
            trBehivasidopontja.Visible = false;
            LabelmennyitSzallit.Text = "Hány darabott vitt:";
            LabelMitHozott.Text = "Mit vitt:";
            test.RowSpan = 2;
            Td1.RowSpan = 2;
            LabelCMR.Text = "Szállítólevél / CMR Száma(Befelé):";
            LabelPlomba.Text = "Plomba-szám (Kifelé)";
            LabelCMR.Text = "Szállítólevél / CMR (Kifelé) (Kötelező):";

            EgyebAruk.Text = "Egyéb kimenő áruk:";
   
        }
        else
        {
            LabelLokacio.Text = "Lokáció(Hová érkezik):";         
            LabelIdopont.Text = "Érkezés Időpontja:";
            trBehivasDatuma.Visible = true;
            trBehivasidopontja.Visible = true;
            LabelmennyitSzallit.Text = "Hány darabott hozott:";
            LabelMitHozott.Text = "Mit hozott:";
            EgyebAruk.Text = "Egyéb bejövő Áruk:";
            test.RowSpan = 4;
            Td1.RowSpan = 4;
            LabelCMR.Text = "Szállítólevél / CMR (Kifelé):";


            LabelCMR.Text = "Szállítólevél / CMR Száma(Befelé)(Kötelező):";
            LabelPlomba.Text = "Plomba-szám (Befelé)";
        }
    }
    protected void idopont2(object sender, EventArgs e)
    {
        TextBoxIdopont.Text = DateTime.Now.ToString("HH:mm");
    }
    protected void DropDownListVamaru_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListVamaru.SelectedValue=="1")
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
    protected void Button11_Click(object sender, EventArgs e)
    {
        DropDownListMitSzallit.Visible = false;
        TextBoxMitszallit.Visible = true;
    }
}

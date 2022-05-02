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

    public string KamionkezeloID;
    protected void Button1_Click(object sender, EventArgs e)
    {


        int Soforneve = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxSoforNeve.Text.Trim()));
        int Utassneve = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxUtasNeve.Text.Trim()));

        int vontatorendszam = int.Parse(Feltoltes("SELECT id FROM dbo.rendszamok WHERE (rendszam = @bemenoadat);", "insert into  dbo.rendszamok(rendszam) values(@bemenoadat);", TextBoxVontatoRendszam.Text.Trim()));
        int potkocsirendszam = int.Parse(Feltoltes("SELECT id FROM dbo.rendszamok WHERE (rendszam = @bemenoadat);", "insert into  dbo.rendszamok(rendszam) values(@bemenoadat);", TextBoxPotkocsiRendszam.Text.Trim()));
        int ellenorzestvegezte = int.Parse(Feltoltes("SELECT UserId FROM dbo.Users WHERE (Nev = @bemenoadat);", "insert into  dbo.Users(Nev) values(@bemenoadat);", TextBoxEllenorzestVegezte.Text.Trim()));

       


        int fovalalkozo;
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



        int lokacio = 10;


        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {
            string query = "INSERT INTO [RBHM_LOG-T].[dbo].[Kamionkezelo](vontatorendszam,potkocsirendszam,lokacio,befele,tomege,soforneve,utasneve,datum,behivasdatuma,rampa,fovalalkozo,alvalalkozó,beszallito,szalitolevelCMR,plombaszam,egyebbazonosito,vamaru,vamaruserult,ellenorzestvegezte,ellenorzesmodja,megjeygyzes) VALUES  (@vontatorendszam,@potkocsirendszam,@lokacio,@befele,@tomege,@soforneve,@utasneve,@datum,@behivasdatuma,@rampa,@fovallalkozo,@alvalalkozo,@beszallito,@szalitolevelCMR,@plombaszam,@egyebbazonosito,@vamaru,@vamaruserult,@ellenorzestvegezte,@ellenorzesmodja,@megjegyzes)";

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



                if ( TextBoxRampa.Text=="")
                {
                    command.Parameters.Add("@rampa", SqlDbType.Float).Value = DBNull.Value;
                }

                else
                {
                    command.Parameters.Add("@rampa", SqlDbType.Float).Value = float.Parse(TextBoxRampa.Text);
                }


     
                command.Parameters.Add("@fovallalkozo", SqlDbType.NChar).Value = fovalalkozo.ToString();
                if (alvalakozo.ToString() == "")
                {
                    command.Parameters.Add("@alvalalkozo", SqlDbType.NChar).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@alvalalkozo", SqlDbType.NChar).Value = alvalakozo.ToString();
                }
          
                  if ( TextBoxBeszallito.Text =="")
                {
                    command.Parameters.Add("@beszallito", SqlDbType.NChar).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@beszallito", SqlDbType.NChar).Value = TextBoxBeszallito.Text.ToString();
                }
				
				
                command.Parameters.Add("@hanydarabottszallit", SqlDbType.Int).Value = alvalakozo;
               // command.Parameters.Add("@mitszallit", SqlDbType.SmallInt).Value = mitszallit.ToString();

                command.Parameters.Add("@szalitolevelCMR", SqlDbType.VarChar).Value = alvalakozo.ToString();
                command.Parameters.Add("@plombaszam", SqlDbType.VarChar).Value = alvalakozo.ToString();
                command.Parameters.Add("@egyebbazonosito", SqlDbType.VarChar).Value = alvalakozo.ToString();


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



                con.Open();
                command.ExecuteNonQuery();
                con.Close();


            }
        
        
        }





        SqlDataReader dataReader;


     


        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString))
        {

            string query = "SELECT TOP (100) PERCENT id FROM dbo.Kamionkezelo GROUP BY id ORDER BY id DESC";
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
            foreach (Control ctrl in PlaceHolder1.Controls)
            {
                 try
                {

                    TextBox textBox = PlaceHolder1.FindControl(ctrl.ID) as TextBox;
                      TextBox textBox2 = PlaceHolder3.FindControl(ctrl.ID + ctrl.ID + ctrl.ID + ctrl.ID) as TextBox;
                DropDownList dlx = PlaceHolder2.FindControl(ctrl.ID + ctrl.ID ) as DropDownList;


                //DropDownList cmb = (DropDownList)sender;
                //int selectedIéndex = cmb.SelectedIndex;
                //string tex = cmb.ID;

              


                string query = "INSERT INTO [RBHM_LOG-T].[dbo].[KamionkezeloMennyiseg](KamionkezeloID,hanydarabottszallit,mitszallit) VALUES  (@KamionkezeloID,@hanydarabottszallit,@mitszallit)";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@KamionkezeloID", SqlDbType.Int).Value = KamionkezeloID;
                    int mitszallit;
                    if (textBox2.Visible==true)
                    {
                        mitszallit = int.Parse(Feltoltes("SELECT id,megnevezes  FROM [RBHM_LOG-T].[dbo].[mitszallit]   WHERE (megnevezes = @bemenoadat);", "insert into  [RBHM_LOG-T].[dbo].[mitszallit](megnevezes) values(@bemenoadat);", textBox2.Text.Trim()));

                    }
                    else
                    {
                        mitszallit = int.Parse(dlx.SelectedValue);
                        
                    }

                    command.Parameters.Add("@hanydarabottszallit", SqlDbType.Int).Value = textBox.Text;
                    command.Parameters.Add("@mitszallit", SqlDbType.Int).Value = mitszallit;
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                              }

                }
                catch (Exception)
                {
                    
                    
                }




            }



            GridView1.DataBind();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            GridView1.DataBind();
        }
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
            LabelLokacio.Text = "Lokáció(Honnan indul):";
            LabelDatum.Text = "Távozás dátuma:";
            LabelIdopont.Text = "Távozás időpontja:";
            trBehivasDatuma.Visible = false;
            trBehivasidopontja.Visible = false;

            test.RowSpan = 2;
            Td1.RowSpan = 2;
            LabelCMR.Text = "Szállítólevél / CMR Száma(Befelé):";
            LabelPlomba.Text = "Plomba-szám (Kifelé)";
            LabelCMR.Text = "Szállítólevél / CMR (Kifelé):";



        }
        else
        {
            LabelLokacio.Text = "Lokáció(Hová érkezik):";
            LabelIdopont.Text = "Érkezés időpontja:";
            trBehivasDatuma.Visible = true;
            trBehivasidopontja.Visible = true;


            test.RowSpan = 4;
            Td1.RowSpan = 4;
            LabelCMR.Text = "Szállítólevél / CMR (Kifelé):";


            LabelCMR.Text = "Szállítólevél / CMR Száma(Befelé):";
            LabelPlomba.Text = "Plomba-szám (Befelé)";
        }
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
       int szam=PlaceHolder1.Controls.Count;
        if (szam!=0)
        {
         szam = szam - 2;
           int parsedValue;

           TextBox textBox = PlaceHolder1.Controls[szam] as TextBox;
           DropDownList dlx = PlaceHolder2.Controls[szam]  as DropDownList;
           TextBox textBox2 = PlaceHolder3.Controls[szam] as TextBox;
         


           if (!int.TryParse(textBox.Text, out parsedValue))
           {
               Hiba.Text = "Csak szám lehet.";
                return;

           }


           else
           {
               Hiba.Text = null;
           }


           if (textBox2.Visible == true)
           {
               if (textBox2.Text =="")
               {
                   Hiba.Text = "A tipus kitöltés kötelező!";
                   return;

               }


               else
               {
                   Hiba.Text = null;
               }
                             
               
           
           }
           else
           {
               if (dlx.SelectedIndex==0)
               {
                   Hiba.Text = "Kérlek válasz egy adatot a legördülő listából!";
                   return;

               }


               else
               {
                   Hiba.Text = null;
               }

           }
            
        
                //TextBox textBox2 = PlaceHolder2.FindControl(ctrl.ID + ctrl.ID + ctrl.ID + ctrl.ID) as TextBox;
                //DropDownList dlx = PlaceHolder2.FindControl(ctrl.ID + ctrl.ID ) as DropDownList;

        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT '- 1' AS Expr1, '  Kérlek válasz egyet!' AS Expr2 UNION ALL SELECT - 2 AS Expr1, ' Egyéb' AS Expr2 UNION ALL SELECT id, megnevezes FROM mitszallit ORDER BY Expr2", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        
        DataTable dt=new DataTable();
        da.Fill(dt);





        TextBox txt = new TextBox();
        TextBox txt2 = new TextBox();
        DropDownList dl = new DropDownList();

        dl.ID = "DropDownLis" + NextID.ToString() + NextID.ToString() ;
        dl.CssClass = "bevitelimezo";
        dl.DataTextField = "Expr2";
        dl.DataValueField = "Expr1";
        dl.SelectedIndexChanged += new EventHandler(Button11_Click);
        dl.DataSource = dt;
        dl.AutoPostBack = true;
       
        dl.DataBind();


        txt2.ID = "TextBox" + NextID.ToString() + NextID.ToString() + NextID.ToString() + NextID.ToString(); 
        txt2.CssClass = "bevitelimezo";
        txt2.Visible = false;

        txt.ID = "TextBox" + NextID.ToString();
        txt.CssClass = "bevitelimezo";



        PlaceHolder1.Controls.Add(txt);
        PlaceHolder1.Controls.Add(new LiteralControl("<br>"));

      
        PlaceHolder2.Controls.Add(dl);
        PlaceHolder2.Controls.Add(new LiteralControl("<br>"));


        PlaceHolder3.Controls.Add(txt2);    
        PlaceHolder3.Controls.Add(new LiteralControl("<br>"));


        ControlList.Add(txt.ID);




 
   


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
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDatabaseConnectionString"].ConnectionString);
       SqlCommand cmd = new SqlCommand("SELECT '- 1' AS Expr1, '  Kérlek válasz egyet!' AS Expr2 UNION ALL SELECT - 2 AS Expr1, ' Egyéb' AS Expr2 UNION ALL SELECT id, megnevezes FROM mitszallit ORDER BY Expr2", con);
       SqlDataAdapter da = new SqlDataAdapter(cmd);

       DataTable dt = new DataTable();
       da.Fill(dt);
       


       base.LoadViewState(savedState);

       TextBox textBox = PlaceHolder1.FindControl("TextBox1") as TextBox;
       
       foreach (string txtID in ControlList)
       {
           TextBox txt = new TextBox();
           txt.ID = txtID;
           PlaceHolder1.Controls.Add(txt);
           PlaceHolder1.Controls.Add(new LiteralControl("<br>"));
       }

       foreach (string txtID2 in ControlList)
       {
           TextBox txt2 = new TextBox();
           txt2.ID = txtID2 + txtID2 + txtID2 + txtID2;
           txt2.Visible = false;
           PlaceHolder3.Controls.Add(txt2);
           PlaceHolder3.Controls.Add(new LiteralControl("<br>"));

       }

        int szam=PlaceHolder1.Controls.Count;
   
         szam = szam - 2;


    

       foreach (string dlID in ControlList)
       {
           DropDownList dl = new DropDownList();
           dl.ID = dlID + dlID;
           dl.AutoPostBack = true;
           dl.CssClass = "bevitelimezo";
           dl.DataTextField = "Expr2";
           dl.DataValueField = "Expr1";
          // dl.SelectedIndex =
         dl.DataSource = dt;

           dl.SelectedIndexChanged += new EventHandler(Button11_Click);
           dl.DataBind();

    PlaceHolder2.Controls.Add(dl);
           PlaceHolder2.Controls.Add(new LiteralControl("<br>"));


       }

   }

   protected void Button11_Click(object sender, EventArgs e)
   {



       DropDownList cmb = (DropDownList)sender;
       string selectedIndex = cmb.SelectedValue;
       string tex = cmb.ID;
       if (selectedIndex == "-2")
       {
        
           TextBox textBox = PlaceHolder2.FindControl(cmb.ID + cmb.ID) as TextBox;
           textBox.Visible = true;
           cmb.Visible = false;
        
       
       }



   }

}

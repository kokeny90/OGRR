<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Start.aspx.cs" Inherits="Start"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  


    <table class="styletable">
        <tr>
            <td rowspan="7" class="auto-style56" style="font-size: 100%; font-weight: bold; font-family: 'Bosch Office Sans'; text-align: center; vertical-align: middle;">
                  
                           
              <asp:Label ID="Label5" runat="server" Text="G&lt;/br&gt;É&lt;/br&gt;P&lt;/br&gt;J&lt;/br&gt;Á&lt;/br&gt;R&lt;/br&gt;M&lt;/br&gt;Ű"></asp:Label>

                           
            </td>
              <td rowspan="7" class="auto-style53" style="font-size: 100%; font-weight: bold; font-family: 'Bosch Office Sans'; text-align: center; vertical-align: middle;">
                    <asp:Label ID="Label7" runat="server" Text="A</br>D</br>A</br>T</br>O</br>K"></asp:Label>
            
            </td>

            <td class="auto-style15">
                <asp:Label ID="Label1" runat="server" Text="Vontató rendszáma (Kötelező)"></asp:Label>
            </td>


            <td class="auto-style40">
                <asp:TextBox ID="TextBoxVontatoRendszam" runat="server" CssClass="bevitelimezo"></asp:TextBox>
                </td>


            <td class="auto-style19" class="hibaoszlop"></td>



            <td class="auto-style50">
                <asp:RequiredFieldValidator ControlToValidate="TextBoxVontatoRendszam" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vontató rendszáma nem lehet üres" Display="dynamic">Nem lehet üres</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxVontatoRendszam" ErrorMessage="A rendszám nem megfelelő. Csak szöveg vagy szám lehet pl.: ABC123" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
            </td>



        </tr>
        <tr>




            <td class="auto-style15">
                <asp:Label ID="Label2" runat="server" Text="Pótkocsi / utánfutó rendszáma"></asp:Label>
            </td>


            <td class="auto-style1">
                <asp:TextBox ID="TextBoxPotkocsiRendszam" runat="server"
                    CssClass="bevitelimezo" />
            </td>


            <td class="auto-style25"></td>


            <td class="auto-style50">
                <asp:RegularExpressionValidator ControlToValidate="TextBoxPotkocsiRendszam" ID="RegularExpressionValidator3" runat="server" ErrorMessage="A rendszám nem megfelelő. Csak szöveg vagy szám lehet pl.: ABC123" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
            </td>

        </tr>
        <tr>

            <td class="auto-style45">Irány (Kötelező):</td>


            <td class="auto-style46">
                <asp:DropDownList ID="DropDownListIrany" runat="server"
                    OnSelectedIndexChanged="DropDownListIrany_SelectedIndexChanged"
                    AutoPostBack="True" CssClass="bevitelimezo">
                    <asp:ListItem Value="0">Kérlek válasz egyet!</asp:ListItem>
                    <asp:ListItem Value="1">Befelé</asp:ListItem>
                    <asp:ListItem Value="2">Kifelé</asp:ListItem>
                </asp:DropDownList>
            </td>


            <td class="auto-style47"></td>


            <td class="auto-style48">
                
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListIrany"
                ErrorMessage="Kérlek válasz egyet!" InitialValue="0"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>

            <td class="auto-style16">
                <asp:Label ID="LabelLokacio" runat="server" Text="Lokáció(Hová érkezik) (Kötelező):"></asp:Label>
            </td>


            <td class="auto-style1">
                <asp:DropDownList CssClass="bevitelimezo" ID="DropDownLokacio" runat="server"
                    DataSourceID="SqlDataSource5" DataTextField="Expr2" DataValueField="Expr1">
                </asp:DropDownList>
            </td>


            <td class="auto-style35">&nbsp;</td>


            <td class="auto-style50">
                
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownLokacio"
                ErrorMessage="Kérlek válasz egyet!" InitialValue="-1" style="text-align: left"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>

            <td class="auto-style16">Gépjármű tömege (Kötelező):</td>


            <td class="auto-style1">
                <asp:TextBox ID="TextBoxTomeg" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Tonna"></asp:Label>
            </td>


            <td class="auto-style35">&nbsp;</td>


            <td class="auto-style50">
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBoxTomeg" ErrorMessage="Csak szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            </td>

        </tr>
        <tr>

            <td class="auto-style16">
                <asp:Label ID="Label3" runat="server" Text="Sofőr neve"></asp:Label>
                :</td>


            <td class="auto-style1">
                <asp:TextBox ID="TextBoxSoforNeve" runat="server" CssClass="bevitelimezo" />

            </td>


            <td class="auto-style35">&nbsp;</td>


            <td class="auto-style50">&nbsp;</td>

        </tr>
        <tr style="border-bottom-style: outset; border-bottom-width: thick; border-bottom-color: #FF0000;">

            <td class="auto-style16">Utas neve:</td>


            <td class="auto-style1">
                <asp:TextBox ID="TextBoxUtasNeve" runat="server" CssClass="bevitelimezo"></asp:TextBox>
            </td>


            <td class="auto-style35">&nbsp;</td>


            <td class="auto-style50">&nbsp;</td>

            <br />


        </tr>
        <tr style="background-color: #000000">
            <td class="auto-style57"></td>
            <td class="auto-style54"></td>

             <td></td>
            <td></td>
          
            </tr>
        <tr>
            <td runat="server" id="test" rowspan="4" class="auto-style56" style="font-size: 100%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #008000; text-align: center; vertical-align: middle;" >I<br>
                D<br>
                Ő<br>
                P<br>
                O<br>
                N<br>
                T<br>
                O<br>
                K
            </td>
                 <td runat="server" id="Td1" rowspan="4" class="auto-style53" style="font-size: 100%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #008000; text-align: center; vertical-align: middle;" >
                          <asp:Label ID="Label6" runat="server" Text="A</br>D</br>A</br>T</br>O</br>K"></asp:Label>       
               
            </td>
            <td class="auto-style16">
                <asp:Label ID="LabelDatum" runat="server" Text="Érkezés dátuma (Kötelező):"></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBoxDatum" runat="server" CssClass="bevitelimezo"></asp:TextBox>
            </td>



            <td class="auto-style35">
                <asp:Button ID="Button2" runat="server" Text="Mai nap" CausesValidation="False"
                    OnClick="Button2_Click" />
            </td>



            <td class="auto-style50">
                <asp:RequiredFieldValidator ControlToValidate="TextBoxDatum"
                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="Nem lehet üres"
                    Display="dynamic">Nem lehet üres</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                    ControlToValidate="TextBoxDatum"
                    ErrorMessage="A dátum formátum nem megfelelő! A helyes formátum pl. 1990.02.01"
                    ValidationExpression="(\d{4}).(\d{2}).(\d{2})"></asp:RegularExpressionValidator>
            </td>



        </tr>
        <tr>
            <td class="auto-style16">
                <asp:Label ID="LabelIdopont" runat="server" Text="Érkezés időpontja (Kötelező):"></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBoxIdopont" runat="server" CssClass="bevitelimezo" MaxLength="5"></asp:TextBox>
            </td>
            <td class="auto-style35">
                <asp:Button  runat="server" Text="Most" CausesValidation="False"
                    OnClick="idopont2" Height="20px" />
            </td>
            <td class="auto-style50">
                <asp:RequiredFieldValidator ControlToValidate="TextBoxIdopont"
                    ID="RequiredFieldValidator7" runat="server" ErrorMessage="Nem lehet üres"
                    Display="dynamic">Nem lehet üres</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                    ControlToValidate="TextBoxIdopont"
                    ErrorMessage="Az időpont formátum nem megfelelő! A helyes formátum pl. 10:15."
                    ValidationExpression="(\d{2}):(\d{2})"></asp:RegularExpressionValidator>
            </td>
         
           
        </tr>
        <tr runat="server" id="trBehivasDatuma">
            <td class="auto-style16">Behívás dátuma (Kötelező):</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBoxBehivasDatum" runat="server" CssClass="bevitelimezo"></asp:TextBox>
            </td>




            <td class="auto-style35">
                <asp:Button  runat="server" Text="Mai nap" CausesValidation="False"
                    OnClick="Button4_Click1" ID="Button9" />
            </td>




            <td class="auto-style50">
                <asp:RequiredFieldValidator ControlToValidate="TextBoxBehivasDatum"
                    ID="RequiredFieldValidator6" runat="server" ErrorMessage="Nem lehet üres"
                    Display="dynamic">Nem lehet üres</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                    ControlToValidate="TextBoxBehivasDatum"
                    ErrorMessage="A dátum formátum nem megfelelő! A helyes formátum pl. 1990.02.01"
                    ValidationExpression="(\d{4}).(\d{2}).(\d{2})"></asp:RegularExpressionValidator>
            </td>




        </tr>
        <tr runat="server" id="trBehivasidopontja">
            <td class="auto-style16">Behívás időpontja (Kötelező):</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBoxBehivasIdopont" runat="server" CssClass="bevitelimezo" MaxLength="5"></asp:TextBox>
            </td>


            <td class="auto-style35">
                <asp:Button runat="server" Text="Most" CausesValidation="False"
                    OnClick="idopont" Style="height: 26px" ID="Button10" />
            </td>


            <td class="auto-style50">
                <asp:RequiredFieldValidator ControlToValidate="TextBoxBehivasIdopont"
                    ID="RequiredFieldValidator5" runat="server" ErrorMessage="Nem lehet üres"
                    Display="dynamic">Nem lehet üres</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                    ControlToValidate="TextBoxBehivasIdopont"
                    ErrorMessage="Az időpont formátum nem megfelelő! A helyes formátum pl. 10:15."
                    ValidationExpression="(\d{2}):(\d{2})"></asp:RegularExpressionValidator>
            </td>


        </tr>

          <tr style="background-color: #000000">
            <td class="auto-style57"></td>
               <td class="auto-style54"></td>
             <td></td>
            <td></td>
          
            </tr>

        <tr>
            <td rowspan="4" class="auto-style56" style="font-size: 100%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #FFFF00; color: #000000; text-align: center; vertical-align: middle;">
                F<br>
                U<br>
                V<br>
                A<br>
                R<br>
                
            </td>
              <td rowspan="4" class="auto-style53" style="font-size: 10px; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #FFFF00; color: #000000; vertical-align: middle; text-align: center;">
        
                A<br>
              D<br>
                A<br>
                T<br>
                A<br>
                I<br>
            </td>




                  <td class="auto-style36">Rámpa:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBoxRampa" runat="server" CssClass="bevitelimezo">0</asp:TextBox>
            </td>



            <td class="auto-style35">&nbsp;</td>



            <td class="auto-style50">&nbsp;</td>



        </tr>
        <tr>

            <td class="auto-style36">Szállitmányozó (Fővállalkozó) (Kötelező):</td>
            <td class="auto-style37">
                <asp:TextBox ID="TextBoxFovalalkozo" runat="server" onkeyup="return SearchList();"
                    CssClass="bevitelimezo" Visible="False"></asp:TextBox>

                <asp:DropDownList ID="DropDownListFovalalkozo" runat="server"
                    DataSourceID="SqlDataSource8" DataTextField="Expr2"
                    DataValueField="Expr1" CssClass="bevitelimezo">
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT '- 1' AS Expr1, ' Kérlek válasz egyet!' AS Expr2 UNION SELECT ID, transporter_name FROM Transportes WHERE (fovallalkozo = 1) ORDER BY Expr2"></asp:SqlDataSource>

            </td>



            <td class="auto-style38">
                <asp:Button ID="Button6" runat="server" CausesValidation="False"
                    OnClick="Button6_Click" Text="Egyéb" />

            </td>



            <td class="auto-style39">
                
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownListFovalalkozo"
                ErrorMessage="Kérlek válasz egyet!" InitialValue="- 1"></asp:RequiredFieldValidator>
            </td>



        </tr>
        <tr>

            <td class="auto-style15">Szállítmányozó (Alvállalkozó) (Kötelező):</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBoxAllvalalkozo" runat="server"
                    onkeyup="return SearchList();" CssClass="bevitelimezo" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="DropDownListAlvallalkozo" runat="server"
                    DataSourceID="SqlDataSource7" DataTextField="Expr2"
                    DataValueField="Expr1" CssClass="bevitelimezo">
                </asp:DropDownList>
            </td>


            <td class="auto-style25">
                <asp:Button ID="Button7" runat="server" CausesValidation="False"
                    OnClick="Button7_Click" Text="Egyéb" />
            </td>


            <td class="auto-style50">
                
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownListAlvallalkozo"
                ErrorMessage="Kérlek válasz egyet!" InitialValue="- 1"></asp:RequiredFieldValidator>
                </td>


        </tr>
        <tr>

            <td class="auto-style31">Beszállító:</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBoxBeszallito" runat="server" CssClass="bevitelimezo"></asp:TextBox>
            </td>



            <td class="auto-style25"></td>



            <td class="auto-style50"></td>



        </tr>
          <tr style="background-color: #000000">
            <td class="auto-style57"></td>
              <td class="auto-style54"></td>
             <td></td>
            <td></td>
          
            </tr>

        <tr>
            <td rowspan="3" class="auto-style56" style="font-size: 50%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #00FFFF; color: #000000; text-align: center; vertical-align: middle;">
                D<br>
                A<br>
                R<br>
                A<br>
                B<br>
                S<br>
                Z<br>
                Á<br>
                M<br />               
            </td>
            <td rowspan="3" class="auto-style53" style="font-size: 50%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #00FFFF; color: #000000; vertical-align: middle; text-align: center;">
                           A<br>
                D<br>
                A<br>
                T<br>
                O<br>
                K<br>
            </td>
            <td class="szurkeinformacio">
                <asp:Label ID="LabelmennyitSzallit" runat="server" Text="Hány darabot hozot (Kötelező):"></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="mithozott" runat="server" CssClass="bevitelimezo"></asp:TextBox>
            </td>



            <td class="auto-style35">&nbsp;</td>



            <td class="auto-style50">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="mithozott" ErrorMessage="Csak szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            </td>



        </tr>
        <tr>
            <td class="auto-style63">
                <asp:Label ID="LabelMitHozott" runat="server" Text="Mit hozott:"></asp:Label>
            </td>
            <td class="auto-style64">
                <asp:DropDownList CssClass="bevitelimezo" ID="DropDownListMitSzallit" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1">
                </asp:DropDownList>
                <asp:TextBox ID="TextBoxMitszallit" CssClass="bevitelimezo" runat="server" Visible="False"></asp:TextBox>
            </td>



            <td class="auto-style65">
                <asp:Button ID="Button11" runat="server" Text="Egyéb" OnClick="Button11_Click" CausesValidation="False" />
            </td>



            <td class="auto-style66"></td>



        </tr>
        <tr>

            <td class="auto-style59">
                <asp:Label ID="EgyebAruk" runat="server" Text="Egyéb Bejövő Áruk:"></asp:Label></td>
            <td class="auto-style60">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="bevitelimezo"></asp:TextBox>
            </td>



            <td class="auto-style61"></td>



            <td class="auto-style62"></td>



        </tr>
          <tr style="background-color: #000000">
            <td class="auto-style57"></td>
                <td class="auto-style54"></td>
             <td></td>
            <td></td>
          
            </tr>

        <tr>
            <td runat="server" id="tdBejovo" rowspan="4" class="auto-style56" style="font-size: 75%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #003399; vertical-align: middle; text-align: center;">
                S<br>
                Z<br>
                Á<br>
                L<br>
                L<br>
                Í<br>
                T<br>
                M<br>
                Á<br>
                N<br>
                Y<br>
               
            </td>
             <td runat="server" id="td2" rowspan="4" class="auto-style53" style="font-size: 75%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #003399; vertical-align: middle; text-align: center;">
                    A<br>
                Z<br>
                O<br>
                N<br>
                O<br>
                S<br>
                Í<br>
                T<br>
                Ó<br>
                K<br>
            </td>
            <td class="szurkeinformacio">
                <asp:Label ID="LabelCMR" runat="server" Text="Szállítólevél / CMR Száma(Kötelező):"></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox7" CssClass="bevitelimezo" runat="server"></asp:TextBox>
            </td>



            <td class="auto-style35">&nbsp;</td>



            <td class="auto-style50">
                &nbsp;</td>



        </tr>
        <tr>

            <td class="auto-style41">
                <asp:Label ID="LabelPlomba" runat="server" Text="Plomba-szám"></asp:Label></td>
            <td class="auto-style42">
                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxPlombaSzam" runat="server"></asp:TextBox>
            </td>


            <td class="auto-style43"></td>


            <td class="auto-style44"></td>


        </tr>
        <tr>

            <td class="auto-style32">Szállítmány egyedi azonosító(Kötelező)<br>iStar;TO-LO;Order szám<td class="auto-style33">
                <asp:TextBox ID="TextBox8" CssClass="bevitelimezo" runat="server"></asp:TextBox>
            </td>



                <td class="auto-style34"></td>



                <td class="auto-style8">
				       <asp:RequiredFieldValidator ControlToValidate="TextBox8"
                    ID="RequiredFieldValidator15" runat="server" ErrorMessage="Nem lehet üres"
                    Display="dynamic">Nem lehet üres</asp:RequiredFieldValidator>
				
				
				</td>
        </tr>

        <tr>


            <td class="szurkeinformacio">Szállítmány státusza (vámáru / nem vámáru)</td>
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownListVamaru" runat="server" OnSelectedIndexChanged="DropDownListVamaru_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>Kérlek válassz!</asp:ListItem>
                    <asp:ListItem Value="1">Igen</asp:ListItem>
                    <asp:ListItem Value="0">Nem</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style35">&nbsp;</td>
            <td class="auto-style50">&nbsp;</td>
        </tr>

        <tr runat="server" id="trvamaru" visible="false">



            <td class="auto-style52">Vámzár sérült-e (sérült/ nem S/N)</td>
            

            <td class="auto-style1">
                <asp:DropDownList ID="DropDownListVamaruSerult" runat="server" OnSelectedIndexChanged="DropDownListVamaru_SelectedIndexChanged">
                    <asp:ListItem>Kérlek válassz!</asp:ListItem>
                    <asp:ListItem Value="1">Igen</asp:ListItem>
                    <asp:ListItem Value="0">Nem</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style35">&nbsp;</td>
            <td class="auto-style50">&nbsp;</td>
        </tr>
         <tr style="background-color: #000000">
            <td class="auto-style57"></td>
             <td class="auto-style54"></td>
              <td class="auto-style54"></td>
            <td></td>
          
            </tr>
        <tr>
            <td rowspan="3" class="auto-style58" style="font-size: 75%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #E26B0A; text-align: center; vertical-align: middle;">E<br>
                G<br>
                Y<br>
                É<br>
                B<br>               
              <td rowspan="3" class="auto-style55" style="font-size: 75%; font-weight: bold; font-family: 'Bosch Office Sans'; background-color: #E26B0A; text-align: center; vertical-align: middle;">
                A<br>
                D<br>
                A<br>
                T<br>
                O<br>
                K</td>
            <td class="szurkeinformacio">Ellenőrzést végző 
                    személy:</td>
            <td class="auto-style1">
                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxEllenorzestVegezte" runat="server"></asp:TextBox>
            </td>

            <td class="auto-style35">&nbsp;</td>

            <td class="auto-style50">
                <asp:RequiredFieldValidator ControlToValidate="TextBoxEllenorzestVegezte"
                    ID="RequiredFieldValidator14" runat="server" ErrorMessage="Nem lehet üres"
                    Display="dynamic">Nem lehet üres</asp:RequiredFieldValidator>
                </td>

            <td class="style1">&nbsp;</td>

        </tr>

        <tr>
            <td class="szurkeinformacio">Ellenőrzés módja:</td>
            <td class="auto-style1">
                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxEllenorzesModja" runat="server"></asp:TextBox>
            </td>

            <td class="auto-style35">&nbsp;</td>

            <td class="auto-style50">&nbsp;</td>

            <td class="style1">&nbsp;</td>

        </tr>
        <tr>
            <td class="szurkeinformacio">Megjegyzés:
             
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxMegjegyzes" CssClass="bevitelimezo" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>



                <td class="auto-style35">&nbsp;</td>



                <td class="auto-style50">&nbsp;</td>
        </tr>
    </table>
     <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click" Text="Adatok Felvétele" />




    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />




   



    <asp:GridView ID="GridView1" runat="server" DataSourceID="Tábla" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-top: 91px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="VONTATÓ RENDSZÁMA" HeaderText="VONTATÓ RENDSZÁMA" SortExpression="VONTATÓ RENDSZÁMA" />
            <asp:BoundField DataField="PÓTKOCSI RENDSZÁMA" HeaderText="PÓTKOCSI RENDSZÁMA" SortExpression="PÓTKOCSI RENDSZÁMA" />
            <asp:BoundField DataField="KI- VAGY BESZÁLLÍTÁSI OLDAL" HeaderText="KI- VAGY BESZÁLLÍTÁSI OLDAL" SortExpression="KI- VAGY BESZÁLLÍTÁSI OLDAL" />
            <asp:BoundField DataField="Soför Neve" HeaderText="Soför Neve" SortExpression="Soför Neve" />
            <asp:BoundField DataField="Utas Neve" HeaderText="Utas Neve" SortExpression="Utas Neve" />
            <asp:BoundField DataField="Érkezés/Távozás Dátuma" HeaderText="Érkezés/Távozás Dátuma" SortExpression="Érkezés/Távozás Dátuma" />
            <asp:BoundField DataField="BEHÍVÁS DÁTUMA" HeaderText="BEHÍVÁS DÁTUMA" SortExpression="BEHÍVÁS DÁTUMA" />
            <asp:BoundField DataField="RÁMPA" HeaderText="RÁMPA" SortExpression="RÁMPA" />
            <asp:BoundField DataField="SZÁLLÍTMÁNYOZÓ
(Fővállalkozó)" HeaderText="SZÁLLÍTMÁNYOZÓ
(Fővállalkozó)" SortExpression="SZÁLLÍTMÁNYOZÓ
(Fővállalkozó)" />
            <asp:BoundField DataField="FUVAROZÓ (Alvállalkozó)" HeaderText="FUVAROZÓ (Alvállalkozó)" SortExpression="FUVAROZÓ (Alvállalkozó)" />
            <asp:BoundField DataField="BESZÁLLÍTÓ" HeaderText="BESZÁLLÍTÓ" SortExpression="BESZÁLLÍTÓ" />
            <asp:BoundField DataField="MIT HOZOTT?" HeaderText="MIT HOZOTT?" SortExpression="MIT HOZOTT?" />
            <asp:BoundField DataField="DARABSZÁM" HeaderText="DARABSZÁM" SortExpression="DARABSZÁM" />
            <asp:BoundField DataField="SZÁLLÍTÓLEVÉL / CMR" HeaderText="SZÁLLÍTÓLEVÉL / CMR" SortExpression="SZÁLLÍTÓLEVÉL / CMR" />
            <asp:BoundField DataField="PLOMBA-SZÁM" HeaderText="PLOMBA-SZÁM" SortExpression="PLOMBA-SZÁM" />
            <asp:BoundField DataField="SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ" HeaderText="SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ" SortExpression="SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ" />
            <asp:CheckBoxField DataField="SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)" HeaderText="SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)" SortExpression="SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)" />
            <asp:CheckBoxField DataField="VÁMZÁR SÉRÜLT-E (sérült / nem)" HeaderText="VÁMZÁR SÉRÜLT-E (sérült / nem)" SortExpression="VÁMZÁR SÉRÜLT-E (sérült / nem)" />
            <asp:BoundField DataField="GÉPJÁRMŰ TÖMEG (t)" HeaderText="GÉPJÁRMŰ TÖMEG (t)" SortExpression="GÉPJÁRMŰ TÖMEG (t)" />
            <asp:BoundField DataField="Ellenörzést Végezte" HeaderText="Ellenörzést Végezte" SortExpression="Ellenörzést Végezte" />
            <asp:BoundField DataField="ELLENŐRZÉS MÓDJA" HeaderText="ELLENŐRZÉS MÓDJA" SortExpression="ELLENŐRZÉS MÓDJA" />
            <asp:BoundField DataField="MEGJEGYZÉS (VONTATÓ RENDSZÁM VÁLTOZÁS / BOSCH KAPCSOLATTARTÓ)" HeaderText="MEGJEGYZÉS (VONTATÓ RENDSZÁM VÁLTOZÁS / BOSCH KAPCSOLATTARTÓ)" SortExpression="MEGJEGYZÉS (VONTATÓ RENDSZÁM VÁLTOZÁS / BOSCH KAPCSOLATTARTÓ)" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
   

      <asp:SqlDataSource ID="Tábla" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT        TOP (100) PERCENT rendszamok_1.rendszam AS [VONTATÓ RENDSZÁMA], dbo.rendszamok.rendszam AS [PÓTKOCSI RENDSZÁMA], 
                         dbo.[True/False].befelekifele AS [KI- VAGY BESZÁLLÍTÁSI OLDAL], Users_2.Nev AS [Soför Neve], dbo.Users.Nev AS [Utas Neve], 
                         dbo.Kamionkezelo.datum AS [Érkezés/Távozás Dátuma], dbo.Kamionkezelo.behivasdatuma AS [BEHÍVÁS DÁTUMA], dbo.Kamionkezelo.rampa AS RÁMPA, 
                         Transportes_1.transporter_name AS [SZÁLLÍTMÁNYOZÓ
(Fővállalkozó)], dbo.Transportes.transporter_name AS [FUVAROZÓ (Alvállalkozó)], 
                         dbo.cegek.cegnev AS BESZÁLLÍTÓ, dbo.Kamionkezelo.mitszallit AS [MIT HOZOTT?], dbo.Kamionkezelo.hanydarabottszallit AS DARABSZÁM, 
                         dbo.Kamionkezelo.szalitolevelCMR AS [SZÁLLÍTÓLEVÉL / CMR], dbo.Kamionkezelo.plombaszam AS [PLOMBA-SZÁM], 
                         dbo.Kamionkezelo.egyebbazonosito AS [SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ], dbo.Kamionkezelo.vamaru AS [SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)], 
                         dbo.Kamionkezelo.vamaruserult AS [VÁMZÁR SÉRÜLT-E (sérült / nem)], dbo.Kamionkezelo.tomege AS [GÉPJÁRMŰ TÖMEG (t)], 
                         Users_1.Nev AS [Ellenörzést Végezte], dbo.Kamionkezelo.ellenorzesmodja AS [ELLENŐRZÉS MÓDJA], 
                         dbo.Kamionkezelo.megjeygyzes AS [MEGJEGYZÉS (VONTATÓ RENDSZÁM VÁLTOZÁS / BOSCH KAPCSOLATTARTÓ)]
FROM            dbo.Transportes AS Transportes_1 RIGHT OUTER JOIN
                         dbo.Kamionkezelo INNER JOIN
                         dbo.cegek ON dbo.Kamionkezelo.lokacio = dbo.cegek.ID INNER JOIN
                         dbo.Users AS Users_2 ON dbo.Kamionkezelo.soforneve = Users_2.UserId INNER JOIN
                         dbo.Users ON dbo.Kamionkezelo.utasneve = dbo.Users.UserId INNER JOIN
                         dbo.Users AS Users_1 ON dbo.Kamionkezelo.ellenorzestvegezte = Users_1.UserId INNER JOIN
                         dbo.mitszallit ON dbo.Kamionkezelo.mitszallit = dbo.mitszallit.id INNER JOIN
                         dbo.[True/False] ON dbo.Kamionkezelo.befele = dbo.[True/False].Boolean LEFT OUTER JOIN
                         dbo.rendszamok AS rendszamok_1 ON dbo.Kamionkezelo.vontatorendszam = rendszamok_1.id ON 
                         Transportes_1.ID = dbo.Kamionkezelo.fovalalkozo LEFT OUTER JOIN
                         dbo.rendszamok ON dbo.Kamionkezelo.potkocsirendszam = dbo.rendszamok.id LEFT OUTER JOIN
                         dbo.Transportes ON dbo.Kamionkezelo.alvalalkozó = dbo.Transportes.ID
ORDER BY [Érkezés/Távozás Dátuma] DESC"></asp:SqlDataSource>
   

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT [Nev] FROM [Soforneve] ORDER BY [Nev]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Kamionkezelo]"></asp:SqlDataSource>




   




    <br />
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT - 1 AS Expr1, ' Kérlek válasz egyet!' AS Expr2 UNION SELECT id, megnevezes FROM mitszallit ORDER BY Expr2"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server"
                    ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>"
                    SelectCommand="SELECT - 1 AS Expr1, 'Kérlek válasz egyet!' AS Expr2 UNION SELECT ID, cegnev FROM cegek WHERE (ID = 379) OR (ID = 380) OR (ID = 381) ORDER BY Expr1"
                    OnSelecting="SqlDataSource5_Selecting"></asp:SqlDataSource>




    



    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT '- 1' AS Expr1, ' Kérlek válasz egyet!' AS Expr2 UNION SELECT ID, transporter_name FROM Transportes WHERE (fovallalkozo = 0) ORDER BY Expr2"></asp:SqlDataSource>




    



    <br />
    <br />

    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
        ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>"
        SelectCommand="SELECT rendszamok.rendszam, rendszamok.alvallalkozo, Kamionkezelo.soforneve, Kamionkezelo.KÁRTYA, Kamionkezelo.ertkezettdatum, Kamionkezelo.behivasdatuma, Kamionkezelo.tavozasdatuma, Kamionkezelo.rampa, Kamionkezelo.mithozott, Kamionkezelo.palettabefele, Kamionkezelo.szalitolevelCMRbefele, Kamionkezelo.plombaszambefele, Kamionkezelo.tavozasmodja, Kamionkezelo.mitvisz, Kamionkezelo.palettaszamkifele, Kamionkezelo.szalitolevelCMRkifel, Kamionkezelo.Plombaszamkifel, Kamionkezelo.[ELLENŐRZÉST VÉGEZTE], Kamionkezelo.VÁMÁRUS, Kamionkezelo.MEGJEGYZÉS, Users.Username, Users.Email FROM Kamionkezelo INNER JOIN rendszamok ON Kamionkezelo.vontatorendszam = rendszamok.id AND Kamionkezelo.potkocsirendszam = rendszamok.id INNER JOIN Users ON Kamionkezelo.USERID = Users.UserId LEFT OUTER JOIN Transportes ON Kamionkezelo.fovalalkozo = Transportes.transporter_id AND Kamionkezelo.alvalalkozó = Transportes.transporter_id AND rendszamok.alvallalkozo = Transportes.transporter_id ORDER BY Kamionkezelo.ertkezettdatum"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server"
        ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>"
        SelectCommand="SELECT * FROM [Kamionkezelo]"></asp:SqlDataSource>
    <br />




    <br />






</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">


    


    <style type="text/css">
        .auto-style1 {
        width: 475px;
    }
        .auto-style8 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            font-weight: bold;
            background-color: white;
            border: 0px solid black;
            color: red;
            height: 24px;
            width: 520px;
        }
        .auto-style15 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
            width: 328px;
        }
        .auto-style16 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
            height: 11pt;
            width: 328px;
        }
        .auto-style19 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            font-weight: bold;
            background-color: white;
            text-align: center;
            border: 0px solid black;
            text-align: center;
            color: red;
            width: 181px;
        }
        .auto-style25 {
        font-family: 'Bosch Office Sans';
        font-size: 8pt;
        width: 181px;
        font-weight: bold;
        background-color: white;
        text-align: center;
        border: 0px solid black;
        text-align: left;
        color: red;
    }
        .auto-style31 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
        }
    .auto-style32 {
        background-color: #808080;
        font-family: Bosch Office Sans;
        font-size: 11pt;
        color: #FFFFFF;
        font-weight: lighter;
        text-align: left;
        height: 24px;
    }
    .auto-style33 {
        width: 475px;
        height: 24px;
    }
    .auto-style34 {
        font-family: 'Bosch Office Sans';
        font-size: 8pt;
        width: 181px;
        height: 24px;
        font-weight: bold;
        background-color: white;
        text-align: center;
        border: 0px solid black;
        text-align: left;
        color: red;
    }
    .auto-style35 {
        font-family: 'Bosch Office Sans';
        font-size: 8pt;
        width: 181px;
        height: 10px;
        font-weight: bold;
        background-color: white;
        text-align: center;
        border: 0px solid black;
        text-align: left;
        color: red;
    }
    .auto-style36 {
        background-color: #808080;
        font-family: Bosch Office Sans;
        font-size: 11pt;
        color: #FFFFFF;
        font-weight: lighter;
        text-align: left;
        width: 328px;
        height: 47px;
    }
    .auto-style37 {
        width: 475px;
        height: 47px;
    }
    .auto-style38 {
        font-family: 'Bosch Office Sans';
        font-size: 8pt;
        width: 181px;
        font-weight: bold;
        background-color: white;
        text-align: center;
        border: 0px solid black;
        text-align: left;
        color: red;
        height: 47px;
    }
    .auto-style39 {
        font-family: 'Bosch Office Sans';
        font-size: 8pt;
        font-weight: bold;
        background-color: white;
        border: 0px solid black;
        color: red;
        width: 520px;
        height: 47px;
    }
    .auto-style40 {
        font-family: 'Bosch Office Sans';
        font-size: 8pt;
        font-weight: bold;
        background-color: whitesmoke;
        text-align: center;
        border: 1px solid black;
        text-align: left;
        width: 475px;
    }
        .auto-style41 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
            height: 35px;
        }
        .auto-style42 {
            width: 475px;
            height: 35px;
        }
        .auto-style43 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            width: 181px;
            height: 35px;
            font-weight: bold;
            background-color: white;
            text-align: center;
            border: 0px solid black;
            text-align: left;
            color: red;
        }
        .auto-style44 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            font-weight: bold;
            background-color: white;
            border: 0px solid black;
            color: red;
            width: 520px;
            height: 35px;
        }
        .auto-style45 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
            height: 26px;
            width: 328px;
        }
        .auto-style46 {
            width: 475px;
            height: 26px;
        }
        .auto-style47 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            width: 181px;
            height: 26px;
            font-weight: bold;
            background-color: white;
            text-align: center;
            border: 0px solid black;
            text-align: left;
            color: red;
        }
        .auto-style48 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            font-weight: bold;
            background-color: white;
            border: 0px solid black;
            color: red;
            width: 520px;
            height: 26px;
        }
        .auto-style50 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            font-weight: bold;
            background-color: white;
            border: 0px solid black;
            color: red;
            width: 520px;
        }
        .auto-style52 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
            height: 11pt;
            width: 111px;
        }
        .auto-style53 {
            background-color: #0070C0;
            font-family: 'Bosch Office Sans';
            font-weight: bold;
            color: #FFFFFF;
            text-align: center;
            font-size: 11pt;
            width: 22px;
        }
        .auto-style54 {
            width: 22px;
        }
        .auto-style55 {
            background-color: #E26B0A;
            font-family: 'Bosch Office Sans';
            font-weight: bold;
            color: #FFFFFF;
            text-align: left;
            font-size: 11pt;
            width: 22px;
        }
        .auto-style56 {
            background-color: #0070C0;
            font-family: 'Bosch Office Sans';
            font-weight: bold;
            color: #FFFFFF;
            text-align: center;
            font-size: 11pt;
            width: 23px;
        }
        .auto-style57 {
            width: 23px;
        }
        .auto-style58 {
            background-color: #E26B0A;
            font-family: 'Bosch Office Sans';
            font-weight: bold;
            color: #FFFFFF;
            text-align: left;
            font-size: 11pt;
            width: 23px;
        }
        .auto-style59 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
            height: 1px;
        }
        .auto-style60 {
            width: 475px;
            height: 1px;
        }
        .auto-style61 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            width: 181px;
            height: 1px;
            font-weight: bold;
            background-color: white;
            text-align: center;
            border: 0px solid black;
            text-align: left;
            color: red;
        }
        .auto-style62 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            font-weight: bold;
            background-color: white;
            border: 0px solid black;
            color: red;
            height: 1px;
            width: 520px;
        }
        .auto-style63 {
            background-color: #808080;
            font-family: Bosch Office Sans;
            font-size: 11pt;
            color: #FFFFFF;
            font-weight: lighter;
            text-align: left;
            height: 16px;
        }
        .auto-style64 {
            width: 475px;
            height: 16px;
        }
        .auto-style65 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            width: 181px;
            height: 16px;
            font-weight: bold;
            background-color: white;
            text-align: center;
            border: 0px solid black;
            text-align: left;
            color: red;
        }
        .auto-style66 {
            font-family: 'Bosch Office Sans';
            font-size: 8pt;
            font-weight: bold;
            background-color: white;
            border: 0px solid black;
            color: red;
            height: 16px;
            width: 520px;
        }
    </style>


    


</asp:Content>



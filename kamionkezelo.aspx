<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="kamionkezelo.aspx.cs" Inherits="kamionkezelo" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="DataFilter.ascx" TagName="DataFilter" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr style="text-align: left">
            <td>
                <asp:Button ID="ButtonBefele" runat="server" Text="Bejövő" Height="50px" Width="100px" OnClick="ButtonBefele_Click" CausesValidation="False" />

            </td>



            <td>
                <asp:Button ID="ButtonKifele" runat="server" Text="Kimenő" Height="50px" Width="100px" OnClick="ButtonKifele_Click" CausesValidation="False" />

            </td>


        </tr>


    </table>


    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>

            <table class="styletable">
                <thead>
                    <tr>
                        <th colspan="2" style="height: 30px">
                            <asp:Label CssClass="fejlec" ID="Fejresz" runat="server">Bejövő</asp:Label>
                        </th>

                        <th style="height: 30px"></th>
                        <th class="bevitelimezocella" style="height: 30px"></th>
                        <th runat="server" visible="false" id="adat1" class="bejovofejresz" style="height: 30px">
                            <asp:Label ID="Label4" Width="100%" runat="server" Visible="False">Kimenő</asp:Label>
                        </th>


                        <th class="helposzlop" style="height: 30px"></th>
                        <th class="hibaoszlop" style="height: 30px"></th>
                    </tr>
                </thead>

                <tr>
                    <td rowspan="7" class="oldalsavkek">G<br>
                        É<br>
                        P<br>
                        J<br>
                        Á<br>
                        R<br>
                        M<br>
                        Ű</td>
                    <td rowspan="7" class="oldalsavkek">A<br>
                        D<br>
                        A<br>
                        T<br>
                        A<br>
                        I</td>
                    <td class="szurkeinformacio">Vontató rendszáma</td>
                    <td class="bevitelimezocella">

                        <asp:TextBox ID="TextBoxVontatoRendszam" runat="server" CssClass="bevitelimezo" AutoPostBack="True" OnTextChanged="TextBoxVontatoRendszam_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="hibaoszlop" ID="RequiredFieldValidator23" ControlToValidate="TextBoxVontatoRendszam" Display="dynamic" ErrorMessage="A Vontató rendszáma nem lehet üres">Nem lehet üres</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="TextBoxVontatoRendszam" CssClass="hibaoszlop" ErrorMessage="A rendszám nem megfelelő. Csak szöveg vagy szám lehet pl.: ABC123" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
                    </td>
                    <td runat="server" visible="false" id="adat2" class="bejovokozepe">
                        <asp:Label ID="LabelVontatoRendszam" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="A rendszám csak szöveg vagy szám lehet." />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label8" runat="server" Text="*Kötelező" Font-Names="Bosch Office Sans" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">Pótkocsi / utánfutó rendszáma</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxPotkocsiRendszam" runat="server" CssClass="bevitelimezo" OnTextChanged="TextBoxPotkocsiRendszam_TextChanged" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="TextBoxPotkocsiRendszam" CssClass="hibaoszlop" ErrorMessage="A rendszám nem megfelelő. Csak szöveg vagy szám lehet pl.: ABC123" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
                    </td>
                    <td runat="server" visible="false" id="adat3" class="bejovokozepe">
                        <asp:Label ID="LabelPotkocsiRendszam" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image2" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="A rendszám csak szöveg vagy szám lehet." /></td>
                    <td class="hibaoszlop">
                </tr>
                <tr>
                    <td class="szurkeinformacio">Irány:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxIrany" runat="server" CssClass="bevitelimezo" Enabled="False" /></td>
                    <td runat="server" visible="false" id="adat4" class="bejovokozepe">
                        <asp:Label ID="LabelIrany" runat="server" Text=""></asp:Label></td>



                    <td class="helposzlop">
                        <asp:Image ID="Image3" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="A rendszer automatikusan kitölti." /></td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label10" runat="server" Text="*Kötelező" Font-Names="Bosch Office Sans" Font-Size="Small"></asp:Label>
                    </td>



                </tr>
                <tr>

                    <td class="szurkeinformacio" style="height: 30px">
                        <asp:Label ID="LabelLokacio" runat="server" Text="Lokáció (Hová érkezik):"></asp:Label>
                    </td>


                    <td class="bevitelimezocella" style="height: 30px">
                        <asp:DropDownList CssClass="bevitelimezo" ID="DropDownListLokacio" runat="server" DataSourceID="SqlDataSource5" DataTextField="Expr2" DataValueField="Expr1" ToolTip="Ki kell választani egyet a listából.">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLokacio3" runat="server" ControlToValidate="DropDownListLokacio" ErrorMessage="Kérlek válassz egyet!" InitialValue="-1" CssClass="hibaoszlop" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>

                    <td runat="server" visible="false" id="adat5" class="bejovokozepe" style="height: 30px">
                        <asp:Label ID="LabelLokaciokimeno" runat="server" CssClass="bevitelimezo" Text=""></asp:Label>
                    </td>

                    <td class="helposzlop" style="height: 30px">
                        <asp:Image ID="Image11" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" ToolTip="Cég, akinek az áruját hozza a fuvaros. A fuvarokmányokon is rajta van a név. Csak 1 cég áruja van az autón." Width="35px" />
                    </td>


                    <td class="hibaoszlop" style="height: 30px"></td>


                </tr>
                <tr>

                    <td class="szurkeinformacio">Szállítmány tömege:</td>


                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxTomeg" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" Text="kg"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" CssClass="hibaoszlop" ControlToValidate="TextBoxTomeg" ErrorMessage="Csak szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    </td>




                    <td runat="server" visible="false" id="adat7" class="bejovokozepe">
                        <asp:Label ID="LabelTomeg" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image13" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" ToolTip="A szállítót áru súlya KG-ban. Ha nem szállít, semmit 0 kell beírni" Width="35px" />
                    </td>


                    <td class="hibaoszlop">

                        <asp:Label ID="Label22" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label>
                    </td>



                </tr>
                <tr>

                    <td class="szurkeinformacio">Sofőr neve:</asp:Label>
                    </td>


                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxSoforNeve" runat="server" CssClass="bevitelimezo" />

                    </td>
                    <td runat="server" visible="false" id="adat8" class="bejovokozepe">
                        <asp:Label ID="LabelSoforneve" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image14" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" ToolTip="Ki vezeti a kamiont" Width="35px" />
                    </td>
                    <td class="bevitelimezocella"></td>


                </tr>
                <tr style="border-bottom-style: outset; border-bottom-width: thick; border-bottom-color: #FF0000;">

                    <td class="szurkeinformacio">Utas neve:</td>


                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxUtasNeve" runat="server" CssClass="bevitelimezo"></asp:TextBox>
                    </td>
                    <td runat="server" visible="false" id="adat9" class="bejovokozepe">
                        <asp:Label ID="LabelUtasNeve" runat="server" Text=""></asp:Label>
                    </td>


                    <td class="helposzlop">
                        <asp:Image ID="Image15" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" ToolTip="Sofőrön kívül még ki utazik." Width="35px" />
                    </td>
                    <td class="hibaoszlop"></t<caption>
                        <caption>
                            <br />
                        </caption>
                    </td>
                    </caption>


                </tr>
                </caption>
                </tr>
                <tr style="background-color: #000000">
                    <td colspan="7"></td>



                </tr>
                <tr>
                    <td runat="server" id="test" rowspan="4" class="oldalsavzold">I<br>
                        D<br>
                        Ő<br>
                        P<br>
                        O<br>
                        N<br>
                        T<br>
                        O<br>
                        K</td>
                    <td runat="server" id="Td1" rowspan="4" class="oldalsavzold"></td>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelDatum" runat="server" Text="Érkezés dátuma:"></asp:Label></td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxDatum" runat="server" CssClass="bevitelimezo"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="TextBoxDatum" ErrorMessage="A dátum formátum nem megfelelő! A helyes formátum pl. 1990.02.01" CssClass="hibaoszlop" ValidationExpression="(\d{4}).(\d{2}).(\d{2})"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" CssClass="hibaoszlop" ControlToValidate="TextBoxDatum" Display="dynamic" ErrorMessage="Nem lehet üres">Nem lehet üres</asp:RequiredFieldValidator>
                    </td>





                    <td runat="server" visible="false" id="adat10" class="bejovokozepe">
                        <asp:Label ID="LabelerkezesDatuma0" runat="server" Text=""></asp:Label>
                    </td>

                    <td class="helposzlop">
                        <asp:Button ID="Button2" runat="server" Text="Mai nap" CausesValidation="False"
                            OnClick="Button2_Click" CssClass="gomb" Height="26px" Width="69px" />
                    </td>



                    <td class="hibaoszlop">
                        <asp:Label ID="Label23" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label>
                    </t>






                </tr>
                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelIdopont" runat="server" Text="Érkezés időpontja:"></asp:Label></td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxIdopont" runat="server" CssClass="bevitelimezo" MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="hibaoszlop" ID="RequiredFieldValidator25" runat="server" ControlToValidate="TextBoxIdopont" Display="dynamic" ErrorMessage="Nem lehet üres">Nem lehet üres</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="hibaoszlop" ID="RegularExpressionValidator20" runat="server" ControlToValidate="TextBoxIdopont" ErrorMessage="Az időpont formátum nem megfelelő! A helyes formátum pl. 10:15." ValidationExpression="(\d{2}):(\d{2})"></asp:RegularExpressionValidator>
                    </td>
                    <td runat="server" visible="false" id="adat11" class="bejovokozepe">
                        <asp:Label ID="LabelerkezesIdopontja0" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="helposzlop">
                        <asp:Button ID="Button1" runat="server" Text="Most" CausesValidation="False"
                            OnClick="idopont2" CssClass="gomb" />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label24" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label>
                    </td>





                </tr>
                <tr runat="server" id="trBehivasDatuma">
                    <td class="szurkeinformacio">Behívás dátuma:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxBehivasDatum" runat="server" CssClass="bevitelimezo"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="TextBoxBehivasDatum" CssClass="hibaoszlop" Display="dynamic" ErrorMessage="Nem lehet üres" ToolTip="Cég, akinek az áruját hozza a fuvaros. A fuvarokmányokon is rajta van a név. Csak 1 cég áruja van az autón.">Nem lehet üres</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="TextBoxBehivasDatum" CssClass="hibaoszlop" ErrorMessage="A dátum formátum nem megfelelő! A helyes formátum pl. 1990.02.01" ValidationExpression="(\d{4}).(\d{2}).(\d{2})"></asp:RegularExpressionValidator>
                    </td>






                    <td runat="server" visible="false" id="adat13" class="bejovokozepe">&nbsp;</td>

                    <td class="helposzlop">
                        <asp:Button runat="server" Text="Mai nap" CausesValidation="False"
                            OnClick="Button4_Click1" ID="Button9" CssClass="gomb" Height="35px" Width="67px" />
                    </td>




                    <td class="hibaoszlop">
                        <asp:Label ID="Label25" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label>
                    </td>








                </tr>
                <tr runat="server" id="trBehivasidopontja">
                    <td class="szurkeinformacio">Behívás időpontja:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxBehivasIdopont" runat="server" CssClass="bevitelimezo" MaxLength="5"></asp:TextBox>
                        <asp:RegularExpressionValidator CssClass="hibaoszlop" ID="RegularExpressionValidator15" runat="server" ControlToValidate="TextBoxBehivasIdopont" ErrorMessage="Az időpont formátum nem megfelelő! A helyes formátum pl. 10:15." ValidationExpression="(\d{2}):(\d{2})"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator CssClass="hibaoszlop" ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBoxBehivasIdopont" Display="dynamic" ErrorMessage="Nem lehet üres">Nem lehet üres</asp:RequiredFieldValidator>

                    </td>



                    <td runat="server" visible="false" id="adat14" class="bejovokozepe">&nbsp;</td>
                    <td class="helposzlop">
                        <asp:Button runat="server" Text="Most" CausesValidation="False"
                            OnClick="idopont" Style="height: 26px" ID="Button10" CssClass="gomb" />
                    </td>


                    <td class="hibaoszlop">
                        <asp:Label ID="Label26" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label>
                    </td>





                </tr>

                <tr style="background-color: #000000">
                    <td colspan="7"></td>

                </tr>

                <tr>
                    <td rowspan="4" class="oldalsavsarga">F<br>
                        U<br>
                        V<br>
                        A<br>
                        R<br>
                    </td>
                    <td rowspan="4" class="oldalsavsarga">A<br>
                        D<br>
                        A<br>
                        T<br>
                        A<br>
                        I<br>
                    </td>
                    <td class="szurkeinformacio" style="height: 30px">Rámpa:</td>
                    <td class="bevitelimezocella" style="height: 30px">
                        <asp:TextBox ID="TextBoxRampa" runat="server" CssClass="bevitelimezo"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionRampa" runat="server" CssClass="hibaoszlop" ControlToValidate="TextBoxRampa" ErrorMessage="Csak szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>


                    </td>
                    <td runat="server" visible="false" id="adat15" class="bejovokozepe" style="height: 30px">
                        <asp:Label ID="Labelrampa" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="helposzlop" style="height: 30px">
                        <asp:Image ID="Image16" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="Melyik rámpára érkezik." /></td>

                    <td class="hibaoszlop" style="height: 30px"></td>


                </tr>
                <tr>

                    <td class="szurkeinformacio">
                        <asp:Label ID="Szallirtmanyozofovallakozo" runat="server" Text="Szállítmányozó (Fővállalkozó):"></asp:Label></td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxFovalalkozo" runat="server" onkeyup="return SearchList();"
                            CssClass="bevitelimezo" Visible="False" OnTextChanged="TextBoxFovalalkozo_TextChanged"></asp:TextBox>
                        <asp:DropDownList ID="DropDownListFovalalkozo" runat="server"
                            DataSourceID="SqlDataSource8" DataTextField="Expr2"
                            DataValueField="Expr1" CssClass="bevitelimezo" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFovalalkozo_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT '- 1' AS Expr1, '  Kérlek válassz egyet!' AS Expr2 UNION ALL SELECT - 2 AS Expr1, ' Egyéb' AS Expr2 UNION ALL SELECT - 3 AS Expr1, ' Elérhetőség!' AS Expr2 UNION ALL SELECT ID, transporter_name FROM Transportes WHERE (fovallalkozo = 1) ORDER BY Expr2"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListFovalalkozo" ErrorMessage="Kérlek válassz egyet!" InitialValue="-1" CssClass="hibaoszlop" Display="Dynamic"></asp:RequiredFieldValidator>                 
                        <asp:RequiredFieldValidator ID="RequiredFieldTextBoxFovalalkozo" runat="server" ControlToValidate="TextBoxFovalalkozo" ErrorMessage="Kérlek írj elérhetőséget!" CssClass="hibaoszlop"  Display="Dynamic"></asp:RequiredFieldValidator>
                    
                    </td>





                    <td runat="server" visible="false" id="adat16" class="bejovokozepe">
                        <asp:Label ID="LabelFovalalkozo0" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image8" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="Cég, aki az árut szállítja. Szállíthatja alvállalkozóval is, de ide a fővállalkozót kell beírni! pl.: a DHL-GF konténereit szinte mindig alvállalkozó hozza, de ide a &quot;DHL-GF&quot;-ot kell beírni! Rá kell kérdezni a sofőrnél, hogy ki a fővállalkozó! " />

                    </td>



                    <td class="hibaoszlop">

                        <asp:Label ID="Label27" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label>
                    </td>







                </tr>
                <tr>

                    <td class="szurkeinformacio">Szállítmányozó (Alvállalkozó):</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxAllvalalkozo" runat="server"
                            onkeyup="return SearchList();" CssClass="bevitelimezo" Visible="False"></asp:TextBox>
                        <asp:DropDownList ID="DropDownListAlvallalkozo" runat="server"
                            DataSourceID="SqlDataSource7" DataTextField="Expr2"
                            DataValueField="Expr1" CssClass="bevitelimezo" OnSelectedIndexChanged="DropDownListAlvallalkozo_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="DropDownListAlvallalkozo" ErrorMessage="Kérlek válassz egyet!" InitialValue="- 1"></asp:RequiredFieldValidator>
                    </td>

                    <td runat="server" visible="false" id="adat17" class="bejovokozepe">
                        <asp:Label ID="LabelAlvalakozo0" runat="server" Text=""></asp:Label>
                    </td>

                    <td class="helposzlop">
                        <asp:Image ID="Image9" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="A cég, aki a fuvart teljesíti. Valamikor megegyezik a fővállalkozóval." />
                    </td>


                    <td class="hibaoszlop">&nbsp;</td>





                </tr>
                <tr>

                    <td class="szurkeinformacio">Beszállító:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxBeszallito" runat="server" CssClass="bevitelimezo"></asp:TextBox>
                    </td>
                    <td runat="server" visible="false" id="adat18" class="bejovokozepe">
                        <asp:Label ID="LabelBeszallito0" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image10" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" ToolTip="Cég, akinek az áruját hozza a fuvaros. A fuvarokmányokon is rajta van a név. Csak 1 cég áruja van az autón." Width="35px" />
                    </td>

                    <td class="hibaoszlop"></td>




                </tr>
                <tr style="background-color: #000000">
                    <td colspan="7"></td>

                </tr>

                <tr>
                    <td class="oldalsavcian">S<br>
                        Z<br>
                        Á<br>
                        L<br>
                        L<br>
                        Í<br>
                        T<br>
                        M<br>
                        Á<br>
                        N</td>
                    <td class="oldalsavcian">A<br>
                        D<br>
                        A<br>
                        T<br>
                        A<br>
                        I<br>
                    </td>
                    <td class="szurkeinformacio">Szállítmány mennyisége:</td>
                    <td style="vertical-align: top" class="bevitelimezocella">
                        <table style="vertical-align: top">
                            <thead>
                                <tr>
                                    <td>Mennyiség:      </td>
                                    <td>Mit szállít:    </td>
                                </tr>

                            </thead>
                            <tr>
                                <td>
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                        <asp:TextBox ID="TextBoxS1" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS2" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS3" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS4" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS5" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS6" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS7" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS8" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS9" Visible="false" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="TextBoxS10" Visible="false" runat="server"></asp:TextBox><br />
                                    </asp:PlaceHolder>


                                </td>

                                <td>
                                    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                                        <asp:DropDownList Visible="false" ID="DropDownList1" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD1" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList2" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD2" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList3" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD3" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList4" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD4" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList5" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD5" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList6" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD6" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList7" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD7" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList8" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD8" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList9" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD9" runat="server" Visible="false"></asp:TextBox><br />
                                        <asp:DropDownList Visible="false" ID="DropDownList10" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList><asp:TextBox ID="TextBoxD10" runat="server" Visible="false"></asp:TextBox><br />
                                    </asp:PlaceHolder>
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="+" CausesValidation="False" OnClick="Button3_Click1" Style="width: 22px" />
                                    <asp:Label ID="LabelHiba" runat="server" Text=""></asp:Label>

                                </td>
                            </tr>
                        </table>


                    </td>
                    <td runat="server" id="adat20" class="bejovokozepe" style="vertical-align: top">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource9" Visible="False">
                            <Columns>
                                <asp:BoundField DataField="hanydarabottszallit" HeaderText="Mennyiseg:" SortExpression="hanydarabottszallit" />
                                <asp:BoundField DataField="megnevezes" HeaderText="Mitszallit:" SortExpression="megnevezes" />
                                <%--         <asp:BoundField DataField="KamionkezeloID" HeaderText="KamionkezeloID" SortExpression="KamionkezeloID" />
                                --%>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT KamionkezeloMennyiseg.hanydarabottszallit, mitszallit.megnevezes, KamionkezeloMennyiseg.KamionkezeloID FROM KamionkezeloMennyiseg INNER JOIN mitszallit ON KamionkezeloMennyiseg.mitszallit = mitszallit.id"></asp:SqlDataSource>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image17" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="A pluszgomb megnyomása után ki lehet, választani mit szállít egy legördülő listából és be kell írni a mennyiséget." />
                        <asp:Label ID="Hiba" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="vertical-align: top" class="hibaoszlop"></td>
                </tr>
                <tr style="background-color: #000000">
                    <td colspan="7"></td>
                </tr>
                <tr>
                    <td runat="server" id="tdBejovo" rowspan="5" class="oldalsavsotetekek">S<br>
                        Z<br>
                        Á<br>
                        L<br>
                        L<br>
                        Í<br>
                        T<br>
                        M<br>
                        Á<br>
                        N<br>
                        Y</td>
                    <td runat="server" id="td2" rowspan="5" class="oldalsavsotetekek">A<br>
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
                        <asp:Label ID="LabelCMR" runat="server" Text="Szállítólevél / CMR Száma"></asp:Label></td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBox7" CssClass="bevitelimezo" runat="server"></asp:TextBox></td>
                    <td runat="server" visible="false" id="adat21" class="bejovokozepe">
                        <asp:Label ID="CMRSzam" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image18" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="Szállítólevél CMR száma" /></td>
                    <td class="hibaoszlop"></td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelPlomba" runat="server" Text="Plomba-szám"></asp:Label></td>
                    <td class="bevitelimezocella" style="height: 35px">
                        <asp:TextBox CssClass="bevitelimezo" ID="TextBoxPlombaSzam" runat="server"></asp:TextBox></td>
                    <td runat="server" visible="false" id="adat22" class="bejovokozepe" style="height: 35px">
                        <asp:Label ID="PlombaSzam" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop" style="height: 35px">
                        <asp:Image ID="Image19" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="Plomba-szám" /></td>
                    <td class="hibaoszlop"></td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">Szállítmány egyedi azonosító:<br>
                        iStar;TO-LO;Order szám</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBox8" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" CssClass="hibaoszlop" ControlToValidate="TextBox8" Display="dynamic" ErrorMessage="Nem lehet üres">Nem lehet üres</asp:RequiredFieldValidator>
                    </td>
                    <td runat="server" visible="false" id="adat23" class="bejovokozepe">
                        <asp:Label ID="Labelegyebb" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image20" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" ToolTip="iStar;TO-LO;Order szám" />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label32" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label></td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">Szállítmány vámjogi státusza<asp:Label ID="Label28" runat="server" Text="Label"></asp:Label><asp:Label ID="Label29" runat="server" Text="Label"></asp:Label></td>
                    <td class="bevitelimezocella">
                        <asp:DropDownList ID="DropDownListVamaru" runat="server" OnSelectedIndexChanged="DropDownListVamaru_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem>Kérlek válassz!</asp:ListItem>
                            <asp:ListItem Value="1">Vámárú</asp:ListItem>
                            <asp:ListItem Value="0">Nem vámárú</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td runat="server" visible="false" id="adat24" class="bejovokozepe">
                        <asp:Label ID="LabelVAmjog" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image21" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" /></td>
                    <td class="hibaoszlop"></td>
                </tr>
                <tr runat="server" id="trvamaru" visible="false">
                    <td class="szurkeinformacio">Vámzár sérült-e</td>
                    <td class="bevitelimezocella">
                        <asp:DropDownList ID="DropDownListVamaruSerult" runat="server" OnSelectedIndexChanged="DropDownListVamaru_SelectedIndexChanged">
                            <asp:ListItem>Kérlek válassz!</asp:ListItem>
                            <asp:ListItem Value="1">Igen</asp:ListItem>
                            <asp:ListItem Value="0">Nem</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td runat="server" visible="false" id="adat25" class="bejovokozepe">
                        <asp:Label ID="LabelVamSerult" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop"></td>
                    <td class="hibaoszlop"></td>
                </tr>
                <tr style="background-color: #000000">
                    <td colspan="7"></td>
                </tr>
                <tr>
                    <td rowspan="3" class="oldalsavnarancs">E<br>
                        G<br>
                        Y<br>
                        É<br>
                        B</td>
                    <td rowspan="3" class="oldalsavnarancs">A<br>
                        D<br>
                        A<br>
                        T<br>
                        O<br>
                        K</td>
                    <td class="szurkeinformacio">Ellenőrzést végzőszemély:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox CssClass="bevitelimezo" ID="TextBoxEllenorzestVegezte" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBoxEllenorzestVegezte" CssClass="hibaoszlop" Display="dynamic" ErrorMessage="Nem lehet üres">Nem lehet üres</asp:RequiredFieldValidator>
                    </td>
                    <td runat="server" visible="false" id="adat26" class="bejovokozepe">
                        <asp:Label ID="LabelEllenorzestVegezte" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image22" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" /></td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label35" runat="server" Font-Names="Bosch Office Sans" Font-Size="Small" Text="*Kötelező"></asp:Label></td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">Ellenőrzés módja:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox CssClass="bevitelimezo" ID="TextBoxEllenorzesModja" runat="server"></asp:TextBox></td>
                    <td runat="server" visible="false" id="adat27" class="bejovokozepe">
                        <asp:Label ID="EllenorzesModjka" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image23" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" /></td>
                    <td class="hibaoszlop"></td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">Megjegyzés:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxMegjegyzes" CssClass="bevitelimezo" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    <td runat="server" visible="false" id="adat28" class="bejovokozepe">
                        <asp:Label ID="LabelMegjegyzes" runat="server" Text=""></asp:Label></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image24" runat="server" Height="35px" ImageUrl="~/Picture/maxresdefault.jpg" Width="35px" />
                    </td>
                    <td class="hibaoszlop"></td>
                </tr>
            </table>
        </ContentTemplate>

    </asp:UpdatePanel>

    <br>

    <asp:Button ID="Button4" runat="server" OnClick="Button1_Click" Text="Adatok Felvétele" Visible="False" Style="height: 26px" />




    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Names="Bosch Office Sans" Font-Size="Larger" Font-Strikeout="False" ForeColor="#FF3300" />

    <div>

        <br />
        <asp:Button ID="btnExportWord" runat="server" Text="ExportToWord" OnClick="btnExportWord_Click" Visible="False" CausesValidation="False" />
        &nbsp;
        <asp:Button ID="btnExportExcel" runat="server" Text="ExportToExcel" OnClick="btnExportExcel_Click" Visible="False" />
        &nbsp;
        <asp:Button ID="btnExportPDF" runat="server" Text="ExportToPDF" OnClick="btnExportPDF_Click" Visible="False" />
        &nbsp;
        <asp:Button ID="Button5" runat="server" Text="ExportToCSV" OnClick="btnExportCSV_Click" Visible="False" />
        <br />
        <br />
        <uc1:DataFilter ID="DataFilter1" runat="server" Visible="False" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView OnRowDeleting="OnRowDeleting" ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeader="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" DataSourceID="Tábla">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="VONTATÓ RENDSZÁMA" HeaderText="VONTATÓ RENDSZÁMA" SortExpression="VONTATÓ RENDSZÁMA" />


                        <asp:BoundField DataField="PÓTKOCSI RENDSZÁMA" HeaderText="PÓTKOCSI RENDSZÁMA" SortExpression="PÓTKOCSI RENDSZÁMA" />
                        <asp:BoundField DataField="KI- VAGY BESZÁLLÍTÁSI OLDAL" HeaderText="KI- VAGY BESZÁLLÍTÁSI OLDAL" SortExpression="KI- VAGY BESZÁLLÍTÁSI OLDAL" />
                        <asp:BoundField DataField="GÉPJÁRMŰ TÖMEG (t)" HeaderText="GÉPJÁRMŰ TÖMEG (t)" SortExpression="GÉPJÁRMŰ TÖMEG (t)" />
                        <asp:BoundField DataField="Soför Neve" HeaderText="Soför Neve" SortExpression="Soför Neve" />
                        <asp:BoundField DataField="Utas Neve" HeaderText="Utas Neve" SortExpression="Utas Neve" />
                        <asp:BoundField DataField="ÉRKEZÉS DÁTUMA" HeaderText="ÉRKEZÉS DÁTUMA" SortExpression="ÉRKEZÉS DÁTUMA" ItemStyle-Width="1000">
                            
                            <ItemStyle Width="10px" />
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="BEHÍVÁS DÁTUMA" HeaderText="BEHÍVÁS DÁTUMA" SortExpression="BEHÍVÁS DÁTUMA" />
                        <asp:BoundField DataField="TÁVOZÁS DÁTUMA" HeaderText="TÁVOZÁS DÁTUMA" SortExpression="TÁVOZÁS DÁTUMA" />
                        <asp:BoundField DataField="RÁMPA" HeaderText="RÁMPA" SortExpression="RÁMPA" />
                        <asp:BoundField DataField="SZÁLLÍTMÁNYOZÓ
(Fővállalkozó)"
                            HeaderText="SZÁLLÍTMÁNYOZÓ
(Fővállalkozó)"
                            SortExpression="SZÁLLÍTMÁNYOZÓ
(Fővállalkozó)" />
                        <asp:BoundField DataField="FUVAROZÓ (Alvállalkozó)" HeaderText="FUVAROZÓ (Alvállalkozó)" SortExpression="FUVAROZÓ (Alvállalkozó)" />
                        <asp:BoundField DataField="DARABSZÁM" HeaderText="DARABSZÁM" SortExpression="DARABSZÁM" />

                        <asp:BoundField DataField="MIT HOZOTT?" HeaderText="MIT HOZOTT?" SortExpression="MIT HOZOTT?" />
                        <asp:BoundField DataField="SZÁLLÍTÓLEVÉL / CMR(BEFELÉ)" HeaderText="SZÁLLÍTÓLEVÉL / CMR(BEFELÉ)" SortExpression="SZÁLLÍTÓLEVÉL / CMR(BEFELÉ)" />
                        <asp:BoundField DataField="PLOMBA-SZÁM (BEFELÉ" HeaderText="PLOMBA-SZÁM (BEFELÉ" SortExpression="PLOMBA-SZÁM (BEFELÉ" />
                        <asp:BoundField DataField="SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ" HeaderText="SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ" SortExpression="SZÁLLÍTMÁNY EGYEDI AZONOSÍTÓ" />
                        <asp:CheckBoxField DataField="SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)" HeaderText="SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)" SortExpression="SZÁLLÍTMÁNY STÁTUSZA (vámáru / nem vámáru)" />
                        <asp:CheckBoxField DataField="VÁMZÁR SÉRÜLT-E (sérült / nem)" HeaderText="VÁMZÁR SÉRÜLT-E (sérült / nem)" SortExpression="VÁMZÁR SÉRÜLT-E (sérült / nem)" />
                        <asp:BoundField DataField="TÁVOZÁS MÓDJA (üres / rakott)" HeaderText="TÁVOZÁS MÓDJA (üres / rakott)" SortExpression="TÁVOZÁS MÓDJA (üres / rakott)" />
                        <asp:BoundField DataField="MIT VISZ?" HeaderText="MIT VISZ?" SortExpression="MIT VISZ?" />
                        <asp:BoundField DataField="KIMENŐ ÁRU DARABSZÁM" HeaderText="KIMENŐ ÁRU DARABSZÁM" SortExpression="KIMENŐ ÁRU DARABSZÁM" />
                        <asp:BoundField DataField="SZÁLLÍTÓLEVÉL / CMR(KIFELÉ)" HeaderText="SZÁLLÍTÓLEVÉL / CMR(KIFELÉ)" SortExpression="SZÁLLÍTÓLEVÉL / CMR(KIFELÉ)" />
                        <asp:BoundField DataField="PLOMBA SZÁM (KIFELÉ)" HeaderText="PLOMBA SZÁM (KIFELÉ)" SortExpression="PLOMBA SZÁM (KIFELÉ)" />
                        <asp:BoundField DataField="Ellenörzést Végezte" HeaderText="Ellenörzést Végezte" SortExpression="Ellenörzést Végezte" />
                        <asp:BoundField DataField="ELLENŐRZÉS MÓDJA" HeaderText="ELLENŐRZÉS MÓDJA" SortExpression="ELLENŐRZÉS MÓDJA" />
                        <asp:BoundField DataField="MEGJEGYZÉS (VONTATÓ RENDSZÁM VÁLTOZÁS / BOSCH KAPCSOLATTARTÓ)" HeaderText="MEGJEGYZÉS (VONTATÓ RENDSZÁM VÁLTOZÁS / BOSCH KAPCSOLATTARTÓ)" SortExpression="MEGJEGYZÉS (VONTATÓ RENDSZÁM VÁLTOZÁS / BOSCH KAPCSOLATTARTÓ)" />
                        <asp:CheckBoxField DataField="torolve" HeaderText="torolve" SortExpression="torolve" Visible="False" />
                        <asp:BoundField DataField="Azonosito" HeaderText="Azonosito" SortExpression="Azonosito" Visible="False" />
                        <asp:BoundField DataField="Expr2" HeaderText="Expr2" SortExpression="Expr2" Visible="False" />
                        <asp:BoundField DataField="Expr1" HeaderText="Expr1" SortExpression="Expr1" Visible="False" />
                        <asp:BoundField DataField="Lokáció" HeaderText="Lokáció" SortExpression="Lokáció" Visible="False" />
                        <asp:BoundField DataField="lokacio" HeaderText="lokacio" SortExpression="lokacio" Visible="False" />
                        <asp:BoundField DataField="userid" HeaderText="userid" SortExpression="userid" Visible="False" />
                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/site/img/icons/cross.png"
                                    CommandName="Delete" OnClientClick="return confirm('Biztosan törölni akarod?');"
                                    AlternateText="Törlés" />
                            </ItemTemplate>



                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />

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

            </ContentTemplate>
        </asp:UpdatePanel>

        <br />
        <br />

    </div>




    <asp:SqlDataSource ID="Tábla" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT * FROM [tabla]"></asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT [Nev] FROM [Soforneve] ORDER BY [Nev]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Kamionkezelo]"></asp:SqlDataSource>









    <br />
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT '- 1' AS Expr1, '  Kérlek válassz egyet!' AS Expr2 UNION ALL SELECT - 2 AS Expr1, ' Egyéb' AS Expr2 UNION ALL SELECT id, megnevezes FROM mitszallit ORDER BY Expr2"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server"
        ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>"
        SelectCommand="SELECT - 1 AS Expr1, ' Kérlek válassz egyet!' AS Expr2 UNION SELECT ID, cegnev FROM cegek WHERE (ID = 379) OR (ID = 380) OR (ID = 381) OR (ID = 2)  OR (ID = 382)  OR (ID = 383)  OR (ID = 384) OR (ID = 385)  ORDER BY Expr2"
        OnSelecting="SqlDataSource5_Selecting"></asp:SqlDataSource>








    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT '- 1' AS Expr1, '  Kérlek válassz egyet!' AS Expr2 UNION ALL SELECT - 2 AS Expr1, ' Egyéb' AS Expr2 UNION ALL SELECT ID, transporter_name FROM Transportes WHERE (fovallalkozo = 0) ORDER BY Expr2"></asp:SqlDataSource>








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
</asp:Content>


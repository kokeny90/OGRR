<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="OnlineGepjarmuRegisztraciosRendszer.aspx.cs" Inherits="OnlineGepjarmuRegisztraciosRendszer" Theme="mySkin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="true">
        <ContentTemplate>
            <h1>
                <asp:Label ID="lbl_utolso_szkennelo" runat="server" Text="Szkennelje be a QR kód azonosítót!: "></asp:Label>
            </h1>
            <br />
            <asp:Label ID="lbl_uzi" ForeColor="Red" runat="server" Text=""></asp:Label>
            <br />
            <asp:TextBox ID="txt_szken" runat="server" SkinID="tb_oval_scanner" AutoPostBack="true" OnTextChanged="txt_szken_TextChanged"></asp:TextBox>


            <table id="table1" runat="server" class="styletable" visible="false">
                <thead>
                    <tr>
                        <th colspan="5" style="height: 30px">
                            <asp:Label ID="Fejresz" runat="server" CssClass="fejlec"></asp:Label>
                        </th>

           
                    </tr>
                </thead>
                <tr>
                    <td class="szurkeinformacio">Vontató rendszáma</td>
                    <td>
                        <asp:TextBox ID="TextBoxVontatoRendszam" runat="server" AutoPostBack="true" CausesValidation="True" CssClass="bevitelimezo" OnTextChanged="TextBoxVontatoRendszam_TextChanged" RepeatLayout="Flow" ValidationGroup="First" MaxLength="50"></asp:TextBox>
                    </td>
                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TextBoxVontatoRendszam" ErrorMessage="A Vontató rendszáma nem lehet üres" ValidationGroup="First" Width="213px">Nem lehet üres</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="TextBoxVontatoRendszam" CssClass="hibaoszlop" EnableClientScript="False" ErrorMessage="A rendszám nem megfelelő. Csak szöveg vagy szám lehet pl.: ABC123" ValidationExpression="^[a-zA-Z0-9]+$" ValidationGroup="First" Width="366px"></asp:RegularExpressionValidator>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png" Width="35px" ToolTip="A rendszám csak szöveg vagy szám lehet." />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label8" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">Pótkocsi rendszáma</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxPotkocsiRendszam" runat="server" AutoPostBack="True" CausesValidation="True" CssClass="bevitelimezo" OnTextChanged="TextBoxPotkocsiRendszam_TextChanged" RepeatLayout="Flow" MaxLength="50" />
                        &nbsp; </td>
                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPotkocsiRendszam" ErrorMessage="A Vontató rendszáma nem lehet üres" ValidationGroup="First">Nem lehet üres</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="TextBoxPotkocsiRendszam" rrorMessage="A rendszám nem megfelelő. Csak szöveg vagy szám lehet pl.: ABC123" ValidationExpression="^[a-zA-Z0-9]+$" ValidationGroup="First" Height="16px" ></asp:RegularExpressionValidator>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image2" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png"  ToolTip="A rendszám csak szöveg vagy szám lehet." />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label1" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelLokacioText" runat="server" Text="Lokáció (Hová érkezik):"></asp:Label>
                    </td>
                    <td class="bevitelimezocella">
                        <asp:Label ID="LabelLokacio" runat="server" BackColor="WhiteSmoke" CssClass="bevitelimezo"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td class="helposzlop">
                        <asp:Image ID="Image3" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png" ToolTip="Cég, akinek az áruját hozza a fuvaros. A fuvarokmányokon is rajta van a név. Csak 1 cég áruja van az autón."/>
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label2" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>
                <tr id="irany" runat="server">
                    <td class="szurkeinformacio">Irány:</td>
                    <td class="bevitelimezocella">
                        <asp:DropDownList ID="DropDownListIrany" CssClass="bevitelimezo" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="DropDownListIrany_SelectedIndexChanged">
                            <asp:ListItem Value="0">Kérlek válasz!</asp:ListItem>
                            <asp:ListItem Value="1">Bejövő</asp:ListItem>
                            <asp:ListItem Value="2">Kimenő</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIrany" runat="server" ControlToValidate="DropDownListIrany" CssClass="hibaoszlop" ErrorMessage="Kérlek válasz irányt!" ValidationGroup="First" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image4" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png"/>
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label3" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">KI/Beszállítás:</td>
                    <td class="bevitelimezocella">
                        <asp:DropDownList CssClass="bevitelimezo" ID="DropDownListKIBEszállítás" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="DropDownListKIBEszállítás_SelectedIndexChanged">
                            <asp:ListItem Value="-1">Kérlek válasz!</asp:ListItem>
                            <asp:ListItem Value="1">Kiszállítás</asp:ListItem>
                            <asp:ListItem Value="0">Beszállítás</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListKIBEszállítás" CssClass="hibaoszlop" ErrorMessage="Kérlek válasz irányt!" ValidationGroup="First" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image5" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png"  />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label12" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelDatum" runat="server" Text="Érkezés dátuma:"></asp:Label>
                    </td>
                    <td class="bevitelimezocella">
                        <asp:Label ID="TextBoxDatum" runat="server" CssClass="bevitelimezo"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td class="helposzlop">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelIdopont" runat="server" Text="Érkezés időpontja:"></asp:Label>
                    </td>
                    <td class="bevitelimezocella">
                        <asp:Label ID="TextBoxIdopont" runat="server" CssClass="bevitelimezo"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td class="helposzlop">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="Szallirtmanyozofovallakozo" runat="server" Text="Szállítmányozó neve (ki hozta?) (fővállalkozó)"></asp:Label>
                    </td>
                    <td class="bevitelimezocella">
                        <asp:Label ID="LabelFovalalkozo" runat="server"></asp:Label>

                    </td>
                    <td></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image7" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png"  ToolTip="Cég, aki az árut szállítja. Szállíthatja alvállalkozóval is, de ide a fővállalkozót kell beírni! pl.: a DHL-GF konténereit szinte mindig alvállalkozó hozza, de ide a &quot;DHL-GF&quot;-ot kell beírni! Rá kell kérdezni a sofőrnél, hogy ki a fővállalkozó! " />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label4" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>

                <tr runat="server" id="beszallitosor">
                    <td class="szurkeinformacio">Beszállító neve (mit hozott?):</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxBeszallito" runat="server" CssClass="bevitelimezo"></asp:TextBox>
                    </td>
                    <td class="hibaoszlop"></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image8" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png" ToolTip="Cég, akinek az áruját hozza a fuvaros. A fuvarokmányokon is rajta van a név. Csak 1 cég áruja van az autón." Width="35px" />
                    </td>
                    <td class="hibaoszlop">&nbsp;</td>
                </tr>                






                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelPalette" runat="server" Text="Paletta szám:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxPaletta" runat="server" CssClass="bevitelimezo" MaxLength="10" ></asp:TextBox>
                    </td>
                    <td class="hibaoszlop">
                        <asp:RegularExpressionValidator ID="RegularExpressionRampa" runat="server" ControlToValidate="TextBoxPaletta" ValidationGroup="First" CssClass="hibaoszlop" ErrorMessage="Csak pozítiv egész szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="hibaoszlop" ControlToValidate="TextBoxPaletta" ErrorMessage="Csak szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxPaletta" ErrorMessage="A Paletta szám nem lehet üres" ValidationGroup="First" Width="213px">Nem lehet üres</asp:RequiredFieldValidator>
                    </td>
                    <td class="hibaoszlop">&nbsp;</td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label11" runat="server" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left" Text="*Kötelező"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="vamsor">
                    <td class="szurkeinformacio">Szállítmány vámjogi státusza</td>
                    <td class="bevitelimezocella">
                        <asp:DropDownList ID="DropDownListVamaru" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="-1">Kérlek válassz!</asp:ListItem>
                            <asp:ListItem Value="1">Vámárú</asp:ListItem>
                            <asp:ListItem Value="0">Nem vámárú</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListVamaru" CssClass="hibaoszlop" ErrorMessage="Kérlek válasz!" ValidationGroup="First" InitialValue="-1"></asp:RequiredFieldValidator>

                    </td>
                    <td class="hibaoszlop">&nbsp;</td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label10" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelCMR" runat="server" Text="Szállítólevél / CMR Száma"></asp:Label></td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxCMR" CssClass="bevitelimezo" runat="server" MaxLength="200"></asp:TextBox></td>
                    <td class="hibaoszlop"></td>
                    <td class="helposzlop">
                        <asp:Image ID="Image11" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png" ToolTip="Szállítólevél CMR száma" Width="35px" />
                    </td>
                    <td class="hibaoszlop">&nbsp;</td>
                </tr>

                <tr>
                    <td class="szurkeinformacio">Sofőr neve: </td>
                    <td>
                        <asp:TextBox ID="TextBoxSoforNeve" runat="server" CssClass="bevitelimezo" MaxLength="50" />
                    </td>
                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSoforNeve" runat="server" ControlToValidate="TextBoxSoforNeve" ErrorMessage="A Vontató rendszáma nem lehet üres" ValidationGroup="First" Width="213px">Nem lehet üres</asp:RequiredFieldValidator>
                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image12" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png" ToolTip="Ki vezeti a kamiont" Width="35px" />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label9" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>


                <tr>

                    <td class="szurkeinformacio" style="height: 30px">Kártyaszám:</td>
                    <td class="bevitelimezocella" style="height: 30px">
                        <asp:TextBox ID="TextBoxKartyaszam" runat="server" CssClass="bevitelimezo" MaxLength="50"></asp:TextBox>
                    </td>
                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxKartyaszam" ErrorMessage="A Vontató rendszáma nem lehet üres" ValidationGroup="First" Width="213px">Nem lehet üres</asp:RequiredFieldValidator>
                    </td>
                    <td class="hibaoszlop" style="height: 30px">&nbsp;</td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label6" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>


                <tr>
                    <td class="szurkeinformacio">
                        <asp:Label ID="LabelPlomba" runat="server" Text="Plomba-szám"></asp:Label></td>
                    <td class="bevitelimezocella" style="height: 35px">
                        <asp:TextBox CssClass="bevitelimezo" MaxLength="6" ID="TextBoxPlombaSzam" runat="server"></asp:TextBox></td>


                    <td class="hibaoszlop">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPlombaSzam" runat="server" ControlToValidate="TextBoxPlombaSzam" ErrorMessage="A Vontató rendszáma nem lehet üres" ValidationGroup="First" Width="213px">Nem lehet üres</asp:RequiredFieldValidator>

                    </td>
                    <td class="helposzlop">
                        <asp:Image ID="Image14" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png" ToolTip="Plomba-szám" Width="35px" />
                    </td>
                    <td class="hibaoszlop">
                        <asp:Label ID="Label5" runat="server" Text="*Kötelező" Font-Names="Titillium Web" Font-Size="Small" Style="text-align: left"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="szurkeinformacio">Szállítmány egyedi azonosító:<br>
                        <asp:Label ID="Label7" runat="server" Text="iStar;TO-LO;Order szám;konténerszám"> </asp:Label>

                    </td>
                    <td>&nbsp;<asp:TextBox ID="TextBoxEgyediAzonosito" runat="server" MaxLength="200" AutoPostBack="true" CssClass="bevitelimezo" ></asp:TextBox>

                        <asp:Label ID="LabelHiba" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td class="helposzlop">
                        <asp:Image ID="Image15" runat="server" Height="35px" ImageUrl="~/Images/confirmation_verification-512.png" ToolTip="iStar;TO-LO;Order szám" />

                    </td>
                    <td class="hibaoszlop">&nbsp;</td>
                </tr>

                <tr>
                    <td class="szurkeinformacio">Megjegyzés:</td>
                    <td class="bevitelimezocella">
                        <asp:TextBox ID="TextBoxMegjegyzes" runat="server" CssClass="bevitelimezo" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="vertical-align: bottom; line-height: 10px;">
                    <td></td>
                </tr>
                <tr style="vertical-align: bottom; line-height: 10px;">
                    <td></td>
                    <td>
                        <h6><strong>
                            <asp:Button CssClass="btn btn-default send-message" ID="ButtonInsert" runat="server" OnClick="ButtonInsert_Click" Style="height: 50px; font-weight: bold;" ValidationGroup="First" Text="Adatok Felvétele" Visible="true" />
                        </strong></h6>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>



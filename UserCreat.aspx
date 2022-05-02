<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserCreat.aspx.cs" Inherits="UserCreat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table>
            <tr style="text-align: left">
                <td>
                    <strong>
                        <asp:Button ID="ButtonFelhsznalo" runat="server" Text="Felhasznaló Felvétele" CssClass="nagygomb" CausesValidation="False" OnClick="ButtonFelhsznalo_Click" />
                    </strong>
                </td>
                <td>
                    <strong>
                        <asp:Button ID="ButtonFelhsznalo0" runat="server" CssClass="nagygomb" Text="Felhasznaló Modositás" CausesValidation="False" OnClick="ButtonFelhsznalo0_Click" />
                    </strong>
                </td>
                <td>
                    <strong>
                        <asp:Button ID="ButtonRaktar" runat="server" Text="Porta Felvétele" CssClass="nagygomb" CausesValidation="False" OnClick="ButtonRaktar_Click" />
                    </strong>
                </td>
                <td>
                    <strong>
                        <asp:Button ID="ButtonRaktar0" runat="server" Text="Porta Modositás" CssClass="nagygomb" CausesValidation="False" OnClick="ButtonRaktar0_Click" />
                    </strong>
                </td>
            </tr>
        </table>
        <asp:Panel ID="PanelAll" Visible="false" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <table class="styletable">
                        <tr>
                            <th colspan="3" style="height: 21px">
                                <asp:Label CssClass="fejlec" ID="LabelFejlec" runat="server" Text="Regisztráció"></asp:Label>
                            </th>
                        </tr>
                        <tr runat="server" visible="false" id="elsosor">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Eddigi Felhasználók:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="Users" CssClass="bevitelimezo" DataTextField="Username" DataValueField="UserId" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                    <asp:ListItem Text="' * Kérlek válassz egyet! *'" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="Users" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT ' * Kérlek válassz egyet! *' AS Username, '-1' AS UserId, 0 AS CegID, 0 AS torolve, 0 AS ID, 0 AS UserId UNION ALL SELECT Users.Username, Users.UserId, Users.CegID, Users.torolve, TPortak.ID, TPortak.UserId AS Expr1 FROM Users LEFT OUTER JOIN TPortak ON Users.UserId = TPortak.UserId WHERE (TPortak.UserId IS NULL) AND (Users.Username IS NOT NULL) AND (Users.torolve &lt;&gt; 1)"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr runat="server" visible="false" id="nulladiksor1">
                            <td>
                                <asp:Label CssClass="bevitelimezo" ID="LabelNev" runat="server" Text="Porta név:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox CssClass="bevitelimezo" ID="txtUsername" runat="server" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr runat="server" visible="false" id="regijelszo">
                            <td runat="server" visible="false" id="Td1">Régi jelszó:
                            </td>

                            <td>
                                <asp:Button ID="ButtonJelszo" CausesValidation="false" runat="server" Text="Button" OnClick="ButtonJelszo_Click" />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:ChangePassword ID="ChangePassword1" Visible="false" runat="server" OnChangingPassword="OnChangingPassword"
                                    RenderOuterTable="false" NewPasswordRegularExpression="^[\s\S]{5,}$" NewPasswordRegularExpressionErrorMessage="Password must be of minimum 5 characters." CancelDestinationPageUrl="~/Home.aspx">
                                </asp:ChangePassword>
                                <br />
                                <asp:Label ID="lblMessage" runat="server" /></td>

                        </tr>

                        <tr runat="server" id="jelszo">
                            <td runat="server" visible="false" id="nulladiksor2">Jelszó:
                            </td>
                            <td>
                                <asp:TextBox CssClass="bevitelimezo" ID="txtPassword" runat="server" TextMode="Password" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr runat="server" id="jelszo2">
                            <td runat="server" visible="false" id="nulladiksor3" style="height: 24px">Jelszó megerősítése
                            </td>
                            <td style="height: 24px">
                                <asp:TextBox CssClass="bevitelimezo" ID="txtConfirmPassword" runat="server" TextMode="Password" />
                            </td>
                            <td style="height: 24px">
                                <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                                    ControlToValidate="txtConfirmPassword" runat="server" />
                            </td>
                        </tr>
                        <tr runat="server" id="jelszo3">
                            <td runat="server" visible="false" id="nulladiksor4">E-mail
                            </td>
                            <td>
                                <asp:TextBox CssClass="bevitelimezo" ID="txtEmail" runat="server" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="txtEmail" runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationExpression=".+([-+.']\w+)(@)+\w+(.bosch)+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                            </td>
                        </tr>

                        <tr runat="server" id="vastagvonal" visible="false" style="background-color: #000000">
                            <td colspan="8"></td>
                        </tr>


                        <tr runat="server" visible="false" id="masodiksor">
                            <td>Lokáció(k):</td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="Cegek" DataTextField="cegnev" DataValueField="ID"></asp:CheckBoxList>
                                <asp:SqlDataSource ID="Cegek" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT cegnev, ID FROM cegek WHERE (varos = 'Miskolc') ORDER BY cegnev"></asp:SqlDataSource>
                                <asp:Button ID="Button2" runat="server" Text="Új Lokáció Felvétele" CausesValidation="False" OnClick="Button2_Click" />
                                <asp:Panel ID="Panel1" Visible="false" runat="server">
                                    <table>

                                        <tr>
                                            <td>Cégnév</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxcegnev" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Ország</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListOrszag" runat="server" DataSourceID="Orszag" CssClass="bevitelimezo" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList>
                                                <asp:SqlDataSource ID="Orszag" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT ' * Kérlek válassz egyet! *' AS Expr2, '0' AS Expr1 UNION ALL
SELECT [orszagkod], [id] FROM [country]"></asp:SqlDataSource>
                                            </td>
                                            <asp:TextBox Visible="false" ID="TextBoxOrszag" runat="server"></asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td>Irányitószám</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxIranyitoszam" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionRampa" runat="server" CssClass="hibaoszlop" ControlToValidate="TextBoxIranyitoszam" ErrorMessage="Csak szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Város</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxVaros" runat="server"></asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td>Cím</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxCim" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="ButtonLokacio" runat="server" Style="height: 50px; font-weight: bold;" Text="Adatok Felvétele" Visible="true" OnClick="ButtonLokacio_Click" CausesValidation="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>&nbsp;</td>
                        </tr>


                        <tr runat="server" id="vastagvonal2" visible="false" style="background-color: #000000">
                            <td colspan="8"></td>
                        </tr>





                        <tr runat="server" visible="false" id="harmadiksor">
                            <td>Gépjármű tipusa:</td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList2" runat="server" DataValueField="ID" DataSourceID="SqlGepjarmutipusa" DataTextField="gepjarmufajtai"></asp:CheckBoxList>
                                <asp:SqlDataSource ID="SqlGepjarmutipusa" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT [gepjarmufajtai], [ID] FROM [gepjarmuvekcsoportositasa]"></asp:SqlDataSource>
                                <asp:Button ID="Button3" runat="server" Text="Új Gepjarmu tipus Felvétele" CausesValidation="False" OnClick="Button3_Click" />
                                <asp:Panel ID="Panel2" Visible="false" runat="server">
                                    <table>


                                        <tr>
                                            <td>Gépjármű Tipus:</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxgepjarmufajtai" runat="server"></asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td>Kategória:</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxkategoria" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td style="text-align: center">
                                                <asp:Button ID="ButtonTipus" runat="server" Style="height: 50px; font-weight: bold;" Text="Adatok Felvétele" Visible="true" CausesValidation="False" OnClick="ButtonTipus_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr runat="server" id="vastagvonal3" visible="false" style="background-color: #000000">
                            <td colspan="8"></td>
                        </tr>


                        <tr runat="server" visible="false" id="negyediksor">
                            <td>Szállítmányozó(k):</td>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlSzallitmanyozo">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                        <asp:BoundField DataField="transporter_name" HeaderText="transporter_name" SortExpression="transporter_name" />

                                        <asp:TemplateField HeaderText="Fővállalkozó" SortExpression="Fővállalkozó">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("Fővállalkozó") == DBNull.Value ? false : Convert.ToBoolean(Eval("Fővállalkozó"))   %>' Enabled="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alvállalkozó" SortExpression="Alvállalkozó">

                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%#  Eval("Alvállalkozó") == DBNull.Value ? false : Convert.ToBoolean(Eval("Alvállalkozó")) %>' Enabled="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlSzallitmanyozo" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT dbo.Transportes.transporter_name,dbo.Transportes.ID,dbo.KapcsoloTransportesrs.Fővállalkozó, dbo.KapcsoloTransportesrs.Alvállalkozó FROM dbo.Transportes LEFT OUTER JOIN dbo.KapcsoloTransportesrs ON dbo.Transportes.ID = dbo.KapcsoloTransportesrs.TransportesID AND dbo.KapcsoloTransportesrs.PortaID = null ORDER BY dbo.Transportes.transporter_name"></asp:SqlDataSource>
                                <asp:Button ID="Button4" runat="server" Text="Új Szállítmányozó Felvétele" CausesValidation="False" OnClick="Button4_Click" />
                                <asp:Panel ID="Panel3" Visible="false" runat="server">
                                    <table>

                                        <tr>
                                            <td>Neve:</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxTransporterName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>E-mail</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxTransporterEmail" runat="server"></asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td style="height: 31px">Ország</td>
                                            <td style="height: 31px">
                                                <asp:DropDownList ID="DropDownListTransporterOrszag" runat="server" DataSourceID="Orszag" CssClass="bevitelimezo" DataTextField="Expr2" DataValueField="Expr2"></asp:DropDownList>
                                        </tr>

                                        <tr>
                                            <td>Város</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxCity" runat="server"></asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td>Irányitószám</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxpostcode" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="hibaoszlop" ControlToValidate="TextBoxpostcode" ErrorMessage="Csak szám lehet!" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                        </tr>
                                        <tr>
                                            <td>Cím</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxAddress" runat="server"></asp:TextBox>
                                        </tr>



                                        <tr>
                                            <td>Kontakt:

                                            </td>
                                            <td>
                                                <table style="vertical-align: top" id="mitszallit" runat="server">
                                                    <thead>
                                                        <tr>
                                                            <td>Kontakt Név:</td>
                                                            <td>Kontakt Telefonszám:</td>
                                                        </tr>
                                                    </thead>
                                                    <tr>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                                                <asp:TextBox ID="TextBoxS1" Visible="false" runat="server"></asp:TextBox><br />
                                                                <asp:TextBox ID="TextBoxS2" Visible="false" runat="server"></asp:TextBox><br />
                                                                <asp:TextBox ID="TextBoxS3" Visible="false" runat="server"></asp:TextBox><br />
                                                            </asp:PlaceHolder>
                                                        </td>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                                                                <asp:TextBox ID="TextBox9" Visible="false" runat="server"></asp:TextBox><br />
                                                                <asp:TextBox ID="TextBox10" Visible="false" runat="server"></asp:TextBox><br />
                                                                <asp:TextBox ID="TextBox11" Visible="false" runat="server"></asp:TextBox><br />
                                                            </asp:PlaceHolder>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button8" runat="server" Text="+" CausesValidation="False" OnClick="Button3_Click1" Style="width: 22px" />
                                                            <asp:Label ID="LabelHiba" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>


                                            </td>
                                        </tr>

                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Style="height: 50px; font-weight: bold;" Text="Adatok Felvétele" Visible="true" CausesValidation="False" OnClick="Button1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr runat="server" id="vastagvonal4" visible="false" style="background-color: #000000">
                            <td colspan="8"></td>
                        </tr>

                        <tr runat="server" visible="false" id="otodiksor">
                            <td>Mitszállíthat:</td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="megnevezes" DataValueField="id"></asp:CheckBoxList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT [id], [megnevezes] FROM [mitszallit]"></asp:SqlDataSource>
                                <asp:Button ID="ButtonMitszallit" runat="server" Text="Új szállítmány Felvétele" CausesValidation="False" OnClick="ButtonMitszallit_Click" />
                                <asp:Panel ID="Panel4" Visible="false" runat="server">
                                    <table>

                                        <tr>
                                            <td>Megnevezes</td>
                                            <td>
                                                <asp:TextBox CssClass="bevitelimezo" ID="TextBoxMegnevezes" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button6" runat="server" Style="height: 50px; font-weight: bold;" Text="Adatok Felvétele" Visible="true" CausesValidation="False" OnClick="Button6_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr runat="server" id="vastagvonal7" visible="false" style="background-color: #000000">
                            <td colspan="8"></td>
                        </tr>


                        <tr runat="server" visible="false" id="szallitmanysor">
                            <td>Szállítmány egyedi azonosító:</td>
                            <td>
                                <asp:TextBox CssClass="bevitelimezo" ID="TextBox1" runat="server"></asp:TextBox>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr runat="server" visible="false" id="gombsor">
                            <td>
                                <asp:SqlDataSource ID="SqlDataSourceRaktarak" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT ' * Kérlek válassz egyet! *' AS Username, '-1' AS UserId, 0 AS ID, 0 AS Expr1, 0 AS PortaID  UNION ALL 
SELECT       Users.Username,  Users.UserId, TPortak.ID, TPortak.UserId AS Expr1, TPortak.PortaID
FROM            Users LEFT OUTER JOIN
                         TPortak ON Users.UserId = TPortak.UserId
WHERE        (TPortak.UserId IS NOT NULL) AND (Users.Username IS NOT NULL) AND (Users.torolve &lt;&gt; 1)
"></asp:SqlDataSource>
                            </td>
                            <td style="text-align: center">

                                <asp:Button ID="Button5" runat="server" OnClick="RegisterUser" Style="height: 50px; font-weight: bold;" Text="Adatok Felvétele" />
                            </td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Style="font-weight: bold; background-color: #FF0000;" Text="Adatok Törlése" OnClick="Button7_Click" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="LabelHibaKi" runat="server" Style="color: #FF3300"></asp:Label>


                            </td>


                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>
    </div>
</asp:Content>

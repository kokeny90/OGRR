<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserCreat.aspx.cs" Inherits="UserCreat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="Panel1" runat="server" DefaultButton="bt_useradd">

        <table border="0">

            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label6" runat="server" SkinID="lbl_text" Text="<% $Resources:Resource, username %>"></asp:Label>:
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="tb_felhasznalonev" runat="server" SkinID="tb_oval_mandatory"
                        AutoPostBack="True" OnTextChanged="tb_felhasznalonev_TextChanged"></asp:TextBox>
                </td>


            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label5" runat="server" SkinID="lbl_text" Text="<% $Resources:Resource, name %>"></asp:Label>:
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="tb_nev" runat="server" SkinID="tb_oval_mandatory"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label7" runat="server" SkinID="lbl_text" Text="E-mail:"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="tb_email" runat="server" SkinID="tb_oval"></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server"
                        ControlToValidate="tb_email" ErrorMessage="<% $Resources:Resource, email_not_valid %>" ForeColor="Red" Font-Size="Smaller"
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <%--<td>&nbsp;
                </td>--%>
            </tr>
            <tr>
                <td>Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
                </td>
                <td>
                    <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                        ControlToValidate="txtConfirmPassword" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <%--<asp:Label ID="Label2" runat="server" SkinID="lbl_text" Text="Osztály: "></asp:Label>--%>
                </td>
                <td style="text-align: left"><%--
                    <asp:DropDownList ID="ddl_osztaly" runat="server" OnTextChanged="ddl_osztaly_TextChanged" AutoPostBack="True" SkinID="ddl_oval_mandatory"
                        OnSelectedIndexChanged="ddl_osztaly_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Válasszon...</asp:ListItem>
                    </asp:DropDownList>--%>
                    <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:conn %>"
                        SelectCommand=""></asp:SqlDataSource>--%>
                </td>
                <%--<td>&nbsp;
                </td>--%>
            </tr>
            <%--<tr>
                <td style="text-align: right">
                    <asp:Label ID="Label3" runat="server" Style="font-family: 'Century Gothic'" Text="PVB: "></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddl_pvb" runat="server" OnTextChanged="ddl_pvb_TextChanged" AutoPostBack="True" SkinID="ddl_oval"  onselectedindexchanged="ddl_pvb_SelectedIndexChanged">
                        <asp:ListItem>Válasszon...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    <asp:Button ID="bt_pvb_hozzaad" runat="server" Text="+" ToolTip="Itt új PVB-kat adhat meg adott Osztályhoz." OnClick="bt_pvb_hozzaad_Click" SkinID="btn_blue" Width="50"/>
                </td>
            </tr>--%>
            <tr>
                <td style="text-align: right; vertical-align: top">
                    <asp:Label ID="lbl_csoportok" runat="server" Text="<% $Resources:Resource, groups %>" SkinID="lbl_text"></asp:Label>:
                </td>
                <td style="display: inline-block; text-align: left; vertical-align: top" colspan="0">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div style="display: inline-block">
                                <asp:CheckBoxList ID="CheckBoxListTopMenu"
                                    runat="server" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxListUsers_SelectedIndexChanged" DataSourceID="SqlDataSourceMenuTop" DataTextField="Name" DataValueField="MenuId">
                                </asp:CheckBoxList>
                            </div>
                            <div style="display: inline-block">
                                <asp:CheckBoxList ID="CheckBoxListMenu"
                                    runat="server" CssClass="oval"
                                    BorderStyle="Solid" BorderColor="Red" EnableTheming="True">
                                </asp:CheckBoxList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td style="text-align: right; vertical-align: top">
                    <%--<asp:Label ID="Lbl_mail_list" runat="server" Text="Levelezőlisták:"></asp:Label>--%>
                </td>
                <td style="text-align: left; vertical-align: top" colspan="0"><%--
                    <asp:CheckBoxList ID="CheckBoxList_mail_list" runat="server" CssClass="oval" BorderStyle="Solid" BorderColor="Gainsboro"
                        DataSourceID="SqlDataSource_mail_list" DataTextField="riportnev"
                        DataValueField="riportnev" EnableTheming="True">
                    </asp:CheckBoxList>
                    <asp:SqlDataSource ID="SqlDataSource_mail_list" runat="server"
                        ConnectionString="<%$ ConnectionStrings:conn %>"
                        OnSelecting="SqlDataSource2_Selecting"
                        SelectCommand="SELECT DISTINCT [riportnev] FROM [sl_mail_list] ORDER BY riportnev ASC"></asp:SqlDataSource>--%>
                </td>
                <%--<td style="text-align: right" colspan="0">&nbsp;
                </td>--%>
            </tr>
            <tr>
                <%--<td>&nbsp;
                </td>--%>
                <td style="text-align: left" colspan="2">
                    <asp:Label ID="lbl_uzenet" runat="server" Text="Label" Visible="false"></asp:Label>
                </td>
                <%--<td>&nbsp;
                </td>--%>
            </tr>
            <tr>
                <%--      <td style="text-align: center">
                    <asp:Button ID="bt_adaturit" Visible="false" runat="server" OnClick="bt_adaturit_Click" SkinID="btn_blue" Text="Adatok ürítése" />
                </td>--%>
                <td style="text-align: center" align="right">
                    <asp:Button ID="bt_useradd" runat="server" Text="<% $Resources:Resource, useradd %>" OnClick="bt_useradd_Click" SkinID="btn_blue" />
                </td>
                <%--<td>&nbsp;
                </td>--%>
            </tr>
        </table>
        <asp:SqlDataSource runat="server" ID="SqlDataSourceMenu" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT     Name, MenuId FROM dbo.TPageNames GROUP BY Name, MenuId HAVING (Name IS NOT NULL) ORDER BY Name"></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="SqlDataSourceMenuTop" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT MenuId, Name FROM TPageNames where  ParentmenuId =0"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>

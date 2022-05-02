<%@ Page Title="" ValidateRequest="false"  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LSP.aspx.cs" Inherits="Transporters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tableBackground {
            background-color: silver;
            opacity: 0.7;
        }
    </style>
    <style type="text/css">
        .rotate {
            border-radius: 50%;
            -webkit-transition: -webkit-transform .8s ease-in-out;
            transition: transform .8s ease-in-out;
        }

            .rotate:hover {
                -webkit-transform: rotate(360deg);
                transform: rotate(360deg);
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ImageButton ID="ImageButtonExcel"    Width="50" Height="50" runat="server" ImageUrl="~/Images/excel.png" ToolTip="Excelbe importálás" OnClick="ImageButtonExcel_Click" />

            <asp:GridView ID="GridViewLSP" OnRowDeleting="GridViewLSP_RowDeleting" ShowFooter="true" DataKeyNames="ID" OnRowDataBound="GridViewSGHUORDER_RowDataBound" CssClass="nowrap" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnRowCancelingEdit="GridViewSGHUORDER_RowCancelingEdit" OnPageIndexChanging="GridViewSGHUORDER_PageIndexChanging" OnRowEditing="GridViewSGHUORDER_RowEditing" PageSize="100" OnRowUpdating="GridViewSGHUORDER_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <HeaderTemplate>
                            <asp:Label ID="Label2" runat="server" Text="Filter"></asp:Label><br />
                            <asp:ImageButton ID="ImageButtonUpd" AutoPostBack="true" OnClick="ImageButtonUpd_Click" runat="server" CssClass="rotate" ImageUrl="~/Images/upd-sg_green.png" Width="25" Height="25" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" Text="Edit" OnClick="lnkEdit_Click" CausesValidation="false" runat="server"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/Images/ml_add.png" Width="25" Height="25" OnClick="ImageButtonAdd_Click1" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeaderID" runat="server" Text="ID"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" ID="TextBoxID" runat="server" OnTextChanged="TextBoxID_TextChanged"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelID" runat="server" Text='<% #Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxID" runat="server" Text='<% #Bind("ID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="HeaderLabelName" runat="server" Text="Name"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" ID="TextBoxName" OnTextChanged="TextBoxName_TextChanged" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelOrderName" runat="server" Text='<% #Bind("Name")  %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="LabelEditOrderName" runat="server" Text='<% #Bind("Name") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeaderEmail" runat="server" Text="Email"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="TextBoxEmail_TextChanged" ID="TextBoxEmail" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelEmail" runat="server" Text='<% #Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="LabelEmail" runat="server" Text='<% #Bind("Email") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeaderCC" runat="server" Text="CC (Carbon copy)"></asp:Label><br>
                            <%--            <asp:TextBox AutoPostBack="true" OnTextChanged="TextBoxEmail_TextChanged" ID="TextBoxEmail" runat="server"></asp:TextBox>--%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelCC" runat="server" Text='<% #Bind("CC") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="LabelCC" runat="server" Text='<% #Bind("CC") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeaderPostCode" runat="server" Text="PostCode"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="TextBoxPostCode_TextChanged" ID="TextBoxPostCode" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelPostCode" runat="server" Text='<% #Bind("PostCode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxPostCode" runat="server" Text='<% #Bind("PostCode") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="HeaderLabelCity" runat="server" Text="City"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="TextBoxCity_TextChanged" ID="TextBoxCity" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelCity" runat="server" Text='<% #Bind("City") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxCity" runat="server" Text='<% #Bind("City") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="HeaderLabelFax" runat="server" Text="Fax"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="TextBoxFax_TextChanged" ID="TextBoxFax" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelFax" runat="server" Text='<% #Bind("Fax") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxFax" runat="server" Text='<% #Bind("Fax") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeaderorszagkod" runat="server" Text="Országkod"></asp:Label><br>
                            <asp:DropDownList CssClass="bevitelimezo" ID="DropDownListorszagkod" AutoPostBack="true" runat="server" DataSourceID="SqlDataSourceOrszag" OnTextChanged="DropDownListorszagkod_TextChanged" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labelorszagkod" runat="server" Text='<% #Bind("orszagkod") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxorszagkod" runat="server" Text='<% #Bind("orszagkod") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeaderContactName" runat="server" Text="Contact Name"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="TextBoxContactName_TextChanged" ID="TextBoxContactName" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelContactName" runat="server" Text='<% #Bind("ContactName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxContactName" runat="server" Text='<% #Bind("ContactName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeaderContactPhone" runat="server" Text="ContactPhone"></asp:Label><br>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="TextBoxContactPhone_TextChanged" ID="TextBoxContactPhone" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelContactPhone" runat="server" Text='<% #Bind("ContactPhone") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxContactPhone" runat="server" Text='<% #Bind("ContactPhone") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSourceOrszag" runat="server" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT '- 1' AS Expr1, ' * Kérlek válassz egyet! * ' AS Expr2 UNION ALL SELECT id, orszagkod FROM country ORDER BY Expr2"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceLSP" runat="server"></asp:SqlDataSource>

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="modelPopup" PopupControlID="updatePanel"
                BackgroundCssClass="tableBackground">
            </asp:ModalPopupExtender>
            <asp:Label ID="lblmsg" runat="server" />
            <asp:Button ID="modelPopup" runat="server" Style="display: none" />
            <asp:Panel ID="updatePanel" runat="server" BackColor="White" Height="555px" Width="444px" Style="display: none">
                <table width="100%" cellspacing="4">
                    <tr style="background-color: #33CC66">
                        <td colspan="2" align="center">Store Details</td>
                    </tr>
                    <tr runat="server" id="idsor">
                        <td align="right" style="width: 45%">Stor ID:
                        </td>
                        <td>
                            <asp:Label ID="lblstor_id" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" AutoPostBack="true" OnTextChanged="txtName_TextChanged" CssClass="bevitelimezo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Email:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" CssClass="bevitelimezo" runat="server" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">CC:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCC" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" CssClass="bevitelimezo" runat="server" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">PostCode:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostCode" CssClass="bevitelimezo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Adress:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdress" CssClass="bevitelimezo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">City:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" CssClass="bevitelimezo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Orszagkod:
                        </td>
                        <td>
                            <asp:DropDownList CssClass="bevitelimezo" ID="DropDownListCountry" runat="server" DataSourceID="SqlDataSourceOrszag" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Fax:
                        </td>
                        <td>
                            <asp:TextBox CssClass="bevitelimezo" ID="txtFax" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView OnRowCancelingEdit="GridViewContact_RowCancelingEdit" OnRowUpdating="GridViewContact_RowUpdating" OnRowEditing="GridViewContact_RowEditing" ShowHeaderWhenEmpty="true" OnRowDeleting="GridViewContact_RowDeleting" ShowHFooterWhenEmpty="true" ID="GridViewContact" ShowFooter="true" runat="server" AutoGenerateColumns="False" Style="margin-top: 0px" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="Filter"></asp:Label><br />
                                            <asp:ImageButton ID="ImageButtonUpd" runat="server" CssClass="rotate" ImageUrl="~/Images/upd-sg_green.png" Width="25" Height="25" />
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="ImageButtonAdd" Visible="true" runat="server" ImageUrl="~/Images/ml_add.png" Width="25" Height="25" OnClick="ImageButtonAdd_Click3" />
                                            <asp:ImageButton ID="ImageButtonCancel" runat="server" ImageUrl="~/Images/ml_cancel.png" Visible="false" Width="25" Height="25" />
                                            <asp:ImageButton ID="ImageButtonOK" runat="server" ImageUrl="~/Images/ml_ok.png" Visible="false" Width="25" Height="25" OnClick="ImageButtonOK_Click" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenFieldID" runat="server"
                                                Value='<%# Eval("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ContactName" SortExpression="ContactName">
                                        <HeaderTemplate>
                                            <asp:TextBox ID="TextBoxContactName" runat="server"></asp:TextBox><br />
                                            <asp:Label ID="LabelContactName" runat="server" Text="ContactName"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# Bind("ContactName") %>' ID="TextBoxContactName"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBoxContactName" Visible="false" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ContactPhone" SortExpression="ContactPhone">
                                        <HeaderTemplate>
                                            <asp:TextBox ID="TextBoxContactPhone" runat="server"></asp:TextBox><br />
                                            <asp:Label ID="LabelContactPhone" runat="server" Text="ContactPhone"></asp:Label>
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelContactPhone" runat="server" Text='<%# Bind("ContactPhone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# Bind("ContactPhone") %>' ID="TextBoxContactPhone"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="LabelPlus" Visible="false" runat="server" Text="+"></asp:Label>&nbsp;<asp:TextBox ID="TextBoxContactPhone" PlaceHolder="36706254234" OnTextChanged="TextBoxContactPhone_TextChanged1" AutoPostBack="true" Visible="false" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

                                <RowStyle BackColor="#E3EAEB"></RowStyle>

                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                            <asp:Label Visible="false" ID="LabelHiba" runat="server"></asp:Label>
                            <asp:SqlDataSource runat="server" ID="SqlDataSourceContact" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' ></asp:SqlDataSource>
                        </td>

                    </tr>

                    <tr>
                        <td align="right">
                            <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update Data" OnClick="btnUpdate_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


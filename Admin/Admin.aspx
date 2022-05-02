<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="styletable">
        <tr>
            <td>
                <asp:Button ID="ButtonMailSettings" CausesValidation="false" CssClass="button" runat="server" Text="Levelezés Beállitás" OnClick="ButtonMailSettings_Click" />
            </td>
            <td>
                <asp:Button ID="ButtonUsersSettings" CausesValidation="false" CssClass="button" runat="server" Text="Felhasználók Beállitás" OnClick="ButtonUsersSettings_Click" />
            </td>
            <td>
                <asp:Button ID="ButtonDatabaseSettings" CausesValidation="false" CssClass="button" runat="server" Text="Adatbázis Beállítás" OnClick="ButtonDatabaseSettings_Click" />
            </td>
        </tr>
        <tr runat="server" id="MailSettings" visible="false">
            <td colspan="3">
                <table>
                    <tr>
                        <td>

                            <asp:Label ID="LabelMailAddress" runat="server" CssClass="bevitelimezo" Text="Levelezési cím:"></asp:Label><br />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMailAddress" CssClass="bevitelimezo" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelPort" runat="server" CssClass="bevitelimezo" Text="Port:"></asp:Label><br />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPort" CssClass="bevitelimezo" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelPassword" runat="server" CssClass="bevitelimezo" Text="Jelszó:"></asp:Label><br />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPassword" CssClass="bevitelimezo" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelHost" runat="server" CssClass="bevitelimezo" Text="Host:"></asp:Label><br />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxHost" CssClass="bevitelimezo" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ButtonMailSettingsSave" CssClass="btn btn-default send-message" runat="server" Text="Mentés" OnClick="ButtonMailSettingsSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonTestMail" CssClass="btn btn-default send-message" runat="server" Text="Próba Levél" OnClick="ButtonTestMail_Click" />
                        </td>
                    </tr>

                </table>
            </td>

        </tr>
        <tr runat="server" id="UsersSettings" visible="false">
            <td>
                <asp:DropDownList AutoPostBack="true" ID="DropDownListUser" runat="server" DataSourceID="SqlDataSourceUserName" DataTextField="Username" DataValueField="UserId" OnSelectedIndexChanged="DropDownListUser_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <table runat="server" id="userdata" visible="false" border="0">
                    <tr>
                        <td style="text-align: right" class="auto-style2">
                            <asp:Label ID="Label6" runat="server" SkinID="lbl_text" Text="<% $Resources:Resource, username %>"></asp:Label>
                        </td>
                        <td style="text-align: left" class="auto-style2">
                            <asp:TextBox ID="tb_felhasznalonev" runat="server" SkinID="tb_oval_mandatory" AutoPostBack="True"></asp:TextBox>
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
                        <td style="text-align: right"></td>
                        <td style="text-align: left"></td>

                    </tr>

                    <tr>
                        <td style="text-align: right; vertical-align: top">
                            <asp:Label ID="lbl_csoportok" runat="server" Text="<% $Resources:Resource, groups %>" SkinID="lbl_text"></asp:Label>:
                        </td>
                        <td style="display: inline-block; text-align: left; vertical-align: top" colspan="0">
                            <div style="display: inline-block">
                                <asp:CheckBoxList ID="CheckBoxListTopMenu" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxListUsers_SelectedIndexChanged" DataTextField="Name" DataValueField="MenuId">
                                </asp:CheckBoxList>

                            </div>
                            <div style="display: inline-block">
                                <asp:CheckBoxList ID="CheckBoxListMenu" runat="server" CssClass="oval" BorderStyle="Solid" BorderColor="Red"
                                    EnableTheming="True">
                                </asp:CheckBoxList>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top"></td>
                        <td style="text-align: left; vertical-align: top" colspan="0"></td>

                    </tr>
                    <tr>

                        <td style="text-align: left" colspan="2">
                            <asp:Label ID="lbl_uzenet" runat="server" Text="Label" Visible="false"></asp:Label>
                        </td>

                    </tr>
                    <tr>

                        <td style="text-align: center" align="right">
                            <%--<asp:Button ID="bt_useradd" runat="server" Text="<% $Resources:Resource, useradd %>" OnClick="bt_useradd_Click" SkinID="btn_blue" />--%>
                        </td>

                    </tr>
                </table>



            </td>
            <td style="width: 10px; height: 10px">
                <asp:GridView ShowFooter="True" Style="width: 10px; height: 10px" ID="GridViewUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit" OnRowEditing="GridViewUsers_RowEditing" OnRowUpdating="GridViewUsers_RowUpdating" OnRowDataBound="GridViewUsers_RowDataBound" AutoGenerateDeleteButton="True" OnRowDeleting="GridViewUsers_RowDeleting">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/Images/ml_add.png" Width="25" Height="25" OnClick="ImageButtonAdd_Click" />
                                <asp:ImageButton ID="ImageButtonCancel" runat="server" ImageUrl="~/Images/ml_cancel.png" Visible="false" Width="25" Height="25" OnClick="ImageButtonCancel_Click" />
                                <asp:ImageButton ID="ImageButtonOK" runat="server" ImageUrl="~/Images/ml_ok.png" Visible="false" Width="25" Height="25" OnClick="ImageButtonOK_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserId" InsertVisible="False" SortExpression="UserId">
                            <EditItemTemplate>
                                <asp:Label ID="LabelUserIdEdit" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelUserId" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Username" SortExpression="Username">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxUsernameEdit" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelUsername" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxUsername" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password" SortExpression="Password">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxPasswordEdit" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelPassword" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxPassword" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxEmailEdit" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxEmail" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CreatedDate" SortExpression="CreatedDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxCreatedDate" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="LastLoginDate" SortExpression="LastLoginDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("LastLoginDate") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("LastLoginDate") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Signature" SortExpression="Signature">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxSignatureEdit" runat="server" Text='<%# Bind("Signature") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Signature") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxSignature" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nev" SortExpression="Nev">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxNevEdit" runat="server" Text='<%# Bind("Nev") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelNev" runat="server" Text='<%# Bind("Nev") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNev" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CegID" SortExpression="CegID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxCegIDEdit" runat="server" Text='<%# Bind("CegID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("CegID") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxCegID" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="torolve" SortExpression="torolve">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBoxTorolveEdit" runat="server" Checked='<%# Bind("torolve") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("torolve") %>' Enabled="false" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="CheckBoxtorolve" CssClass="bevitelimezo" Visible="false" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PasswordChange" SortExpression="PasswordChange">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBoxPasswordChangeEdit" runat="server" Checked='<%# Bind("PasswordChange") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("PasswordChange") %>' Enabled="false" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="CheckBoxPasswordChange" CssClass="bevitelimezo" Visible="false" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HomePage" SortExpression="HomePage">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxHomePageEdit" runat="server" Text='<%# Bind("HomePage") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("HomePage") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxHomePage" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="active" SortExpression="active">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBoxactiveEdit" runat="server" Checked='<%# Bind("active") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("active") %>' Enabled="false" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="CheckBoxactive" CssClass="bevitelimezo" Visible="false" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999"></EditRowStyle>

                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                    <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </td>

        </tr>
        <tr runat="server" id="DatabaseSettings" visible="false" style="width: 100%">
            <td colspan="3" class="szurkeinformacio">
                <table cellpadding="10">
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Adatbézis Kapcsolat:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="bevitelimezo" Width="500px" ID="TextBoxConnectionString" TextMode="MultiLine" MaxLength="50" runat="server"></asp:TextBox><br />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-default send-message" Style="width: 222px" ID="Button1" runat="server" Text="Adatbázis szerekezet létrehozás" OnClick="ButtonDatabseSave_Click" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-default send-message" Style="width: 222px" ID="Button2" runat="server" Text="Adatbázis Tesztelése" OnClick="ButtonDatabseSave_Click" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-default send-message" Style="width: 222px" ID="ButtonDatabseSav" runat="server" Text="Adatbázis Mentése" OnClick="ButtonDatabseSave_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Teszt Adatbázis Kapcsolat:"></asp:Label></td>
                        <td>
                            <asp:TextBox CssClass="bevitelimezo" Width="500px" ID="TextBoxTestConnectionString" TextMode="MultiLine" MaxLength="50" runat="server"></asp:TextBox><br />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-default send-message" Style="width: 222px" ID="Button3" runat="server" Text="Teszt Adatbázis szerekezet létrehozása" OnClick="ButtonDatabseSave_Click" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-default send-message" Style="width: 222px" ID="Button4" runat="server" Text="Teszt Adatbázis Tesztelése" OnClick="ButtonDatabseSave_Click" />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-default send-message" Style="width: 222px" ID="Button5" runat="server" Text="Teszt Adatbázis Mentése" OnClick="ButtonDatabseSave_Click" />
                        </td>
                    </tr>
                </table>


            </td>



        </tr>
    </table>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceMenu" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT     Name, MenuId FROM dbo.TPageNames GROUP BY Name, MenuId HAVING (Name IS NOT NULL) ORDER BY Name"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceMenuTop" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT MenuId, Name FROM TPageNames where  ParentmenuId =0"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceUsers" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceUserName" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT [UserId], [Username] FROM [Users] WHERE ([Username] IS NOT NULL) ORDER BY [Username]"></asp:SqlDataSource>


</asp:Content>


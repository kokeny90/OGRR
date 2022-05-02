<%@ Page Title="" Language="C#" ValidateRequest="false" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="ordernew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="scripts/jquery-3.1.0.js">
    </script>
    <script type="text/javascript" src="Mail.js">

    </script>
    <script type="text/javascript" src="Upload.js">

    </script>

    <style type="text/css">
        body {
            font-family: Verdana;
            font-size: 8pt;
            margin: 10px;
        }

        .button {
            font-family: Verdana;
            font-size: 8pt;
            width: 100px;
            height: 30px;
        }

        .previewButton {
            margin-left: 10px;
            margin-right: 10px;
            margin-top: 3px;
            width: 75px;
            height: 28px;
        }

        .radiobuttonList label {
            margin-right: 5px;
        }

        .auto-style3 {
            font-family: 'Titillium Web';
            font-size: large;
            font-weight: bold;
            background-color: whitesmoke;
            text-align: left;
            width: 110px;
            align-items: center;
            height: 30px;
        }

        .preview {
            width: 578px;
            padding: 10px;
        }

        div#Content {
            width: 780px;
        }

        table#DemoTable {
            width: 780px;
        }

        td#EditorCell {
            width: 600px;
            vertical-align: top;
        }

        td#OptionsCell {
            width: 180px;
            vertical-align: top;
        }

        div#Options {
            width: 150px;
            margin-left: 5px;
        }

        div#DemoControls {
            width: 600px;
            height: 25px;
            line-height: 25px;
            text-align: center;
        }

        div#Preview {
            width: 598px;
            border: solid 1px gray;
            margin-top: 25px;
        }

        div#PreviewControls {
            height: 35px;
            line-height: 35px;
            text-align: left;
            border-bottom: solid 1px gray;
        }

        div.demoHeading {
            height: 25px;
            line-height: 25px;
            color: black;
            font-weight: bold;
            border-bottom: solid 1px gray;
            text-align: center;
        }

        div.optionsHeading {
            font-size: 10pt;
            border: none;
            text-align: left;
            margin-left: 10px;
        }

        div.optionsLabel {
            margin: 10px;
            font-weight: bold;
        }

        div.optionControls {
            margin-left: 10px;
        }

        div#Footer {
            margin-top: 10px;
            color: #7f9db9;
            font-size: 7pt;
        }

        div#Footer {
            margin-top: 10px;
            color: black;
            font-size: 7pt;
        }

        a:link.poweredby, a:visited.poweredby, a:active.poweredby {
            color: black;
            text-decoration: none;
        }

        a:hover.poweredby {
            text-decoration: underline;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="styletable">
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label8" runat="server" Text="Computer Name:"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <asp:Label ID="LabelMachineName" runat="server" Text="Label" CssClass="bevitelimezo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label9" runat="server" Text="User Name:"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <asp:LoginName CssClass="bevitelimezo" ID="LoginName1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label10" runat="server" Text="From:"></asp:Label><br />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListFrom" CssClass="bevitelimezo" runat="server" DataSourceID="SqlDataSourceOrszag" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label11" runat="server" Text="To:"></asp:Label><br />
                </td>
                <td class="bevitelimezocella">
                    <asp:DropDownList ID="DropDownListTo" CssClass="bevitelimezo" runat="server" DataSourceID="SqlDataSourceOrszag" DataTextField="Expr2" DataValueField="Expr1"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label1" runat="server" Text="Date Of Order:" Width="161px"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="TextBoxDate" runat="server" Enabled="true" Format="yyyy.MM.dd" FirstDayOfWeek="Monday" />
                    <asp:TextBox ID="TextBoxDate" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="LabelPlannedPickUp" runat="server" Text="Planned pick up:" Width="161px"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="TextBoxPlannedPickUp" runat="server" Enabled="true" Format="yyyy.MM.dd" FirstDayOfWeek="Monday" />
                    <asp:TextBox ID="TextBoxPlannedPickUp" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label4" runat="server" Text="Profit Center"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <asp:DropDownList CssClass="bevitelimezo" AutoPostBack="true" ID="DropDownListProfitCenter" runat="server" DataSourceID="SqlDataSource2" DataTextField="Expr2" DataValueField="Expr1" OnSelectedIndexChanged="DropDownListProfitCenter_SelectedIndexChanged" OnTextChanged="DropDownListProfitCenter_TextChanged">
                    </asp:DropDownList>
                    <table id="profitcentertabla" runat="server" visible="false">
                        <tr>
                            <td>
                                <asp:Label ID="LabelProfitcenter" runat="server" Text="Profitcenter"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="LabelMegnevezes" runat="server" Text="Megnevezés"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBoxProfitCenter" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMegnevezes" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButtonProfitCenter" AutoPostBack="true" runat="server" CssClass="rotate" ImageUrl="~/Images/ml_cancel.png" Width="25" Height="25" OnClick="ImageButtonProfitCenter_Click" Visible="False" CausesValidation="False" />

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Labeltransportername" runat="server" Text="Forwarder Name"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <asp:DropDownList CssClass="bevitelimezo" AutoPostBack="True" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Expr1" DataValueField="Expr2" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnTextChanged="DropDownList1_TextChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="TextBoxTransporter" CssClass="bevitelimezo" Visible="false" runat="server"></asp:TextBox>&nbsp;<asp:ImageButton ID="ImageButtonFor" AutoPostBack="true" runat="server" CssClass="rotate" ImageUrl="~/Images/ml_cancel.png" Width="25" Height="25" OnClick="ImageButtonFor_Click" Visible="False" CausesValidation="False" />

                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label5" runat="server" Text="Requester:"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <asp:TextBox CssClass="bevitelimezo" ID="TextBoxPerson" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label7" runat="server" Text="To...*"></asp:Label><br />
                </td>
                <td class="bevitelimezocella">
                    <asp:TextBox CssClass="bevitelimezo" ID="txtEmail" runat="server" Width="500px"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label13" runat="server" Text="Cc...*"></asp:Label><br />
                </td>
                <td class="bevitelimezocella">
                    <asp:TextBox CssClass="bevitelimezo" ID="TextCC" runat="server" Width="500px"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="Label6" runat="server" Height="16px" Text="Information:" Width="106px"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <textarea runat="server" id="TextBoxInfo"></textarea>
                </td>
            </tr>
            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="LabelAlairas" runat="server" Height="16px" Text="Signature:" Width="106px"></asp:Label>
                </td>
                <td class="bevitelimezocella">
                    <textarea id="TextBoxAlairas" runat="server"></textarea><br />
                </td>
            </tr>





            <tr>
                <td class="szurkeinformacio">
                    <asp:Label ID="LabelAttachment" runat="server" Height="16px" Text="Attachment:" Width="106px"></asp:Label>
                </td>
                <td class="bevitelimezocella">

                    <div>
                        <asp:Label runat="server" ID="myThrobber" Style="display: none;"><img  alt="" src="images/uploading.gif"/></asp:Label>
                        <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete" EnablePartialRendering="true" MaximumNumberOfFiles="10" />

                    </div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No files uploaded">
                        <Columns>
                            <asp:BoundField DataField="Text" HeaderText="File Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="DownloadFile"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" Text="Delete" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="DeleteFile" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


                </td>

            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT -2  AS Expr1, ' * Kérlek válassz egyet! * ' AS Expr2 UNION ALL SELECT -1  AS Expr1, ' * Egyéb * ' AS Expr2 UNION ALL  SELECT ID, ProfitCenter + ' | ' + Megnevezés AS legordulo FROM [Copy Of dbo_ProfitCenter]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT        ' * Kérlek válassz egyet! *' AS Expr1, - 1 AS Expr2
UNION ALL
SELECT        '* Egyéb *' AS Expr1, - 2 AS Expr2
UNION ALL
SELECT        NAME, ID
FROM            LSP
ORDER BY Expr1"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceOrszag" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" SelectCommand="SELECT '- 1' AS Expr1, ' * Kérlek válassz egyet! * ' AS Expr2 UNION ALL SELECT id, orszagkod FROM country ORDER BY Expr2"></asp:SqlDataSource>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr style="vertical-align: bottom; line-height: 10px;">
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr style="vertical-align: bottom; line-height: 10px;">
                <td class="auto-style3">
                    <h6><strong>
                        <asp:Button CausesValidation="false" ID="Button4" runat="server" OnClick="Button4_Click" Text="Back" Width="56px" CssClass="gomb" />
                    </strong></h6>
                </td>
                <td class="auto-style3">
                    <h6 style="text-align: center"><strong>
                        <asp:Button CausesValidation="false" ID="Button3" runat="server" OnClick="Button1_Click" Text="Save And Send Mail" CssClass="gomb" />
                    </strong></h6>
                </td>
                <td class="auto-style3"></td>
            </tr>
        </table>

    </div>



</asp:Content>

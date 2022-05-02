<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Form_Kereses.aspx.cs" ValidateRequest="false" Inherits="Form_Kereses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="Mail.js">
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="styletable">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="Resend E-mail:"></asp:Label>

            </td>
            <td class="bevitelimezocella">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="bevitelimezo" DataSourceID="SqlDataSource1" DataTextField="legordulo" DataValueField="OrderID" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem Value="">Please Select</asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>
        <tr runat="server" visible="false" id="RowResendmail">
            <td colspan="2">
                <table>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelOrderNumberText" runat="server" Text="Order Number:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:Label ID="LabelOrderNumber" runat="server" Text="Label" CssClass="bevitelimezo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label7" runat="server" Text="Computer:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:Label ID="LabelComputer" runat="server" Text="Label" CssClass="bevitelimezo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label6" runat="server" Text="Person"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:Label ID="LabelPerson" runat="server" Text="Label" CssClass="bevitelimezo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelTracking" runat="server" Text="Tracking Number:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBoxTracking" CssClass="bevitelimezocellaTracking" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelTrailer" runat="server" Text="Trailer Number"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBoxTrailer" CssClass="bevitelimezocellaTrailer" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label16" runat="server" Text="From:"></asp:Label><br />
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListFrom" AutoPostBack="True" CssClass="bevitelimezo" runat="server" DataSourceID="SqlDataSourceOrszagKod" DataTextField="OrszagKod" DataValueField="ID" OnSelectedIndexChanged="DropDownListFrom_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label17" runat="server" Text="To:"></asp:Label><br />
                        </td>
                        <td class="bevitelimezocella">
                            <asp:DropDownList ID="DropDownListTo" CssClass="bevitelimezo" runat="server" DataSourceID="SqlDataSourceOrszagKod" AutoPostBack="True" DataTextField="OrszagKod" DataValueField="ID" OnSelectedIndexChanged="DropDownListTo_SelectedIndexChanged1"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label5" CssClass="bevitelimezocella1" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:Label ID="LabelDate" runat="server" Text="Label" CssClass="bevitelimezo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelPlannedPickUp" runat="server" Text="Planned pick up:" Width="161px"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="TextBoxPlannedPickUp" runat="server" Enabled="true" Format="yyyy.MM.dd" />
                            <asp:TextBox ID="TextBoxPlannedPickUp" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelActualpickup" runat="server" Text="Actual pick up:" Width="161px"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="TextBoxActualpickup" runat="server" Enabled="true" Format="yyyy.MM.dd" />
                            <asp:TextBox ID="TextBoxActualpickup" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelPlanned" runat="server" Text="Planned arrival:" Width="161px"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="TextBoxPlannedarrival" runat="server" Enabled="true" Format="yyyy.MM.dd" />
                            <asp:TextBox ID="TextBoxPlannedarrival" CssClass="bevitelimezo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelActual" runat="server" Text="Actual arrival:" Width="161px"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:Label ID="LabelActualarrival" runat="server" Text="Label" CssClass="bevitelimezo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label3" runat="server" Text="Profit Center"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:DropDownList ID="DropDownListProfitCenter" runat="server" DataSourceID="SqlDataSource6" DataTextField="Expr2" DataValueField="Expr1" Height="26px" AppendDataBoundItems="True">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Labeltransportername" runat="server" Text="Forwarder Name"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:DropDownList CssClass="bevitelimezo" AutoPostBack="True" ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" OnTextChanged="DropDownList5_TextChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBoxTransporter" CssClass="bevitelimezocella1" Visible="false" runat="server"></asp:TextBox>&nbsp;<asp:ImageButton ID="ImageButtonFor" AutoPostBack="true" runat="server" CssClass="rotate" ImageUrl="~/Images/ml_cancel.png" Width="25" Height="25" OnClick="ImageButtonFor_Click" Visible="False" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label8" runat="server" Text="Requester:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBoxRequester" runat="server" OnTextChanged="TextBoxRequester_TextChanged"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label19" runat="server" Text="To...*"></asp:Label><br />
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox CssClass="bevitelimezo" ID="txtEmail" runat="server" Width="500px"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label20" runat="server" Text="Cc...*"></asp:Label><br />
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox CssClass="bevitelimezo" ID="TextCC" runat="server" Width="500px"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label4" runat="server" Text="Info"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <%--         <asp:TextBox ID="TextBoxInfo" runat="server"></asp:TextBox>--%>
                            <textarea runat="server" id="TextBoxInfo" style="width: auto; height: auto;"> </textarea>
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
                            <asp:Label ID="Label9" runat="server" Text="Tracking Number:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label10" runat="server" Text="Booking Number:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label11" runat="server" Text="Invoice Number:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label12" runat="server" Text="Invoiced Price:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelComment" runat="server" Text="Comment:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBoxComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label18" runat="server" Text="Service:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBoxService" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelDeleted" runat="server" Text="Deleted:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:CheckBox ID="CheckBoxDeleted" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelArrived" runat="server" Text="Arrived:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:CheckBox ID="CheckBoxArrived" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelReception4" runat="server" Text="Reception:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:Label ID="LabelReception3" runat="server" Text="Reception:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="LabelQRCodeID" runat="server" Text="QR Code ID:"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">
                            <asp:TextBox ID="TextBoxQRCodeID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="szurkeinformacio">
                            <asp:Label ID="Label13" runat="server" Text="Select File PDF"></asp:Label>
                        </td>
                        <td class="bevitelimezocella">

                            <table>
                                <tr>

                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only Excel File" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" CausesValidation="False" />
                                    </td>
                                    <td>

                                        <asp:Button ID="Button4" runat="server" Text="View Files"
                                            OnClick="Button4_Click" />
                                    </td>
                                </tr>

                            </table>
                            <asp:GridView ID="GridViewPDF" runat="server" Caption="Excel Files "
                                CaptionAlign="Top" HorizontalAlign="Justify"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                ToolTip="Excel FIle DownLoad Tool" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <RowStyle BackColor="#E3EAEB" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Download" ControlStyle-ForeColor="Blue" />
                                </Columns>
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button CausesValidation="false" ID="Button3" runat="server" OnClick="Button2_Click" Text="Save And Send Mail" CssClass="gomb" />
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" CssClass="gomb" CausesValidation="False" />
                        </td>
                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="LabelEv" runat="server" Text="Start Date Year"></asp:Label>
            </td>
            <td class="bevitelimezocella">
                <asp:DropDownList ID="DropDownListEV" runat="server" CssClass="bevitelimezo" DataSourceID="SqlDataSourceYear" DataTextField="EV" DataValueField="EV" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label15" runat="server" Text="Tables:"></asp:Label>
            </td>
            <td class="bevitelimezocella">
                <asp:DropDownList ID="DropDownListTables" runat="server" CssClass="bevitelimezo" DataTextField="Column1" DataValueField="Column1" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTables_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">Please Select!</asp:ListItem>
                    <asp:ListItem Value="1">Percent</asp:ListItem>
                    <asp:ListItem Value="2">Delivery time</asp:ListItem>
                    <asp:ListItem Value="3">SGHUORDER</asp:ListItem>                  
                </asp:DropDownList>
            </td>
        </tr>
        <tr runat="server" id="excel" visible="False">
            <td class="auto-style1">
                <asp:Label ID="Label14" runat="server" Text="Export Excel:"></asp:Label>
            </td>
            <td>
                <asp:ImageButton CausesValidation="false" ID="ImageButtonExcel" Width="50" Height="50" runat="server" ImageUrl="~/Images/excel.png" ToolTip="Excelbe importálás" OnClick="ImageButtonExcel_Click" />
            </td>

        </tr>
        <tr runat="server" id="refresh" visible="False">
            <td>
                <asp:Label ID="Label21" runat="server" Text="Frissit Gridview:"></asp:Label>
            </td>
            <td>
                <asp:ImageButton ID="ImageButtonUpd" OnClick="ImageButtonUpd_Click1" runat="server" CssClass="rotate" ImageUrl="~/Images/upd-sg_green.png" Width="50" Height="50" />
            </td>
        </tr>

        <tr runat="server" id="Tr1" visible="False">
            <td class="auto-style1">
                <asp:Label ID="LabelTableName" runat="server"></asp:Label>
            </td>
            <td></td>

        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridViewPercent2" OnRowCreated="GridViewPercent2_RowCreated" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GridViewPercent2_RowDataBound" OnRowDeleting="GridViewPercent2_RowDeleting">
                            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="ImageButtonUpdGridViewPercent" OnClick="ImageButtonUpdGridViewPercent_Click1" runat="server" CssClass="rotate" ImageUrl="~/Images/upd-sg_green.png" Width="25" Height="25" />
                                    </HeaderTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LSP Name" SortExpression="Name">
                                    <HeaderTemplate>
                                        <asp:Label ID="LabellspNameHeader" runat="server" Text="LSP Name"></asp:Label><br />
                                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" ID="DropDownList3" runat="server" DataSourceID="SqlDataSourcellsp" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSourcellsp" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT 0 as ID, '* Please Select *' as name union all
SELECT [ID], [Name] FROM [LSP] order by name;"></asp:SqlDataSource>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelLSPName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MonthName" SortExpression="MonthName">
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelMonthNameHeader" runat="server" Text="MonthName"></asp:Label><br />
                                        <asp:DropDownList ID="DropDownListMonthName" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="DropDownListMonthName_SelectedIndexChanged" runat="server" DataSourceID="SqlDataSourceMonthName" DataTextField="MonthName" DataValueField="ID"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSourceMonthName" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT * FROM [Month] ORDER BY [ID]"></asp:SqlDataSource>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:Label ID="LabelMonthName" runat="server" Text='<%# Bind("MonthName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Percent" SortExpression="MonthName">

                                    <ItemTemplate>
                                        <asp:Label ID="LabelPercent" runat="server" Text='<%# Bind("Percent") %>'></asp:Label>
                                    </ItemTemplate>
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
                        <asp:GridView ID="GridViewPercent" Visible="False" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="SqlDataSourcePercent" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelPercent" runat="server" Text="Filter"></asp:Label><br />
                                        <asp:ImageButton ID="ImageButtonUpdGridViewPercent" OnClick="ImageButtonUpdGridViewPercent_Click" runat="server" CssClass="rotate" ImageUrl="~/Images/upd-sg_green.png" Width="25" Height="25" />
                                    </HeaderTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OrderID" InsertVisible="False" SortExpression="OrderID">
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderLabelPercentOrderID" runat="server" Text="Order number"></asp:Label><br>
                                    </HeaderTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OrderID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Perc Eltérnés" SortExpression="Perc Eltérnés">
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderLabelMinuteDifference" runat="server" Text="Minute difference"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterMinuteDifference" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterMinuteDifference_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelMinuteDifference" runat="server" Text='<%# Bind("[Perc Eltérnés]") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plannedarrival" SortExpression="Plannedarrival">
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderLabelPlannedarrival" runat="server" Text="Plannedarrival"></asp:Label><br>
                                        <asp:DropDownList ID="DropDownListPlannedarrival" runat="server" DataSourceID="SqlDataSourceMonth" AutoPostBack="true" OnSelectedIndexChanged="DropDownListPlannedarrival_SelectedIndexChanged" DataTextField="MonthName" DataValueField="ID"></asp:DropDownList>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelPlannedarrival" runat="server" Text='<%# Bind("Plannedarrival") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actualarrival" SortExpression="Actualarrival">
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderActualarrival" runat="server" Text="Actualarrival"></asp:Label><br>
                                        <asp:DropDownList ID="DropDownListActualarrival" runat="server" DataSourceID="SqlDataSourceMonth" AutoPostBack="true" OnSelectedIndexChanged="DropDownListActualarrival_SelectedIndexChanged" DataTextField="MonthName" DataValueField="ID"></asp:DropDownList>

                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelActualarrival" runat="server" Text='<%# Bind("Actualarrival") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LSP Name" SortExpression="Name">
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderLabelLSPName" runat="server" Text="LSP Name"></asp:Label><br>
                                        <asp:DropDownList ID="DropDownListFilterLSP" runat="server" DataSourceID="SqlDataSourceFilterLSP" DataTextField="Name" DataValueField="Name" AutoPostBack="true" OnSelectedIndexChanged="DropDownListFilterLSP_SelectedIndexChanged"></asp:DropDownList>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:Label ID="LabelLSPName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
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
                        <asp:GridView Visible="false" ID="GridViewSGHUORDER" OnRowDataBound="GridViewSGHUORDER_RowDataBound" CssClass="nowrap" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnRowCancelingEdit="GridViewSGHUORDER_RowCancelingEdit" OnPageIndexChanging="GridViewSGHUORDER_PageIndexChanging" OnRowDeleting="GridViewSGHUORDER_RowDeleting" OnRowEditing="GridViewSGHUORDER_RowEditing" PageSize="100" OnRowUpdating="GridViewSGHUORDER_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCreated="GridViewSGHUORDER_RowCreated" OnSelectedIndexChanged="GridViewSGHUORDER_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label2" runat="server" Text="Filter"></asp:Label><br />
                                        <asp:ImageButton ID="ImageButtonUpd" OnClick="ImageButtonUpd_Click" runat="server" CssClass="rotate" ImageUrl="~/Images/upd-sg_green.png" Width="25" Height="25" />
                                    </HeaderTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/Images/ml_add.png" Width="25" Height="25" OnClick="ImageButtonAdd_Click" />
                                        <asp:ImageButton ID="ImageButtonCancel" runat="server" ImageUrl="~/Images/ml_cancel.png" Visible="false" Width="25" Height="25" OnClick="ImageButtonCancel_Click" />
                                        <asp:ImageButton ID="ImageButtonOK" runat="server" ImageUrl="~/Images/ml_ok.png" Visible="false" Width="25" Height="25" OnClick="ImageButtonOK_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Truck Number">
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderTrackingNumber" runat="server" Text="Tracking number"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterTrackingNumber" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterTrackingNumber_TextChanged1"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelTrackingNumber" runat="server" Text='<% #Bind("TrackingNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxTrackingNumber" runat="server" OnTextChanged="TextBoxTrackingNumber_TextChanged1" AutoPostBack="true" Text='<% #Bind("TrackingNumber") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trailer Number">
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderTrailerNumber" runat="server" Text="Trailer number"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterTrailerNumber" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterTrackingNumber_TextChanged1"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelTrailerNumber" runat="server" Text='<% #Bind("TrailerNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxTrailerNumber" runat="server" OnTextChanged="TextBoxTrailerNumber_TextChanged" AutoPostBack="true" Text='<% #Bind("TrailerNumber") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderLabelOrderID" runat="server" Text="Order number"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterOrderNumber" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterOrderNumber_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelOrderID" runat="server" Text='<% #"SGHU ORDER-" + Eval("OrderID")  %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="LabelEditOrderID" runat="server" Text='<% #"SGHU ORDER-" + Eval("OrderID") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderHonnan" runat="server" Text="From"></asp:Label><br>
                                        <asp:DropDownList ID="DropDownListFilterFrom" Width="80px" runat="server" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="DropDownListFilterFrom_SelectedIndexChanged" DataSourceID="SqlDataSourceOrszagKod" DataTextField="orszagkod">
                                        </asp:DropDownList>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelHonnan" runat="server" Text='<% #Bind("Honnan") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListHonnan" DataTextField="OrszagKod" DataValueField="ID" DataSourceID="SqlDataSourceOrszagKod" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderHova" runat="server" Text="TO"></asp:Label><br>
                                        <asp:DropDownList ID="DropDownListFilterTo" Width="80px" runat="server" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="DropDownListFilterTo_SelectedIndexChanged" DataSourceID="SqlDataSourceOrszagKod" DataTextField="orszagkod">
                                        </asp:DropDownList>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelHova" runat="server" Text='<% #Bind("Hova") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListHova" DataTextField="orszagkod" DataValueField="ID" DataSourceID="SqlDataSourceOrszagKod" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderLabelForwarder" runat="server" Text="Forwarder"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterForvarder" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterForvarder_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelForwarder" runat="server" Text='<% #Eval("Forwarder") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListForwarder" runat="server" Height="22px" Width="190px" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ID">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="HeaderLabelService" runat="server" Text="Service"></asp:Label><br>
                                        <asp:DropDownList ID="DropDownListFilterService" runat="server" Width="80" DataValueField="gyartosor" AutoPostBack="true" OnSelectedIndexChanged="DropDownListFilterService_SelectedIndexChanged"></asp:DropDownList>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelService" runat="server" Text='<% #Bind("Service") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxService" runat="server" Text='<% #Bind("Service") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderPlannedpickup" runat="server" Text="Planned pick up"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterPlannedpickup" OnTextChanged="TextBoxFilterPlannedpickup_TextChanged" AutoPostBack="true" Width="120" runat="server"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelPlannedpickup" runat="server" Text='<% #Bind("Plannedpickup") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CalendarExtender ID="CalendarExtenderPlannedpickup" TargetControlID="TextBoxPlannedpickup" runat="server" Enabled="true" Format="yyyy.MM.dd" />
                                        <asp:TextBox ID="TextBoxPlannedpickup" runat="server" Text='<% #Bind("Plannedpickup") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderActualpickup" runat="server" Text="Actual pick up"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterActualpickup" OnTextChanged="TextBoxFilterActualpickup_TextChanged" AutoPostBack="true" Width="120" runat="server"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelActualpickup" runat="server" Text='<% #Bind("Actualpickup") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CalendarExtender ID="CalendarExtenderActualpickup" TargetControlID="TextBoxActualpickup" runat="server" Enabled="true" Format="yyyy.MM.dd" />
                                        <asp:TextBox ID="TextBoxActualpickup" AutoPostBack="true" OnTextChanged="TextBoxActualpickup_TextChanged" runat="server" Text='<% #Bind("Actualpickup") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderPlannedarrival" runat="server" Text="Planned arrival"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterPlannedarriva" OnTextChanged="TextBoxFilterPlannedarriva_TextChanged" AutoPostBack="true" Width="120" runat="server"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelPlannedarrival" runat="server" Text='<% #Bind("Plannedarrival") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CalendarExtender ID="CalendarExtenderPlannedarrival" TargetControlID="TextBoxPlannedarrival" runat="server" Enabled="true" Format="yyyy.MM.dd" />
                                        Date:&nbsp<asp:TextBox ID="TextBoxPlannedarrival" runat="server" Width="90px" Text='<%#Eval("Plannedarrival", "{0:d}") %>'></asp:TextBox>
                                        Time:&nbsp<asp:TextBox MaxLength="5" AutoPostBack="true" OnTextChanged="TextBoxTime_TextChanged" ID="TextBoxTime" runat="server" Width="60px" Text='<%#Eval("Plannedarrival", "{0:t}") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderActualarrival" runat="server" Text="Actual arrival"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterActualarrival" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterActualarrival_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelActualarrival" runat="server" Text='<% #Bind("Actualarrival") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="LabelActualarrival" runat="server" Text='<% #Bind("Actualarrival") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderComment" runat="server" Text="Comment"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterComment" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterComment_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelComment" runat="server" Text='<% #Bind("Comment") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxComment" runat="server" Text='<% #Bind("Comment") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderReception" runat="server" Text="Reception"></asp:Label><br>
                                        <asp:TextBox ID="TextBoxFilterReceptionr" AutoPostBack="true" Width="120" runat="server" OnTextChanged="TextBoxFilterReceptionr_TextChanged"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelReception" runat="server" Text='<% #Bind("Reception") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="LabelReception2" runat="server" Text='<% #Bind("Reception") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                        <asp:Label ID="LabelHeaderColor" runat="server" Text="Color"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelColor" runat="server" Text='<% #Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListName" DataTextField="Name" DataValueField="ID" DataSourceID="SqlDataSourceColor" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Locked" SortExpression="Locked">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbl_h_Locked" runat="server" Text="Deleted" CommandName="Sort" CommandArgument="Locked" ForeColor="White"></asp:LinkButton><br>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Locked" runat="server" Text='<%# Bind("Deleted") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chb_Locked" runat="server" Checked='<%# Bind("Deleted") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("ColorHexa") %>' />
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Bind("Deleted") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:Label ID="TextBoxHiba" runat="server"></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>


                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    <asp:SqlDataSource ID="SqlDataSourceOrszagKod" runat="server" SelectCommand="SELECT '- 1' AS ID, ' * Kérlek válassz egyet! * ' AS OrszagKod UNION ALL SELECT id, orszagkod FROM country ORDER BY OrszagKod"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" SelectCommand="SELECT -2  AS Expr1, ' * Kérlek válassz egyet! * ' AS Expr2 UNION ALL SELECT -1  AS Expr1, ' * Egyéb * ' AS Expr2 UNION ALL  SELECT ID, ProfitCenter + ' | ' + Megnevezés AS legordulo FROM [Copy Of dbo_ProfitCenter]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSGHUORDER" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" SelectCommand="SELECT ID, ProfitCenter + ' | ' + Megnevezés AS legordulo FROM ProfitCenter"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceColor" runat="server" SelectCommand="SELECT [ID], [Name] FROM [Colors] ORDER BY [Name]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="SELECT        ' * Kérlek válassz egyet! *' AS Name, - 1 AS ID UNION ALL SELECT        '* Egyéb *' AS Name, - 2 AS ID UNION ALL SELECT NAME, ID FROM LSP ORDER BY Name"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT 'SGHU ORDER-' + CONVERT (varchar(10), OrderID) AS legordulo, OrderID FROM SGHUOrder ORDER BY OrderID DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMonth" runat="server" SelectCommand="SELECT [ID], [MonthName] FROM [Month] ORDER BY [ID]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourcePercent" runat="server" SelectCommand="SELECT        dbo.SGHUOrder.OrderID, DATEDIFF(mi, dbo.SGHUOrder.Plannedarrival, dbo.SGHUOrder.Actualarrival) AS [Perc Eltérnés], dbo.SGHUOrder.Plannedarrival, dbo.SGHUOrder.Actualarrival, dbo.LSP.Name FROM dbo.LSP RIGHT OUTER JOIN dbo.SGHUOrder ON dbo.LSP.ID = dbo.SGHUOrder.Forwarder WHERE (NOT (dbo.SGHUOrder.Plannedarrival IS NULL))"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" SelectCommand="SELECT vpercentmonth.Name, Month.MonthName FROM vpercentmonth INNER JOIN Month ON vpercentmonth.PlannedarrivalMonth = Month.ID"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceFilterLSP" runat="server" SelectCommand="SELECT 0 as ID, '* Please Select *' as name union all SELECT [ID], [Name] FROM [LSP] order by name;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceYear" runat="server" SelectCommand="SELECT YEAR(StartDate) AS EV FROM SGHUOrder GROUP BY YEAR(StartDate) HAVING (NOT (YEAR(StartDate) IS NULL)) ORDER BY EV DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourcePDF" runat="server" SelectCommand="SELECT * FROM [PDFiles]"></asp:SqlDataSource>

</asp:Content>

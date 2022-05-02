<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MRTable.aspx.cs" Inherits="KamionKezelo_MRTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="text-align: left;">
        <tr>
            <td>
                <asp:Label ID="LabelDate" runat="server">
                      <%= Resources.Resource.date + ":"%>                
                </asp:Label>
            </td>
            <td>
                <asp:CalendarExtender ID="CalendarExtender10" TargetControlID="TextBoxMRDate" runat="server" Enabled="true" Format="yyyy-MM-dd" FirstDayOfWeek="Monday" />
                <asp:TextBox AutoPostBack="true" ID="TextBoxMRDate" runat="server" OnTextChanged="TextBoxMRDate_TextChanged"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="|" Font-Bold="True" Font-Italic="True"></asp:Label>
                <asp:DropDownList ID="DropDownListMRYear" runat="server">
                    <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListMRDate" runat="server" AutoPostBack="true" DataSourceID="SqlDataSourceMonth" DataTextField="MonthName" DataValueField="IDFull" OnSelectedIndexChanged="DropDownListMRDate_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server">
                <%= Resources.Resource.mr + ":"%>            
                </asp:Label>
            </td>
            <td>
                <asp:Button ID="ButtonAll" CssClass="btn btn-default send-message" runat="server" Text="<%$Resources:Resource, all%>" OnClick="ButtonAll_Click" />
                 <asp:Label ID="Label7" runat="server" Text="|" Font-Bold="True" Font-Italic="True"></asp:Label>
                <asp:Button ID="ButtonAlapanyag" CssClass="btn btn-default send-message" runat="server" Text="<%$Resources:Resource, rawmaterial%>" OnClick="ButtonAlapanyag_Click" Style="height: 26px" />
                <asp:Label ID="Label8" runat="server" Text="|" Font-Bold="True" Font-Italic="True"></asp:Label>
                <asp:Button ID="ButtonKesztermek" CssClass="btn btn-default send-message" runat="server" Text="<%$Resources:Resource, finishedproduct%>" OnClick="ButtonKesztermek_Click" />
                <%--  <asp:Button ID="ButtonLogiconMosos" CssClass="btn btn-default send-message" runat="server" Text="Logicon mosós" OnClick="ButtonLogiconMosos_Click" />
                --%> <asp:Label ID="Label9" runat="server" Text="|" Font-Bold="True" Font-Italic="True"></asp:Label>
                <asp:DropDownList ID="DropDownListMR" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListMR_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text="<%$Resources:Resource, pleaseselect%>">          </asp:ListItem>
                    <asp:ListItem Value="1">MR1</asp:ListItem>
                    <asp:ListItem Value="2">MR2</asp:ListItem>
                    <asp:ListItem Value="3">MR3</asp:ListItem>
                    <asp:ListItem Value="4">MR4</asp:ListItem>
                    <asp:ListItem Value="5">MR5</asp:ListItem>
                </asp:DropDownList><br/>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label3" runat="server">
                          <%= Resources.Resource.view + ":"%>   
                </asp:Label>
            </td>

            <td>
                <asp:CheckBox AutoPostBack="true" ID="CheckBoxTimetable" Text="<%$Resources:Resource, timewindow%>" runat="server" Checked="true" OnCheckedChanged="CheckBoxTimetable_CheckedChanged" />
                <asp:CheckBox AutoPostBack="true" ID="CheckBoxList" Text="<%$Resources:Resource, list%>" runat="server" OnCheckedChanged="CheckBoxList_CheckedChanged" />
                <asp:CheckBox AutoPostBack="true" ID="CheckBoxPercent" Text="<%$Resources:Resource, percent%>" runat="server" OnCheckedChanged="CheckBoxPercent_CheckedChanged" />
            </td>
        </tr>
        <tr runat="server" id="excel">
            <td class="auto-style1">
                <asp:Label ID="Label14" runat="server">
                          <%= Resources.Resource.exportexcel + ":"%>   
                </asp:Label>
            </td>
            <td>
                <asp:ImageButton CausesValidation="false" ID="ImageButtonExcel" Width="50" Height="50" runat="server" ImageUrl="~/Images/excel.png" ToolTip="Excelbe importálás" OnClick="ImageButtonExcel_Click" />
            </td>

        </tr>
    </table>

    <asp:Label ID="LabelError"  ForeColor="Red"  runat="server"></asp:Label>


    <table class="styletable" runat="server" id="percent" visible="false" style="width: 100%;">
        <tr>

            <td>
                <asp:Label class="szurkeinformacio" ID="Label4" runat="server">
                        <%= Resources.Resource.date + ":"%>            
                </asp:Label>
                <asp:Label class="bevitelimezocella" ID="LabelPercentDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label class="szurkeinformacio" ID="Label5" runat="server">
                        <%= Resources.Resource.mr + ":"%>            
                </asp:Label>
                <asp:Label class="bevitelimezocella" ID="LabelPercentMR" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label class="szurkeinformacio" ID="Label6" runat="server">
                        <%= Resources.Resource.percent + ":"%>            
                </asp:Label>

                <asp:Label class="bevitelimezocella" ID="LabelPercen" runat="server" Text="Label"></asp:Label>

            </td>

        </tr>
    </table>
    <br/>


    <table style="width: 100%">
        <tr>
            <td>
                <asp:GridView ID="GridView2" OnRowDataBound="GridView2_RowDataBound" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
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



            </td>
            <td>
                <asp:GridView HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridViewPercent_RowDataBound" ID="GridViewPercent" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>


        </tr>



    </table>








    <asp:GridView ID="GridViewMilk" Visible="false" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridViewMilk_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TrackingNumber" HeaderText="<%$Resources:Resource, truckplatenumber%>" SortExpression="TrackingNumber"></asp:BoundField>
            <asp:BoundField DataField="TrailerNumber" HeaderText="<%$Resources:Resource, platenumber%>" SortExpression="TrailerNumber"></asp:BoundField>
            <asp:BoundField DataField="DriverName" HeaderText="<%$Resources:Resource, drivername%>" SortExpression="DriverName"></asp:BoundField>
            <asp:BoundField DataField="InDate" DataFormatString="{0:yyyy.MM.dd HH:mm}" HeaderText="<%$Resources:Resource, arrivaldate%>" SortExpression="InDate"></asp:BoundField>
            <asp:BoundField DataField="OutDate" DataFormatString="{0:yyyy.MM.dd HH:mm}" HeaderText="<%$Resources:Resource, exitdate%>" SortExpression="OutDate"></asp:BoundField>
            <asp:TemplateField SortExpression="Reception">
                <HeaderTemplate>
                    <asp:Label ID="LabelHeaderReception" runat="server" Text="<%$Resources:Resource, reception%>"></asp:Label><br>
                    <%--       <asp:DropDownList OnSelectedIndexChanged="DropDownListHeaderReception_SelectedIndexChanged" ID="DropDownListHeaderReception" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="0">Kérlek Válasz! </asp:ListItem>
                        <asp:ListItem Value="1">TESZTUSER</asp:ListItem>
                        <asp:ListItem Value="2">tesztfelhasznalo</asp:ListItem>
                        <asp:ListItem Value="3">tesztfelhasznalo22</asp:ListItem>
                    </asp:DropDownList>--%>
                </HeaderTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxReception" runat="server" Text='<%# Bind("Reception") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelReception" runat="server" Text='<%# Bind("Reception") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="MR">
                <HeaderTemplate>
                    <asp:Label ID="LabelHeaderMR" runat="server" Text="<%$Resources:Resource, mr%>"></asp:Label><br>
                    <%--      <asp:DropDownList OnSelectedIndexChanged="DropDownListHeaderMR_SelectedIndexChanged" ID="DropDownListHeaderMR" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="0">Kérlek Válasz! </asp:ListItem>
                        <asp:ListItem Value="1">MR1</asp:ListItem>
                        <asp:ListItem Value="2">MR2</asp:ListItem>
                        <asp:ListItem Value="3">MR3</asp:ListItem>
                        <asp:ListItem Value="4">MR4</asp:ListItem>
                        <asp:ListItem Value="5">MR5</asp:ListItem>
                        <asp:ListItem Value="6">MR6</asp:ListItem>
                        <asp:ListItem Value="7">MR7</asp:ListItem>
                    </asp:DropDownList>--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("MR") %>' ID="LabelMR"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="MR Kör">
                <HeaderTemplate>
                    <asp:Label ID="LabelHeaderMRKör" runat="server" Text="<%$Resources:Resource, mrcircle%>"></asp:Label><br>
                    <%--   <asp:DropDownList OnSelectedIndexChanged="DropDownListHeaderMRKör_SelectedIndexChanged" AutoPostBack="true" ID="DropDownListHeaderMRKör" runat="server">
                        <asp:ListItem Value="0">Kérlek Válasz! </asp:ListItem>
                        <asp:ListItem Value="1">Alapanyag</asp:ListItem>
                        <asp:ListItem Value="2">Késztermék</asp:ListItem>
                        <asp:ListItem Value="3">Logicon mosós</asp:ListItem>
                    </asp:DropDownList>--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelMRKör" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="<%$Resources:Resource, incomingpalette%>">
                <ItemTemplate>
                    <asp:Label ID="LabelPaletteIn" runat="server" Text='<%# Bind("[InPalette]") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:Resource, outboundpalette%>">
                <ItemTemplate>
                    <asp:Label ID="LabelPaletteOut" runat="server" Text='<%# Bind("[OutPalette]") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Plombaszám">
                <ItemTemplate>
                    <asp:Label ID="Labelplombaszam" runat="server" Text='<%# Bind("[plombaszam]") %>'></asp:Label>
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

    <asp:SqlDataSource ID="MILK" runat="server" SelectCommand="SELECT Milkruns.TrackingNumber, Milkruns.TrailerNumber, Milkruns.DriverName, MilkRunMovement.InDate, MilkRunMovement.OutDate, Users.Username AS Reception, 'MR' + CONVERT (varchar(2), Milkruns.ID) AS MR, DATEDIFF(mi, dbo.MilkRunMovement.indate, dbo.MilkRunMovement.OutDate) AS [Perc Eltérés] FROM MilkRunMovement LEFT OUTER JOIN Users ON MilkRunMovement.receptionID = Users.UserId RIGHT OUTER JOIN Milkruns ON MilkRunMovement.TrackingNumberID = Milkruns.ID ORDER BY MilkRunMovement.ID" ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSGHUORDER" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceMonth" ConnectionString='<%$ ConnectionStrings:LocalDatabaseConnectionString %>' SelectCommand="SELECT [IDFull], [MonthName] FROM [Month] ORDER BY [ID]"></asp:SqlDataSource>

</asp:Content>


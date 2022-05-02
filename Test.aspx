<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<%@ Register src="DataFilter.ascx" tagname="DataFilter" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:DataFilter ID="DataFilter1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="vontatorendszam" HeaderText="vontatorendszam" SortExpression="vontatorendszam" />
                        <asp:BoundField DataField="potkocsirendszam" HeaderText="potkocsirendszam" 
                            SortExpression="potkocsirendszam" />
                        <asp:BoundField DataField="lokacio" HeaderText="lokacio" SortExpression="lokacio" />
                        <asp:BoundField DataField="porta" HeaderText="porta" SortExpression="porta" />
                        <asp:CheckBoxField DataField="befele" HeaderText="befele" SortExpression="befele" />
                        <asp:BoundField DataField="tomege" HeaderText="tomege" SortExpression="tomege" />
                        <asp:BoundField DataField="soforneve" HeaderText="soforneve" SortExpression="soforneve" />
                        <asp:BoundField DataField="utasneve" HeaderText="utasneve" SortExpression="utasneve" />
                        <asp:BoundField DataField="KÁRTYA" HeaderText="KÁRTYA" SortExpression="KÁRTYA" />
                        <asp:BoundField DataField="datum" HeaderText="datum" SortExpression="datum" />
                        <asp:BoundField DataField="behivasdatuma" HeaderText="behivasdatuma" SortExpression="behivasdatuma" />
                        <asp:BoundField DataField="rampa" HeaderText="rampa" SortExpression="rampa" />
                        <asp:BoundField DataField="fovalalkozo" HeaderText="fovalalkozo" SortExpression="fovalalkozo" />
                        <asp:BoundField DataField="alvalalkozó" HeaderText="alvalalkozó" SortExpression="alvalalkozó" />
                        <asp:BoundField DataField="beszallito" HeaderText="beszallito" SortExpression="beszallito" />
                        <asp:BoundField DataField="szalitolevelCMR" HeaderText="szalitolevelCMR" SortExpression="szalitolevelCMR" />
                        <asp:BoundField DataField="plombaszam" HeaderText="plombaszam" SortExpression="plombaszam" />
                        <asp:BoundField DataField="egyebbazonosito" HeaderText="egyebbazonosito" SortExpression="egyebbazonosito" />
                        <asp:CheckBoxField DataField="vamaru" HeaderText="vamaru" SortExpression="vamaru" />
                        <asp:CheckBoxField DataField="vamaruserult" HeaderText="vamaruserult" SortExpression="vamaruserult" />
                        <asp:BoundField DataField="ellenorzestvegezte" HeaderText="ellenorzestvegezte" SortExpression="ellenorzestvegezte" />
                        <asp:BoundField DataField="ellenorzesmodja" HeaderText="ellenorzesmodja" SortExpression="ellenorzesmodja" />
                        <asp:BoundField DataField="megjeygyzes" HeaderText="megjeygyzes" SortExpression="megjeygyzes" />
                        <asp:BoundField DataField="userid" HeaderText="userid" SortExpression="userid" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalDatabaseConnectionString %>" 
                    SelectCommand="SELECT * FROM [Kamionkezelo]">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>

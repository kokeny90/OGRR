<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="kezdolap" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 578px;
        }
    </style>
</head>
<body bgcolor="#EFF3FB">
    <form id="form1" runat="server">
    <div>
            <table style="height: 57px; width: 100%; margin-top: 0px;">
                <tr>
                    <td class="auto-style1">
        <asp:Button ID="But_Kereses" runat="server"  Text="Search" OnClick="But_Kereses_Click" BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" style="height: 18px"  />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Own Form" BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98"  />
                        </td>
                                        <td style="text-align: right">
                                                    <asp:LoginName ID="LoginName1" runat="server" Font-Bold="true" />
        <asp:Label ID="lblLastLoginDate" runat="server" />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
                        </td>
                    </tr>
                </table> 
    </div>
    </form>
</body>
</html>

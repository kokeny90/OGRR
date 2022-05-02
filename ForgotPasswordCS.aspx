<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPasswordCS.aspx.cs" Inherits="ForgotPasswordCS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table>
        <tr>
            <td>User Name:
            </td>
            <td>
                <asp:TextBox ID="TextUserName" runat="server" Width="250" />

            </td>

        </tr>
        <tr>
            <td>Email Address:
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="250" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblMessage" runat="server" />
            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button Text="Send" runat="server" OnClick="SendEmail" />
            </td>

        </tr>






    </table>




</asp:Content>



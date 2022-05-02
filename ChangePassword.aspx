<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ChangePassword ID="ChangePassword1" runat="server" OnChangingPassword="OnChangingPassword"
        RenderOuterTable="false" NewPasswordRegularExpression="^[\s\S]{5,}$" NewPasswordRegularExpressionErrorMessage="Password must be of minimum 5 characters." CancelDestinationPageUrl="~/Home.aspx">
    </asp:ChangePassword>
    <br />
    <asp:Label ID="lblMessage" runat="server" />


</asp:Content>

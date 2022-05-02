<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Errors_Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        /*Kép forgatása*/
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


    <table style="width: 100%" border="0">
        <tr>
            <td style="font-family: 'Century Gothic'; border-bottom-style: solid; font-size: x-large">
                <b>Error - Hiba</b>
            </td>
        </tr>
    </table>
    <asp:Label ID="Label_err_en" runat="server" Text="We are very sorry for the inconvenience caused to you..."></asp:Label><br />
    <asp:Label ID="Label_err_hu" runat="server" Text="Elnézést kérünk az okozott kellemetlenségért..."></asp:Label>
    <br />
    <br />
    <%--    <table align="center">
        <tr valign="middle" align="center">
            <td align="center" valign="middle">
                <asp:ImageButton ID="ImageButton_reload" runat="server" src="../Images/upd-sg_green.png" CssClass="rotate" Height="100" Width="100" AlternateText="Reload" />
            </td>
        </tr>
    </table>--%>
    <br />




</asp:Content>


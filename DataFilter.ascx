<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DataFilter.ascx.cs" Inherits="DataFilter" %>
<asp:UpdatePanel ID="updatePanel" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlNewFilter" runat="server">
        </asp:Panel>
        <asp:Panel ID="pnlToolbar" runat="server" >
            <asp:Button ID="btnAddNewFilter" runat="server"  OnClick="btnAddNewFilter_Click" Text="Add Filter" CssClass="buttons" CausesValidation="False" />
            <asp:Button ID="btnAndNewFilter" runat="server" CssClass="buttons" Text="AND" OnClick="btnAndNewFilter_Click" Visible="False" CausesValidation="False" style="height: 26px" />
            <asp:Button ID="btnOrNewFilter" runat="server" CssClass="buttons" Text="OR" OnClick="btnOrNewFilter_Click" Visible="False" CausesValidation="False" /></asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblSelection.Text = "You picked " + ComboBox1.SelectedItem.Text;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Static</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            Describe how spicy you like your food:
        <br />
            <cc1:ComboBox ID="ComboBox1" runat="server" OnItemInserted="ComboBox1_ItemInserted" OnSelectedIndexChanged="ComboBox1_SelectedIndexChanged" AutoPostBack="True" DataTextField="megnevezes" DataValueField="id" MaxLength="0" Style="display: inline;">
                <asp:ListItem Text="Mild" Value="0" />
                <asp:ListItem Text="Medium" Value="1" />
                <asp:ListItem Text="Hot" Value="2" />
            </cc1:ComboBox>

            <asp:Button
                ID="btnSubmit"
                Text="Submit"
                runat="server" OnClick="btnSubmit_Click" />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <br />
            <br />
            <br />

            <hr />
            <asp:Label
                ID="lblSelection"
                runat="server" />

        </div>
    </form>
</body>
</html>

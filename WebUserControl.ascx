<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>

<asp:Panel ID="Panel2" runat="server" Width="436px">

    <asp:Button ID="Button1" Style="width: auto; height: auto" runat="server" OnClick="Button1_Click1" Text="Szürő" />
    <asp:Panel ID="Panel1" runat="server" Style="width: auto; height: auto; background-color: whitesmoke; position: absolute;" Visible="false">
        <table style="font-family: 'Bosch Office Sans'; text-align: left">
            <tr>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="Szürő törlése" OnClick="Button6_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="Szovegszuro" OnClick="Button4_Click" />
                </td>
            </tr>
            <tr>

                <td>
                    <asp:Button ID="Button5" OnClick="Button5_Click" runat="server" Text="Összes kijeleőlése" />
                </td>
            </tr>
            <tr>
                <td>
                    <div style="width: auto; height:200px; overflow: auto; text-align: left;">
                      <div runat="server" id="szovegszuro" visible="false">
                             <asp:Label ID="Label2" runat="server" Text="Egyenlő"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                            <br>

                                <asp:Label ID="Label1" runat="server" Text="Tartalmazza"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                             <br>
                             <br>
                             <br></br>
                             <br>
                             <br></br>
                             <br></br>
                             <br></br>
                             </br>
                             </br>
                             </br>
                            </br>

                   </div>

                        <asp:CheckBoxList ID="CheckBoxList1" runat="server"  >
                        </asp:CheckBoxList>
                    </div>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="OK" OnClick="Button3_Click" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Cancel" />


                </td>
            </tr>



        </table>
    </asp:Panel>



</asp:Panel>









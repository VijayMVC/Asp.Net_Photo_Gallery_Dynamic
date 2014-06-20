<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="search" %>

&nbsp;<asp:Panel DefaultButton="Button1" ID="Panel1" runat="server">

<table style="position: relative; width: 296px;">
    <tr>
        <td style="width: 100px">
            Keyword:</td>
        <td style="width: 100px">
            <asp:TextBox ID="TextBox1" runat="server" Style="position: relative"></asp:TextBox></td>
        <td style="width: 53px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="position: relative"
                Text="Search" /></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Label ID="Label1" runat="server" Style="left: 0px; position: relative" ForeColor="Red"></asp:Label></td>
    </tr>
</table>
</asp:Panel>

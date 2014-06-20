<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    Select the image and press the Upload button<br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" Style="position: relative" /><br />
    <br />
    Keywords:
    <asp:TextBox ID="TextBox1" runat="server" Style="position: relative" ></asp:TextBox><br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
        Style="position: relative" Text="Upload" Width="96px" /><br />
    <br />
    <asp:Label ID="Label1" runat="server" Style="position: relative"></asp:Label>&nbsp;<br />
    <br />
    <br />
    <br />
    <asp:Label ID="counter" runat="server" Style="position: relative"></asp:Label>
</asp:Content>


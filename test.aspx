<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>
<body>
    <form runat="server">
    Currency Converter
    <br />
    <input runat="server" id="Text1" type="text" />
    USD to<select ID="Currency" runat="server" /><br />
    <br />
    <input runat="server" id="Button1" onserverclick="but_click" type="button" value="button" />
    <input type="submit" value="Show Graph" ID="ShowGraph" runat="server" OnServerClick="ShowGraph_ServerClick"/>
<br /><br />
<img ID="Graph" scr="" alt="Currency Graph" runat="server" />
    
    <div id="Result" style="font-weight:bold;" runat="server">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;<br />
        <br />
        <br />
        Rows<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>cols
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;
        <asp:CheckBox ID="CheckBox1" runat="server" Text="border?" />
        <asp:Button ID="Button2" runat="server" Text="Create" /></div>
</form>
</body>
</html>
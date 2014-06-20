<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="viewimg.aspx.cs" Inherits="viewimg" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" Style="position: relative"><< Go Back</asp:HyperLink>
    <br />
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" HorizontalAlign="Center"
        Style="position: relative">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Style="position: relative"
                Text='<%# Eval("Name") %>'></asp:Label><br />
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Url","~/upload/{0}") %>'
                Style="position: relative" /><br />
            <br />
            Keywords:
            <asp:Label ID="Label4" runat="server" Style="position: relative" Text='<%# Eval("Keywords") %>'></asp:Label><br />
            Uploaded on:
            <asp:Label ID="Label2" runat="server" Style="position: relative" Text='<%# Eval("Date", "{0:d}") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList><br />
    <div id="attr">
                <asp:Label ID="Label3" runat="server" Style="position: relative" Text="Label"></asp:Label></div>
    &nbsp;<br />
    <asp:HyperLink ID="HyperLink2" runat="server" Style="position: relative"><< Go Back</asp:HyperLink><br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT [Name], [Url], [Date],[Keywords] FROM [meta] WHERE ([Url] = @Url)" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter Name="Url" QueryStringField="img" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>


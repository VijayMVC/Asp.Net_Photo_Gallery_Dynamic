<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="gallery" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Style="position: relative" CellSpacing="20" HorizontalAlign="Center" RepeatColumns="6" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <asp:HyperLink rel="lightbox" ID="HyperLink2" runat="server" ImageUrl='<%# Eval("Url","~/upload/thumbs/{0}") %>'
                NavigateUrl='<%# Eval("Url","~/upload/{0}") %>'>[HyperLink2]</asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>&nbsp;
    <asp:SqlDataSource ID="SqlDataSource1"  runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT [Url], [Name] FROM [meta] WHERE ([Keywords] LIKE '%' + @Keywords + '%') ORDER BY [img_id] DESC" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="%" Name="Keywords" QueryStringField="key"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    <br />
</asp:Content>


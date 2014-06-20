<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="manage.aspx.cs" Inherits="manage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" Style="position: relative"  AutoGenerateColumns="False" DataKeyNames="img_id" DataSourceID="SqlDataSource1" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" CellPadding="3" PageSize="5" Width="800px" OnRowDeleting="GridView1_RowDeleting" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridView1_RowDataBound" OnSorted="GridView1_Sorted" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" >
        <Columns>
            <asp:TemplateField HeaderText="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Url") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Url", "~/upload/thumbs/{0}") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" >
                <ItemStyle Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="Keywords" HeaderText="Keywords" SortExpression="Keywords" NullDisplayText="No Keywords" >
                <ItemStyle Font-Bold="True" Font-Italic="True" ForeColor="#C04000" />
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    &nbsp;<b>In Stock:</b>
                   <%# Eval("Name") %>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/close.gif" CommandName="StatusClick" CommandArgument='<%# Eval("Name") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Position="TopAndBottom" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <RowStyle ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        DeleteCommand="DELETE FROM [meta] WHERE [img_id] = @img_id" InsertCommand="INSERT INTO [meta] ([Name], [Url], [Date], [Keywords]) VALUES (@Name, @Url, @Date, @Keywords)"
        SelectCommand="SELECT [img_id], [Name], [Url], [Date], [Keywords] FROM [meta] ORDER BY [img_id] DESC" UpdateCommand="UPDATE [meta] SET [Name] = @Name, [Url] = @Url, [Date] = @Date, [Keywords] = @Keywords WHERE [img_id] = @img_id">
        <DeleteParameters>
            <asp:Parameter Name="img_id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Url" Type="String" />
            <asp:Parameter Type="datetime" Name="Date" />
            <asp:Parameter Name="Keywords" Type="String" />
            <asp:Parameter Name="img_id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Url" Type="String" />
            <asp:Parameter Type="datetime" Name="Date" />
            <asp:Parameter Name="Keywords" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>


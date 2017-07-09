<%@ Page Title="Category List" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalesManagementSystem.Category.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:content>
<asp:Content ID="catList" ContentPlaceHolderID="body" runat="server">
    <asp:GridView ID="grdCategory" AutoGenerateColumns="False" runat="server" CssClass="table table-hover" OnRowDataBound="grdCategory_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("CatName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category Description">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("CatDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="Action" Text="Edit" />
        </Columns>
      
    </asp:GridView>
</asp:Content>
<%@ Page Title="Sub Category List" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalesManagementSystem.SubCat.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="catList" ContentPlaceHolderID="body" runat="server">
    
    <div class="row">
        <div class="col-lg-6">
            <div class="form-inline">
                <div class="input-group">
                    <input id="searchInput" type="text" class="form-control" placeholder="Search for..." runat="server">
                    <span class="input-group-btn">
                        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-default" Text="Go!"/>
                    </span>
                </div>
            </div>
        </div>
    </div>
    
    <asp:GridView ID="grdCategory" AutoGenerateColumns="False" runat="server" CssClass="table table-hover">
        <Columns>
            <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                    <asp:Label ID="lblCatName" runat="server" Text='<%#Eval("SubCategoryName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category Description">
                <ItemTemplate>
                    <asp:Label ID="lblCatDescription" runat="server" Text='<%#Eval("SubCatDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category Description">
                <ItemTemplate>
                    <asp:Label ID="lblCatDescription" runat="server" Text='<%#Eval("CatName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ItemSubCategoryID", "~/Admin/SubCat/Edit.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-success btn-sm">
                            <span class="glyphicon glyphicon-pencil"></span> Edit
                        </button>
                    </asp:HyperLink>
                    <asp:HyperLink runat="server" ID="btnDelete"  NavigateUrl='<%# Eval("ItemSubCategoryID", "~/Admin/SubCat/Delete.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-danger btn-sm">
                            <span class="glyphicon glyphicon-trash"></span>Delete
                        </button>
                    </asp:HyperLink>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ItemSubCategoryID", "~/Admin/SubCat/Details.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-info btn-sm">
                            <span class="glyphicon glyphicon-eye-open"></span> Details
                        </button>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
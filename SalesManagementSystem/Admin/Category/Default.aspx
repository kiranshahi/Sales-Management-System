<%@ Page Title="Category List" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalesManagementSystem.Category.Default" %>

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
                        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-default" Text="Go!" OnClick="BtnSearch_Click" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <label id="message" runat="server"></label>
    <asp:GridView ID="grdCategory" AutoGenerateColumns="False" runat="server" CssClass="table table-hover" AllowPaging="True" OnPageIndexChanging="grdCategory_PageIndexChanging" OnRowDataBound="grdCategory_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                    <asp:Label ID="lblCatName" runat="server" Text='<%#Eval("CatName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category Description">
                <ItemTemplate>
                    <asp:Label ID="lblCatDescription" runat="server" Text='<%#Eval("CatDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ItemCategoryID", "~/Admin/Category/Edit.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-success btn-sm">
                            <span class="glyphicon glyphicon-pencil"></span> Edit
                        </button>
                    </asp:HyperLink>
                    <asp:HyperLink runat="server" ID="btnDelete" NavigateUrl='<%# Eval("ItemCategoryID", "~/Admin/Category/Delete.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-danger btn-sm">
                            <span class="glyphicon glyphicon-trash"></span>Delete
                        </button>
                    </asp:HyperLink>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ItemCategoryID", "~/Admin/Category/Details.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-info btn-sm">
                            <span class="glyphicon glyphicon-eye-open"></span> Details
                        </button>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

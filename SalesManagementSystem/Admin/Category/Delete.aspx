<%@ Page Title="Delete Category" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="SalesManagementSystem.Category.Delete" %>

<asp:Content ID="catList" ContentPlaceHolderID="body" runat="server">
    <div id="warning" runat="server">
        <p class="text-danger">
            Do you really want to delete <asp:Label ID="lblCategoryName" CssClass="lead" Text="" runat="server" /> from category?
        </p>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click"/>
    </div>
    <div id="success" runat="server">
        <p class="text-success">
            Category deleted successfully.
        </p>
    </div>
</asp:Content>
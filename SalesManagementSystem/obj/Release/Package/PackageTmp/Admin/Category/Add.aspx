<%@ Page Title="Add Categories" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SalesManagementSystem.AddCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="addCatForm" ContentPlaceHolderID="body" runat="server">
    <label id="lblMessage" runat="server"></label>
    <div class="form-group">
        <label for="catName">Category Name:</label>
        <asp:TextBox ID="txtCatName" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>
    
    <div class="form-group">
        <label for="catDescription">Category Description:</label>
        <textarea id="txtCatDescription" cols="20" rows="2" class="form-control" runat="server"></textarea>
    </div>
    
    <div class="form-group row">
        <asp:Button ID="btnSaveCat" runat="server" Text="Save Category" CssClass="btn btn-success" OnClick="InsertCat"/>
    </div>

</asp:Content>
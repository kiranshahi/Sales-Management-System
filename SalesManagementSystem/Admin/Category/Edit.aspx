<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SalesManagementSystem.Category.Edit" %>
<asp:Content ID="editCatForm" ContentPlaceHolderID="body" runat="server">
    <label id="lblMessage" runat="server"></label>
    
    <asp:HiddenField ID="catId" runat="server"/>
    
    <div class="form-group">
        <label for="catName">Category Name:</label>
        <asp:TextBox ID="txtCatName" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>
    
    <div class="form-group">
        <label for="catDescription">Category Description:</label>
        <textarea id="txtCatDescription" cols="20" rows="2" class="form-control" runat="server"></textarea>
    </div>
    
    <div class="form-group row">
        <asp:Button ID="btnUpdateCat" runat="server" Text="Update Category" CssClass="btn btn-success" OnClick="BtnUpdateCat_Click"/>
    </div>
</asp:Content>
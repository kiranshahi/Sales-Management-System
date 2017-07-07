<%@ Page Title="Add Sub Categories" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SalesManagementSystem.AddSubCat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="AddSubCat" ContentPlaceHolderID="main" runat="server">
        
        <div class="form-group"> 
            <label for="subCatName">Sub Category Name:</label>
            <asp:TextBox ID="subCatName" runat="server" CssClass="form-control" required></asp:TextBox>
        </div>
    
        <div class="form-group">
            <label for="selectCat">Select Category:</label>
            <asp:DropDownList ID="selectCat" CssClass="form-control" runat="server" name="selectCat"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="subCatDescription">Sub Category Description:</label>
            <textarea id="subCatDescription" cols="40" rows="2" class="form-control" runat="server"></textarea>
        </div>

        <div class="form-group row">
            <asp:Button ID="btnSaveSubCat" runat="server" Text="Save Sub Category" CssClass="btn btn-success" OnClick="btnSaveSubCat_Click"/>
        </div>
</asp:Content>

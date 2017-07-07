<%@ Page Title="Add Items" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SalesManagementSystem.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="addCatForm" ContentPlaceHolderID="body" runat="server">
        
    <div class="form-group">
        <label for="itemName">Item Name:</label>
        <asp:TextBox ID="itemName" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="selectSubCat">Select Sub Category:</label>
        <asp:DropDownList ID="selectSubCat" CssClass="form-control" runat="server"></asp:DropDownList>
    </div>
        
    <div class="form-group">
        <label for="itemDescription">Item Description:</label>
        <textarea id="itemDescription" cols="20" rows="2" class="form-control" runat="server"></textarea>
    </div>
        
    <div class="form-group row">
        <asp:Button ID="btnSaveCat" runat="server" Text="Save Category" CssClass="btn btn-success" OnClick="btnSaveCat_Click" />
    </div>

</asp:Content>
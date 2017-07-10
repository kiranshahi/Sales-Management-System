<%@ Page Title="Add Items" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SalesManagementSystem.AddItem" %>
<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
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
        <asp:Button ID="btnSaveItem" runat="server" Text="Save Item" CssClass="btn btn-success" OnClick="BtnSaveItem_Click" />
    </div>

</asp:Content>
<%@ Page Title="Item Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddItemDetails.aspx.cs" Inherits="SalesManagementSystem.AddItemDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="AddIitemDetails" ContentPlaceHolderID="body" runat="server">

    <div class="form-group">
        <label for="selectItem">Select Item:</label>
        <asp:DropDownList ID="selectItem" CssClass="form-control" runat="server" name="selectItem"></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="itemColor">Color:</label>
        <asp:TextBox ID="itemColor" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="itemSize">Size:</label>
        <asp:TextBox ID="itemSize" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="itemWeight">Weight:</label>
        <asp:TextBox ID="itemWeight" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="sellingPrice">Selling Price:</label>
        <asp:TextBox ID="sellingPrice" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>
        
    <div class="form-group row">
        <asp:Button ID="btnSaveDetails" runat="server" Text="Save Item Details" CssClass="btn btn-success" OnClick="btnSaveDetails_Click" />
    </div>

</asp:Content>
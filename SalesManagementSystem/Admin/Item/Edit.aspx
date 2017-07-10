<%@ Page Title="Edit Item Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SalesManagementSystem.Item.Edit" %>
<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="addCatForm" ContentPlaceHolderID="body" runat="server">
    
    <div class = "panel panel-warning">
        
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
        
        <div class = "panel-body" >
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
            
            <div class="form-group">
                <asp:Button ID="btnUpdateItem" runat="server" Text="Update Item" CssClass="btn btn-success" OnClick="BtnUpdateItem_Click" />
            </div>
        </div>
    </div>

</asp:Content>
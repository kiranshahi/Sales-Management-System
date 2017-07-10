<%@ Page Title="Item Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="SalesManagementSystem.Item.Details" %>

<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="itemDetailsForm" ContentPlaceHolderID="body" runat="server">
    
    <div class = "panel panel-warning">
        
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
        
        <div class = "panel-body" >
            
            <label>Item Name:</label>
            <p id="itemName" runat="server"></p>

            <label>Sub Category:</label>
            <p id="subCat" runat="server"></p>
            
            <label>Category:</label>
            <p id="category" runat="server"></p>

            <label>Item Description:</label>
            <p id="itemDesc" runat="server"></p>

        </div>
    </div>

</asp:Content>
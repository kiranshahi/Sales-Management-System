<%@ Page Title="Item Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="SalesManagementSystem.ItemDetails.Details" %>

<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="itemDetailsForm" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-warning">

        <div class="panel-heading">
            <h3 class="panel-title"><%: Title %> </h3>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="panel-body">

            <label>Item Name:</label>
            <p id="itemName" runat="server"></p>

            <label>Color:</label>
            <p id="itemColor" runat="server"></p>

            <label>Size:</label>
            <p id="itemSize" runat="server"></p>

            <label>Weight:</label>
            <p id="itemWeight" runat="server"></p>

            <label>Selling Price:</label>
            <p id="itemSellingPrice" runat="server"></p>

            <label>Quantity:</label>
            <p id="itemQuantity" runat="server"></p>

            <label>Description:</label>
            <p id="itemDescription" runat="server"></p>

            <label>Sub Category Name:</label>
            <p id="itemSubCategoryName" runat="server"></p>

            <label>Category Name:</label>
            <p id="itemCatName" runat="server"></p>

        </div>
    </div>
</asp:Content>

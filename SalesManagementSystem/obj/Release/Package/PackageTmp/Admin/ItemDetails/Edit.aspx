<%@ Page Title="Edit Item Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SalesManagementSystem.ItemDetails.Edit" %>

<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>

<asp:Content ID="AddIitemDetails" ContentPlaceHolderID="body" runat="server">

    <div class="panel panel-warning">

        <div class="panel-heading">
            <h3 class="panel-title"><%: Title %> </h3>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="panel-body">
            <div class="form-group">
                <label for="selectItem">Item Name:</label>
                <asp:TextBox ID="itemName" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="itemColor">Color:</label>
                <asp:TextBox ID="itemColor" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="itemSize">Size:</label>
                <asp:TextBox ID="itemSize" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="itemWeight">Weight:</label>
                <asp:TextBox ID="itemWeight" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="sellingPrice">Selling Price:</label>
                <asp:RequiredFieldValidator ID="sellingPriceValidator" runat="server" ControlToValidate="sellingPrice" ErrorMessage="Selling Price is required."></asp:RequiredFieldValidator>
                <asp:TextBox ID="sellingPrice" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group row">
                <label></label>
                <asp:Button ID="btnUpdateDetails" runat="server" Text="Update Item Details" CssClass="btn btn-success" />
            </div>
        </div>
    </div>

</asp:Content>

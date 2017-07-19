<%@ Page Title="Delete Item" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="SalesManagementSystem.Item.Delete" %>

<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="catList" ContentPlaceHolderID="body" runat="server">
    <div id="warning" runat="server">
        <p class="text-danger">
            Do you really want to delete
            <asp:Label ID="lblItemName" CssClass="lead" Text="" runat="server" />
            from Item?
        </p>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click" />
    </div>
    <div id="success" runat="server">
        <p class="text-success">
            Item deleted successfully.
        </p>
    </div>
</asp:Content>

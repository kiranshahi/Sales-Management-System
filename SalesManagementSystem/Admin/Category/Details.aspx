<%@ Page Title="Category Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="SalesManagementSystem.Category.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="catDetails" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="page-header">
                Category Details
            </div>
            <h3 id="catName" runat="server"></h3>

            <p id="catDescription" runat="server">
            </p>
        </div>
    </div>
</asp:Content>
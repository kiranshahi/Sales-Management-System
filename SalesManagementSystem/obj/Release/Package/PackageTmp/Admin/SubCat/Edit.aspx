<%@ Page Title="Edit Sub Category Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SalesManagementSystem.SubCat.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="AddSubCat" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-warning">

        <div class="panel-heading">
            <h3 class="panel-title"><%: Title %> </h3>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="panel-body">
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
                <asp:Button ID="btnUpdateSubCat" runat="server" Text="Update Sub Category" CssClass="btn btn-success" OnClick="BtnUpdateSubCat_Click" />
            </div>
        </div>
    </div>
</asp:Content>

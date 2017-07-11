<%@ Page Title="Add Item Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SalesManagementSystem.AddItemDetails" %>

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
                <asp:RegularExpressionValidator ID="valSellingPrice" runat="server" ControlToValidate="sellingPrice" ErrorMessage="Selling Price must be numeric." ValidationExpression="^[0-9]\d{0,9}(\.\d{1,3})?%?$"></asp:RegularExpressionValidator>
                <asp:TextBox ID="sellingPrice" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="uploadImage">Upload image</label>
                <asp:FileUpload ID="uploadImage" runat="server" />
            </div>

            <div class="form-group row">
                <label></label>
                <asp:Button ID="btnSaveDetails" runat="server" Text="Save Item Details" CssClass="btn btn-success" OnClick="BtnSaveDetails_Click" />
            </div>
        </div>
    </div>
</asp:Content>

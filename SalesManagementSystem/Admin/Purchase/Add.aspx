<%@ Page Title="Add Purchases" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SalesManagementSystem.AddPurchase" %>

<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="AddPurchase" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-warning">

        <div class="panel-heading">
            <h3 class="panel-title"><%: Title %> </h3>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="panel-body">
            <div class="form-group row">
                <label for="selectItem" class="col-sm-2">Item:</label>
                <div class="col-sm-8">
                    <asp:DropDownList ID="selectItem" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectItem_SelectedIndexChanged" EnableTheming="True"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="selectColor" class="col-sm-2">Color:</label>
                <div class="col-sm-8">
                    <asp:DropDownList ID="selectColor" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectColor_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="selectSize" class="col-sm-2">Size:</label>
                <div class="col-sm-8">
                    <asp:DropDownList ID="selectSize" CssClass="form-control" runat="server" name="selectSize"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="purchasedFrom" class="col-sm-2">Suppliers:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtPurchasedFrom" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="purchasedQuantity" class="col-sm-2">Quantity:</label><asp:RegularExpressionValidator ID="QuantityValidator" runat="server" ControlToValidate="txtPurchasedQuantity" ErrorMessage="Quantity must be numeric." ValidationExpression="\d+"></asp:RegularExpressionValidator>
                &nbsp;<div class="col-sm-8">
                    <asp:TextBox ID="txtPurchasedQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="costPrice" class="col-sm-2">Cost Price</label><asp:RegularExpressionValidator ID="CostPriceValidator" runat="server" ControlToValidate="txtCostPrice" ErrorMessage="Cost price must be numeric." ValidationExpression="^[0-9]\d{0,9}(\.\d{1,3})?%?$"></asp:RegularExpressionValidator>
                &nbsp;<div class="col-sm-8">
                    <asp:TextBox ID="txtCostPrice" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtPurchasedDate" class="col-sm-2">Purchased Date:</label>
                <div class="form-inline">
                    <div class="col-sm-10">
                        <div class='input-group date' id='SalesMngtDatetimePicker'>
                            <asp:TextBox ID="txtPurchasedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server"></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group row">
                <asp:Button ID="btnSavePurchase" runat="server" Text="Save Purchase" CssClass="btn btn-success" OnClick="BtnSavePurchase_Click" />
            </div>
        </div>
    </div>
</asp:Content>

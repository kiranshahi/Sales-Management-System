<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SalesManagementSystem.AddPurchase" %>

<asp:Content ID="AddPurchase" ContentPlaceHolderID="body" runat="server">

    <div class="form-group row">
        <label for="selectItem" class="col-sm-2">Item:</label>
        <div class="col-sm-8">
            <asp:DropDownList ID="selectItem" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectItem_SelectedIndexChanged"></asp:DropDownList>
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
        <label for="purchasedQuantity" class="col-sm-2">Quantity:</label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtPurchasedQuantity" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label for="costPrice" class="col-sm-2">Cost Price</label>
        <div class="col-sm-8">
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
        <asp:Button ID="btnSavePurchase" runat="server" Text="Save Purchase" CssClass="btn btn-success" OnClick="BtnSavePurchase_Click"/>
    </div>

</asp:Content>
<%@ Page Title="Item Sales" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="SalesManagementSystem.Sales.Sale" %>

<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="AddPurchase" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group row">
                <label for="selectItem" class="col-sm-4">Item:</label>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanelItem" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="selectItem" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectItem_SelectedIndexChanged" EnableTheming="True"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="form-group row">
                <label for="selectColor" class="col-sm-4">Color:</label>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanelColor" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="selectColor" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectColor_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="form-group row">
                <label for="selectSize" class="col-sm-4">Size:</label>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanelSize" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="selectSize" CssClass="form-control" runat="server" AutoPostBack="true" name="selectSize" OnSelectedIndexChanged="SelectSize_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtQuantity" class="col-sm-4">Quantity:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtItemPrice" class="col-sm-4">Selling Price:</label>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtItemPrice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>


            <div class="form-group row">
                <label class="col-sm-4"></label>
                <div class="col-sm-8">
                    <button id="btnAddToSale" type="button" class="btn btn-success" onclick="addItem()">Add Item To Sales</button>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div id='cart'></div>

            <asp:Button ID="btnGenerateBill" runat="server" Text="Generate Bill" CssClass="btn btn-success" OnClick="BtnGenerateBill_Click"/>

            <asp:HiddenField ID="ItemDetailsId" runat="server" />
            <asp:HiddenField ID="Quantity" runat="server" />
            <asp:HiddenField ID="Price" runat="server" />
            <asp:HiddenField ID="Total" runat="server" />
        </div>
    </div>
</asp:Content>

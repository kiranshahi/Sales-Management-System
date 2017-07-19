<%@ Page Title="Purchase History" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalesManagementSystem.Purchase.Default" %>
<asp:Content ID="name" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="itemList" ContentPlaceHolderID="body" runat="server">
    
    <div class="row">
        <div class="col-lg-6">
            <div class="form-inline">
                <div class="input-group">
                    <input id="searchInput" type="text" class="form-control" placeholder="Search for..." runat="server">
                    <span class="input-group-btn">
                        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-default" Text="Go!" OnClick="BtnSearch_Click"  />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <a href="~/Admin/Purchase/Add" runat="server">Add New Purchase</a>
    <label id="message" runat="server"></label>
    <asp:GridView ID="grdPurchase" AutoGenerateColumns="False" runat="server" CssClass="table table-hover" AllowPaging="True" OnPageIndexChanging="grdPurchase_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:Label ID="lblCatName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color">
                <ItemTemplate>
                    <asp:Label ID="lblCatName" runat="server" Text='<%#Eval("Color") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size">
                <ItemTemplate>
                    <asp:Label ID="lblCatName" runat="server" Text='<%#Eval("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="suppliers">
                <ItemTemplate>
                    <asp:Label ID="lblCatDescription" runat="server" Text='<%#Eval("PurchasedFrom") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblCatStatus" runat="server" Text='<%#Eval("PurchasedQuantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cost Price">
                <ItemTemplate>
                    <asp:Label ID="lblCatStatus" runat="server" Text='<%#Eval("CostPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Purchased Date">
                <ItemTemplate>
                    <asp:Label ID="lblCatStatus" runat="server" Text='<%#Eval("PurchasedOn") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
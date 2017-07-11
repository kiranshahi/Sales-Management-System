<%@ Page Title="Stock List" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalesManagementSystem.ItemDetails.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Name" runat="server">
    <span id="lblName" runat="server"></span>
</asp:Content>
<asp:Content ID="catList" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-lg-6">
            <div class="form-inline">
                <div class="input-group">
                    <input id="searchInput" type="text" class="form-control" placeholder="Search for..." runat="server">
                    <span class="input-group-btn">
                        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-default" Text="Go!" OnClick="BtnSearch_Click" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <a href="~/Admin/ItemDetails/Add" runat="server">Add New Item Details</a>
    <label id="message" runat="server"></label>
    <asp:GridView ID="grdItemDetails" AutoGenerateColumns="False" runat="server" CssClass="table table-hover" AllowPaging="True" OnPageIndexChanging="grdItemDetails_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Item Name">
                <ItemTemplate>
                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Color">
                <ItemTemplate>
                    <asp:Label ID="lblItemColor" runat="server" Text='<%#Eval("Color") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Size">
                <ItemTemplate>
                    <asp:Label ID="lblItemSize" runat="server" Text='<%#Eval("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Weight">
                <ItemTemplate>
                    <asp:Label ID="lblItemWeight" runat="server" Text='<%#Eval("ItmWeight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblItemWeight" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <div class="thumbnail img-circle">
                        <asp:Image ID="ImageButton1" runat="server" CssClass="media-object" ImageUrl='<%#"~/images/"+Eval("Image") %>' />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ItemDetailsID", "~/Admin/ItemDetails/Edit.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-success btn-sm">
                            <span class="glyphicon glyphicon-pencil"></span> Edit
                        </button>
                    </asp:HyperLink>
                    <asp:HyperLink runat="server" ID="btnDelete" NavigateUrl='<%# Eval("ItemDetailsID", "~/Admin/ItemDetails/Delete.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-danger btn-sm">
                            <span class="glyphicon glyphicon-trash"></span>Delete
                        </button>
                    </asp:HyperLink>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ItemDetailsID", "~/Admin/ItemDetails/Details.aspx?Id={0}") %>'>
                        <button type="button" class="btn btn-info btn-sm">
                            <span class="glyphicon glyphicon-eye-open"></span> Details
                        </button>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

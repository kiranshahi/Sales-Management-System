<%@ Page Title="Edit Profile Details" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SalesManagementSystem.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="editProfile" ContentPlaceHolderID="body" runat="server">
    
    <div class = "panel panel-warning">
        
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
        
        <div class = "panel-body" >
            
            <div class="form-group row">
                <label for="txtUserName" class="col-sm-2">First Name:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtName" class="col-sm-2">Last Name:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtEmail" class="col-sm-2">Email:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtPhone" class="col-sm-2">Contact No:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row" id="password">
                <label for="txtPassword" class="col-sm-2">Password:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtPhone" class="col-sm-2"></label>
                <div class="col-sm-8">
                    <button type="button" class="btn btn-default" id="showPasswordFields" onclick="makeid()"> Generate Password </button>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-2"></label>
                <div class="col-sm-8">
                    <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" CssClass="btn btn-success" OnClick="BtnUpdateProfile_Click"/>
                    <asp:Button ID="btnDactivate" runat="server" Text="Deactivate Account" CssClass="btn btn-danger" OnClick="BtnDactivate_Click"/>
                </div>
            </div>
        </div>
    
    </div>

</asp:Content>
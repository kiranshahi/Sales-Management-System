<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalesManagementSystem.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Login | Sales Management System</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body class="login">
    <div class="container body-content">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1>Login</h1>
                <label id="lblErrorMessage" runat="server"></label>
                <form id="loginForm" runat="server">
                    <div class="form-group">
                        <label for="email">Email address</label>
                        <input type="email" class="form-control" id="email" placeholder="example@yourdomain.com" name="email" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="password">Password</label>
                        <input type="password" class="form-control" id="password" placeholder="Password" name="password" runat="server" />
                    </div>
                
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" /> Remember Me
                        </label>
                    </div>

                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-default" OnClick="BtnLogin_Click"/>

                    <asp:ScriptManager runat="server">
                        <Scripts>
                            <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                            <%--Framework Scripts--%>
                            <asp:ScriptReference Name="MsAjaxBundle" />
                            <asp:ScriptReference Name="jquery" />
                            <asp:ScriptReference Name="bootstrap" />
                            <asp:ScriptReference Name="respond" />
                            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                            <asp:ScriptReference Name="WebFormsBundle" />
                            <%--Site Scripts--%>
                        </Scripts>
                    </asp:ScriptManager>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
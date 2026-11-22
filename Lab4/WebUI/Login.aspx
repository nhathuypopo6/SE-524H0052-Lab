<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUI.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>SE Lab 4 - Login Form</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: #f0f2f5; display: flex; justify-content: center; align-items: center; height: 100vh; margin: 0; }
        .login-card { background: white; padding: 30px; border-radius: 8px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); width: 340px; }
        .form-group { margin-bottom: 15px; }
        .form-group label { display: block; margin-bottom: 5px; font-weight: 600; font-size: 14px; }
        .form-control { width: 100%; padding: 8px 12px; box-sizing: border-box; border: 1px solid #ccc; border-radius: 4px; }
        .btn-primary { width: 100%; padding: 10px; background: #007bff; color: white; border: none; border-radius: 4px; font-weight: bold; cursor: pointer; }
        .btn-primary:hover { background: #0056b3; }
        .error { color: #dc3545; font-size: 13px; margin-top: 10px; display: block; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-card">
            <h2 style="text-align: center; color: #333; margin-top: 0;">SE LAB 4 LOGIN</h2>
            <div class="form-group">
                <label>Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn-primary" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
        </div>
    </form>
</body>
</html>

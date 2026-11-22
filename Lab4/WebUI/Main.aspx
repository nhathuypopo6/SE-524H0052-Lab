<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebUI.Main" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>SE Lab 4 - Main Portal</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: #eef2f7; margin: 0; }
        .navbar { background: #1a2238; color: white; padding: 15px 30px; display: flex; justify-content: space-between; align-items: center; }
        .navbar a { color: white; text-decoration: none; margin-left: 20px; font-weight: 500; }
        .container { max-width: 1000px; margin: 40px auto; padding: 20px; background: white; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.05); }
        .menu-grid { display: grid; grid-template-columns: repeat(2, 1fr); gap: 20px; margin-top: 30px; }
        .menu-card { background: #f8fafc; border: 1px solid #e2e8f0; border-radius: 8px; padding: 25px; text-align: center; text-decoration: none; color: #334155; transition: all 0.2s; }
        .menu-card:hover { transform: translateY(-3px); box-shadow: 0 4px 12px rgba(0,0,0,0.1); border-color: #3b82f6; }
        .menu-card h3 { margin: 0 0 10px 0; color: #1e293b; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <h2 style="margin: 0; font-size: 20px;">FIT - TDTU | Software Engineering Lab 4</h2>
            <div>
                <span>Welcome, <asp:Label ID="lblUser" runat="server" Font-Bold="true"></asp:Label></span>
                <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" ForeColor="#ff6b6b">Logout</asp:LinkButton>
            </div>
        </div>
        <div class="container">
            <h2>3-Tier Architecture Web Portal</h2>
            <p>Select a management module to execute CRUD operations with Business Logic & Data Access Layer:</p>
            <div class="menu-grid">
                <a href="CustomerWForm.aspx" class="menu-card">
                    <h3>👥 Customer Management</h3>
                    <p>Exercise 1: Add, Update, Delete and List Customers via Entity Framework.</p>
                </a>
                <a href="CustomerWForm.aspx?type=student" class="menu-card">
                    <h3>🎓 Student Management</h3>
                    <p>Manage Student records, GPA, Majors, and academic enrollments.</p>
                </a>
                <a href="CustomerWForm.aspx?type=product" class="menu-card">
                    <h3>📦 Product Catalog</h3>
                    <p>Manage store inventory, prices, stock quantities and categories.</p>
                </a>
                <a href="CustomerWForm.aspx?type=supplier" class="menu-card">
                    <h3>🏭 Supplier Directory</h3>
                    <p>Manage vendor contact info, corporate partners and supply lines.</p>
                </a>
            </div>
        </div>
    </form>
</body>
</html>

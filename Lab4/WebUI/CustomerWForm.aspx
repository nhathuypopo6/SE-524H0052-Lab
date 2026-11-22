<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerWForm.aspx.cs" Inherits="WebUI.CustomerWForm" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Customer Management - 3-Tier WebForm</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: #f8fafc; margin: 0; padding: 20px; }
        .container { max-width: 900px; margin: 0 auto; background: white; padding: 25px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.06); }
        .form-row { display: flex; gap: 15px; margin-bottom: 15px; align-items: center; }
        .form-row label { width: 80px; font-weight: 600; }
        .form-row input[type="text"] { flex: 1; padding: 8px 12px; border: 1px solid #cbd5e1; border-radius: 4px; }
        .btn-group { margin: 20px 0; display: flex; gap: 10px; }
        .btn { padding: 9px 18px; border: none; border-radius: 4px; font-weight: 600; cursor: pointer; }
        .btn-add { background: #10b981; color: white; }
        .btn-update { background: #3b82f6; color: white; }
        .btn-delete { background: #ef4444; color: white; }
        .btn-back { background: #64748b; color: white; text-decoration: none; padding: 9px 18px; border-radius: 4px; }
        .gridview { width: 100%; border-collapse: collapse; margin-top: 20px; }
        .gridview th { background: #1e293b; color: white; padding: 10px; text-align: left; }
        .gridview td { padding: 9px; border-bottom: 1px solid #e2e8f0; }
        .gridview tr:nth-child(even) { background: #f1f5f9; }
        .status { margin-top: 10px; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>👥 Customer Management (3-Tier WebForm)</h2>
            <div class="form-row">
                <label>ID:</label>
                <asp:TextBox ID="txtId" runat="server" placeholder="Auto-generated or enter for Update/Delete"></asp:TextBox>
            </div>
            <div class="form-row">
                <label>Name:</label>
                <asp:TextBox ID="txtName" runat="server" placeholder="Enter customer name"></asp:TextBox>
            </div>
            <div class="form-row">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter customer email"></asp:TextBox>
            </div>

            <div class="btn-group">
                <asp:Button ID="btnAdd" runat="server" Text="Add Customer" CssClass="btn btn-add" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update Customer" CssClass="btn btn-update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete Customer" CssClass="btn btn-delete" OnClick="btnDelete_Click" />
                <a href="Main.aspx" class="btn-back">⬅ Back to Portal</a>
            </div>

            <asp:Label ID="lblStatus" runat="server" CssClass="status"></asp:Label>

            <h3>Customer List</h3>
            <asp:GridView ID="gvCustomers" runat="server" CssClass="gridview" AutoGenerateColumns="true" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged"></asp:GridView>
        </div>
    </form>
</body>
</html>

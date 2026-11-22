using System;
using BLL;
using DAL;

namespace WebUI
{
    public partial class CustomerWForm : System.Web.UI.Page
    {
        private readonly CustomerService _customerService = new CustomerService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomerGrid();
            }
        }

        private void BindCustomerGrid()
        {
            gvCustomers.DataSource = _customerService.GetAllCustomers();
            gvCustomers.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = new Customer
                {
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                _customerService.AddCustomer(customer);
                lblStatus.Text = "Customer added successfully!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                BindCustomerGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                var customer = new Customer
                {
                    Id = id,
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                _customerService.UpdateCustomer(customer);
                lblStatus.Text = "Customer updated successfully!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                BindCustomerGrid();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                _customerService.DeleteCustomer(id);
                lblStatus.Text = "Customer deleted successfully!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                BindCustomerGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvCustomers.SelectedRow != null)
            {
                txtId.Text = gvCustomers.SelectedRow.Cells[1].Text;
                txtName.Text = gvCustomers.SelectedRow.Cells[2].Text;
                txtEmail.Text = gvCustomers.SelectedRow.Cells[3].Text;
            }
        }

        private void ClearInputs()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    }
}

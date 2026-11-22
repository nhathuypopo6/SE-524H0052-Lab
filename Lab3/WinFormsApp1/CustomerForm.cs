using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinFormUI
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerService _customerService;

        public CustomerForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter customer name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = new Customer
                {
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                _customerService.AddCustomer(customer);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCustomerId.Text.Trim(), out int customerId))
                {
                    MessageBox.Show("Please enter a valid Customer ID (integer)!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = _customerService.GetCustomer(customerId);
                if (customer != null)
                {
                    txtName.Text = customer.Name;
                    txtEmail.Text = customer.Email;
                }
                else
                {
                    MessageBox.Show("Customer not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCustomerId.Text.Trim(), out int customerId))
                {
                    MessageBox.Show("Please select or enter a valid Customer ID to update!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = new Customer
                {
                    Id = customerId,
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                _customerService.UpdateCustomer(customer);
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCustomerId.Text.Trim(), out int customerId))
                {
                    MessageBox.Show("Please select or enter a valid Customer ID to delete!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    _customerService.DeleteCustomer(customerId);
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadCustomers();
        }

        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtName.Clear();
            txtEmail.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
                {
                    txtCustomerId.Text = row.Cells["Id"].Value.ToString();
                    txtName.Text = row.Cells["Name"]?.Value?.ToString() ?? "";
                    txtEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";
                }
            }
        }
    }
}

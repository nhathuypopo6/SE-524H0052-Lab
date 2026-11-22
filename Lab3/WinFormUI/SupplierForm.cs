using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinFormUI
{
    public partial class SupplierForm : Form
    {
        private readonly SupplierService _supplierService;

        public SupplierForm()
        {
            InitializeComponent();
            _supplierService = new SupplierService();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = _supplierService.GetAllSuppliers();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = suppliers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                {
                    MessageBox.Show("Please enter supplier name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var supplier = new Supplier
                {
                    Name = txtSupplierName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };

                _supplierService.AddSupplier(supplier);
                MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtSupplierId.Text.Trim(), out int supplierId))
                {
                    MessageBox.Show("Please enter a valid Supplier ID!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var supplier = _supplierService.GetSupplier(supplierId);
                if (supplier != null)
                {
                    txtSupplierName.Text = supplier.Name;
                    txtAddress.Text = supplier.Address;
                    txtPhone.Text = supplier.Phone;
                }
                else
                {
                    MessageBox.Show("Supplier not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtSupplierId.Text.Trim(), out int supplierId))
                {
                    MessageBox.Show("Please select or enter a valid Supplier ID to update!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var supplier = new Supplier
                {
                    Id = supplierId,
                    Name = txtSupplierName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };

                _supplierService.UpdateSupplier(supplier);
                MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtSupplierId.Text.Trim(), out int supplierId))
                {
                    MessageBox.Show("Please select or enter a valid Supplier ID to delete!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _supplierService.DeleteSupplier(supplierId);
                    MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadSuppliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadSuppliers();
        }

        private void ClearInputs()
        {
            txtSupplierId.Clear();
            txtSupplierName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
                {
                    txtSupplierId.Text = row.Cells["Id"].Value.ToString();
                    txtSupplierName.Text = row.Cells["Name"]?.Value?.ToString() ?? "";
                    txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
                    txtPhone.Text = row.Cells["Phone"]?.Value?.ToString() ?? "";
                }
            }
        }
    }
}

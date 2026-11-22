using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinFormUI
{
    public partial class ProductForm : Form
    {
        private readonly ProductService _productService;

        public ProductForm()
        {
            InitializeComponent();
            _productService = new ProductService();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    MessageBox.Show("Please enter product name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
                {
                    MessageBox.Show("Please enter a valid price (number)!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtStock.Text.Trim(), out int stock))
                {
                    stock = 0;
                }

                var product = new Product
                {
                    Name = txtProductName.Text.Trim(),
                    Price = price,
                    Stock = stock
                };

                _productService.AddProduct(product);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductId.Text.Trim(), out int productId))
                {
                    MessageBox.Show("Please enter a valid Product ID!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = _productService.GetProduct(productId);
                if (product != null)
                {
                    txtProductName.Text = product.Name;
                    txtPrice.Text = product.Price.ToString("0.##");
                    txtStock.Text = product.Stock.ToString();
                }
                else
                {
                    MessageBox.Show("Product not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductId.Text.Trim(), out int productId))
                {
                    MessageBox.Show("Please select or enter a valid Product ID to update!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
                {
                    MessageBox.Show("Please enter a valid price!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtStock.Text.Trim(), out int stock))
                {
                    stock = 0;
                }

                var product = new Product
                {
                    Id = productId,
                    Name = txtProductName.Text.Trim(),
                    Price = price,
                    Stock = stock
                };

                _productService.UpdateProduct(product);
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductId.Text.Trim(), out int productId))
                {
                    MessageBox.Show("Please select or enter a valid Product ID to delete!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _productService.DeleteProduct(productId);
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadProducts();
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
                {
                    txtProductId.Text = row.Cells["Id"].Value.ToString();
                    txtProductName.Text = row.Cells["Name"]?.Value?.ToString() ?? "";
                    txtPrice.Text = row.Cells["Price"]?.Value?.ToString() ?? "";
                    txtStock.Text = row.Cells["Stock"]?.Value?.ToString() ?? "";
                }
            }
        }
    }
}

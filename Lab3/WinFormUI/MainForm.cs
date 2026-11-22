using System;
using System.Windows.Forms;
using DAL;

namespace WinFormUI
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;

        public MainForm(User user = null)
        {
            InitializeComponent();
            _currentUser = user;
            if (_currentUser != null)
            {
                lblStatusUser.Text = $"Logged in as: {_currentUser.FullName} ({_currentUser.Role})";
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            form.ShowDialog(this);
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            form.ShowDialog(this);
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SupplierForm();
            form.ShowDialog(this);
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new StudentForm();
            form.ShowDialog(this);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var mainForm = new MainForm(loginForm.CurrentUser);
                mainForm.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

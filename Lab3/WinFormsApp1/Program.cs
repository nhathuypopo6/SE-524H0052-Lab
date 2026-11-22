using System;
using System.Windows.Forms;

namespace WinFormUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // =========================================================================
            // OPTION A (Full Flow - Exercise 2 + 3 + Homework):
            // Login -> Main Form (with MenuStrip to Customer, Product, Supplier, Student)
            // =========================================================================
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(loginForm.CurrentUser));
            }

            // =========================================================================
            // OPTION B (Exercise 1 direct run):
            // Uncomment the line below and comment OPTION A above if you only want to test Exer1:
            // Application.Run(new CustomerForm());
            // =========================================================================
        }
    }
}
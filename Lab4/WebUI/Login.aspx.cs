using System;
using BLL;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UserService _userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role;

            if (_userService.Authenticate(username, password, out role))
            {
                Session["User"] = username;
                Session["Role"] = role;
                Response.Redirect("Main.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password!";
            }
        }
    }
}

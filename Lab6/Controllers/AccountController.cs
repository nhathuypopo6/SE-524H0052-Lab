using System.Web.Mvc;
using Lab06_ASPNET_MVC.Models;

namespace Lab06_ASPNET_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblUser model)
        {
            if (model.Username == "admin" && model.Password == "admin123")
            {
                Session["User"] = "admin";
                Session["Role"] = "Administrator";
                return RedirectToAction("Index", "Students");
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

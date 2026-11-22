using System.Web.Mvc;

namespace Lab06_ASPNET_MVC.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult StudentTranscript()
        {
            ViewBag.Message = "Student Academic Progress & Transcript Report (RDLC / ReportViewer Demo)";
            return View();
        }
    }
}

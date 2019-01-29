using Framo.WebUI.Areas.Administrator.Models;
using System.Globalization;
using System.Web.Mvc;

namespace Framo.WebUI.Areas.Administrator.Controllers
{
    [AdminLogin]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
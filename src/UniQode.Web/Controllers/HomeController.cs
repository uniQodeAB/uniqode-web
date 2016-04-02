using System.Web.Mvc;

namespace UniQode.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        // GET: Home
        public ActionResult Index(bool preview = false)
        {
            return View();
        }
    }
}
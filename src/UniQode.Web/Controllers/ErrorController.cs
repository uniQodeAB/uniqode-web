using System.Web.Mvc;

namespace UniQode.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            Response.StatusCode = 500;
            return View();
        }
        
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}
using System;
using System.Web.Mvc;
using UniQode.Contracts.Services;
using UniQode.Data;
using UniQode.Entities.Data;
using UniQode.Models.Admin;

namespace UniQode.Web.Controllers
{
    [Authorize]
    [RoutePrefix("admin")]
    public class AdminController : Controller
    {
        public AdminController(
            IMultiTenantService<SpotlightQuestion, Guid> spotlightQuestionService
            )
        {
            _spotlightQuestionService = spotlightQuestionService;
        }

        private readonly IMultiTenantService<SpotlightQuestion, Guid> _spotlightQuestionService;

        public ActionResult Index(bool invalidateCache = false)
        {
            var model = new StartModel();

            return View(model);
        }

        public ActionResult Employees(bool invalidateCache = false)
        {
            return View();
        }

        public ActionResult News(bool invalidateCache = false)
        {
            return View();
        }
    }
}
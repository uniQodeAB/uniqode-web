using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
using UniQode.Models.Shared;

namespace UniQode.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IMultiTenantService<Motto, Guid> mottoService)
        {
            _mottoService = mottoService;
        }

        private readonly IMultiTenantService<Motto, Guid> _mottoService;

        // GET: Home
        public ActionResult Index(bool preview = false)
        {
            return View();
        }

        [ChildActionOnly]
        [HttpGet]
        public ActionResult Mottos(bool preview = false)
        {
            ICollection<Motto> dtos = null;

            if (preview)
            {
                dtos = _mottoService.Secondary.List(true);
            }
            else
            {
                dtos = _mottoService.Primary.List(true);
            }

            var models = dtos.Select(MottoModel.FromDto).ToList();

            return PartialView("Partials/_Mottos", models);
        }
    }
}
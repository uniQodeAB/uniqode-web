using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniQode.Common.Extensions;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
using UniQode.Models.Shared;

namespace UniQode.Web.Controllers
{
    [Authorize]
    public class SpotlightController : Controller
    {
        public SpotlightController(
            IMultiTenantService<SpotlightQuestion, Guid> spotlightQuestionService, IMultiTenantService<Employee, Guid> employeeService
            )
        {
            _spotlightQuestionService = spotlightQuestionService;
            _employeeService = employeeService;
        }

        private readonly IMultiTenantService<SpotlightQuestion, Guid> _spotlightQuestionService;
        private readonly IMultiTenantService<Employee, Guid> _employeeService;

        /// <summary>
        /// Used in admin view, no caching
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [HttpGet]
        public ActionResult Questions()
        {
            var dtos = _spotlightQuestionService.Secondary.List(true);
            var models = dtos.Select(SpotlightQuestionModel.FromDto).ToList();

            return PartialView("Partials/Admin/_SpotlightQuestions", models);
        }

        [AllowAnonymous]
        [ChildActionOnly]
        [HttpGet]
        public ActionResult Public(bool preview = false)
        {
            ICollection<Employee> dtos = null;

            if (preview)
            {
                dtos = _employeeService.Secondary.List(true);
            }
            else
            {
                dtos = _employeeService.Primary.List();
            }

            var models = dtos.Select(EmployeeModel.FromDto).ToList();
            models.RemoveAll(x => x.Spotlights == null || !x.Spotlights.Any());
            models.Shuffle();

            return PartialView("Partials/_Spotlight", models);
        }
    }
}
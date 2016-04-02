using System;
using System.Linq;
using System.Web.Mvc;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
using UniQode.Models.Shared;

namespace UniQode.Web.Controllers
{
    [Authorize]
    public class SpotlightController : Controller
    {
        public SpotlightController(
            IMultiTenantService<SpotlightQuestion, Guid> spotlightQuestionService
            )
        {
            _spotlightQuestionService = spotlightQuestionService;
        }

        private readonly IMultiTenantService<SpotlightQuestion, Guid> _spotlightQuestionService;

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
    }
}
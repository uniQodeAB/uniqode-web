using System;
using System.Linq;
using System.Web.Mvc;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;
using UniQode.Models.Shared;

namespace UniQode.Web.Controllers
{
    [Authorize]
    public class WorkfieldController : Controller
    {
        public WorkfieldController(IMultiTenantService<WorkField, Guid> workfieldService)
        {
            _workfieldService = workfieldService;
        }

        private readonly IMultiTenantService<WorkField, Guid> _workfieldService;

        /// <summary>
        /// Used in admin view, no caching
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [HttpGet]
        public ActionResult List(State state = State.None)
        {
            var dtos = _workfieldService.Secondary.List(true);
            var models = dtos.Select(WorkFieldModel.FromDto).ToList();

            switch (state)
            {
                case State.Adding:
                    models.Add(new WorkFieldModel
                    {
                        Id = Guid.NewGuid(),
                        State = state
                    });
                    break;
            }

            return PartialView("Partials/Admin/_WorkFields", models);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;
using UniQode.Models.Shared;
using UniQode.Web.Extensions;

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
        public ActionResult List(string state = null)
        {
            var dtos = _workfieldService.Secondary.List(true);
            var models = dtos.Select(WorkFieldModel.FromDto).ToList();

            WorkFieldModel parsedModel = null;
            var parsedState = State.None;
            if (!string.IsNullOrEmpty(state) && !Enum.TryParse(state, out parsedState))
            {
                parsedModel = JsonConvert.DeserializeObject<WorkFieldModel>(state);
            }

            if (parsedModel != null && models.FirstOrDefault(m => m.Id == parsedModel.Id) != null)
            {
                for (var i = 0; i < models.Count; ++i)
                {
                    if (models[i].Id == parsedModel.Id)
                    {
                        models[i] = parsedModel;
                    }
                }
            }
            else if (parsedModel != null)
            {
                models.Add(parsedModel);
            }

            switch (parsedState)
            {
                case State.Adding:
                    models.Add(new WorkFieldModel
                    {
                        Id = Guid.NewGuid(),
                        State = parsedState
                    });
                    break;
                default:
                    foreach (var model in models)
                    {
                        this.ValidateViewModel(model);
                    }
                    break;

            }

            return PartialView("Partials/Admin/_WorkFields", models);
        }

        [HttpPost]
        public ActionResult Act(WorkFieldModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.State == State.None)
                {
                    switch (model.Action)
                    {
                        case AdminAction.Preview:
                        case AdminAction.Publish:
                        case AdminAction.Update:
                        case AdminAction.Save:
                            model.State = State.Updating;
                            break;
                        case AdminAction.Add:
                            model.State = State.Adding;
                            break;
                        case AdminAction.Delete:
                            model.State = State.Deleting;
                            break;
                    }
                }

                if (model.Action != AdminAction.Delete)
                    return RedirectToAction("Index", "Admin", new { motto = JsonConvert.SerializeObject(model) });
            }

            switch (model.Action)
            {
                case AdminAction.Delete:
                    try
                    {
                        _workfieldService.Primary.Delete(model.Id, User.Identity);
                    }
                    catch
                    {
                        // suppress since it could be missing in the primary schema (if not published yet)
                    }
                    _workfieldService.Secondary.Delete(model.Id, User.Identity);
                    break;
                case AdminAction.Save:
                    _workfieldService.Secondary.Update(model.ToDto(), User.Identity);
                    break;
                case AdminAction.Preview:
                    _workfieldService.Secondary.Update(model.ToDto(), User.Identity);
                    return RedirectToAction("Index", "Home", new { Preview = true });
                case AdminAction.Publish:
                    _workfieldService.Primary.Update(model.ToDto(), User.Identity);
                    _workfieldService.Secondary.Update(model.ToDto(), User.Identity);
                    return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Admin");
        }

        [AllowAnonymous]
        [ChildActionOnly]
        [HttpGet]
        public ActionResult Public(bool preview = false)
        {
            ICollection<WorkField> dtos = null;

            if (preview)
            {
                dtos = _workfieldService.Secondary.List(true);
            }
            else
            {
                dtos = _workfieldService.Primary.List();
            }

            var models = dtos.Select(WorkFieldModel.FromDto).ToList();

            return PartialView("Partials/_Workfields", models);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using UniQode.Common.Extensions;
using UniQode.Contracts.Services;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;
using UniQode.Models.Admin;
using UniQode.Models.Shared;
using UniQode.Web.Attributes;
using UniQode.Web.Extensions;

namespace UniQode.Web.Controllers
{
    [Authorize]
    [RoutePrefix("mottos")]
    public class MottoController : Controller
    {
        public MottoController(IMultiTenantService<Motto, Guid> mottoService, IMultiTenantService<Employee, Guid> employeeService)
        {
            _mottoService = mottoService;
            _employeeService = employeeService;
        }

        private readonly IMultiTenantService<Motto, Guid> _mottoService;
        private readonly IMultiTenantService<Employee, Guid> _employeeService;
        
        /// <summary>
        /// Used in admin view, no caching
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [HttpGet]
        public ActionResult List(string state = null)
        {
            var dtos = _mottoService.Secondary.List(true);
            var models = dtos.Select(MottoModel.FromDto).ToList();

            MottoModel parsedModel = null;
            var parsedState = State.None;
            if (!string.IsNullOrEmpty(state) && !Enum.TryParse(state, out parsedState))
            {
                parsedModel = JsonConvert.DeserializeObject<MottoModel>(state);
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
                    models.Add(new MottoModel
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
            
            return PartialView("Partials/Admin/_Mottos", models);
        }

        [HttpPost]
        public ActionResult Act(MottoModel model)
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

                if(model.Action != AdminAction.Delete)
                    return RedirectToAction("Index", "Admin", new { motto = JsonConvert.SerializeObject(model) });
            }

            switch (model.Action)
            {
                case AdminAction.Delete:
                    try
                    {
                        _mottoService.Primary.Delete(model.Id, User.Identity);
                    }
                    catch
                    {
                        // suppress since it could be missing in the primary schema (if not published yet)
                    }
                    _mottoService.Secondary.Delete(model.Id, User.Identity);
                    break;
                case AdminAction.Save:
                    _mottoService.Secondary.Update(model.ToDto(), User.Identity);
                    break;
                case AdminAction.Preview:
                    _mottoService.Secondary.Update(model.ToDto(), User.Identity);
                    return RedirectToAction("Index", "Home", new { Preview = true });
                case AdminAction.Publish:
                    _mottoService.Primary.Update(model.ToDto(), User.Identity);
                    _mottoService.Secondary.Update(model.ToDto(), User.Identity);
                    return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Admin");
        }

        [AllowAnonymous]
        [ChildActionOnly]
        [HttpGet]
        public ActionResult Public(bool preview = false)
        {
            ICollection<Motto> mottoDtos = null;
            ICollection<Employee> employeeDtos = null;

            if (preview)
            {
                mottoDtos = _mottoService.Secondary.List(true);
                employeeDtos = _employeeService.Secondary.List(true);
            }
            else
            {
                mottoDtos = _mottoService.Primary.List();
                employeeDtos = _employeeService.Primary.List();
            }

            var mottoModels = mottoDtos.Select(MottoModel.FromDto).ToList();
            var employeeModels = employeeDtos.Select(EmployeeModel.FromDto).ToList();
            employeeModels.Shuffle();

            var model = Tuple.Create(mottoModels, employeeModels);

            return PartialView("Partials/_Mottos", model);
        }
    }
}
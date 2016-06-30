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
    public class EmployeeController : Controller
    {
        public EmployeeController(IMultiTenantService<Employee, Guid> employeeService)
        {
            _employeeService = employeeService;
        }

        private readonly IMultiTenantService<Employee, Guid> _employeeService;

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
            models.Shuffle();

            return PartialView("Partials/_Employees", models);
        }
    }
}
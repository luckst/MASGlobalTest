namespace MasGlobal.Test.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MasGlobal.Test.Application.Services;
    using MasGlobal.Test.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        IEmployeesApplicationService employeesApplicationService;

        public EmployeesController(IEmployeesApplicationService employeesApplicationService)
        {
            this.employeesApplicationService = employeesApplicationService;
        }

        [HttpGet("[action]")]
        public List<Employee> GetEmployees(int? id)
        {
            return employeesApplicationService.GetEmployees(id);
        }
    }
}
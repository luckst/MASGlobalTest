using MasGlobal.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Test.Application.Services
{
    public interface IEmployeesApplicationService
    {
        List<Employee> GetEmployees(int? id);
    }
}

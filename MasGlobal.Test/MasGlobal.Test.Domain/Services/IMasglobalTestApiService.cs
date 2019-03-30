using MasGlobal.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Test.Domain.Services
{
    public interface IMasglobalTestApiService
    {
        List<Employee> GetEmployees(int? id);
    }
}

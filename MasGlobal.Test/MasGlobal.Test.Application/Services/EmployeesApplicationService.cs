using System;
using System.Collections.Generic;
using System.Text;
using MasGlobal.Test.Domain.Entities;
using MasGlobal.Test.Domain.Services;

namespace MasGlobal.Test.Application.Services
{
    public class EmployeesApplicationService : IEmployeesApplicationService
    {
        IMasglobalTestApiService masglobalTestApiService;

        public EmployeesApplicationService(IMasglobalTestApiService masglobalTestApiService)
        {
            this.masglobalTestApiService = masglobalTestApiService;
        }

        public List<Employee> GetEmployees(int? id)
        {
            try
            {
                return masglobalTestApiService.GetEmployees(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

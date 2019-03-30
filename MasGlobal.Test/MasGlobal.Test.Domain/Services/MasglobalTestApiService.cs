using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasGlobal.Test.Domain.Entities;
using MasGlobal.Test.Domain.Factory;
using MasGlobal.Test.Infrastructure.Framework.Utilities;
using Microsoft.Extensions.Configuration;

namespace MasGlobal.Test.Domain.Services
{
    public class MasglobalTestApiService : IMasglobalTestApiService
    {
        EmployeeFactory employeeFactory;
        IConfigurationRoot configuration;

        public MasglobalTestApiService(IConfigurationRoot configuration)
        {
            this.employeeFactory = new EmployeeFactory();
            this.configuration = configuration;
        }

        public List<Employee> GetEmployees(int? id)
        {
            var employees = new List<Employee>();
            var employeesDynamic = ServiceUtility<dynamic>.HttpGet(configuration["ApiServiceURL"]);

            foreach (var item in employeesDynamic)
            {
                Employee employee = employeeFactory.GetEmployee(item.contractTypeName.ToString());

                employee.Id = Convert.ToInt32(item.id);
                employee.Name = item.name.ToString();
                employee.ContractTypeName = item.contractTypeName.ToString();
                employee.Role = new Role(Convert.ToInt32(item.roleId), item.roleName.ToString(), string.Empty);
                employee.HourlySalary = Convert.ToDecimal(item.hourlySalary);
                employee.MonthlySalary = Convert.ToDecimal(item.monthlySalary);
                employees.Add(employee);
            }

            return employees.Where(e=> !id.HasValue || e.Id == id).ToList();
        }
    }
}

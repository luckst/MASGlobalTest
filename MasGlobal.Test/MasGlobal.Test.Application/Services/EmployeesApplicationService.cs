using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasGlobal.Test.Domain.Entities;
using MasGlobal.Test.Domain.Factory;
using MasGlobal.Test.Domain.Services;
using MasGlobal.Test.Infrastructure.Framework.RepositoryPattern;

namespace MasGlobal.Test.Application.Services
{
    public class EmployeesApplicationService : IEmployeesApplicationService
    {
        IMasglobalTestApiService masglobalTestApiService;
        IRepository<EmployeeDTO> repositoryEmployee;
        EmployeeFactory employeeFactory;

        public EmployeesApplicationService(IMasglobalTestApiService masglobalTestApiService, IRepository<EmployeeDTO> repositoryEmployee)
        {
            this.masglobalTestApiService = masglobalTestApiService;
            this.repositoryEmployee = repositoryEmployee;
            this.employeeFactory = new EmployeeFactory();
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

        public List<Employee> GetEmployeesFromDB(int? id)
        {
            try
            {
                var employees = new List<Employee>();
                var employeesDto = repositoryEmployee.GetAll();
                foreach (var item in employeesDto)
                {
                    Employee employee = employeeFactory.GetEmployee(item.ContractTypeName.ToString());

                    employee.Id = Convert.ToInt32(item.Id);
                    employee.Name = item.Name.ToString();
                    employee.ContractTypeName = item.ContractTypeName.ToString();
                    employee.Role = new Role(Convert.ToInt32(item.RoleId), item.RoleName.ToString(), string.Empty);
                    employee.HourlySalary = Convert.ToDecimal(item.HourlySalary);
                    employee.MonthlySalary = Convert.ToDecimal(item.MonthlySalary);
                    employees.Add(employee);
                }

                return employees.Where(e => !id.HasValue || e.Id == id).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

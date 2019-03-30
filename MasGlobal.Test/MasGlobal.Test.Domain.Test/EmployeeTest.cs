namespace MasGlobal.Test.Domain.Test
{
    using MasGlobal.Test.Domain.Entities;
    using MasGlobal.Test.Domain.Factory;
    using MasGlobal.Test.Domain.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EmployeeTest
    {
        private EmployeeFactory employeeFactory;

        public EmployeeTest()
        {
            employeeFactory = new EmployeeFactory();
        }

        [TestMethod]
        public void MonthlyEmployee()
        {
            Employee employee = employeeFactory.GetEmployee("MonthlySalaryEmployee");
            employee.ContractTypeName = "MonthlySalaryEmployee";
            employee.HourlySalary = 200;
            employee.Id = 1;
            employee.MonthlySalary = 1000;
            employee.Role = new Role() { Id = 1, Name = "Administrator" };

            Assert.AreEqual(employee.Salary, 12000m);
        }

        [TestMethod]
        public void HourlyEmployee()
        {
            Employee employee = employeeFactory.GetEmployee("HourlySalaryEmployee");
            employee.ContractTypeName = "HourlySalaryEmployee";
            employee.HourlySalary = 200;
            employee.Id = 2;
            employee.MonthlySalary = 1000;
            employee.Role = new Role() { Id = 2, Name = "Contractor" };

            Assert.AreEqual(employee.Salary, 288000m);
        }

        
    }
}

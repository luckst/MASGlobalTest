using MasGlobal.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Test.Domain.Factory
{
    public class EmployeeFactory
    {
        public Employee GetEmployee(string contractType)
        {
            switch (contractType)
            {
                case "MonthlySalaryEmployee":
                    return new MonthlyEmployee();
                case "HourlySalaryEmployee":
                    return new HourlyEmployee();
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Test.Domain.Entities
{
    public class MonthlyEmployee : Employee
    {
        public override decimal CalculateSalary()
        {
            return MonthlySalary * 12;
        }
    }
}

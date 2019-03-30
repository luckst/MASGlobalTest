using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Test.Domain.Entities
{
    public class HourlyEmployee : Employee
    {
        public override decimal CalculateSalary()
        {
            return 120 * this.HourlySalary * 12;
        }
    }
}

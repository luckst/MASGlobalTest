using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Test.Domain.Entities
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public Role Role { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal Salary
        {
            get
            {
                return CalculateSalary();
            }
        }

        public virtual decimal CalculateSalary()
        {
            return 0;
        }
    }
}

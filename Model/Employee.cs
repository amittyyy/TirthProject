using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public abstract class Employee
    {
        //internal readonly object grossEarning;
        //internal readonly object netEarning;
        //internal readonly object tax;

        public int ID { get; set; }
        public string? Name { get; set; }

        public EmployeeType EmpType { get; set; }

        public abstract decimal GrossEarning { get; }
        public decimal Tax => GrossEarning * 0.2M;
        public decimal NetEarning => GrossEarning - Tax;
    }

    public class HourlyEmployee : Employee
    {
        public decimal HourlyWage { get; set; }
        public decimal HoursWorked { get; set; }

        // Override GrossEarnings property
        public override decimal GrossEarning
        {
            get
            {
                if (HoursWorked <= 40)
                    return HoursWorked * HourlyWage;
                else
                    return 40 * HourlyWage + (HoursWorked - 40) * HourlyWage * 1.5m;
            }
        }
    }

    public class CommissionEmployee : Employee
    {
        public decimal GrossSales { get; set; }
        public decimal CommissionRate { get; set; }

        public override decimal GrossEarning => GrossSales * CommissionRate;
    }

    public class SalariedEmployee : Employee
    {
        public decimal WeeklySalary { get; set; }

        public override decimal GrossEarning => WeeklySalary;
    }

    public enum EmployeeType
    {
        HourlyEmployee,
        CommissionEmployee,
        SalariedEmployee,
    }
}
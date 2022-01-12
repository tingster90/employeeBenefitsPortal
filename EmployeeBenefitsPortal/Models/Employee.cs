using System.Collections.Generic;

namespace EmployeeBenefitsPortal.Models
{
    public class Employee : Person
    {
        public Employee()
        {
            GrossPayPerPaycheck = Constants.BASE_PAYCHECK;
        }

        public List<Dependent> Dependents { get; set; }

        public decimal GrossPayPerPaycheck { get; set; }

        public override decimal GetBenefitCost()
        {
            return Constants.EMPLOYEE_ANNUAL_BENEFIT_COST;
        }
    }
}



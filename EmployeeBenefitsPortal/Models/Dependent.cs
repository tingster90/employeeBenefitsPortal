using System;

namespace EmployeeBenefitsPortal.Models
{
    public class Dependent : Person
    {
        public enum DependentType
        {
            Child,
            Spouse
        }

        public DependentType Type { get; set; }

        public override decimal GetBenefitCost()
        {
            return Constants.DEPENDENT_ANNUAL_BENEFIT_COST;
        }
    }
}

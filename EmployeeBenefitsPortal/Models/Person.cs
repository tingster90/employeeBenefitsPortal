using System;

namespace EmployeeBenefitsPortal.Models
{
    public class Person
    {
        protected decimal _baseBenefitCost;

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual decimal GetBenefitCost()
        {
            return _baseBenefitCost;
        }
    }
}

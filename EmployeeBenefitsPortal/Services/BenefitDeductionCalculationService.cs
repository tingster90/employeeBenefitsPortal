using EmployeeBenefitsPortal.Interfaces;
using EmployeeBenefitsPortal.Models;

namespace EmployeeBenefitsPortal.Services
{
    public class BenefitDeductionCalculationService : IBenefitDeductionCalculationService
    {
        public BenefitDeductionCalculationService()
        {
        }

        public decimal GetAnnualDeduction(Employee employee)
        {
            decimal sumOfDependentsDeduction = 0.0M;
            var employeeDeduction = employee.GetBenefitCost() * (1 - GetBenefitDiscountRateByName(employee.FirstName, employee.LastName));

            if (employee.Dependents != null && employee.Dependents.Count > 0)
            {
                foreach (var dependent in employee.Dependents)
                {
                    var dependentDeduction = dependent.GetBenefitCost() * (1 - GetBenefitDiscountRateByName(dependent.FirstName, dependent.LastName));
                    sumOfDependentsDeduction += dependentDeduction;
                }
            }

            return employeeDeduction + sumOfDependentsDeduction;
        }

        public decimal GetDeductionPerPaycheck(Employee employee)
        {
            return GetAnnualDeduction(employee) / Constants.NUM_OF_PAYCHECK_PER_YEAR;
        }

        public decimal GetBenefitDiscountRateByName(string firstName, string lastName)
        {
            if (firstName.ToLower().StartsWith(Constants.NAME_DISCOUNT_RULE) || lastName.ToLower().StartsWith(Constants.NAME_DISCOUNT_RULE))
            {
                return Constants.NAME_DISCOUNT;
            }

            return 0;
        }
    }
}

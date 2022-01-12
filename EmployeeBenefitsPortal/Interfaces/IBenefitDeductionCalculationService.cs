using EmployeeBenefitsPortal.Models;

namespace EmployeeBenefitsPortal.Interfaces
{
    public interface IBenefitDeductionCalculationService
    {
        decimal GetDeductionPerPaycheck(Employee employee);
        decimal GetAnnualDeduction(Employee employee);
        decimal GetBenefitDiscountRateByName(string firstName, string lastNlame);
    }
}

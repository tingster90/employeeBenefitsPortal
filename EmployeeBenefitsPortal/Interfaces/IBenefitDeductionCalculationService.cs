using EmployeeBenefitsPortal.Models;

namespace EmployeeBenefitsPortal.Interfaces
{
    public interface IBenefitDeductionCalculationService
    {
        /// <summary>
        /// Get the benefit deduction per paycheck
        /// </summary>
        /// <param name="employee">The employee to calculate the deduction for</param>
        /// <returns>The benefit deduction per paycheck</returns>
        decimal GetDeductionPerPaycheck(Employee employee);

        /// <summary>
        /// Get the benefit deduction per year
        /// </summary>
        /// <param name="employee">The employee to calculate the deduction for<</param>
        /// <returns>The benefit deduction per year</returns>
        decimal GetAnnualDeduction(Employee employee);

        /// <summary>
        /// Get the discount rate based on name (first or last)
        /// </summary>
        /// <remarks>
        /// If the person's first name or last name starts with the letter "a", apply 10% discount
        /// </remarks>
        /// <param name="firstName">First name</param>
        /// <param name="lastNlame">Last name</param>
        /// <returns>The discount rate based on the name</returns>
        decimal GetBenefitDiscountRateByName(string firstName, string lastNlame);

        /// <summary>
        /// Get the take home amount per paycheck after the benefit deduction
        /// </summary>
        /// <param name="grossPay">The base salary pay - $2000 per paycheck</param>
        /// <param name="deduction">The benefit deduction per paycheck</param>
        /// <returns>The take home pay amount</returns>
        decimal GetTakeHomePayPerPaycheck(decimal grossPay, decimal deduction);
    }
}

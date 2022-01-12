using System;

namespace EmployeeBenefitsPortal.Models
{
    public class BenefitOverviewDto
    {
        public Guid EmployeeId { get; set; }

        public decimal GrossPayPerPaycheck { get; set; }

        public decimal TakeHomePayPerPaycheck { get; set; }

        public decimal AnnualDeductionCost { get; set; }
        
        public decimal DeductionPerPaycheck { get; set; }
    }
}

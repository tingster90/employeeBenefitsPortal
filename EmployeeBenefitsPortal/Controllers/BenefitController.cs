using System;
using System.Threading.Tasks;
using EmployeeBenefitsPortal.Interfaces;
using EmployeeBenefitsPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BenefitController : ControllerBase
    {
        private readonly IBenefitDeductionCalculationService benefitDeductionCalculationService;
        private readonly IEmployeeService employeeService;

        public BenefitController(IBenefitDeductionCalculationService benefitDeductionCalculationService, IEmployeeService employeeService)
        {
            this.benefitDeductionCalculationService = benefitDeductionCalculationService;
            this.employeeService = employeeService;
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<BenefitOverviewDto>> Get(Guid employeeId)
        {
            var employee = await employeeService.GetEmployee(employeeId);
            var deductionPerPaycheck = benefitDeductionCalculationService.GetDeductionPerPaycheck(employee);

            BenefitOverviewDto benefitOverview = new BenefitOverviewDto
            {
                EmployeeId = employee.Id,
                GrossPayPerPaycheck = employee.GrossPayPerPaycheck,
                DeductionPerPaycheck = deductionPerPaycheck,
                TakeHomePayPerPaycheck = benefitDeductionCalculationService.GetTakeHomePayPerPaycheck(employee.GrossPayPerPaycheck, deductionPerPaycheck),
                AnnualDeductionCost = benefitDeductionCalculationService.GetAnnualDeduction(employee),
            };

            return Ok(benefitOverview);
        }
    }
}

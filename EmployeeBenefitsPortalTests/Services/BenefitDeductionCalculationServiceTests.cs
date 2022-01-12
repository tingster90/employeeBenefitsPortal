using EmployeeBenefitsPortal;
using EmployeeBenefitsPortal.Interfaces;
using EmployeeBenefitsPortal.Models;
using EmployeeBenefitsPortal.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace EmployeeBenefitsPortalTests.Services
{
    public class BenefitDeductionCalculationServiceTests
    {
        private readonly IBenefitDeductionCalculationService service;

        public BenefitDeductionCalculationServiceTests()
        {
            service = new BenefitDeductionCalculationService();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldCalculateAnnualDeduction()
        {
            var employee = CreateEmployeeWithSpouseAndChild();
            var expectedAnnualDeduction = Constants.EMPLOYEE_ANNUAL_BENEFIT_COST + Constants.DEPENDENT_ANNUAL_BENEFIT_COST * 2;
            var actualAnnualDeduction = service.GetAnnualDeduction(employee);
            Assert.AreEqual(expectedAnnualDeduction, actualAnnualDeduction);

        }

        [Test]
        public void ShouldCalculateAnnualDeductionWithDiscount()
        {
            var employee = CreateEmployeeWithDiscountEligibility();
            var expectedAnnualDeduction = Constants.EMPLOYEE_ANNUAL_BENEFIT_COST * (1 - Constants.NAME_DISCOUNT);
            var actualAnnualDeduction = service.GetAnnualDeduction(employee);
            Assert.AreEqual(expectedAnnualDeduction, actualAnnualDeduction);

        }

        [Test]
        public void ShouldCaculateDeductionPerPaycheck()
        {
            var employee = CreateEmployeeWithSpouseAndChild();
            var expectedDeductionPeyPaycheck = (Constants.EMPLOYEE_ANNUAL_BENEFIT_COST + Constants.DEPENDENT_ANNUAL_BENEFIT_COST * 2) / Constants.NUM_OF_PAYCHECK_PER_YEAR;
            var actualDeductionPerPaycheck = service.GetDeductionPerPaycheck(employee);
            Assert.AreEqual(expectedDeductionPeyPaycheck, actualDeductionPerPaycheck);
        }

        [Test]
        public void ShouldCaculateDeductionPerPaycheckWithDiscount()
        {
            var employee = CreateEmployeeWithDiscountEligibility();
            var expectedDeductionPeyPaycheck = (Constants.EMPLOYEE_ANNUAL_BENEFIT_COST * (1 - Constants.NAME_DISCOUNT)) / Constants.NUM_OF_PAYCHECK_PER_YEAR;
            var actualDeductionPerPaycheck = service.GetDeductionPerPaycheck(employee);
            Assert.AreEqual(expectedDeductionPeyPaycheck, actualDeductionPerPaycheck);
        }

        [Test]
        public void ShouldDiscountForFirstNameThatStartsWithA()
        {
            var employee = new Employee()
            {
                FirstName = "Adam",
                LastName = "Doe"
            };

            var discount = service.GetBenefitDiscountRateByName(employee.FirstName, employee.LastName);

            Assert.AreEqual(discount, Constants.NAME_DISCOUNT);
        }

        [Test]
        public void ShouldCalculateTakeHomePayPerPaycheck()
        {
            decimal grossPay = Constants.BASE_PAYCHECK;
            decimal deduction = 100.0M;

            decimal actualTakeHomePay = service.GetTakeHomePayPerPaycheck(grossPay, deduction);

            Assert.AreEqual((grossPay - deduction), actualTakeHomePay);
        }

        [Test]
        public void ShouldDiscountForLastNameThatStartsWithA()
        {
            var employee = CreateEmployeeWithDiscountEligibility();

            var discount = service.GetBenefitDiscountRateByName(employee.FirstName, employee.LastName);

            Assert.AreEqual(discount, Constants.NAME_DISCOUNT);
        }

        [Test]
        public void ShouldNotDiscountIfFirstAndLastNameDoesNotStartWithA()
        {
            var employee = new Employee()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var discount = service.GetBenefitDiscountRateByName(employee.FirstName, employee.LastName);

            Assert.AreEqual(discount, 0);
        }

        private Employee CreateEmployeeWithSpouseAndChild()
        {
            return new Employee()
            { 
                FirstName = "John",
                LastName = "Doe",
                Dependents = new List<Dependent>()
                { 
                    new Dependent()
                    { 
                        FirstName = "Jane",
                        LastName = "Doe",
                        Type = Dependent.DependentType.Spouse
                    },
                    new Dependent()
                    {
                        FirstName = "Baby",
                        LastName = "Doe",
                        Type = Dependent.DependentType.Child
                    }
                }
            };
        }

        private Employee CreateEmployeeWithDiscountEligibility()
        {
            return new Employee()
            {
                FirstName = "Adam",
                LastName = "Doe"
            };
        }

    }
}

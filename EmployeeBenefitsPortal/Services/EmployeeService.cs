using EmployeeBenefitsPortal.Interfaces;
using EmployeeBenefitsPortal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeBenefitsPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddEmployee(Employee employee)
        {
            repository.AddEmployee(employee);
            await repository.Save();
        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            await repository.DeleteEmployee(employeeId);
            await repository.Save();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await repository.GetAllEmployeesAndDependents();
        }

        public async Task<Employee> GetEmployee(Guid employeeId)
        {
            var employee = await repository.GetEmployeeById(employeeId);
            return employee;
        }
    }
}

using EmployeeBenefitsPortal.Interfaces;
using EmployeeBenefitsPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeBenefitsPortal.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeBenefitsPortalContext context;

        public EmployeeRepository(EmployeeBenefitsPortalContext context)
        {
            this.context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAndDependents()
        {
            return await context.Employees
                .Include(e => e.Dependents)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId)
        {
            return await context.Employees
                .Include(e => e.Dependents)
                .SingleOrDefaultAsync(e => e.Id == employeeId);
        }

        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            Employee employee = await GetEmployeeById(employeeId);
            context.Employees.Remove(employee);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}

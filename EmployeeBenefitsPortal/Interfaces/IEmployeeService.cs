using EmployeeBenefitsPortal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeBenefitsPortal.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(Guid employeeId);
        Task<List<Employee>> GetAllEmployees();
        Task AddEmployee(Employee employee);
        Task DeleteEmployee(Guid employeeId);
    }
}

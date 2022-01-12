using EmployeeBenefitsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeBenefitsPortal.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(Guid employeeId);
        Task<List<Employee>> GetAllEmployeesAndDependents();
        void AddEmployee(Employee employee);
        Task DeleteEmployee(Guid employeeId);
        Task Save();
    }
}

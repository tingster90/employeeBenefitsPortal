using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeBenefitsPortal.Interfaces;
using EmployeeBenefitsPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> Get(Guid employeeId)
        {
            var employee = await employeeService.GetEmployee(employeeId);

            if (employee == null)
            {
                // Intentionally returning generic bad request response instead of NotFound to protect employee data
                return BadRequest($"Employee not found with ID: {employeeId}");
            }

            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var result = await employeeService.GetAllEmployees();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            await employeeService.AddEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteTodoItem(Guid employeeId)
        {
            await employeeService.DeleteEmployee(employeeId);
            return NoContent();
        }
    }
}
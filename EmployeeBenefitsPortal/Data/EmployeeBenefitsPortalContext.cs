using EmployeeBenefitsPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitsPortal.Data
{
    public class EmployeeBenefitsPortalContext : DbContext
    {
        public EmployeeBenefitsPortalContext(DbContextOptions<EmployeeBenefitsPortalContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}

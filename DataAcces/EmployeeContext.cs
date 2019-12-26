
using System.Data.Entity;


namespace DataAcces
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeDB")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Pasport> Pasports { get; set; }
    }
}

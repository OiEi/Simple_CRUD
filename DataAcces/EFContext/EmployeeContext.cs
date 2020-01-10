using System.Data.Entity;

namespace DataAcces
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Pasport> Pasports { get; set; }
    
        static EmployeeContext()
        {
            Database.SetInitializer<EmployeeContext>(new MyDBInitializer());
        }
        public EmployeeContext(string connectionString) : base (connectionString)
        {

        }
    }
}



using DataAcces.Repositories;
using System;

namespace DataAcces.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeContext db;
        private EmployeeRepository employeeRepo;
        private CompanyRepository companyRepo;

        public UnitOfWork(string connectionString)
        {
            db = new EmployeeContext(connectionString);
        }
        
        public IEmplRepository<Employee> Employees
        {
            get
            {
                if (employeeRepo == null)
                    employeeRepo = new EmployeeRepository(db);
                return employeeRepo;
            }
        }
        public ICompanyRepository<Company> Companies
        {
            get
            {
                if (companyRepo == null)
                    companyRepo = new CompanyRepository(db);
                return companyRepo;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;


namespace DataAcces
{
    public class UnitOfWork : IDisposable
    {
        private EmployeeContext db = new EmployeeContext();
        private EmployeeRepo employeeRepo;
        private CompanyRepo companyRepo;

        public EmployeeRepo Employees
        {
            get
            {
                if (employeeRepo == null)
                    employeeRepo = new EmployeeRepo(db);
                return employeeRepo;
            }
        }
        public CompanyRepo Companies
        {
            get
            {
                if (companyRepo == null)
                    companyRepo = new CompanyRepo(db);
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

using System.Collections.Generic;
using System.Data.Entity;


namespace DataAcces
{
    public class EmployeeRepo : IEmplRepository<Employee>
    {
        private EmployeeContext db;

        public EmployeeRepo(EmployeeContext context)
        {
            this.db = context;
        }


        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
                db.Employees.Remove(employee);
        }
    }

          
    public class CompanyRepo : ICompanyRepository<Employee>
    {
        private EmployeeContext db;

        public CompanyRepo(EmployeeContext context)
        {
            this.db = context;
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public IEnumerable<Employee> GetAllEmplFromCompany(int companyid)
        {
            return db.Employees;
        }

    }
}



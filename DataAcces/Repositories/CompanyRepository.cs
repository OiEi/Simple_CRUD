using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    
    public class CompanyRepository : ICompanyRepository<Company>
    {
        private EmployeeContext db;

        public CompanyRepository(EmployeeContext context)
        {
            this.db = context;
        }

        public void Create(Company company)
        {
            db.Companies.Add(company);
        }

        public IEnumerable<Company> GetAllEmplFromCompany(int companyid)
        {
            return db.Companies;
        }

    }
}

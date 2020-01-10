using DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_CRUD.DTO
{
    public class CompanyDTO
    {
        public int Companyid { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
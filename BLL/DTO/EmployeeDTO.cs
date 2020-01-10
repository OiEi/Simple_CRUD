using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_CRUD.DTO
{
    public class EmployeeDTO
    {
        
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public int? CompanyId { get; set; }
    }
}
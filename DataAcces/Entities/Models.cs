using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcces
{ 
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }

        [JsonIgnore]
        public Company Company { get; set; }

        [ForeignKey("Pasport")]
        public int? PasportId { get; set; }
        
        [JsonIgnore]
        public Pasport Pasport { get; set; }
    }
    public class Company
    {
        [Key]
        public int Companyid { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
    public class Pasport
    {
        [Key]
        public int Pasportid { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}
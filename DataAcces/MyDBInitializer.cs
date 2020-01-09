using System.Collections.Generic;
using System.Data.Entity;

namespace DataAcces
{
    public class MyDBInitializer : CreateDatabaseIfNotExists<EmployeeContext>
    {
        protected override void Seed(EmployeeContext context)
        {
            Company c1 = new Company();
            Company c2 = new Company();
            context.Companies.Add(c1);
            context.Companies.Add(c2);
            context.SaveChanges();
            Pasport p1 = new Pasport { Type = "RU", Number = "456" };
            Pasport p2 = new Pasport { Type = "ENG", Number = "987" };
            Pasport p3 = new Pasport { Type = "RU", Number = "123" };
            context.Pasports.Add(p1);
            context.Pasports.Add(p2);
            context.Pasports.Add(p3);
            Employee empl1 = new Employee { Name = "Роналду", Surname = "Иванов", Phone = "987456321", Pasport = p1, Company = c1 };
            Employee empl2 = new Employee { Name = "Petia", Surname = "Tarashkevich", Phone = "9876544896", Pasport = p2, Company = c1 };
            Employee empl3 = new Employee { Name = "Zina", Surname = "Kuzina", Phone = "34521564562", Pasport = p3, Company = c2 };
            context.Employees.AddRange(new List<Employee> { empl1, empl2, empl3 });
            
            base.Seed(context);
        }
    }
}

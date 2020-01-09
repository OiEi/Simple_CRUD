using DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Simple_CRUD.Controllers
{
    [RoutePrefix("v1")]
    public class EmployeeController : ApiController
    {
        /*        //Создание тестовых таблиц
                [Route("api/createdata")]
                public void Post()
                {
                    using (EmployeeContext db = new EmployeeContext())
                    {
                        Company c1 = new Company();
                        Company c2 = new Company();
                        db.Companies.Add(c1);
                        db.Companies.Add(c2);
                        db.SaveChanges();
                        Pasport p1 = new Pasport { Type = "RU", Number = "456" };
                        Pasport p2 = new Pasport { Type = "ENG", Number = "987" };
                        Pasport p3 = new Pasport { Type = "RU", Number = "123" };
                        db.Pasports.Add(p1);
                        db.Pasports.Add(p2);
                        db.Pasports.Add(p3);
                        Employee empl1 = new Employee { Name = "Роналду", Surname = "Иванов", Phone = "987456321", Pasport = p1, Company = c1 };
                        Employee empl2 = new Employee { Name = "Petia", Surname = "Tarashkevich", Phone = "9876544896", Pasport = p2, Company = c1 };
                        Employee empl3 = new Employee { Name = "Zina", Surname = "Kuzina", Phone = "34521564562", Pasport = p3, Company = c2 };
                        db.Employees.AddRange(new List<Employee> { empl1, empl2, empl3 });
                        db.SaveChanges();
                    }
                }*/

        [Route("api/get_all_empl")]
        public IEnumerable<Employee> Get()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        [Route("api/get_empl_from_companies/{companyid}")]
        public IEnumerable<Employee> Get(int companyid)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employees = db.Employees.Where(e => e.CompanyId == companyid);

                return employees.ToList();
            }
        }

        [Route("api/create_empl")]
        public void Post([FromBody]Employee employee)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        [Route("api/create_pasports")]
        public void Post([FromBody]Pasport pasport)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Pasports.Add(pasport);
                db.SaveChanges();
            }
        }

        [Route("api/create_companies")]
        public void Post([FromBody]Company company)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
        }
               
        //Тут я конечно не допилил. Метод работает, но с огрехами
        [Route("api/edit_empl/{Id}")]
        public HttpResponseMessage Put(int id, [FromBody]Employee employee)
        {
            try
            {
                using (EmployeeContext db = new EmployeeContext())
                {
                    var editempl = db.Employees.FirstOrDefault(e => e.id == id);

                    if (editempl == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id = {id} not found to update");
                    }
                    else
                    {
                        editempl.Name = employee.Name ?? editempl.Name; ;
                        editempl.Surname = employee.Surname ?? editempl.Surname;
                        editempl.Phone = employee.Phone ?? editempl.Phone;
                        editempl.CompanyId = employee.CompanyId ?? editempl.CompanyId;
                        editempl.PasportId = employee.PasportId ?? editempl.PasportId;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, editempl);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("api/delete_empl/{Id}")]
        public HttpResponseMessage Delete(int Id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employee = db.Employees.FirstOrDefault(e => e.id == Id);
                if (employee == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id {Id} not found");
                }
                else
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, $"Employee with id {Id} was remove");
                }
            }
        }
    }
}





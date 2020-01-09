
using DataAcces;
using System.Collections.Generic;

using System.Web.Http;

namespace Simple_CRUD.Controllers
{
    [RoutePrefix("v2")]
    public class Employee2Controller : ApiController
    {
        UnitOfWork unitOfWork;
        public Employee2Controller()
        {
            unitOfWork = new UnitOfWork();
        }

        [Route("api/test")]
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            {
                var Employees = unitOfWork.Employees.GetAll();
                return Employees;
            }
        }
    }
}

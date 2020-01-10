
using DataAcces;
using System.Collections.Generic;

using System.Web.Http;

namespace Simple_CRUD.Controllers
{
    [RoutePrefix("v2")]
    public class Employee2Controller : ApiController
    {
        UnitOfWork1 _unitOfWork;
        public Employee2Controller()
        {
            _unitOfWork = new UnitOfWork1();
        }

        [Route("api/test")]
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            {
                var Employees = _unitOfWork.Employees.GetAll();
                return Employees;
            }
        }
    }
}

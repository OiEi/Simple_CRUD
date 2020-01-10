using Simple_CRUD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO GetEmployee(int? id);
        IEnumerable<EmployeeDTO> GetAllEmployees();
        void Dispose();
    }
}

using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using DataAcces;
using DataAcces.Interfaces;
using Simple_CRUD.DTO;
using System.Collections.Generic;


namespace BLL.Services
{
    class EmployeeService : IEmployeeService
    {
        IUnitOfWork Database { get; set; }
        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }
    
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }

        public EmployeeDTO GetEmployee(int? id)
        {
            if (id == null)
                throw new ValidationException("не установлено id сотрудника", "");
            var employee = Database.Employees.Get(id.Value);
            if (employee == null)
                throw new ValidationException("Сотрудник не найден", "");
            return new EmployeeDTO { id = employee.id, Name = employee.Name, Surname = employee.Surname, Phone = employee.Surname, CompanyId = employee.CompanyId };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
               
    }
}

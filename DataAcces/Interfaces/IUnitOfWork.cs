using System;


namespace DataAcces.Interfaces
{
    public interface IUnitOfWork : IDisposable

    {
        IEmplRepository<Employee> Employees { get; }
        ICompanyRepository<Company> Companies { get; }
        void Save();
    }
}

using System.Collections.Generic;


namespace DataAcces
{
    public interface IEmplRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public interface ICompanyRepository<T> where T : class
    {
        void Create(T item);
        IEnumerable<T> GetAllEmplFromCompany(int companyid);
    }   




}



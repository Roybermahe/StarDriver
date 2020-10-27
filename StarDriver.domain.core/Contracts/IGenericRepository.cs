using System.Collections.Generic;
using StarDriver.domain.core.Base;

namespace StarDriver.domain.core.Contracts
{
    public interface IRepository
    {
    }
    
    public interface IGenericRepository<T> : IRepository
    {
        T Find(object id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void AddRange(List<T> entities);
        void DeleteRange(List<T> entities);
        IEnumerable<T> GetAll();
    }
}
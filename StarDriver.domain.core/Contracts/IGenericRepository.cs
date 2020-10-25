using System.Collections.Generic;

namespace StarDriver.domain.core.Contracts
{
    public interface IGenericRepository<T>
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
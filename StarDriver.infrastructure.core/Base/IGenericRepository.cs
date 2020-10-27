using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Contracts;

namespace StarDriver.infrastructure.core.Base
{
    public abstract  class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private IDbContext _dbContext;
        private readonly DbSet<T> _dbset;

        protected GenericRepository(IDbContext context)
        {
            _dbContext = context;
            _dbset = context.Set<T>();
        }

        public T Find(object id)
        {
            return _dbset.Find(id);
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Edit(T entity)
        {
            _dbset.Update(entity);
        }

        public void AddRange(List<T> entities)
        {
            _dbset.AddRange(entities);
        }

        public void DeleteRange(List<T> entities)
        {
           _dbset.RemoveRange(entities);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using StarDriver.domain.core.Contracts;

namespace StarDriver.infrastructure.core.Base
{
    public class UnitOfWork : UnitRepos, IUnitOfWork
    {
        public UnitOfWork(IDbContext context)
        {
           DbContext = context;
        }
        
        public int Commit()
        {
            return DbContext.SaveChanges();
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing || DbContext == null) return;
            ((DbContext)DbContext).Dispose();
            DbContext = null;
        }
    }
}
using System;
using Roteirizador.Data.Context;

namespace Roteirizador.Domain.Core.Repositories
{
    public abstract class RepositoryBase : IRepository
    {
        protected readonly RouterDbContext _context;

        public RepositoryBase(RouterDbContext context)
        {
            _context = context;
        }
        
        #region IDisposable
        
        private bool disposed;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
                _context.Dispose();
            this.disposed = true;
        }

        #endregion
    }
}
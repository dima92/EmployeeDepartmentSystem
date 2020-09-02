using Dal.Core.Dal_Core.Interface;
using Dal.Core.EF;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal.Core.Dal_Core.Repository
{
    public class DbFactory : Disposable, IDbFactory
    {
        ApplicationContext _dbContext;
        public ApplicationContext Init()
        {
            return _dbContext ??= new ApplicationContext(new DbContextOptions<ApplicationContext>());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }

    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}

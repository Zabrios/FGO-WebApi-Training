using FGO.WebApi.Persistence.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;
using FGO.WebApi.Persistence.Context;

namespace FGO.WebApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IFGOContext Context;
        private bool _disposed;

        public UnitOfWork(IFGOContext context)
        {
            Context = context;
        }
        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.Instance.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Instance.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

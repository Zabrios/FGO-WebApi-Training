using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FGO.WebApi.Persistence.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}

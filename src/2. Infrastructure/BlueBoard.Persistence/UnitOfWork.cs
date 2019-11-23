using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using BlueBoard.Persistence.Abstractions;

namespace BlueBoard.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction transaction;

        public IDataContext Context { get; set; }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Abstractions
{
    public interface IUnitOfWork
    {
        IDataContext Context { get; set; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}

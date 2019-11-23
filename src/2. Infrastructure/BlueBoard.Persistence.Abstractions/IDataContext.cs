using System;
using System.Data;

namespace BlueBoard.Persistence.Abstractions
{
    public interface IDataContext : IDisposable
    {
        T GetConnection<T>()
            where T : class, IDbConnection;
    }
}

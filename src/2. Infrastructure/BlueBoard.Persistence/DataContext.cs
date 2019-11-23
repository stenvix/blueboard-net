using System;
using System.Data;
using BlueBoard.Persistence.Abstractions;
using Dawn;

namespace BlueBoard.Persistence
{
    public class DataContext : IDataContext
    {
        protected readonly IDbConnection Connection;

        public DataContext(IDbConnection connection)
        {
            Guard.Argument(connection).NotNull();

            this.Connection = connection;
        }

        public T GetConnection<T>()
            where T : class, IDbConnection
        {
            Guard.Argument(this.Connection).NotNull();
            return this.Connection as T;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.Connection?.Dispose();
        }
    }
}

using System;
using System.Data;

using BlueBoard.Persistence.Abstractions;

using Dawn;

namespace BlueBoard.Persistence
{
    public class TransactionalDataContext : DataContext, ITransactionalDataContext
    {
        private IDbTransaction transaction;

        public TransactionalDataContext(IDbConnection connection)
            : base(connection)
        {
        }

        public void CreateTransaction()
        {
            if (this.transaction == null)
            {
                this.transaction = this.Connection.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            Guard.Argument(this.transaction).NotNull();
            this.transaction.Commit();
        }

        public void RollbackTransaction()
        {
            Guard.Argument(this.transaction).NotNull();
            this.transaction.Rollback();
        }
    }
}

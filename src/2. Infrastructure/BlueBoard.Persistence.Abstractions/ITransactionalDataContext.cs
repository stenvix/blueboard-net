namespace BlueBoard.Persistence.Abstractions
{
    public interface ITransactionalDataContext : IDataContext
    {
        void CreateTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}

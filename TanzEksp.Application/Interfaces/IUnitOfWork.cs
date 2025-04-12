namespace TanzEksp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void BeginTransaction(System.Data.IsolationLevel isolationLevel);
    }
}

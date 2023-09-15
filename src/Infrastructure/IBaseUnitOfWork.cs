namespace Infrastructure
{
    public interface IBaseUnitOfWork
    {
        Task Commit();
        void Rollback();
    }
}

namespace Domain.SeedWork
{
    public interface IBaseUnitOfWork
    {
        Task Commit();
        void Rollback();
    }
}

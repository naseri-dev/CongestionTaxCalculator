using System.Linq.Expressions;

namespace Domain.SeedWork
{
    public interface IReadRepository<T> where T : class
    {
        IQueryable<T> Get(
          Expression<Func<T, bool>> filter = null,
          bool deleted = false,
          List<string> orderByFields = null,
          List<bool> orderByDescs = null,
          int pageIndex = 0,
          int pageSize = 0,
          List<string> includes = null);

        T Get(long id);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);

        bool Any(Expression<Func<T, bool>> filter);

        Task<long> CountAsync(Expression<Func<T, bool>> filter = null, bool deleted = false);

        long Count(Expression<Func<T, bool>> filter = null, bool deleted = false);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        T FirstOrDefault();
    }
}

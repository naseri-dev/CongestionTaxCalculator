using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Domain.SeedWork
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(
          Expression<Func<T, bool>> filter = null,
          List<string> orderByFields = null,
          List<bool> orderByDescs = null,
          int pageIndex = 0,
          int pageSize = 0,
          List<string> includes = null);

        T Get(long id);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);

        bool Any(Expression<Func<T, bool>> filter);

        Task<long> CountAsync(Expression<Func<T, bool>> filter = null);

        long Count(Expression<Func<T, bool>> filter = null);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        T FirstOrDefault();

        void Add(T entity);

        Task<EntityEntry<T>> AddAsync(T entity);

        void AddRange(IEnumerable<T> entites);

        Task AddRangeAsync(IEnumerable<T> entites);

        void SoftRemove(T entity);

        void SoftRemoveRangeEntities(List<T> entitiesToUpdate);

        void RemoveById(object Id);

        void SoftRemoveById(object Id);

        void RemoveRange(IEnumerable<T> entities);

        Task RemoveEntityAsync(T entityToDelete = null, Expression<Func<T, bool>> filter = null);

        void RemoveEntity(T entityToDelete = null, Expression<Func<T, bool>> filter = null);

        void UpdateEntity(T entityToUpdate, params string[] fields);

        void UpdateRangeEntities(List<T> entitiesToUpdate, params string[] fields);
    }
}

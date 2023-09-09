using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Infrastructure
{
    public abstract class BaseGenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private IQueryable<T> query;

        public DbContext _dbContext { get; set; }

        protected BaseGenericRepository(DbContext dbContext) => _dbContext = dbContext;

        public void Add(T entity) => _dbContext.Set<T>().Add(entity);

        public async Task<EntityEntry<T>> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await _dbContext.Set<T>().AddAsync(entity);
            return entityEntry;
        }

        public void AddRange(IEnumerable<T> entites) => _dbContext.Set<T>().AddRange(entites);

        public async Task AddRangeAsync(IEnumerable<T> entites) => await _dbContext.Set<T>().AddRangeAsync(entites);

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate) => _dbContext.Set<T>().Where(predicate);

        public IQueryable<T> Get(
          Expression<Func<T, bool>> filter = null,
          List<string> orderByFields = null,
          List<bool> orderByDescs = null,
          int pageIndex = 0,
          int pageSize = 0,
          List<string> includes = null)
        {
            IQueryable<T> getQuery = Query ?? (IQueryable<T>)_dbContext.Set<T>();
            if (filter != null)
                getQuery = getQuery.Where(filter);
            if (includes != null && includes.Any())
                includes.ForEach((Action<string>)(c => getQuery = getQuery.Include<T>(c).Where((Expression<Func<T, bool>>)(c => !c.Deleted))));
            if (orderByFields != null && orderByFields.Any())
                getQuery = OrderByDynamicList(getQuery, orderByFields, orderByDescs);
            if (pageSize > 0)
            {
                int count = (pageIndex - 1) * pageSize;
                getQuery = getQuery.Skip(count).Take(pageSize);
            }
            return getQuery;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> anyQuery = Query != null ? Query : _dbContext.Set<T>();
            if (filter != null)
                anyQuery = anyQuery.Where(filter);
            bool flag = await anyQuery.AnyAsync();
            anyQuery = null;
            return flag;
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> countQuery = Query != null ? Query : _dbContext.Set<T>();
            if (filter != null)
                countQuery = countQuery.Where(filter);
            int num = await countQuery.CountAsync();
            long num1 = num;
            countQuery = null;
            return num1;
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> source = Query != null ? Query : _dbContext.Set<T>();
            if (filter != null)
                source = source.Where(filter);
            return source.Any();
        }

        public long Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> source = Query != null ? Query : _dbContext.Set<T>();
            if (filter != null)
                source = source.Where(filter);
            return (long)source.Count();
        }

        public T Get(long id) => _dbContext.Set<T>().Find(id);

        public IQueryable<T> GetAll() => _dbContext.Set<T>();

        public T SingleOrDefault(Expression<Func<T, bool>> predicate) => _dbContext.Set<T>().Where(predicate).SingleOrDefault();

        public T FirstOrDefault() => _dbContext.Set<T>().FirstOrDefault();

        public virtual void UpdateEntity(T entityToUpdate, params string[] fields)
        {
            entityToUpdate.UpdatedDateTime = DateTime.UtcNow;
            if (fields != null && fields.Any())
            {
                _dbContext.Set<T>().Attach(entityToUpdate);
                fields.ToList().ForEach((Action<string>)(field => _dbContext.Entry<T>(entityToUpdate).Property(field).IsModified = true));
            }
            else
                _dbContext.Set<T>().Update(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void UpdateRangeEntities(List<T> entitiesToUpdate, params string[] fields)
        {
            string[] source = fields;
            if (source != null && source.Any())
                entitiesToUpdate.ForEach((Action<T>)(c =>
                {
                    c.UpdatedDateTime = DateTime.UtcNow;
                    _dbContext.Set<T>().Attach(c);
                    fields.ToList<string>().ForEach((Action<string>)(field => _dbContext.Entry<T>(c).Property(field).IsModified = true));
                }));
            else
                entitiesToUpdate.ForEach((Action<T>)(c => _dbContext.Set<T>().Update(c).State = EntityState.Modified));
        }

        public async Task RemoveEntityAsync(T entityToDelete = null, Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                IQueryable<T> removeQuery = _dbContext.Set<T>();
                removeQuery = removeQuery.Where(filter);
                DbSet<T> dbSet = _dbContext.Set<T>();
                List<T> entities = await removeQuery.ToListAsync();
                dbSet.RemoveRange(entities);
                dbSet = null;
                entities = null;
                removeQuery = null;
            }
            else
                _dbContext.Set<T>().Remove(entityToDelete);
        }

        public void RemoveEntity(T entityToDelete = null, Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                IQueryable<T> source = _dbContext.Set<T>().Where(filter);
                _dbContext.Set<T>().RemoveRange(source.ToList());
            }
            else
                _dbContext.Set<T>().Remove(entityToDelete);
        }

        public void RemoveRange(IEnumerable<T> entities) => _dbContext.Set<T>().RemoveRange(entities);

        public void RemoveById(object Id)
        {
            T entity = _dbContext.Set<T>().Find(Id);
            _dbContext.Set<T>().Remove(entity);
        }

        public void SoftRemove(T entity)
        {
            entity.Deleted = true;
            entity.UpdatedDateTime = DateTime.UtcNow;
            UpdateEntity(entity, Array.Empty<string>());
        }

        public void SoftRemoveRangeEntities(List<T> entitiesToUpdate)
        {
            entitiesToUpdate.ForEach((Action<T>)(c =>
            {
                c.Deleted = true;
                c.UpdatedDateTime = DateTime.UtcNow;
            }));
            UpdateRangeEntities(entitiesToUpdate, Array.Empty<string>());
        }

        public void SoftRemoveById(object Id)
        {
            T entityToUpdate = _dbContext.Set<T>().Find(Id);
            entityToUpdate.Deleted = true;
            entityToUpdate.UpdatedDateTime = DateTime.UtcNow;
            UpdateEntity(entityToUpdate, Array.Empty<string>());
        }

        public Expression<Func<T, bool>> GetFilter(string filter)
        {
            ParameterExpression parameterExpression = default;
            return Expression.Lambda<Func<T, bool>>(DynamicExpressionParser.ParseLambda(new ParameterExpression[1]
            {
                parameterExpression
            }, (Type)null, filter).Body, parameterExpression);
        }

        public void ApplyFilter(string filter) => Query = Query.Where(GetFilter(filter));

        public IQueryable Join(
          IQueryable source1,
          string alias1,
          IQueryable source2,
          string alias2,
          string key1,
          string key2,
          string selector,
          params object[] args)
        {
            if (source1 == null)
                throw new ArgumentNullException(nameof(source1));
            if (alias1 == null)
                throw new ArgumentNullException(nameof(alias1));
            if (source2 == null)
                throw new ArgumentNullException(nameof(source1));
            if (alias2 == null)
                throw new ArgumentNullException(nameof(alias2));
            if (key1 == null)
                throw new ArgumentNullException(nameof(key1));
            if (key2 == null)
                throw new ArgumentNullException(nameof(key2));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            ParameterExpression parameterExpression1 = Expression.Parameter(source1.ElementType, alias1);
            ParameterExpression parameterExpression2 = Expression.Parameter(source2.ElementType, alias2);
            LambdaExpression lambda1 = DynamicExpressionParser.ParseLambda(new ParameterExpression[1]
            {
        parameterExpression1
            }, (Type)null, key1, (object[])null);
            LambdaExpression lambda2 = DynamicExpressionParser.ParseLambda(new ParameterExpression[1]
            {
        parameterExpression2
            }, (Type)null, key2, (object[])null);
            FixLambdaReturnTypes(ref lambda1, ref lambda2);
            return query;
        }

        private void FixLambdaReturnTypes(ref LambdaExpression lambda1, ref LambdaExpression lambda2)
        {
            Type type1 = lambda1.Body.Type;
            Type type2 = lambda2.Body.Type;
            if (!(type1 != type2))
                return;
            if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(Nullable<>) && type1 == type2.GetGenericArguments()[0])
                lambda1 = Expression.Lambda(Expression.Convert(lambda1.Body, type2), lambda1.Parameters.ToArray());
            else
                lambda2 = Expression.Lambda(Expression.Convert(lambda2.Body, type1), lambda2.Parameters.ToArray());
        }

        private IQueryable<T> OrderByDynamicList(
          IQueryable<T> source,
          List<string> orderByFields,
          List<bool> orderByDescs)
        {
            Expression expression = source.Expression;
            for (int index = 0; index < orderByFields.Count; ++index)
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
                MemberExpression body = Expression.PropertyOrField(parameterExpression, orderByFields[index]);
                string empty = string.Empty;
                expression = Expression.Call(typeof(Queryable), !orderByDescs[index] ? index != 0 ? "ThenBy" : "OrderBy" : index != 0 ? "ThenByDescending" : "OrderByDescending", new Type[2]
                {
          source.ElementType,
          body.Type
                }, expression, Expression.Quote(Expression.Lambda(body, parameterExpression)));
            }
            return source.Provider.CreateQuery<T>(expression);
        }

        public IQueryable<T> Query
        {
            get => query == null ? _dbContext.Set<T>() : query;
            set => query = value;
        }
    }
}

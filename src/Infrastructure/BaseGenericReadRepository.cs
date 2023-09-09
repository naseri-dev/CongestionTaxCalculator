using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Infrastructure
{
    public abstract class BaseGenericReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private IQueryable<T> query;

        public DbContext _dbContext { get; set; }

        protected BaseGenericReadRepository(DbContext dbContext) => _dbContext = dbContext;

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate) => _dbContext.Set<T>().Where(predicate);

        public IQueryable<T> GetAll() => _dbContext.Set<T>();

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
                includes.ForEach((Action<string>)(c => getQuery = getQuery.Include<T>(c)));
            if (orderByFields != null && orderByFields.Any())
                getQuery = OrderByDynamicList(getQuery, orderByFields, orderByDescs);
            if (pageSize > 0)
            {
                int count = (pageIndex - 1) * pageSize;
                getQuery = getQuery.Skip(count).Take(pageSize);
            }
            return getQuery;
        }

        public T Get(long id) => _dbContext.Set<T>().Find(id);

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

        public T SingleOrDefault(Expression<Func<T, bool>> predicate) => _dbContext.Set<T>().Where(predicate).SingleOrDefault();

        public T FirstOrDefault() => _dbContext.Set<T>().FirstOrDefault();

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
            LambdaExpression lambda3 = DynamicExpressionParser.ParseLambda(new ParameterExpression[2]
            {
        parameterExpression1,
        parameterExpression2
            }, (Type)null, selector, args);
            return source1.Provider.CreateQuery(Expression.Call(typeof(Queryable), nameof(Join), new Type[4]
            {
        source1.ElementType,
        source2.ElementType,
        lambda1.Body.Type,
        lambda3.Body.Type
            }, source1.Expression, source2.Expression, Expression.Quote(lambda1), Expression.Quote(lambda2), Expression.Quote(lambda3)));
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
                expression = Expression.Call(typeof(Queryable), orderByDescs[index] ? index == 0 ? "OrderByDescending" : "ThenByDescending" : index == 0 ? "OrderBy" : "ThenBy", new Type[2]
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

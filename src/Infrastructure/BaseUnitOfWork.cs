using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure
{
    public abstract class BaseUnitOfWork : IBaseUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        protected BaseUnitOfWork(AppDbContext context)
        {
            this._context = context;
        }
        public AppDbContext DbContext()
        {
            return this._context;
        }

        public virtual async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Rollback()
        {
            Enumerable.ToList<EntityEntry>(this._context.ChangeTracker.Entries())
                .ForEach(delegate (EntityEntry x)
            {
                x.Reload();
            });
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

    }
}

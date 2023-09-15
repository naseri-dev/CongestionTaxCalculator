using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public abstract class BaseReadUnitOfWork : IDisposable
    {
        private readonly AppDbContext _context;
        protected BaseReadUnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public AppDbContext DbContext()
        {
            return this._context;
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

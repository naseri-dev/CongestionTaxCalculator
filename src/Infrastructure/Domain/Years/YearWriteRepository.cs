using Domain.Entities.Years;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Years
{
    public class YearWriteRepository : BaseGenericRepository<Year>, IYearWriteRepository
    {
        public YearWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

using Domain.Entities.Holidays;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Holidays
{
    public class HolidayWriteRepository : BaseGenericRepository<Holiday>, IHolidayWriteRepository
    {
        public HolidayWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

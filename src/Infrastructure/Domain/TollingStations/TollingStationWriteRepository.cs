using Domain.Entities.TollingStations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TollingStations
{
    public class TollingStationWriteRepository : BaseGenericRepository<TollingStation>, ITollingStationWriteRepository
    {
        public TollingStationWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

using Domain.Entities.StationPasses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.StationPasses
{
    public class StationPassWriteRepository : BaseGenericRepository<StationPass>, IStationPassWriteRepository
    {
        public StationPassWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

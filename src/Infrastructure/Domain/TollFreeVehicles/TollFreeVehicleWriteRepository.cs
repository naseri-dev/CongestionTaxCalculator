using Domain.Entities.TollFreeVehicles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TollFreeVehicles
{
    public class TollFreeVehicleWriteRepository : BaseGenericRepository<TollFreeVehicle>, ITollFreeVehicleWriteRepository
    {
        public TollFreeVehicleWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

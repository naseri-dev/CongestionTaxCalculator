using Domain.Entities.VehicleCategories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.VehicleCategories
{
    public class VehicleCategoryWriteRepository : BaseGenericRepository<VehicleCategory>, IVehicleCategoryWriteRepository
    {
        public VehicleCategoryWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

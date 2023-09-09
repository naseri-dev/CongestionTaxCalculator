using AutoMapper;
using Domain.Entities.VehicleCategories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.VehicleCategories
{
    public class VehicleCategoryReadRepository : BaseGenericReadRepository<VehicleCategory>, IVehicleCategoryReadRepository
    {
        private readonly IMapper _mapper;
        public VehicleCategoryReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

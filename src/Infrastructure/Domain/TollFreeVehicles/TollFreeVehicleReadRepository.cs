using AutoMapper;
using Domain.Entities.TollFreeVehicles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TollFreeVehicles
{
    public class TollFreeVehicleReadRepository : BaseGenericReadRepository<TollFreeVehicle>, ITollFreeVehicleReadRepository
    {
        private readonly IMapper _mapper;
        public TollFreeVehicleReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

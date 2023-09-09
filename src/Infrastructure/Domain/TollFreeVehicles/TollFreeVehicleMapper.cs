
using Domain.Entities.TollFreeVehicles;
using Domain.Entities.TollFreeVehicles.Dtos;

namespace Infrastructure.Domain.TollFreeVehicles
{
    public class TollFreeVehicleMapper : AutoMapper.Profile
    {
        public TollFreeVehicleMapper()
        {
            CreateMap<TollFreeVehicle, TollFreeVehicleDto>();
        }
    }
}


using Domain.Entities.VehicleCategories;
using Domain.Entities.VehicleCategories.Dtos;

namespace Infrastructure.Domain.VehicleCategories
{
    public class VehicleCategoryMapper : AutoMapper.Profile
    {
        public VehicleCategoryMapper()
        {
            CreateMap<VehicleCategory, VehicleCategoryDto>();
        }
    }
}

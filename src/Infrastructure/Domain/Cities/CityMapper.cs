
using Domain.Entities.Cities;
using Domain.Entities.Cities.Dtos;

namespace Infrastructure.Domain.Cities
{
    public class CityMapper : AutoMapper.Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityDto>();
        }
    }
}


using Domain.Entities.Countries;
using Domain.Entities.Countries.Dtos;

namespace Infrastructure.Domain.Countries
{
    public class CountryMapper : AutoMapper.Profile
    {
        public CountryMapper()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}

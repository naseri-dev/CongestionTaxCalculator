
using Domain.Entities.Years;
using Domain.Entities.Years.Dtos;

namespace Infrastructure.Domain.Years
{
    public class YearMapper : AutoMapper.Profile
    {
        public YearMapper()
        {
            CreateMap<Year, YearDto>();
        }
    }
}

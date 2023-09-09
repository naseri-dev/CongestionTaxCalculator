
using Domain.Entities.Holidays;
using Domain.Entities.Holidays.Dtos;

namespace Infrastructure.Domain.Holidays
{
    public class HolidayMapper : AutoMapper.Profile
    {
        public HolidayMapper()
        {
            CreateMap<Holiday, HolidayDto>();
        }
    }
}

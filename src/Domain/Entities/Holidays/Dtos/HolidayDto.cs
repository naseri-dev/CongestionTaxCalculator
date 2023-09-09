using Domain.Enums;

namespace Domain.Entities.Holidays.Dtos
{
    public class HolidayDto
    {
        public Guid YearId { get; set; }
        public Guid CountryId { get; set; }
        public DateTime Date { get; set; }
        public HolidayType HolidayType { get; set; }
    }
}

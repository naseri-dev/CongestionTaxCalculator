using Domain.Entities.Cities.Dtos;
using Domain.Entities.Currencies.Dtos;
using Domain.Entities.Years.Dtos;

namespace Domain.Entities.TaxFeePerHours.Dtos
{
    public class TaxFeePerHourDto
    {
        public Guid Id { get; set; }
        public byte FromHour { get; set; }
        public byte FromMinute { get; set; }
        public byte ToHour { get; set; }
        public byte ToMinute { get; set; }
        public decimal TaxAmount { get; set; }
        public Guid YearId { get; set; }
        public YearDto YearDto { get; set; }
        public Guid CurrencyId { get; set; }
        public CurrencyDto CurrencyDto { get; set; }
        public CityDto CityDto { get; set; }
        public Guid CityId { get; set; }
    }
}

using Domain.Entities.Cities;
using Domain.Entities.Currencies;
using Domain.Entities.Years;
using Domain.SeedWork;

namespace Domain.Entities.TaxFeePerHours
{
    public class TaxFeePerHour : BaseEntity
    {
        public byte FromHour { get; set; }
        public byte FromMinute { get; set; }
        public byte ToHour { get; set; }
        public byte ToMinute { get; set; }
        public decimal TaxAmount { get; set; }
        public Guid YearId { get; set; }
        public Year Year { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public City City { get; set; }
        public Guid CityId { get; set; }
    }
}

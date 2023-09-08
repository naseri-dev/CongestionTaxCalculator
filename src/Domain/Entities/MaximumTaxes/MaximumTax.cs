using Domain.Entities.Cities;
using Domain.Entities.Years;
using Domain.SeedWork;

namespace Domain.Entities.MaximumTaxes
{
    public class MaximumTax : BaseEntity
    {
        public City City { get; set; }
        public Guid CityId { get; set; }
        public Year Year { get; set; }
        public Guid YearId { get; set; }
        public decimal Amount { get; set; }
    }
}

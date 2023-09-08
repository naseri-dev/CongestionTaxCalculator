using Domain.SeedWork;

namespace Domain.Entities
{
    public class TaxPaid: BaseEntity
    {
        public TollingStation TollingStation { get; set; }
        public Guid TollingStationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

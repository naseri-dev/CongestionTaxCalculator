using Domain.Entities.Cars;
using Domain.Entities.TollingStations;
using Domain.SeedWork;

namespace Domain.Entities.TaxPaids
{
    public class TaxPaid : BaseEntity
    {
        public TollingStation TollingStation { get; set; }
        public Guid TollingStationId { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

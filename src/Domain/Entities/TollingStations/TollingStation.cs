using Domain.Entities.Cities;
using Domain.SeedWork;

namespace Domain.Entities.TollingStations
{
    public class TollingStation : BaseEntity
    {
        public Guid CityId { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
    }
}

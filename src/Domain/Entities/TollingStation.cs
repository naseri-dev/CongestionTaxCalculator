using Domain.SeedWork;

namespace Domain.Entities
{
    public class TollingStation: BaseEntity
    {
        public Guid CityId { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
    }
}

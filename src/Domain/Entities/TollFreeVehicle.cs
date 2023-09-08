using Domain.SeedWork;

namespace Domain.Entities
{
    public class TollFreeVehicle : BaseEntity
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}

using Domain.Entities.Cars;
using Domain.Entities.Cities;
using Domain.SeedWork;

namespace Domain.Entities.TollFreeVehicles
{
    public class TollFreeVehicle : BaseEntity
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}

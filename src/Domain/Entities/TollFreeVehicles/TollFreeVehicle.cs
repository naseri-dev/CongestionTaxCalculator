using Domain.Entities.Cities;
using Domain.Entities.VehicleCategories;
using Domain.SeedWork;

namespace Domain.Entities.TollFreeVehicles
{
    public class TollFreeVehicle : BaseEntity
    {
        public Guid VehicleCategoryId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}

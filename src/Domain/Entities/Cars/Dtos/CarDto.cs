using Domain.Entities.VehicleCategories;

namespace Domain.Entities.Cars.Dtos
{
    public class CarDto
    {
        public string PlateNumber { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        public Guid VehicleCategoryId { get; set; }
        public bool IsTollFree { get; set; }
    }
}

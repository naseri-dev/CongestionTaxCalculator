namespace Domain.Entities.TollFreeVehicles.Dtos
{
    public class TollFreeVehicleDto
    {
        public Guid Id { get; set; }
        public Guid VehicleCategoryId { get; set; }
        public Guid CityId { get; set; }
    }
}

namespace Domain.Entities.TollFreeVehicles.Dtos
{
    public class TollFreeVehicleDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid CityId { get; set; }
    }
}

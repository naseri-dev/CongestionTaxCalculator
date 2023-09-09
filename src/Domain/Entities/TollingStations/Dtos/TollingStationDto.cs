namespace Domain.Entities.TollingStations.Dtos
{
    public class TollingStationDto
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}

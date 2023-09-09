
using Domain.Entities.TollingStations;
using Domain.Entities.TollingStations.Dtos;

namespace Infrastructure.Domain.TollingStations
{
    public class TollingStationMapper : AutoMapper.Profile
    {
        public TollingStationMapper()
        {
            CreateMap<TollingStation, TollingStationDto>();
        }
    }
}

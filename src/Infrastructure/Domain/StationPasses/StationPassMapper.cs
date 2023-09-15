
using Domain.Entities.StationPasses;
using Domain.Entities.StationPasses.Dtos;

namespace Infrastructure.Domain.StationPasses
{
    public class StationPassMapper : AutoMapper.Profile
    {
        public StationPassMapper()
        {
            CreateMap<StationPass, StationPassDto>();
        }
    }
}

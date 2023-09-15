using Domain.SeedWork;

namespace Domain.Entities.StationPasses
{
    public interface IStationPassReadRepository : IReadRepository<StationPass>
    {
        Task<List<DateTime>> GetGatePassesTimes(Guid carId, List<DateTime> holidays);
    }
}

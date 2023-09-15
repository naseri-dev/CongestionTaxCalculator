using Domain.SeedWork;

namespace Domain.Entities.TollFreeVehicles
{
    public interface ITollFreeVehicleReadRepository : IReadRepository<TollFreeVehicle>
    {
        Task<bool> IsTollFreeVehicle(Guid vehicleCategoryId);
    }
}

using Domain.SeedWork;

namespace Domain.Entities.Cities
{
    public interface ICityReadRepository : IReadRepository<City>
    {
        Task<City> GetByIdAsync(Guid id);
    }
}

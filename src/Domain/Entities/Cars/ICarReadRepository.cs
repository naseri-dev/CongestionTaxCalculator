using Domain.SeedWork;

namespace Domain.Entities.Cars
{
    public interface ICarReadRepository : IReadRepository<Car>
    {
        Task<Car> GetCar(Guid id);
    }
}

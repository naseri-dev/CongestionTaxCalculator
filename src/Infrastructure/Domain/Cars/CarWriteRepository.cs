using Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Cars
{
    public class CityWriteRepository : BaseGenericRepository<Car>, ICarWriteRepository
    {
        public CityWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

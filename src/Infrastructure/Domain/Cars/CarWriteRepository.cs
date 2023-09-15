using Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Cars
{
    public class CarWriteRepository : BaseGenericRepository<Car>, ICarWriteRepository
    {
        public CarWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

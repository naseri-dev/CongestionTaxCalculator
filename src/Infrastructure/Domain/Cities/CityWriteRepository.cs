using Domain.Entities.Cities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Cities
{
    public class CityWriteRepository : BaseGenericRepository<City>, ICityWriteRepository
    {
        public CityWriteRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}

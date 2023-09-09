using Domain.Entities.Countries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Countries
{
    public class CountryWriteRepository : BaseGenericRepository<Country>, ICountryWriteRepository
    {
        public CountryWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

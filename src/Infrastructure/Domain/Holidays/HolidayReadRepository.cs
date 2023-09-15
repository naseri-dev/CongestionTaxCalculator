using AutoMapper;
using Domain.Entities.Holidays;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Holidays
{
    public class HolidayReadRepository : BaseGenericReadRepository<Holiday>, IHolidayReadRepository
    {
        private readonly IMapper _mapper;
        public HolidayReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public async Task<List<DateTime>> GetHolidays(int year, Guid countryId)
        {
            return await GetAll()
                .Include(y => y.Year)
                .Where(x => x.Year.Value == year && x.CountryId == countryId)
                .Select(x => x.Date)
                .ToListAsync();
        }
    }
}

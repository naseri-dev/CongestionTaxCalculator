using AutoMapper;
using Domain.Entities.StationPasses;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Domain.StationPasses
{
    public class StationPassReadRepository : BaseGenericReadRepository<StationPass>, IStationPassReadRepository
    {
        private readonly IMapper _mapper;
        public StationPassReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public async Task<List<DateTime>> GetGatePassesTimes(Guid carId, List<DateTime> holidays)
        {
            List<DateTime> result = new List<DateTime>();

            var dates = await GetAll()
                .Where(x => x.CarId == carId)
                .Select(x => x.Date)
                .ToListAsync();

            foreach (var date in dates)
            {
                bool isHoliday = holidays.Any(x => x.Date.Date == date.Date);
                if (!isHoliday)
                {
                    result.Add(date);
                }
            }

            return result.OrderBy(x => x).ToList();
        }
    }
}

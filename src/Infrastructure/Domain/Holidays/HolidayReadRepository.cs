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
    }
}

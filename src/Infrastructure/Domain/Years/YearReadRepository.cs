using AutoMapper;
using Domain.Entities.Years;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Years
{
    public class YearReadRepository : BaseGenericReadRepository<Year>, IYearReadRepository
    {
        private readonly IMapper _mapper;
        public YearReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

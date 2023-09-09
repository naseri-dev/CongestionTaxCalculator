using AutoMapper;
using Domain.Entities.Cities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Cities
{
    public class CityReadRepository : BaseGenericReadRepository<City>, ICityReadRepository
    {
        private readonly IMapper _mapper;
        public CityReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

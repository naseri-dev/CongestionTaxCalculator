using AutoMapper;
using Domain.Entities.Countries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Countries
{
    public class CountryReadRepository : BaseGenericReadRepository<Country>, ICountryReadRepository
    {
        private readonly IMapper _mapper;
        public CountryReadRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

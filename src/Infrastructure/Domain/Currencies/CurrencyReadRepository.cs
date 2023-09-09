using AutoMapper;
using Domain.Entities.Currencies;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Currencies
{
    public class CurrencyReadRepository : BaseGenericReadRepository<Currency>, ICurrencyReadRepository
    {
        private readonly IMapper _mapper;
        public CurrencyReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

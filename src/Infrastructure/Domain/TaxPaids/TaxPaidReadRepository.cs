using AutoMapper;
using Domain.Entities.TaxPaids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TaxPaids
{
    public class TaxPaidReadRepository : BaseGenericReadRepository<TaxPaid>, ITaxPaidReadRepository
    {
        private readonly IMapper _mapper;
        public TaxPaidReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

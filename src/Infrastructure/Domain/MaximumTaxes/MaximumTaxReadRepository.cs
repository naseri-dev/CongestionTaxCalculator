using AutoMapper;
using Domain.Entities.MaximumTaxes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.MaximumTaxes
{
    public class MaximumTaxReadRepository : BaseGenericReadRepository<MaximumTax>, IMaximumTaxReadRepository
    {
        private readonly IMapper _mapper;
        public MaximumTaxReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

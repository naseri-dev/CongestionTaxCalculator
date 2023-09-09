using AutoMapper;
using Domain.Entities.TaxFeePerHours;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TaxFeePerHours
{
    public class TaxFeePerHourReadRepository : BaseGenericReadRepository<TaxFeePerHour>, ITaxFeePerHourReadRepository
    {
        private readonly IMapper _mapper;
        public TaxFeePerHourReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}

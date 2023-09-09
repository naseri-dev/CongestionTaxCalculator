using Domain.Entities.TaxFeePerHours;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TaxFeePerHours
{
    public class TaxFeePerHourWriteRepository : BaseGenericRepository<TaxFeePerHour>, ITaxFeePerHourWriteRepository
    {
        public TaxFeePerHourWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

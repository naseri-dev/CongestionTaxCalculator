using Domain.Entities.TaxPaids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.TaxPaids
{
    public class TaxPaidWriteRepository : BaseGenericRepository<TaxPaid>, ITaxPaidWriteRepository
    {
        public TaxPaidWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

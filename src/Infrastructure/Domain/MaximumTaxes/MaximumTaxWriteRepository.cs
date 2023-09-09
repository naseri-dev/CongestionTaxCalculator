using Domain.Entities.MaximumTaxes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.MaximumTaxes
{
    public class MaximumTaxWriteRepository : BaseGenericRepository<MaximumTax>, IMaximumTaxWriteRepository
    {
        public MaximumTaxWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

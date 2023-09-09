using Domain.Entities.Currencies;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Currencies
{
    public class CurrencyWriteRepository : BaseGenericRepository<Currency>, ICurrencyWriteRepository
    {
        public CurrencyWriteRepository(DbContext dbContext) : base(dbContext) { }
    }
}

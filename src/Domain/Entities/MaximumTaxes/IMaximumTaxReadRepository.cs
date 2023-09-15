using Domain.SeedWork;

namespace Domain.Entities.MaximumTaxes
{
    public interface IMaximumTaxReadRepository : IReadRepository<MaximumTax>
    {
        Task<decimal> GetMaximumTaxReadAsync(Guid cityId);
    }
}

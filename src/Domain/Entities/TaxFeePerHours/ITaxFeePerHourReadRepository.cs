using Domain.Entities.TaxFeePerHours.Dtos;
using Domain.SeedWork;

namespace Domain.Entities.TaxFeePerHours
{
    public interface ITaxFeePerHourReadRepository : IReadRepository<TaxFeePerHour>
    {
        Task<List<TaxFeeDto>> GetTaxRates(Guid cityId, int year, List<DateTime> forDates);
    }
}

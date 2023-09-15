using Domain.Entities.TaxFeePerHours.Dtos;

namespace Domain.SeedWork
{
    public interface ITaxService
    {
        decimal GetTax(List<TaxFeeDto> taxFees, decimal maximumTax);
    }
}

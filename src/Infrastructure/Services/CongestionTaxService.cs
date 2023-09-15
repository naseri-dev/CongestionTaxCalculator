using Domain.Entities.TaxFeePerHours.Dtos;
using Domain.SeedWork;

namespace Infrastructure.Services
{
    public class CongestionTaxService : ITaxService
    {
        public decimal GetTax(List<TaxFeeDto> taxFees, decimal maximumTax)
        {
            if (taxFees.Count == 0)
                return 0;

            var start = taxFees[0];
            decimal totalFee = 0;
            foreach (var taxfee in taxFees)
            {
                decimal nextFee = taxfee.TaxAmount;
                decimal tempFee = start.TaxAmount;

                double minutes = 
                    TimeSpan.FromTicks(taxfee.Ticks).TotalMinutes -
                                TimeSpan.FromTicks(start.Ticks).TotalMinutes;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > maximumTax)
                totalFee = maximumTax;

            return totalFee;
        }
    }
}

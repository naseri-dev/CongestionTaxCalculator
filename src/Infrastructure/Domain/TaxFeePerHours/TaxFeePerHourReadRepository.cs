using AutoMapper;
using Domain;
using Domain.Entities.TaxFeePerHours;
using Domain.Entities.TaxFeePerHours.Dtos;
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

        public async Task<List<TaxFeeDto>> GetTaxRates(Guid cityId, int year, List<DateTime> forDates)
        {
            List<TaxFeeDto> result = new List<TaxFeeDto>();

            var taxFees = await GetAll()
                .Where(x => x.Year.Value == year && x.CityId == cityId)
                .ToListAsync();

            foreach (var forDate in forDates)
            {
                var date = forDate.ToString(AppConstants.Hour24).Split(AppConstants.Sign);
                int dateHour = int.Parse(date[0]);
                int dateMinutes = int.Parse(date[1]);

                TaxFeePerHour taxFeePerHour = taxFees.FirstOrDefault(
                    x => dateHour >= x.FromHour && dateMinutes <= x.FromMinute &&
                            dateHour <= x.ToHour && dateMinutes <= x.ToMinute);

                if (taxFeePerHour != default)
                {
                    result.Add(new TaxFeeDto
                    {
                        Date = forDate,
                        TaxAmount = taxFeePerHour.TaxAmount,
                        Ticks = forDate.Ticks
                    });
                }
            }

            return result.OrderBy(x => x.Ticks).ToList();

        }
    }
}

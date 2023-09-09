
using Domain.Entities.TaxFeePerHours;
using Domain.Entities.TaxFeePerHours.Dtos;

namespace Infrastructure.Domain.TaxFeePerHours
{
    public class TaxFeePerHourMapper : AutoMapper.Profile
    {
        public TaxFeePerHourMapper()
        {
            CreateMap<TaxFeePerHour, TaxFeePerHourDto>();
        }
    }
}


using Domain.Entities.TaxPaids;
using Domain.Entities.TaxPaids.Dtos;

namespace Infrastructure.Domain.TaxPaids
{
    public class TaxPaidMapper : AutoMapper.Profile
    {
        public TaxPaidMapper()
        {
            CreateMap<TaxPaid, TaxPaidDto>();
        }
    }
}


using Domain.Entities.MaximumTaxes;
using Domain.Entities.MaximumTaxes.Dtos;

namespace Infrastructure.Domain.MaximumTaxes
{
    public class MaximumTaxMapper : AutoMapper.Profile
    {
        public MaximumTaxMapper()
        {
            CreateMap<MaximumTax, MaximumTaxDto>();
        }
    }
}

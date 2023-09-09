
using Domain.Entities.Currencies;
using Domain.Entities.Currencies.Dtos;

namespace Infrastructure.Domain.Currencies
{
    public class CurrencyMapper : AutoMapper.Profile
    {
        public CurrencyMapper()
        {
            CreateMap<Currency, CurrencyDto>();
        }
    }
}

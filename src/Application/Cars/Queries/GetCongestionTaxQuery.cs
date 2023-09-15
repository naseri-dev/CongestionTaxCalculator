using Application.Cars.Queries;
using MediatR;

namespace Application.Countries.Queries
{
    public record GetCongestionTaxQuery(
        Guid CarId,
        Guid CityId,
        int Year = 2013
        ) : IRequest<CongestionTaxResult>;
}

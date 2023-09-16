using MediatR;

namespace Application.Cars.Queries
{
    public record GetCongestionTaxQuery(
        Guid CarId,
        Guid CityId,
        int Year = 2013
        ) : IRequest<CongestionTaxResult>;
}

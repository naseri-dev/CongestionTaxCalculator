using Domain.Entities.Cities.Dtos;
using MediatR;

namespace Application.Cities.Queries
{
    public record GetCityByIdQuery(Guid Id) : IRequest<CityDto>;
}

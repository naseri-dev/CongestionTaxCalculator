using Domain.Entities.Cities.Dtos;
using MediatR;

namespace Application.Cities.Queries
{
    public record GetCityQuery() : IRequest<List<CityDto>>;
}

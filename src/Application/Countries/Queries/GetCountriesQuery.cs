using Domain.Entities.Countries.Dtos;
using MediatR;

namespace Application.Countries.Queries
{
    public record GetCountriesQuery() : IRequest<List<CountryDto>>;
}

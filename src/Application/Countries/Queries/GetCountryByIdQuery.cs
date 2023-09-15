using Domain.Entities.Countries.Dtos;
using MediatR;

namespace Application.Countries.Queries
{
    public record GetCountryByIdQuery(Guid Id) : IRequest<CountryDto>;
}

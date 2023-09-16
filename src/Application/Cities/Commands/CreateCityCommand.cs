using MediatR;

namespace Application.Cities.Commands
{
    public record CreateCityCommand(string Name, Guid CountryId) : IRequest<Guid>;
}

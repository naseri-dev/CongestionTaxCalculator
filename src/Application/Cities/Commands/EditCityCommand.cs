using MediatR;

namespace Application.Cities.Commands
{
    public record EditCityCommand(
        Guid Id,
        Guid CountryId,
        string Name
        ) : IRequest<Guid>;
}

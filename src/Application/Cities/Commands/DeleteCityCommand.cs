using MediatR;

namespace Application.Cities.Commands
{
    public record DeleteCityCommand(
        Guid Id
        ) : IRequest<Guid>;
}

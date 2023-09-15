using MediatR;

namespace Application.Countries.Commands
{
    public record EditCountryCommand(
        Guid Id,
        string Name
        ) : IRequest<Guid>;
}

using MediatR;

namespace Application.Countries.Commands
{
    public record CreateCountryCommand(string Name) : IRequest<Guid>;
}

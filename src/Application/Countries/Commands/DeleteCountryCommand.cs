using MediatR;

namespace Application.Countries.Commands
{
    public record DeleteCountryCommand(
        Guid Id
        ) : IRequest<Guid>;
}

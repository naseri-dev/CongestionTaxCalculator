using Domain.Entities.Cars.Dtos;
using MediatR;

namespace Application.Cars.Queries
{
    public record GetCarQuery() : IRequest<List<CarDto>>;
}

using Domain.Entities.VehicleCategories.Dtos;
using MediatR;

namespace Application.VehicleCategories.Queries
{
    public record GetVehicleCategoryQuery() : IRequest<List<VehicleCategoryDto>>;
}

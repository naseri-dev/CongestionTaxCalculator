using AutoMapper;
using Domain;
using Domain.Entities.VehicleCategories.Dtos;
using MediatR;

namespace Application.VehicleCategories.Queries
{
    public class GetVehicleCategoryQueryHandler : IRequestHandler<GetVehicleCategoryQuery, List<VehicleCategoryDto>>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetVehicleCategoryQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VehicleCategoryDto>> Handle(GetVehicleCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = _readUnitOfWork
                .VehicleCategoryReadRepository
                .GetAll()
                .ToList();

            List<VehicleCategoryDto> result = _mapper.Map<List<VehicleCategoryDto>>(categories);

            return await Task.FromResult(result);
        }
    }
}

using AutoMapper;
using Domain;
using Domain.Entities.Cars.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cars.Queries
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<CarDto>>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetCarQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CarDto>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var cars = _readUnitOfWork
                .CarReadRepository
                .GetAll()
                .Include(x => x.VehicleCategory)
                .ToList();

            List<CarDto> result = _mapper.Map<List<CarDto>>(cars);

            return await Task.FromResult(result);
        }
    }
}

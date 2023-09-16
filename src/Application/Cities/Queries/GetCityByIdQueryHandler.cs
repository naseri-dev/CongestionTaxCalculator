using AutoMapper;
using Domain;
using Domain.Entities.Cities.Dtos;
using MediatR;

namespace Application.Cities.Queries
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _readUnitOfWork
                .CityReadRepository
                .GetByIdAsync(request.Id);

            return _mapper.Map<CityDto>(city);
        }
    }
}

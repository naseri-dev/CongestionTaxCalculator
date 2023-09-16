using AutoMapper;
using Domain;
using Domain.Entities.Cities.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cities.Queries
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, List<CityDto>>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetCityQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var cities = await _readUnitOfWork
                .CityReadRepository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}

using AutoMapper;
using Domain;
using Domain.Entities.Countries.Dtos;
using MediatR;

namespace Application.Countries.Queries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = _readUnitOfWork
                .CountryReadRepository
                .GetAll()
                .ToList();

            List<CountryDto> result = _mapper.Map<List<CountryDto>>(countries);

            return await Task.FromResult(result);
        }
    }
}

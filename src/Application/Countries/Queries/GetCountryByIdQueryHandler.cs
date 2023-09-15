using AutoMapper;
using Domain;
using Domain.Entities.Countries.Dtos;
using MediatR;

namespace Application.Countries.Queries
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, CountryDto>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetCountryByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }

        public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = _readUnitOfWork.CountryReadRepository.SingleOrDefault(x => x.Id == request.Id);

            CountryDto result = _mapper.Map<CountryDto>(country);

            return await Task.FromResult(result);
        }
    }
}

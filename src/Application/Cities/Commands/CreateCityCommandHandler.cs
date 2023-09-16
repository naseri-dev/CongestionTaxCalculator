using Domain;
using Domain.Entities.Cities;
using MediatR;

namespace Application.Cities.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly IWriteUnitOfWork _unitOfWork;

        public CreateCityCommandHandler(IWriteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            City city = _unitOfWork
                .CityWriteRepository
                .Get(x => x.Name.ToLower().Trim() == request.Name.ToLower().Trim())
                .FirstOrDefault();

            if (city == null)
            {
                city = new City(Guid.NewGuid(), request.Name, request.CountryId);
                _unitOfWork.CityWriteRepository.Add(city);
                await _unitOfWork.Commit();
            }

            return city.Id;
        }
    }
}

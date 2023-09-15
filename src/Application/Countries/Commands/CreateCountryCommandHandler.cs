using Domain;
using Domain.Entities.Countries;
using MediatR;

namespace Application.Countries.Commands
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Guid>
    {
        private readonly IWriteUnitOfWork _unitOfWork;

        public CreateCountryCommandHandler(IWriteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Country country = _unitOfWork
                .CountryWriteRepository
                .Get(x => x.Name.ToLower().Trim() == request.Name.ToLower().Trim())
                .FirstOrDefault();

            if (country == null)
            {
                country = new Country(Guid.NewGuid(), request.Name);
                _unitOfWork.CountryWriteRepository.Add(country);
                await _unitOfWork.Commit();
            }

            return country.Id;
        }
    }
}

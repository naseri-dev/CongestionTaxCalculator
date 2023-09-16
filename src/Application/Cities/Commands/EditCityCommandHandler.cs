using Domain;
using Domain.Entities.Cities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cities.Commands
{
    public class EditCityCommandHandler : IRequestHandler<EditCityCommand, Guid>
    {
        private readonly ICityWriteRepository _repository;
        private readonly IWriteUnitOfWork _unitOfWork;

        public EditCityCommandHandler(ICityWriteRepository repository, IWriteUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(EditCityCommand request, CancellationToken cancellationToken)
        {
            var country = await _repository.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (country is null)
            {
                throw new Exception(AppConstants.CityNotFound);
            }

            country.SetName(request.Name);

            _repository.UpdateEntity(country);
            await _unitOfWork.Commit();

            return country.Id;
        }
    }
}

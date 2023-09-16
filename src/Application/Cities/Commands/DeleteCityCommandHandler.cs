using Domain;
using Domain.Entities.Cities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Cities.Commands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Guid>
    {
        private readonly ICityWriteRepository _repository;
        private readonly IWriteUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(ICityWriteRepository repository, IWriteUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _repository.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (city is null)
            {
                throw new Exception(AppConstants.CityNotFound);
            }

            _repository.RemoveEntity(city);
            await _unitOfWork.Commit();

            return city.Id;
        }
    }
}

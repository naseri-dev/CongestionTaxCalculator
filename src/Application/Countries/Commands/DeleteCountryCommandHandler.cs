using Domain;
using Domain.Entities.Countries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Countries.Commands
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Guid>
    {
        private readonly ICountryWriteRepository _repository;
        private readonly IWriteUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(ICountryWriteRepository repository, IWriteUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _repository.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (country is null)
            {
                throw new Exception("Country not found.");
            }

            _repository.RemoveEntity(country);
            await _unitOfWork.Commit();

            return country.Id;
        }
    }
}

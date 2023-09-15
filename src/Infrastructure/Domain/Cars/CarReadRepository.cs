using AutoMapper;
using Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Cars
{
    public class CarReadRepository : BaseGenericReadRepository<Car>, ICarReadRepository
    {
        private readonly IMapper _mapper;
        public CarReadRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public async Task<Car> GetCar(Guid id) =>
            await
             GetAll()
            .Include(x => x.VehicleCategory)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}

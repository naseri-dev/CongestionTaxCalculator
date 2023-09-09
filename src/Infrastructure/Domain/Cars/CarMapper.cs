using Domain.Entities.Cars;
using Domain.Entities.Cars.Dtos;

namespace Infrastructure.Domain.Cars
{
    public class CarMapper : AutoMapper.Profile
    {
        public CarMapper()
        {
            CreateMap<Car, CarDto>();
        }
    }
}

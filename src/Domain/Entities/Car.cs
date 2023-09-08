using Domain.SeedWork;

namespace Domain.Entities
{
    public class Car : BaseEntity
    {
        public Car(string plateNumber, Guid vehicleCategoryId, bool isTollFree)
        {
            Id = Guid.NewGuid();
            PlateNumber = plateNumber;
            VehicleCategoryId = vehicleCategoryId;
            IsTollFree = isTollFree;
        }

        private Car()
        {

        }

        public string PlateNumber { get; private set; }
        public VehicleCategory VehicleCategory { get; private set; }
        public Guid VehicleCategoryId { get; private set; }
        public bool IsTollFree { get; private set; }
    }
}

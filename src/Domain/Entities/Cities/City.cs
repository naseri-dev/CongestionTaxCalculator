using Domain.Entities.Countries;
using Domain.SeedWork;

namespace Domain.Entities.Cities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        private City()
        {

        }

        public City(Guid id,string name, Guid countryId)
        {
            Id = id;
            Name = name;
            CountryId = countryId;
        }
        public void SetName(string name)
        {
            Name = name;
        }
    }
}

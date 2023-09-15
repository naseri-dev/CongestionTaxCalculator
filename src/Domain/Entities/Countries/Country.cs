using Domain.SeedWork;

namespace Domain.Entities.Countries
{
    public class Country : BaseEntity
    {
        public string Name { get; private set; }
        private Country()
        {

        }

        public Country(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
    }
}

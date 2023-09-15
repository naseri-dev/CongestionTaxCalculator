using Domain.SeedWork;

namespace Domain.Entities.Holidays
{
    public interface IHolidayReadRepository : IReadRepository<Holiday>
    {
        Task<List<DateTime>> GetHolidays(int year, Guid countryId);
    }
}

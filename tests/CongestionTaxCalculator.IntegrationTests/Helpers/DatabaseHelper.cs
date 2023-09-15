using Domain.Entities.Countries;
using Infrastructure;

namespace CongestionTaxCalculator.IntegrationTests.Helpers
{
    public static class DatabaseHelper
    {
        public static void InitialDatabaseForTests(AppDbContext dbContext)
        {
            dbContext.Countries.Add(
                new Country(
                    Guid.Parse("b158fde2-fd7f-4e3f-98eb-2b248465aec9"), "Germany"));

            dbContext.Countries.Add(
                new Country(
                    Guid.Parse("4ea2d518-5146-46c5-80f6-5f0c81afdf29"), "Poland"));

            dbContext.SaveChanges();
        }

        public static void ResetDatabaseForTest(AppDbContext dbContext)
        {
            var countries = dbContext.Countries.ToArray();

            dbContext.RemoveRange(countries);
            dbContext.SaveChanges();

            InitialDatabaseForTests(dbContext);
        }
    }
}

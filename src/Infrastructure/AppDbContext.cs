using Domain.Entities.Cars;
using Domain.Entities.Cities;
using Domain.Entities.Countries;
using Domain.Entities.Currencies;
using Domain.Entities.Holidays;
using Domain.Entities.MaximumTaxes;
using Domain.Entities.TaxFeePerHours;
using Domain.Entities.TaxPaids;
using Domain.Entities.TollFreeVehicles;
using Domain.Entities.TollingStations;
using Domain.Entities.VehicleCategories;
using Domain.Entities.Years;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<MaximumTax> MaximumTaxes { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<TollingStation> TollingStations { get; set; }
        public DbSet<TaxPaid> TaxPaids { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<TaxFeePerHour> TaxFeePerHours { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<TollFreeVehicle> TollFreeVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

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
using Domain.SeedWork;

namespace Domain
{
    public interface IReadUnitOfWork : IBaseReadUnitOfWork
    {
        ICarReadRepository CarReadRepository { get; }
        ICityReadRepository CityReadRepository { get; }
        ICountryReadRepository CountryReadRepository { get; }
        ICurrencyReadRepository CurrencyReadRepository { get; }
        IHolidayReadRepository HolidayReadRepository { get; }
        IMaximumTaxReadRepository MaximumTaxReadRepository { get; }
        ITaxFeePerHourReadRepository TaxFeePerHourReadRepository { get; }
        ITaxPaidReadRepository TaxPaidReadRepository { get; }
        ITollFreeVehicleReadRepository TollFreeVehicleReadRepository { get; }
        ITollingStationReadRepository TollingStationReadRepository { get; }
        IVehicleCategoryReadRepository VehicleCategoryReadRepository { get; }
        IYearReadRepository YearReadRepository { get; }
    }
}

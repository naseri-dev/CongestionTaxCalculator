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
    public interface IWriteUnitOfWork : IBaseUnitOfWork
    {
        ICarWriteRepository CarWriteRepository { get; }
        ICityWriteRepository CityWriteRepository { get; }
        ICountryWriteRepository CountryWriteRepository { get; }
        ICurrencyWriteRepository CurrencyWriteRepository { get; }
        IHolidayWriteRepository HolidayWriteRepository { get; }
        IMaximumTaxWriteRepository MaximumTaxWriteRepository { get; }
        ITaxFeePerHourWriteRepository TaxFeePerHourWriteRepository { get; }
        ITaxPaidWriteRepository TaxPaidWriteRepository { get; }
        ITollFreeVehicleWriteRepository TollFreeVehicleWriteRepository { get; }
        ITollingStationWriteRepository TollingStationWriteRepository { get; }
        IVehicleCategoryWriteRepository VehicleCategoryWriteRepository { get; }
        IYearWriteRepository YearWriteRepository { get; }
    }
}

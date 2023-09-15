using Domain;
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
using Infrastructure.Domain.Cars;
using Infrastructure.Domain.Cities;
using Infrastructure.Domain.Countries;
using Infrastructure.Domain.Currencies;
using Infrastructure.Domain.Holidays;
using Infrastructure.Domain.MaximumTaxes;
using Infrastructure.Domain.TaxFeePerHours;
using Infrastructure.Domain.TaxPaids;
using Infrastructure.Domain.TollFreeVehicles;
using Infrastructure.Domain.TollingStations;
using Infrastructure.Domain.VehicleCategories;
using Infrastructure.Domain.Years;

namespace Infrastructure
{
    public class WriteUnitOfWork : BaseUnitOfWork, IWriteUnitOfWork
    {
        public WriteUnitOfWork(AppDbContext context) : base(context)
        {

        }
        private CarWriteRepository _carWriteRepository;
        public ICarWriteRepository CarWriteRepository
        {
            get
            {
                return _carWriteRepository ??= new CarWriteRepository(DbContext());
            }
        }

        private CityWriteRepository _cityWriteRepository;
        public ICityWriteRepository CityWriteRepository
        {
            get
            {
                return _cityWriteRepository ??= new CityWriteRepository(DbContext());
            }
        }
        private CountryWriteRepository _countryWriteRepository;
        public ICountryWriteRepository CountryWriteRepository
        {
            get
            {
                return _countryWriteRepository ??= new CountryWriteRepository(DbContext());
            }
        }
        private CurrencyWriteRepository _currencyWriteRepository;
        public ICurrencyWriteRepository CurrencyWriteRepository
        {
            get
            {
                return _currencyWriteRepository ??= new CurrencyWriteRepository(DbContext());
            }
        }
        private HolidayWriteRepository _holidayWriteRepository;
        public IHolidayWriteRepository HolidayWriteRepository
        {
            get
            {
                return _holidayWriteRepository ??= new HolidayWriteRepository(DbContext());
            }
        }
        private MaximumTaxWriteRepository _maximumTaxWriteRepository;
        public IMaximumTaxWriteRepository MaximumTaxWriteRepository
        {
            get
            {
                return _maximumTaxWriteRepository ??= new MaximumTaxWriteRepository(DbContext());
            }
        }
        private TaxFeePerHourWriteRepository _taxFeePerHourWriteRepository;
        public ITaxFeePerHourWriteRepository TaxFeePerHourWriteRepository
        {
            get
            {
                return _taxFeePerHourWriteRepository ??= new TaxFeePerHourWriteRepository(DbContext());
            }
        }
        private TaxPaidWriteRepository _taxPaidWriteRepository;
        public ITaxPaidWriteRepository TaxPaidWriteRepository
        {
            get
            {
                return _taxPaidWriteRepository ??= new TaxPaidWriteRepository(DbContext());
            }
        }
        private TollFreeVehicleWriteRepository _tollFreeVehicleWriteRepository;
        public ITollFreeVehicleWriteRepository TollFreeVehicleWriteRepository
        {
            get
            {
                return _tollFreeVehicleWriteRepository ??= new TollFreeVehicleWriteRepository(DbContext());
            }
        }
        private TollingStationWriteRepository _tollingStationWriteRepository;
        public ITollingStationWriteRepository TollingStationWriteRepository
        {
            get
            {
                return _tollingStationWriteRepository ??= new TollingStationWriteRepository(DbContext());
            }
        }
        private VehicleCategoryWriteRepository _vehicleCategoryWriteRepository;
        public IVehicleCategoryWriteRepository VehicleCategoryWriteRepository
        {
            get
            {
                return _vehicleCategoryWriteRepository ??= new VehicleCategoryWriteRepository(DbContext());
            }
        }
        private YearWriteRepository _yearWriteRepository;
        public IYearWriteRepository YearWriteRepository
        {
            get
            {
                return _yearWriteRepository ??= new YearWriteRepository(DbContext());
            }
        }
    }
}

using AutoMapper;
using Domain;
using Domain.Entities.Cars;
using Domain.Entities.Cities;
using Domain.Entities.Countries;
using Domain.Entities.Currencies;
using Domain.Entities.Holidays;
using Domain.Entities.MaximumTaxes;
using Domain.Entities.StationPasses;
using Domain.Entities.TaxFeePerHours;
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
using Infrastructure.Domain.StationPasses;
using Infrastructure.Domain.TaxFeePerHours;
using Infrastructure.Domain.TollFreeVehicles;
using Infrastructure.Domain.TollingStations;
using Infrastructure.Domain.VehicleCategories;
using Infrastructure.Domain.Years;

namespace Infrastructure
{
    public class ReadUnitOfWork : BaseReadUnitOfWork, IReadUnitOfWork
    {
        private readonly IMapper _mapper;
        public ReadUnitOfWork(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private CarReadRepository _carReadRepository;
        public ICarReadRepository CarReadRepository
        {
            get
            {
                return _carReadRepository ?? new CarReadRepository(DbContext(),_mapper);
            }
        }

        private CityReadRepository _cityReadRepository;
        public ICityReadRepository CityReadRepository
        {
            get
            {
                return _cityReadRepository ?? new CityReadRepository(DbContext(), _mapper);
            }
        }

        private CountryReadRepository _countryReadRepository;
        public ICountryReadRepository CountryReadRepository
        {
            get
            {
                return _countryReadRepository ?? new CountryReadRepository(DbContext(), _mapper);
            }
        }

        private CurrencyReadRepository _currencyReadRepository;
        public ICurrencyReadRepository CurrencyReadRepository
        {
            get
            {
                return _currencyReadRepository ?? new CurrencyReadRepository(DbContext(), _mapper);
            }
        }
        
        private HolidayReadRepository _holidayReadRepository;
        public IHolidayReadRepository HolidayReadRepository
        {
            get
            {
                return _holidayReadRepository ?? new HolidayReadRepository(DbContext(), _mapper);
            }
        }
        private MaximumTaxReadRepository _maximumTaxReadRepository;
        public IMaximumTaxReadRepository MaximumTaxReadRepository
        {
            get
            {
                return _maximumTaxReadRepository ?? new MaximumTaxReadRepository(DbContext(), _mapper);
            }
        }

        private TaxFeePerHourReadRepository _taxFeePerHourReadRepository;
        public ITaxFeePerHourReadRepository TaxFeePerHourReadRepository
        {
            get
            {
                return _taxFeePerHourReadRepository ?? new TaxFeePerHourReadRepository(DbContext(), _mapper);
            }
        }

        private StationPassReadRepository _taxPaidReadRepository;
        public IStationPassReadRepository StationPassReadRepository
        {
            get
            {
                return _taxPaidReadRepository ?? new StationPassReadRepository(DbContext(), _mapper);
            }
        }

        private TollFreeVehicleReadRepository _tollFreeVehicleReadRepository;
        public ITollFreeVehicleReadRepository TollFreeVehicleReadRepository
        {
            get
            {
                return _tollFreeVehicleReadRepository ?? new TollFreeVehicleReadRepository(DbContext(), _mapper);
            }
        }
        private TollingStationReadRepository _tollingStationReadRepository;
        public ITollingStationReadRepository TollingStationReadRepository
        {
            get
            {
                return _tollingStationReadRepository ?? new TollingStationReadRepository(DbContext(), _mapper);
            }
        }
        private VehicleCategoryReadRepository _vehicleCategoryReadRepository;
        public IVehicleCategoryReadRepository VehicleCategoryReadRepository
        {
            get
            {
                return _vehicleCategoryReadRepository ?? new VehicleCategoryReadRepository(DbContext(), _mapper);
            }
        }
        private YearReadRepository _yearReadRepository;
        public IYearReadRepository YearReadRepository
        {
            get
            {
                return _yearReadRepository ?? new YearReadRepository(DbContext(), _mapper);
            }
        }
    }
}

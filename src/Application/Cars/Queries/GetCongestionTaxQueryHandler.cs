using AutoMapper;
using Domain;
using Domain.Entities.TaxFeePerHours.Dtos;
using Domain.SeedWork;
using MediatR;

namespace Application.Cars.Queries
{
    public class GetCongestionTaxQueryHandler : IRequestHandler<GetCongestionTaxQuery, CongestionTaxResult>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly ITaxService _taxService;

        public GetCongestionTaxQueryHandler(ITaxService taxService, IReadUnitOfWork readUnitOfWork)
        {
            _taxService = taxService;
            _readUnitOfWork = readUnitOfWork;
        }

        public async Task<CongestionTaxResult> Handle(GetCongestionTaxQuery request, CancellationToken cancellationToken)
        {
            var car = await _readUnitOfWork.CarReadRepository.GetCar(request.CarId);
            if (car == null)
            {
                throw new Exception(AppConstants.CarNotFound);
            }

            var city = await _readUnitOfWork.CityReadRepository.GetByIdAsync(request.CityId);
            if (city == null)
            {
                throw new Exception(AppConstants.CityNotFound);
            }

            var result = new CongestionTaxResult();
            result.CarId = car.Id;
            result.CarPlate = car.PlateNumber;

            // Check tax exempt vehicles
            bool isFree = await _readUnitOfWork
                .TollFreeVehicleReadRepository.IsTollFreeVehicle(car.VehicleCategoryId);

            if (isFree)
            {
                result.TotalTaxAmount = 0;
                return result;
            }

            var holidays = await _readUnitOfWork
                .HolidayReadRepository.GetHolidays(request.Year, city.CountryId);

            List<DateTime> passDates = await _readUnitOfWork
                .StationPassReadRepository
                .GetGatePassesTimes(car.Id, holidays);

            var taxFees = await _readUnitOfWork
                .TaxFeePerHourReadRepository.GetTaxRates(city.Id, request.Year, passDates);

            decimal maximumTax = await _readUnitOfWork.MaximumTaxReadRepository
                                                    .GetMaximumTaxReadAsync(city.Id);

            result.TotalTaxAmount = _taxService.GetTax(taxFees, maximumTax);

            return result;
        }
    }
}

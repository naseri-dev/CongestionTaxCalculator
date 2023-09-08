﻿using Domain.Entities.Cars;
using Domain.Entities.Cities;
using Domain.Entities.Countries;
using Domain.Entities.Currencies;
using Domain.Entities.Holidays;
using Domain.Entities.MaximumTaxes;
using Domain.Entities.TaxFeePerHours;
using Domain.Entities.TollFreeVehicles;
using Domain.Entities.TollingStations;
using Domain.Entities.VehicleCategories;
using Domain.Entities.Years;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class SeedData
{
    public static void Initalizer(IServiceProvider serviceProvider)
    {
        using (var dbContext = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            dbContext.Database.Migrate();

            if (!dbContext.Countries.Any())
            {
                Guid countryId = Guid.NewGuid();
                dbContext.Countries.Add(new Country
                {
                    Id = countryId,
                    Name = "Sweden"
                });
                Guid cityId = Guid.NewGuid();
                dbContext.Cities.Add(new City
                {
                    Id = cityId,
                    CountryId = countryId,
                    Name = "Gothenburg"
                });
                Guid yearId = Guid.NewGuid();
                dbContext.Years.Add(new Year
                {
                    Id = yearId,
                    Value = 2013
                });
                dbContext.MaximumTaxes.Add(
                    new MaximumTax
                    {
                        YearId = yearId,
                        CityId = cityId,
                        Amount = 60
                    });
                Guid currencyId = Guid.NewGuid();
                dbContext.Currencies.Add(new Currency
                {
                    Id = currencyId,
                    Name = "Sweden Krona",
                    Code = "SEK",
                    Symbol = "kr"
                });
                dbContext.TaxFeePerHours.AddRange(
                    new List<TaxFeePerHour>
                    {
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 6,
                            FromMinute = 0,
                            ToHour = 6,
                            ToMinute = 29,
                            TaxAmount = 8
                        },
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 6,
                            FromMinute = 30,
                            ToHour = 6,
                            ToMinute = 59,
                            TaxAmount = 13
                        },
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 7,
                            FromMinute = 0,
                            ToHour = 7,
                            ToMinute = 59,
                            TaxAmount = 18
                        },
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 8,
                            FromMinute = 0,
                            ToHour = 8,
                            ToMinute = 29,
                            TaxAmount = 13
                        },
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 8,
                            FromMinute = 30,
                            ToHour = 14,
                            ToMinute = 59,
                            TaxAmount = 8
                        },
                         new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 15,
                            FromMinute = 00,
                            ToHour = 15,
                            ToMinute = 29,
                            TaxAmount = 13
                        },
                       new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 15,
                            FromMinute = 30,
                            ToHour = 16,
                            ToMinute = 59,
                            TaxAmount = 18
                        },
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 17,
                            FromMinute = 00,
                            ToHour = 17,
                            ToMinute = 59,
                            TaxAmount = 13
                        },
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 18,
                            FromMinute = 00,
                            ToHour = 18,
                            ToMinute = 29,
                            TaxAmount = 8
                        },
                        new TaxFeePerHour
                        {
                            Id = Guid.NewGuid(),
                            CityId = cityId,
                            YearId = yearId,
                            CurrencyId = currencyId,
                            FromHour = 18,
                            FromMinute = 30,
                            ToHour = 5,
                            ToMinute = 59,
                            TaxAmount = 0
                        }
                    });

                var fromDate = new DateTime(2013, 07, 01);
                var toDate = new DateTime(2013, 07, 31);

                for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                {
                    dbContext.Holidays.Add(
                        new Holiday
                        {
                            Id = Guid.NewGuid(),
                            CountryId = countryId,
                            YearId = yearId,
                            HolidayType = HolidayType.SpecificDate,
                            Date = date,
                        });
                }
                // Saturday and Sundays
                fromDate = new DateTime(2013, 1, 1);
                toDate = new DateTime(2013, 12, 31);

                for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        dbContext.Holidays.Add(
                           new Holiday
                           {
                               Id = Guid.NewGuid(),
                               CountryId = countryId,
                               YearId = yearId,
                               HolidayType = HolidayType.Weekend,
                               Date = date,
                           });
                }
                var publicHolidays = new List<DateTime>
                {
                    new DateTime(2013,1,1),// January

                    new DateTime(2013,3,29),// March

                    new DateTime(2013,4,1), // April

                    new DateTime(2013,5,1),// May
                    new DateTime(2013,5,9),

                    new DateTime(2013,6,6),// June

                    new DateTime(2013,11,2),// November

                    new DateTime(2013,12,25),// December
                    new DateTime(2013,12,26),
                };
                foreach (var date in publicHolidays)
                {
                    dbContext.Holidays.Add(
                           new Holiday
                           {
                               Id = Guid.NewGuid(),
                               CountryId = countryId,
                               YearId = yearId,
                               HolidayType = HolidayType.Public,
                               Date = date,
                           });

                    if ((date.Month == 1 && date.Day == 1) || (date.Month == 12 && date.Day == 26))
                        continue;

                    dbContext.Holidays.Add(
                           new Holiday
                           {
                               Id = Guid.NewGuid(),
                               CountryId = countryId,
                               YearId = yearId,
                               HolidayType = HolidayType.SpecificDate,
                               Date = date.AddDays(-1),
                           });
                }

                Guid northGuid = Guid.NewGuid();
                Guid stGuid = Guid.NewGuid();
                dbContext.TollingStations.AddRange(new List<TollingStation>
                {
                    new TollingStation
                    {
                        Name = "Göteborg (Gothenburg) - North",
                        CityId = cityId,
                        Id = northGuid
                    },
                    new TollingStation
                    {
                        Name = "Göteborg (Gothenburg) - St12",
                        CityId = cityId,
                        Id = stGuid
                    }
                }
                    );

                var vehicleCategories = new List<VehicleCategory>();
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Emergency" });
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Bus" });
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Diplomat" });
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Motorcycle" });
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Military" });
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Foreign" });
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Tractor" });
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Personal" }); //7
                vehicleCategories.Add(new VehicleCategory { Id = Guid.NewGuid(), Name = "Taxi" });

                dbContext.VehicleCategories.AddRange(vehicleCategories);

                var cars = new List<Car>();
                cars.Add(new Car("ABC 123",vehicleCategories[0].Id,true));
                cars.Add(new Car("BAD 12A",vehicleCategories[1].Id,true));
                cars.Add(new Car("ASE 52D",vehicleCategories[2].Id,true));
                cars.Add(new Car("GHF 54G",vehicleCategories[3].Id,true));
                cars.Add(new Car("KJH 54A",vehicleCategories[4].Id,true));
                cars.Add(new Car("HGJ 5GQ",vehicleCategories[5].Id,true));
                cars.Add(new Car("TSD 45J",vehicleCategories[6].Id,true));

                cars.Add(new Car("MBV 14S",vehicleCategories[7].Id,false));
                cars.Add(new Car("GHY 57W",vehicleCategories[8].Id,false));
                cars.Add(new Car("SXD 16Q",vehicleCategories[7].Id,false));
                cars.Add(new Car("LKU 2PE",vehicleCategories[7].Id,false));

                dbContext.Cars.AddRange(cars);

                dbContext.TollFreeVehicles.AddRange(new List<TollFreeVehicle>
                {
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[0].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[1].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[2].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[3].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[4].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[5].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[6].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[7].Id},
                    new TollFreeVehicle{ Id = Guid.NewGuid(),CityId = cityId,CarId = cars[8].Id},

                });
            }

            dbContext.SaveChanges();
        }
    }
}

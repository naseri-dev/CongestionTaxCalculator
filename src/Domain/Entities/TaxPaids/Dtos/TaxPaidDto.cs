﻿using Domain.Entities.Cars.Dtos;
using Domain.Entities.TollingStations.Dtos;

namespace Domain.Entities.TaxPaids.Dtos;

public class TaxPaidDto
{
    public Guid Id { get; set; }
    public Guid TollingStationId { get; set; }
    public TollingStationDto TollingStationDto { get; set; }
    public Guid CarId { get; set; }
    public CarDto CarDto { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

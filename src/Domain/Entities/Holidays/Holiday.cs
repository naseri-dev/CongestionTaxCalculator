using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Countries;
using Domain.Entities.Years;
using Domain.Enums;
using Domain.SeedWork;

namespace Domain.Entities.Holidays
{
    public class Holiday : BaseEntity
    {
        public Guid YearId { get; set; }
        public Year Year { get; set; }
        public Country Country { get; set; }
        public Guid CountryId { get; set; }
        public DateTime Date { get; set; }
        public HolidayType HolidayType { get; set; }
    }
}

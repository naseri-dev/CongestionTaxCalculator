using Domain.Entities.TaxFeePerHours;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class TaxFeePerHourConfiguration : IEntityTypeConfiguration<TaxFeePerHour>
    {
        public void Configure(EntityTypeBuilder<TaxFeePerHour> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}

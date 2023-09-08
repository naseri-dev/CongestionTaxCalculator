using Domain.Entities.MaximumTaxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class MaximumTaxConfiguration : IEntityTypeConfiguration<MaximumTax>
    {
        public void Configure(EntityTypeBuilder<MaximumTax> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Amount)
                .IsRequired();
        }
    }
}

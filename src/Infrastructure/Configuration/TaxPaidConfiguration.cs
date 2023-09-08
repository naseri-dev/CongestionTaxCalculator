using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class TaxPaidConfiguration : IEntityTypeConfiguration<TaxPaid>
    {
        public void Configure(EntityTypeBuilder<TaxPaid> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Amount)
                .IsRequired();
        }
    }
}

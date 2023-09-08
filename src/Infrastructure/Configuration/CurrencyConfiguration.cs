using Domain.Entities.Currencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Code)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(u => u.Symbol)
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}

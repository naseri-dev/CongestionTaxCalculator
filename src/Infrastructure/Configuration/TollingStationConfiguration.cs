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
    public class TollingStationConfiguration : IEntityTypeConfiguration<TollingStation>
    {
        public void Configure(EntityTypeBuilder<TollingStation> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

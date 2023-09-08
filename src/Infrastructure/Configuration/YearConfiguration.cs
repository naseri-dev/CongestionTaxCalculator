using Domain.Entities.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class YearConfiguration : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Value)
                .HasMaxLength(4)
                .IsRequired();
        }
    }
}

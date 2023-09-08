using Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PlateNumber)
                .HasMaxLength(14)
                .IsRequired();
        }
    }
}

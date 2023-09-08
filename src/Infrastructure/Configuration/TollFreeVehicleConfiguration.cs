using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TollFreeVehicleConfiguration : IEntityTypeConfiguration<TollFreeVehicle>
    {
        public void Configure(EntityTypeBuilder<TollFreeVehicle> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}

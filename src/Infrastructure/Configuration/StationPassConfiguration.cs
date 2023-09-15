using Domain.Entities.StationPasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class StationPassConfiguration : IEntityTypeConfiguration<StationPass>
    {
        public void Configure(EntityTypeBuilder<StationPass> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("lkLocations");

            builder.HasKey(ci => ci.LocationId);
            builder.Property(ci => ci.LocationId).IsRequired();
            builder.Property(ci => ci.Description).HasMaxLength(50).IsRequired();
        }
    }
}

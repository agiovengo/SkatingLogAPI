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

            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).HasColumnType("int").IsRequired();
            builder.Property(ci => ci.Description).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}

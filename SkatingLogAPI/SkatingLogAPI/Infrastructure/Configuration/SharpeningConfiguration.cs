using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class SharpeningConfiguration : IEntityTypeConfiguration<Sharpening>
    {
        public void Configure(EntityTypeBuilder<Sharpening> builder)
        {
            builder.ToTable("SharpeningEntry");

            builder.HasKey(ci => ci.SharpeningEntryId);
            builder.Property(ci => ci.SharpeningEntryId).IsRequired();
            builder.Property(ci => ci.LastSharpeningDate).IsRequired();
        }
    }
}

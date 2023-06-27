using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class SharpeningRecordConfiguration : IEntityTypeConfiguration<SharpeningRecord>
    {
        public void Configure(EntityTypeBuilder<SharpeningRecord> builder)
        {
            builder.ToTable("SharpeningRecord");

            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).HasColumnType("int").IsRequired();
            builder.Property(ci => ci.Date).HasColumnType("datetime2(7)").IsRequired();
        }
    }
}

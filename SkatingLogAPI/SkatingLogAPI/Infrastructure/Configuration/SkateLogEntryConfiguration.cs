using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkatingLogAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class SkatingLogEntryEntityTypeConfiguration : IEntityTypeConfiguration<SkatingLogEntry>
    {
        public void Configure(EntityTypeBuilder<SkatingLogEntry> builder)
        {
            builder.ToTable("SkatingLogEntry");

            builder.HasKey(ci => ci.EntryId);

            builder.Property(ci => ci.EntryId).UseIdentityColumn();

            builder.Property(ci => ci.EntryDateTime)
                .IsRequired();

            builder.Property(ci => ci.StartDateTime)
                .IsRequired();

            builder.Property(ci => ci.StopDateTime)
                .IsRequired();

            builder.Property(ci => ci.BasicDescription)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(ci => ci.DetailedDescription)
                .HasMaxLength(1024);

            builder.Property(ci => ci.TotalTimeMinutes)
                .HasComputedColumnSql()
                .IsRequired();

            builder.HasOne(l => l.Location)
                .WithMany(e => e.SkatingLogEntries)
                .HasForeignKey(l => l.LocationId)
                .IsRequired();

            builder.HasOne(c => c.Classification)
                .WithMany(e => e.SkatingLogEntries)
                .HasForeignKey(c => c.ClassificationId)
                .IsRequired();

            builder.HasOne(s => s.Subclass)
                .WithMany(e => e.SkatingLogEntries)
                .HasForeignKey(s => s.SubclassId)
                .IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkatingLogAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class LogEntryEntityTypeConfiguration : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.ToTable("LogEntry");

            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).HasColumnType("int").IsRequired().UseIdentityColumn();
            builder.Property(ci => ci.CreatedDateTime).HasColumnType("datetime2(7)").IsRequired();
            builder.Property(ci => ci.StartDateTime).HasColumnType("datetime2(7)").IsRequired();
            builder.Property(ci => ci.StopDateTime).HasColumnType("datetime2(7)").IsRequired();
            builder.Property(ci => ci.RecordTypeId).HasColumnType("int").IsRequired();
            builder.Property(ci => ci.LocationId).HasColumnType("int").IsRequired();
            builder.Property(ci => ci.BasicDescription).HasColumnType("varchar(500)").HasMaxLength(500).IsRequired();
            builder.Property(ci => ci.DetailedDescription).HasColumnType("varchar(1024)").HasMaxLength(1024);
            builder.Property(ci => ci.LevelStateId).HasColumnType("int").IsRequired();
            builder.Property(ci => ci.IsOnIce).HasColumnType("bit").IsRequired();
            builder.Property(ci => ci.TotalTimeMinutes).HasComputedColumnSql();

            builder.HasOne(l => l.Location).WithMany(e => e.LogEntries).HasForeignKey(l => l.LocationId).IsRequired();
            builder.HasOne(s => s.RecordType).WithMany(e => e.LogEntries).HasForeignKey(s => s.RecordTypeId).IsRequired();
            builder.HasOne(s => s.LevelState).WithMany(e => e.LogEntries).HasForeignKey(s => s.LevelStateId).IsRequired();
        }
    }
}
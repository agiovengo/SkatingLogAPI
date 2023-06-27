using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class LevelStateConfiguration : IEntityTypeConfiguration<LevelState>
    {
        public void Configure(EntityTypeBuilder<LevelState> builder)
        {
            builder.ToTable("LevelState");

            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).HasColumnType("int").IsRequired();
            builder.Property(ci => ci.Date).HasColumnType("datetime2(7)").IsRequired();
            builder.Property(ci => ci.FreestyleLevel).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(ci => ci.DanceLevel).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(ci => ci.PairsLevel).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}

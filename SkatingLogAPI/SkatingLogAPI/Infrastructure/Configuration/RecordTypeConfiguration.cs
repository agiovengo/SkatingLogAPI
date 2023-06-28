using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class RecordTypeConfiguration : IEntityTypeConfiguration<RecordType>
    {
        public void Configure(EntityTypeBuilder<RecordType> builder)
        {
            builder.ToTable("lkRecordTypes");

            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).HasColumnType("int").IsRequired();
            builder.Property(ci => ci.Description).HasColumnType("varcar(50)").HasMaxLength(50).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class SubclassConfiguration : IEntityTypeConfiguration<Subclass>
    {
        public void Configure(EntityTypeBuilder<Subclass> builder)
        {
            builder.ToTable("lkSubclasses");

            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).IsRequired();
            builder.Property(ci => ci.Description).HasMaxLength(50).IsRequired();
            builder.Property(ci => ci.Classification).IsRequired();
        }
    }
}

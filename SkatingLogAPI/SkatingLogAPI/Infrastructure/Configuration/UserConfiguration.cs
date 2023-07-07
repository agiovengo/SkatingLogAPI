    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("int").IsRequired();
            builder.Property(u => u.Username).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(u => u.FirstName).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasColumnType("nvarchar(255)").HasMaxLength(255).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("varbinary(max)").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnType("varbinary(max)").IsRequired();
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}

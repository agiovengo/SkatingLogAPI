using SkatingLogAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace SkatingLogAPI.Contexts
{
    public class SkatingLogDBContext : DbContext
    {
        // ctor allows databaseoptions to inherit authentication setup from Program.cs
        public SkatingLogDBContext(DbContextOptions<SkatingLogDBContext> options) : base(options)
        {

        }

        // Set Db prevents null
        public DbSet<SkatingLogEntry> SkatingLogEntries { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Subclass> Subclasses { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkatingLogDBContext).Assembly);
        }
    }
}

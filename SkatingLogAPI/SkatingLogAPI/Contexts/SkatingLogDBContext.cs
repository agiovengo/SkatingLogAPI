using SkatingLogAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace SkatingLogAPI.Contexts
{
    public class dBContext : DbContext
    {
        // ctor allows databaseoptions to inherit authentication setup from Program.cs
        public dBContext(DbContextOptions<dBContext> options) : base(options)
        {

        }

        // Set Db prevents null
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<RecordType> RecordTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LevelState> LevelStates { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(dBContext).Assembly);
        }
    }
}

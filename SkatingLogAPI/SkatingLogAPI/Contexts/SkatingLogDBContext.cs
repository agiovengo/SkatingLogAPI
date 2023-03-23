using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SkatingLogAPI.Models;

namespace SkatingLogAPI.Contexts
{
    public class SkatingLogDBContext : DbContext
    {
        public DbSet<SkatingLogEntry> SkatingLogEntries { get; set; }
        public DbSet<DetailedDescription> DetailedDescriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Define the primary keys
            modelBuilder.Entity<SkatingLogEntry>()
                .HasKey(e => e.EntryId);
            modelBuilder.Entity<DetailedDescription>()
                .HasKey(e => e.DetailedDescriptionId);

            // Define the foreign key constraint
            modelBuilder.Entity<DetailedDescription>()
                .HasRequired(e => e.SkatingLogEntry)
                .WithMany(e => e.DetailedDescriptions)
                .HasForeignKey(e => e.EntryId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}

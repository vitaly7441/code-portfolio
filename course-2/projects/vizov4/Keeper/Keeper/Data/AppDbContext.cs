using System;
using Keeper.Models;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<ActionHistory> ActionHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>()
                .HasMany(v => v.ActionHistories)
                .WithOne(a => a.Visitor)
                .HasForeignKey(a => a.VisitorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


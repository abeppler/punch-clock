using Microsoft.EntityFrameworkCore;
using PunchClock.Domain.Entities;

namespace PunchClock.Infra.Data
{
    public class PunchClockContext : DbContext
    {
        public PunchClockContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Punch> Punches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Punch>().ToTable("Punch");
        }
    }
}
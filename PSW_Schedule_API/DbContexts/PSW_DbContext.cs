using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PSW_Schedule_API.Data;
using PSW_Schedule_API.Models;

namespace PSW_Schedule_API.DbContexts
{
    public class PSW_DbContext : DbContext
    {
        public PSW_DbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>()
                .HasOne(x => x.Employee).WithMany(x => x.Schedules);

            new DbInitializer(modelBuilder).Seed();
        }
    }
}

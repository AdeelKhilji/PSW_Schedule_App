using Microsoft.EntityFrameworkCore;
using PSW_Schedule_API.Models;

namespace PSW_Schedule_API.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Employee>(e =>
            {
                e.HasData(new Employee
                {
                    Id = 1,
                    Name = "Samantha",
                });
                e.HasData(new Employee
                {
                    Id = 2,
                    Name = "Jin Ling",
                });
                e.HasData(new Employee
                {
                    Id = 3,
                    Name = "Martha",
                });
            });

            _modelBuilder.Entity<Schedule>(s =>
            {
                s.HasData(new Schedule
                {
                    Id = 1,
                    ClientName = "XinGao",
                    EmployeeId = 1,
                });
                s.HasData(new Schedule
                {
                    Id = 2,
                    ClientName = "ChinLee",
                    EmployeeId = 1,
                });
                s.HasData(new Schedule
                {
                    Id = 3,
                    ClientName = "Mathew",
                    EmployeeId = 2,
                });
                s.HasData(new Schedule
                {
                    Id = 4,
                    ClientName = "Zamana",
                    EmployeeId = 3,
                });
            });
        }
    }
}

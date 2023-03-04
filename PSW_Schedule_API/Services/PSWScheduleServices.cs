using Microsoft.EntityFrameworkCore;
using PSW_Schedule_API.DbContexts;
using PSW_Schedule_API.Models;

namespace PSW_Schedule_API.Services
{
    public class PSWScheduleServices : IPSWScheduleServices
    {
        private readonly PSW_DbContext _dbContext;

        public PSWScheduleServices(PSW_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //EMPLOYEE

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _dbContext.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Employee> GetEmployeeAsync(long id, bool includeSchedules)
        {
            try
            {
                if (includeSchedules)
                {
                    return await _dbContext.Employees.Include(s => s.Schedules)
                        .FirstOrDefaultAsync(i => i.Id == id);
                }

                return await _dbContext.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                return await _dbContext.Employees.FindAsync(employee.Id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool,string)> DeleteEmployeeAsync(Employee employee)
        {
            try
            {
                var dbEmployee = await _dbContext.Employees.FindAsync(employee.Id);
                if (dbEmployee == null)
                {
                    return (false, "Employee not found");
                }

                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();

                return (true, "Employee is deleted");
            }
            catch (Exception ex)
            {
                return (false, $"ERROR MESSAGE: {ex.Message}");
            }
        }

        //SCHEDULE

        public async Task<List<Schedule>> GetSchedulesAsync()
        {
            try
            {
                return await _dbContext.Schedules.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Schedule> GetScheduleAsync(long id)
        {
            try
            {
                return await _dbContext.Schedules.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Schedule> AddScheduleAsync(Schedule schedule)
        {
            try
            {
                await _dbContext.Schedules.AddAsync(schedule);
                await _dbContext.SaveChangesAsync();
                return await _dbContext.Schedules.FindAsync(schedule.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            try
            {
                _dbContext.Entry(schedule).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return schedule;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteScheduleAsync(Schedule schedule)
        {
            try
            {
                var dbSchedule = await _dbContext.Schedules.FindAsync(schedule.Id);

                if(dbSchedule == null)
                {
                    return (false, "Schedule not found");
                }
                _dbContext.Schedules.Remove(schedule);
                await _dbContext.SaveChangesAsync();

                return (true, "Schedule is deleted");
            }
            catch (Exception ex)
            {
                return (false,$"ERROR MESSAGE: {ex.Message}");
            }

        }
    }
}

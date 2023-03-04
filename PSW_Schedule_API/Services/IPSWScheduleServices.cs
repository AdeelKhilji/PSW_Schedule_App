using PSW_Schedule_API.Models;

namespace PSW_Schedule_API.Services
{
    public interface IPSWScheduleServices
    {
        // Employee Services
        Task<List<Employee>> GetEmployeesAsync();//Get all
        Task<Employee> GetEmployeeAsync(long id, bool includeSchedule = false); //getOne
        Task<Employee> AddEmployeeAsync(Employee employee);//POST
        Task<Employee> UpdateEmployeeAsync(Employee employee);//PUT
        Task<(bool, string)> DeleteEmployeeAsync(Employee employee);//DELETE

        // Schedule Services
        Task<List<Schedule>> GetSchedulesAsync();//GET ALL
        Task<Schedule> GetScheduleAsync(long id);//GET ONE
        Task<Schedule> AddScheduleAsync(Schedule schedule); //POST
        Task<Schedule> UpdateScheduleAsync(Schedule schedule);//PUT
        Task<(bool, string)> DeleteScheduleAsync(Schedule schedule);//DELETE
    }
}

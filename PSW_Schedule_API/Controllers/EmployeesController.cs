using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSW_Schedule_API.DbContexts;
using PSW_Schedule_API.Models;
using PSW_Schedule_API.Services;

namespace PSW_Schedule_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IPSWScheduleServices _PSWservices;

        public EmployeesController(IPSWScheduleServices pSWservices)
        {
            _PSWservices = pSWservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _PSWservices.GetEmployeesAsync(); ;

            if (employees == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "There are no Employees");
            }
            return StatusCode(StatusCodes.Status200OK, employees);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEmployee(int id, bool includeSchedule)
        {
            Employee employee = await _PSWservices.GetEmployeeAsync(id, includeSchedule);
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"There are no Employee at: {id}");
            }
            return StatusCode(StatusCodes.Status200OK, employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var dbEmployee = await _PSWservices.AddEmployeeAsync(employee);

            if (dbEmployee == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{employee.Name} could not be added");
            }
            return CreatedAtAction("GetEmployee", new {id = employee.Id},employee);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }
            var dbEmployee = await _PSWservices.UpdateEmployeeAsync(employee);

            if (dbEmployee == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{employee.Name} could not be updated");
            }
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _PSWservices.GetEmployeeAsync(id, false);
            (bool status, string message) = await _PSWservices.DeleteEmployeeAsync(employee);

            if(status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, employee);
        }
    }
}

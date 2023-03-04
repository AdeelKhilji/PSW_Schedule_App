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
    public class SchedulesController : ControllerBase
    {
        private readonly IPSWScheduleServices _PSWservices;

        public SchedulesController(IPSWScheduleServices pSWservices)
        {
            _PSWservices = pSWservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            var schedules = await _PSWservices.GetSchedulesAsync(); ;

            if (schedules == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "There are no Schedules");
            }
            return StatusCode(StatusCodes.Status200OK, schedules);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetSchedule(long id)
        {
            Schedule schedule = await _PSWservices.GetScheduleAsync(id);
            if (schedule == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"There are no Schedule at: {id}");
            }
            return StatusCode(StatusCodes.Status200OK, schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> AddSchedule(Schedule schedule)
        {
            var dbSchedule = await _PSWservices.AddScheduleAsync(schedule);

            if (dbSchedule == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{schedule.ClientName} could not be updated");
            }
            return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Schedule>> UpdateSchedule(long id, Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }
            var dbSchedule = await _PSWservices.UpdateScheduleAsync(schedule);

            if (dbSchedule == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{schedule.ClientName} could not be updated");
            }
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSchedule(long id)
        {
            var schedule = await _PSWservices.GetScheduleAsync(id);
            (bool status, string message) = await _PSWservices.DeleteScheduleAsync(schedule);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, schedule);
        }
    }
}

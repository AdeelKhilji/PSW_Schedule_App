using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSW_Schedule_API.Models
{
    public class Employee
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Name { get; set; }
        // One-to-many relationship with Schedule
        public IList<Schedule>? Schedules { get; set; } = new List<Schedule>();
        //public IList<Schedule>? Schedules { get; set; }
    }
}

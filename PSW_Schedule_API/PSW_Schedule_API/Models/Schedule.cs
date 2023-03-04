using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSW_Schedule_API.Models
{
    public class Schedule
    {
        [Key]
        public long Id { get; set; }
        public string? ClientName { get; set; }
        
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

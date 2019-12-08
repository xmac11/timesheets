using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class TimesheetEntry
    {
        public int Id { get; set; }
        public MyUser RelatedUser { get; set; }
        public Project RelatedProject { get; set; }
        public DateTime DateCreated { get; set; }
        public int HoursWorked { get; set; }
    }
}

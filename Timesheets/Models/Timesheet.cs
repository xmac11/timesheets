using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Timesheet
    {
        public long TimesheetId { get; set; }

        // one-to-one (timesheet - user}
        //public long UserId { get; set; }
        //public long ProjectId { get;  set; }

        public DateTime DateCreated { get; set; }
        public int HoursWorked { get; set; }
    }
}

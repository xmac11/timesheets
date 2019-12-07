using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class TimesheetViewModel
    {
        [DisplayName("Enter employee Id")]
        public long EmployeeId { get; set; }

        [DisplayName("Enter project Id")]
        public long ProjectId { get; set; }

        [DisplayName("Enter date started")]
        public DateTime DateStarted { get; set; }

        [DisplayName("Enter hours worked")]
        public int HoursWorked { get; set; }
    }
}

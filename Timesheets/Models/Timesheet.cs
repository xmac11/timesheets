﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Timesheet
    {
        public long TimesheetId { get; set; }

        // one-to-many (timesheet - user}
        public long UserId { get; set; }
        public User User { get; set; }

        // many to one
        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime DateStarted { get; set; }
        public int HoursWorked { get; set; }
    }
}
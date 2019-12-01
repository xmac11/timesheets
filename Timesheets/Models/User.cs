using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class User
    {
        public long UserId { get; set; }
        public Timesheet Timesheet { get; set; }
    }
}

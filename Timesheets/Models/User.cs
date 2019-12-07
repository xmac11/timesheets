using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class User
    {
        public long UserId { get; set; }

        // many-to-one (Department)
        public long DepartmentId { get; set; }
        public Department Department { get; set; }

        // many-to-one (Timesheet)
        public IList<Timesheet> Timesheets { get; set; }
    }
}

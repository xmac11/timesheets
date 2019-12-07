using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Project
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }

        // one project can be done by many deparments
        public IList<ProjectDepartment> RelatedDeparments { get; set; }

        // one project is owned by one deparment
        public long OwnerDeparmentId { get; set; }
        public Department OwnerDeparment { get; set; }

        // one to many
        public IList<Timesheet> Timesheets { get; set; }
    }
}

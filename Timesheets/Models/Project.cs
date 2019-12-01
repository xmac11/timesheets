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
        // one department works on many projects
        public IList<ProjectDepartment> RelatedDeparments { get; set; }
    }
}

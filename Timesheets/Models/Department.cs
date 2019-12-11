using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Department
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string DepartmentHeadId { get; set; }
        public virtual MyUser DepartmentHead { get; set; }

        public virtual ICollection<MyUser> RelatedUsers { get; set; }
        // one department works on many projects
        public virtual ICollection<DepartmentProject> Projects { get; set; }

        // one deparment onws many projects
        public virtual ICollection<Project> OwnedProjects { get; set; }
    }
}

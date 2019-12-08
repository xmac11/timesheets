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
        public MyUser DepartmentHead { get; set; }

        public ICollection<MyUser> RelatedUsers { get; set; }
        public ICollection<DepartmentProject> Projects { get; set; }
    }
}

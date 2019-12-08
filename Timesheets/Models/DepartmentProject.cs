using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class DepartmentProject
    {
        public Department Department {get; set;}
        public int DepartmentId { get; set; }

        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}

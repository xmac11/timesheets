using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class DepartmentProject
    {
        public int DepartmentId { get; set; }
        public virtual Department Department {get; set;}

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}

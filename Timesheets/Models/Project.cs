using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Project
    {
        public Project(string name, Department ownerDept)
        {
            Name = name;
            OwnerDept = ownerDept;
        }

        public Project(int id, string name, Department ownerDept)
        {
            Id = id;
            Name = name;
            OwnerDept = ownerDept;
        }

        public Project() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerDeptId { get; set; }
        public virtual Department OwnerDept { get; set; }

        public virtual ICollection<DepartmentProject> Departments { get; set; }
    }
}

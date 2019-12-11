﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Department OwnerDept { get; set; }

        public virtual ICollection<DepartmentProject> Departments { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class MyUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public double CostPerHour { get; set; }
        public string ManagerId { get; set; }
        public virtual MyUser Manager { get; set; }
        public virtual ICollection<TimesheetEntry> TimesheetEntries { get; set; }
    }
}

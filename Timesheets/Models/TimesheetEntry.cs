using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class TimesheetEntry
    {
        public TimesheetEntry(MyUser relatedUser, Project relatedProject, DateTime dateCreated, int hoursWorked)
        {
            RelatedUser = relatedUser;
            RelatedProject = relatedProject;
            DateCreated = dateCreated;
            HoursWorked = hoursWorked;
        }

        public TimesheetEntry(int id, MyUser relatedUser, Project relatedProject, DateTime dateCreated, int hoursWorked)
        {
            Id = id;
            RelatedUser = relatedUser;
            RelatedProject = relatedProject;
            DateCreated = dateCreated;
            HoursWorked = hoursWorked;
        }

        public TimesheetEntry() { }

        public int Id { get; set; }
        public virtual MyUser RelatedUser { get; set; }
        public virtual Project RelatedProject { get; set; }
        public DateTime DateCreated { get; set; }
        public int HoursWorked { get; set; }
    }
}

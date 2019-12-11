using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class TimesheetEntryViewModel
    {

        public List<string> Users { get; set; } = new List<string>();
        public List<string> Projects { get; set; } = new List<string>();

        [DisplayName("Select employee")]
        public string RelatedUserName { get; set; }

        [DisplayName("Enter project Id")]
        public long ProjectId { get; set; }

        [DisplayName("Enter date started")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Enter hours worked")]
        [Range(1, 24)]
        public int HoursWorked { get; set; }
    }
}

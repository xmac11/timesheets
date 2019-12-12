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
        // will be populated with all usersnames for the drop-down list
        public List<string> UserNames { get; set; } = new List<string>();
        // will be populated with all project names for the drop-down list
        public List<string> ProjectNames { get; set; } = new List<string>();

        public int Id { get; set; }

        [DisplayName("Select employee")]
        [Required(ErrorMessage = "You must select an employee")]
        public string RelatedUserName { get; set; }

        [DisplayName("Select project")]
        [Required (ErrorMessage = "You must select a project")]
        public string ProjectName { get; set; }

        [DisplayName("Enter date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RestrictedDate (ErrorMessage = "Date must be in current year and must not be in the future")]
        [Required(ErrorMessage = "You must enter a date")]
        public DateTime? DateCreated { get; set; }

        [DisplayName("Enter hours worked")]
        [Required(ErrorMessage = "You must enter the hours worked")]
        [Range(1, 24, ErrorMessage = "Enter a value between {1} and {2}")]
        public int HoursWorked { get; set; }
    }
}

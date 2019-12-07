using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class TimeSheetViewModel
    {
        [DisplayName("Enter User ID")]
        [Required(ErrorMessage = "You should enter the user's ID")]
        public long Usergghhj { get; set; }

        [DisplayName("Enter User ID")]
        [Required(ErrorMessage = "You should enter the project's ID")]
        public long Projectgghhj { get; set; }

        [DisplayName("Enter hours worked")]
        [Required(ErrorMessage = "You should enter worked hours")]
        public int HoursWorked { get; set; }
    }
}

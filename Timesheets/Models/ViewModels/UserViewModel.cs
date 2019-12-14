using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [DisplayName ("E-mail Address")]
        [Required (ErrorMessage = "Please enter e-mail address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName ("Roles")]
        [Required (ErrorMessage = "Please select at least one role")]
        public IList<string> Roles { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [DisplayName("Cost Per Hour")]
        [Required(ErrorMessage = "Please enter cost per hour")]
        public double CostPerHour { get; set; }

        [DisplayName("Manager")]
        public string ManagerId { get; set; }

        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
    }
}

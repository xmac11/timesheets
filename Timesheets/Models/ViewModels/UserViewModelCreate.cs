using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.ViewModels
{
    public class UserViewModelCreate
    {
        public string Id { get; set; }
        [DisplayName("Enter First Name")]
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [DisplayName("Enter Last Name")]
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        
        [DisplayName("Enter Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [DisplayName ("Enter e-mail Address")]
        [Required (ErrorMessage = "Please enter e-mail address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName ("Select Roles")]
        [Required (ErrorMessage = "Please select at least one role")]
        public IList<string> Roles { get; set; }

        [DisplayName("Select Department")]
        public int DepartmentId { get; set; }

        [DisplayName("Enter Cost Per Hour")]
        [Required(ErrorMessage = "Please enter cost per hour")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive value")]
        public double CostPerHour { get; set; }

        [DisplayName("Select Manager")]
        [Required(ErrorMessage = "Please select manager")]
        public string ManagerId { get; set; }
    }
}

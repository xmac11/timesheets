using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.ViewModels
{
    public class ProjectViewModel
    {

        // will be populated with all department names for the drop-down list (to choose the Owner Department)
        //public List<string> DepartmentNames { get; set; } = new List<string>();

        public int Id { get; set; }

        [DisplayName("Enter a project name")]
        [Required(ErrorMessage = "You must enter a name for the project")]
        public string Name { get; set; }

        [DisplayName("Select the owner department")]
        [Required(ErrorMessage = "You must select the owner department of the project")]
        public string OwnerDeptName { get; set; }

        [DisplayName("Add related departments")]
        public List<Department> RelatedDepartments { get; set; } = new List<Department>();

        [DisplayName("Add related users")]
        public List<string> RelatedUsers { get; set; }

        // bool isSelected (?)

    }
}

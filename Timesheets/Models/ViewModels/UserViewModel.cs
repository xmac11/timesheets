using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.ViewModels
{
    public class UserViewModel
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public double CostPerHour { get; set; }
        public string ManagerId { get; set; }
        public MyUser Manager { get; set; }

    }
}

namespace Timesheets.Models
{
    public class ProjectDepartment
    {
        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public long DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Models;

namespace Timesheets.Mappers
{
    public class TimesheetEntryMapper : ITimesheetEntryMapper
    {
        private readonly ApplicationDbContext _context;

        public TimesheetEntryMapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public TimesheetEntry MapViewModelToTimesheetEntry(TimesheetEntryViewModel viewModel) 
        {
            MyUser relatedUser = _context.Users.First(user => user.UserName.Equals(viewModel.RelatedUserName));
            Project relatedProject = _context.Projects.First(project => project.Name.Equals(viewModel.ProjectName));

            return new TimesheetEntry(viewModel.Id, relatedUser, relatedProject, viewModel.DateCreated ?? DateTime.Now, viewModel.HoursWorked);
        }
    }
}

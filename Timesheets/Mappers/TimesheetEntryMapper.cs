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
            MyUser relatedUser = AttachUserToTimesheet(viewModel);
            Project relatedProject = AttachProjectToTimesheet(viewModel);

            return new TimesheetEntry(viewModel.Id, relatedUser, relatedProject, viewModel.DateCreated ?? DateTime.Now, viewModel.HoursWorked);
        }

        // private helper
        private MyUser AttachUserToTimesheet(TimesheetEntryViewModel viewModel)
        {
            List<MyUser> users = _context.Users.ToList();
            // attach a User to the Timesheet 
            MyUser relatedUser = null;
            foreach (MyUser user in users)
            {
                if (user.UserName.Equals(viewModel.RelatedUserName))
                {
                    relatedUser = user;
                    break;
                }
            }

            return relatedUser;
        }

        // private helper
        private Project AttachProjectToTimesheet(TimesheetEntryViewModel viewModel)
        {
            List<Project> projects = _context.Projects.ToList();
            // attach a Project to the Timesheet 
            Project relatedProject = null;
            foreach (Project project in projects)
            {
                if (project.Name.Equals(viewModel.ProjectName))
                {
                    relatedProject = project;
                    break;
                }
            }

            return relatedProject;
        }
    }
}

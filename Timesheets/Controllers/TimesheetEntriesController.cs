using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    public class TimesheetEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimesheetEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimesheetEntries
        public async Task<IActionResult> Index()
        {
            List<TimesheetEntry> timesheets = _context.TimesheetEntries.Include(t => t.RelatedUser).Include(t => t.RelatedProject).ToList();
            foreach (TimesheetEntry timesheet in timesheets)
            {
                Console.WriteLine(timesheet);
            }
            return View(await _context.TimesheetEntries.ToListAsync());
        }

        // GET: TimesheetEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetEntry = await _context.TimesheetEntries.Include(t => t.RelatedUser).Include(t => t.RelatedProject)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (timesheetEntry == null)
            {
                return NotFound();
            }

            return View(timesheetEntry);
        }

        // GET: TimesheetEntries/Create
        public IActionResult Create()
        {
            TimesheetEntryViewModel viewModel = new TimesheetEntryViewModel();

            this.AddUsernamesToViewModel(viewModel);

            this.AddProjectNamesToViewModel(viewModel);

            return View(viewModel);
        }

        // POST: TimesheetEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimesheetEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                MyUser relatedUser = AttachUserToTimesheet(viewModel);
                Project relatedProject = AttachProjectToTimesheet(viewModel);

                TimesheetEntry timesheetEntry = new TimesheetEntry(relatedUser, relatedProject, viewModel.DateCreated ?? DateTime.Now, viewModel.HoursWorked);

                _context.Add(timesheetEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: TimesheetEntries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetEntry = _context.TimesheetEntries.Include(t => t.RelatedUser).Include(t => t.RelatedProject).First(x => x.Id == id);
            if (timesheetEntry == null)
            {
                return NotFound();
            }

            TimesheetEntryViewModel viewModel = new TimesheetEntryViewModel
            {
                Id = timesheetEntry.Id,
                RelatedUserName = timesheetEntry.RelatedUser.UserName,
                ProjectName = timesheetEntry.RelatedProject.Name,
                DateCreated = timesheetEntry.DateCreated,
                HoursWorked = timesheetEntry.HoursWorked
            };


            this.AddUsernamesToViewModel(viewModel);

            this.AddProjectNamesToViewModel(viewModel);

            return View(viewModel);
        }

        // POST: TimesheetEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TimesheetEntryViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                MyUser relatedUser = AttachUserToTimesheet(viewModel);
                Project relatedProject = AttachProjectToTimesheet(viewModel);

                TimesheetEntry timesheetEntry = new TimesheetEntry(id, relatedUser, relatedProject, viewModel.DateCreated ?? DateTime.Now, viewModel.HoursWorked);

                try
                {
                    _context.Update(timesheetEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimesheetEntryExists(timesheetEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
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

        // private helper
        private void AddProjectNamesToViewModel(TimesheetEntryViewModel viewModel)
        {
            List<Project> projects = _context.Projects.ToList();
            foreach (Project project in projects)
            {
                viewModel.ProjectNames.Add(project.Name);
            }
        }

        // private helper
        private void AddUsernamesToViewModel(TimesheetEntryViewModel viewModel)
        {
            List<MyUser> users = _context.Users.ToList();
            foreach (MyUser user in users)
            {
                viewModel.UserNames.Add(user.UserName);
            }
        }

        // GET: TimesheetEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetEntry = await _context.TimesheetEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheetEntry == null)
            {
                return NotFound();
            }

            return View(timesheetEntry);
        }

        // POST: TimesheetEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timesheetEntry = await _context.TimesheetEntries.FindAsync(id);
            _context.TimesheetEntries.Remove(timesheetEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetEntryExists(int id)
        {
            return _context.TimesheetEntries.Any(e => e.Id == id);
        }
    }
}

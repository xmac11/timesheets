using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data;
using Timesheets.Mappers;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    public class TimesheetEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITimesheetEntryMapper _mapper;

        public TimesheetEntriesController([FromServices] ApplicationDbContext context, ITimesheetEntryMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                TimesheetEntry timesheetEntry = _mapper.MapViewModelToTimesheetEntry(viewModel);

                if (NoEntryExistsForSameDateAndProject(timesheetEntry))
                {
                    _context.Add(timesheetEntry);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    /*this.AddUsernamesToViewModel(viewModel);

                    this.AddProjectNamesToViewModel(viewModel);

                    return View(viewModel);*/
                    ViewBag.ErrorTitle = "Error";
                    ViewBag.ErrorMessage = "User already has a timesheet entry for the same date and project";
                    return View("CustomError");
                }
            }
            return View(viewModel);
        }

        private bool NoEntryExistsForSameDateAndProject(TimesheetEntry timesheetEntry)
        {
            return _context.TimesheetEntries.FirstOrDefault(e => e.DateCreated == timesheetEntry.DateCreated
                                                    && e.RelatedUser.UserName.Equals(timesheetEntry.RelatedUser.UserName)
                                                    && e.RelatedProject.Id == timesheetEntry.RelatedProject.Id) == null;
        }

        private bool NoEntryExistsForSameDateAndProjectExcludingSelf(TimesheetEntry timesheetEntry)
        {
            var otherEntries = _context.TimesheetEntries.Where(e => e.Id != timesheetEntry.Id);
            return otherEntries.FirstOrDefault(e => e.DateCreated == timesheetEntry.DateCreated
                                                    && e.RelatedUser.UserName.Equals(timesheetEntry.RelatedUser.UserName)
                                                    && e.RelatedProject.Id == timesheetEntry.RelatedProject.Id) == null;
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
                TimesheetEntry timesheetEntry = _mapper.MapViewModelToTimesheetEntry(viewModel);

                if (NoEntryExistsForSameDateAndProjectExcludingSelf(timesheetEntry))
                {
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
                else
                {
                    ViewBag.ErrorTitle = "Error";
                    ViewBag.ErrorMessage = "User already has a timesheet entry for the same date and project";
                    return View("CustomError");
                }
            }
            return View(viewModel);
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

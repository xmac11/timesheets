using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Mappers;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class TimesheetEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITimesheetEntryMapper _mapper;
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;


        public TimesheetEntriesController([FromServices] ApplicationDbContext context, ITimesheetEntryMapper mapper, UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: TimesheetEntries
        public async Task<IActionResult> Index()
        {
            List<TimesheetEntry> timesheets = new List<TimesheetEntry>();
            
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MyUser currentUser = await _userManager.FindByIdAsync(currentUserId);
            var roles = await _userManager.GetRolesAsync(currentUser);

            if (roles.Contains("Admin"))
            {
                return View(await _context.TimesheetEntries
                                     .Include(t => t.RelatedUser)
                                     .Include(t => t.RelatedProject)
                                     .ToListAsync());
            }

            if (roles.Contains("Manager"))
            {
                return View(await _context.TimesheetEntries
                    .Include(t => t.RelatedUser)
                    .Include(t => t.RelatedProject)
                    .Where(t => t.RelatedUser.ManagerId.Equals(currentUser.Id))
                    .ToListAsync());
            }

            if (roles.Contains("Employee"))
            {
                return View(await _context.TimesheetEntries
                    .Include(t => t.RelatedUser)
                    .Include(t => t.RelatedProject)
                    .Where(t=> t.RelatedUser.Id == currentUserId)
                    .ToListAsync());
            }
            return View(new List<TimesheetEntry>());
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
        public async Task<IActionResult> Create()
        {
            TimesheetEntryViewModel viewModel = new TimesheetEntryViewModel();

            await this.AddUsernamesToViewModel(viewModel);

            await this.AddProjectNamesToViewModel(viewModel);

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
        public async Task<IActionResult> Edit(int? id)
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


            await this.AddUsernamesToViewModel(viewModel);

            await this.AddProjectNamesToViewModel(viewModel);

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
        private async Task AddProjectNamesToViewModel(TimesheetEntryViewModel viewModel)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MyUser currentUser = await _userManager.FindByIdAsync(currentUserId);
            var roles = await _userManager.GetRolesAsync(currentUser);

            List<Project> projects = new List<Project>();

            if (roles.Contains("Admin"))
            {
                projects = _context.DepartmentProjects
                                      .Include(dp => dp.Project)
                                      .Select(dp => dp.Project)
                                      .ToList();
            }
            else if (roles.Contains("Manager") || roles.Contains("Employee"))
            {
                projects = _context.DepartmentProjects
                                      .Include(dp => dp.Project)
                                      .Where(dp => dp.DepartmentId == currentUser.DepartmentId)
                                      .Select(dp => dp.Project)
                                      .ToList();
            }

            foreach (Project project in projects)
            {
                viewModel.ProjectNames.Add(project.Name);
            }
        }

        // private helper
        private async Task AddUsernamesToViewModel(TimesheetEntryViewModel viewModel)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MyUser currentUser = await _userManager.FindByIdAsync(currentUserId);
            var roles = await _userManager.GetRolesAsync(currentUser);

            List<MyUser> users = new List<MyUser>();

            if (roles.Contains("Admin"))
            {
                users = _context.Users.ToList();
            }
            else if(roles.Contains("Manager"))
            {
                users = _context.Users.Where(u => u.ManagerId.Equals(currentUser.Id)).ToList();
            }
            else if (roles.Contains("Employee"))
            {
                users = _context.Users.Where(u => u.Id == currentUser.Id).ToList();
            }

            foreach (MyUser user in users)
            {
                viewModel.UserNames.Add(user.UserName);
            }

        }

        // GET: TimesheetEntries/Delete/5
        [Authorize(Roles = "Admin, Manager")]
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
        [Authorize(Roles = "Admin, Manager")]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data;
using Timesheets.Models;
using Timesheets.Models.ViewModels;

namespace Timesheets.Controllers
{ 
    [Authorize(Roles = "Admin,Manager")]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public ProjectsController(ApplicationDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MyUser currentUser = await _userManager.FindByIdAsync(currentUserId);
            var roles = await _userManager.GetRolesAsync(currentUser);

            IList<Project> projects = new List<Project>();

            if (roles.Contains("Admin"))
            {
                projects = await _context.Projects.Include(p => p.OwnerDept).ToListAsync();
            }
            else if (roles.Contains("Manager"))
            {
                projects = await _context.DepartmentProjects
                                         .Include(dp => dp.Project)
                                         .Include(dp => dp.Project.OwnerDept)
                                         .Where(dp => dp.DepartmentId == currentUser.DepartmentId)
                                         .Select(dp => dp.Project)
                                         .ToListAsync();
            }

            return View(projects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                            .Include(p => p.OwnerDept)
                            .Include(p => p.Departments)
                            .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            ProjectViewModel viewModel = new ProjectViewModel()
            {
                Id = project.Id,
                Name = project.Name,
                OwnerDeptName = project.OwnerDept.Name
            };

            this.AddRelatedDepartments(id, viewModel);

            return View(viewModel);
        }

        private void AddRelatedDepartments(int? id, ProjectViewModel viewModel)
        {
            List<DepartmentProject> departmentProjects = _context.DepartmentProjects
                                                                    .Include(dp => dp.Department)
                                                                    .Where(dp => dp.ProjectId == id)
                                                                    .ToList();

            foreach (DepartmentProject departmentProject in departmentProjects)
            {
                viewModel.RelatedDepartments.Add(departmentProject.Department);
            }
        }

        // GET: Projects/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ProjectViewModel viewModel = new ProjectViewModel();

            this.AddDepartmentNamesToViewModel(viewModel);

            for (int i = 0; i < viewModel.DepartmentNames.Count; i++)
            {
                viewModel.AreSelected.Add(false);
            }

            ViewData["OwnerDeptName"] = new SelectList(_context.Departments, "Name", "Name");
            return View(viewModel);
        }

        private void AddDepartmentNamesToViewModel(ProjectViewModel viewModel)
        {
            List<Department> departments = _context.Departments.ToList();
            foreach (Department department in departments)
            {
                viewModel.DepartmentNames.Add(department.Name);
            }
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel viewModel)
        {
            Project project = null;

            if (ModelState.IsValid)
            {
                Department ownerDepartment = _context.Departments.First(department => department.Name == viewModel.OwnerDeptName);

                this.AddSelectedDepartments(viewModel);

                project = new Project(viewModel.Name, ownerDepartment);

                _context.Add(project);
                await _context.SaveChangesAsync();

                // create relationship table
                this.CreateDepartmentProjects(viewModel, project);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerDeptId"] = new SelectList(_context.Departments, "Id", "Id", project.OwnerDeptId);
            return View(project);
        }

        private void CreateDepartmentProjects(ProjectViewModel viewModel, Project project)
        {
            for (int i = 0; i < viewModel.RelatedDepartments.Count; i++)
            {
                DepartmentProject departmentProject = new DepartmentProject()
                {
                    DepartmentId = viewModel.RelatedDepartments[i].Id,
                    ProjectId = project.Id
                };
                _context.Add(departmentProject);
            }
        }

        private void AddSelectedDepartments(ProjectViewModel viewModel)
        {
            for (int i = 0; i < viewModel.DepartmentNames.Count; i++)
            {
                if (viewModel.AreSelected[i])
                {
                    string departmentName = viewModel.DepartmentNames[i];
                    Department department = _context.Departments.First(d => d.Name.Equals(departmentName));
                    viewModel.RelatedDepartments.Add(department);
                }
            }
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects.Include(p => p.OwnerDept).First(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            ProjectViewModel viewModel = new ProjectViewModel()
            {
                Id = project.Id,
                Name = project.Name,
                OwnerDeptName = project.OwnerDept.Name,
            };

            this.AddDepartmentNamesToViewModel(viewModel);
            this.AddRelatedDepartments(id, viewModel);
            for(int i = 0; i < viewModel.DepartmentNames.Count; i++)
            {
                bool isSelected = viewModel.RelatedDepartments.Exists(d => d.Name == viewModel.DepartmentNames[i]);
                viewModel.AreSelected.Add(isSelected);
            }

            ViewData["OwnerDeptId"] = new SelectList(_context.Departments, "Id", "Id", project.OwnerDeptId);
            return View(viewModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Department ownerDepartment = _context.Departments.First(department => department.Name == viewModel.OwnerDeptName);
                this.AddSelectedDepartments(viewModel);
                Project project = new Project(viewModel.Id, viewModel.Name, ownerDepartment);

                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // clear relationship table for this project
                this.ClearDepartmentProjects(id);

                // add new entries in relationship table
                this.CreateDepartmentProjects(viewModel, project);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        private void ClearDepartmentProjects(int id)
        {
            List<DepartmentProject> departmentProjects = _context.DepartmentProjects
                                                                                .Include(dp => dp.Department)
                                                                                .Include(dp => dp.Project)
                                                                                .Where(dp => dp.ProjectId == id)
                                                                                .ToList();

            foreach (DepartmentProject departmentProject in departmentProjects)
            {
                _context.Remove(departmentProject);
            }
            _context.SaveChanges();
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.OwnerDept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}

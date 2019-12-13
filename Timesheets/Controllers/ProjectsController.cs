using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data;
using Timesheets.Models;
using Timesheets.Models.ViewModels;

namespace Timesheets.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Projects.Include(p => p.OwnerDept);
            return View(await applicationDbContext.ToListAsync());
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

            List<DepartmentProject> departmentProjects = _context.DepartmentProjects
                                                        .Include(dp => dp.Department)
                                                        .Where(dp => dp.ProjectId == id)
                                                        .ToList();

            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.Id = project.Id;
            viewModel.Name = project.Name;
            viewModel.OwnerDeptName = project.OwnerDept.Name;
            foreach (DepartmentProject departmentProject in departmentProjects)
            {
                viewModel.RelatedDepartments.Add(departmentProject.Department);
            }

            return View(viewModel);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ProjectViewModel viewModel = new ProjectViewModel();

            this.AddDepartmentNamesToViewModel(viewModel);
            foreach (string name in viewModel.DepartmentNames)
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

                this.AddRelatedDepartments(viewModel);

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

        private void AddRelatedDepartments(ProjectViewModel viewModel)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["OwnerDeptId"] = new SelectList(_context.Departments, "Id", "Id", project.OwnerDeptId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OwnerDeptId")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerDeptId"] = new SelectList(_context.Departments, "Id", "Id", project.OwnerDeptId);
            return View(project);
        }

        // GET: Projects/Delete/5
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

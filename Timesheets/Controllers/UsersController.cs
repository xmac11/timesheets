using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Mappers;
using Timesheets.Models;
using Timesheets.Models.ViewModels;

namespace Timesheets.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserMapper _mapper;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(ApplicationDbContext context, IUserMapper mapper, UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _context.Users.Include(u => u.Department);
            List<UserViewModel> userData = new List<UserViewModel>();
            foreach (MyUser user in users) 
            {
                UserViewModel userViewModel = new UserViewModel();

                userViewModel.Id = user.Id;
                userViewModel.FirstName = user.FirstName;
                userViewModel.LastName = user.LastName;
                userViewModel.Email = user.Email;
                userViewModel.CostPerHour = user.CostPerHour;
                userViewModel.Roles = await _userManager.GetRolesAsync(user);
                
                if (user.Department != null)
                {
                    userViewModel.DepartmentName = user.Department.Name;
                }
                if (user.Manager != null)
                {
                    userViewModel.ManagerName = user.Manager.FirstName + " " + user.Manager.LastName;
                }

                userData.Add(userViewModel);
            }
             
            return View(userData);
        }

        // GET: TimesheetEntries/Create
        public async Task<IActionResult> Create()
        {
            UserViewModelCreate viewModel = new UserViewModelCreate();

            var roles = await _roleManager.Roles.ToListAsync();
            ViewData["Roles"] = new SelectList(roles, "Name", "Name");
            var departments = await _context.Departments.ToListAsync();
            ViewData["Departments"] = new SelectList(departments, "Id", "Name");
            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            ViewData["Managers"] = new SelectList(managers, "Id", "UserName");
            return View(viewModel);
        }

        // POST: TimesheetEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModelCreate viewModel)
        {
            if (ModelState.IsValid)
            {
                MyUser user = _mapper.CreateUser(viewModel, _userManager, _roleManager).Result;

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {

                    //_context.SaveChanges();
                    await _userManager.SetEmailAsync(user, viewModel.Email);
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _userManager.ConfirmEmailAsync(user, token);

                    //remove roles and add only the ones from viewmodel
                    await _userManager.AddToRolesAsync(user, viewModel.Roles);


                    //_context.Add(user);
                    //await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            UserViewModel viewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CostPerHour = user.CostPerHour,
                DepartmentId = user.DepartmentId,
                ManagerId = user.ManagerId,
                Roles = await _userManager.GetRolesAsync(user)
            };

            var roles = await _roleManager.Roles.ToListAsync();
            //List<SelectListItem> rolesItems = new List<SelectListItem>();
            //foreach (var r in roles)
            //{
            //    rolesItems.Add((SelectListItem) r);
            //}
            ViewData["Roles"] = new SelectList(roles, "Name", "Name", viewModel.Roles);
            var departments = await _context.Departments.ToListAsync();
            ViewData["Departments"] = new SelectList(departments, "Id", "Name", viewModel.DepartmentId);
            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            ViewData["Managers"] = new SelectList(managers, "Id","UserName", viewModel.ManagerId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {

                MyUser user = await _mapper.MapViewModelToUser(viewModel, _userManager, _roleManager);
                var userRolesDebug = await _userManager.GetRolesAsync(user);
                try
                {
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await  _userManager.FindByIdAsync(id); 
            //_context.Users.FindAsync(id);
            await _userManager.DeleteAsync(user);
            //_context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool UserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}

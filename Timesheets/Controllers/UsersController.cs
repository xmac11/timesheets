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

        public UsersController(ApplicationDbContext context, IUserMapper mapper, UserManager<MyUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Users;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TimesheetEntries/Create
        public async Task<IActionResult> Create()
        {
            UserViewModel viewModel = new UserViewModel();

            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            ViewData["Managers"] = new SelectList(managers, viewModel.ManagerId);
            return View(viewModel);
        }

        // POST: TimesheetEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MyUser user = await _mapper.MapViewModelToUser(viewModel, _userManager);

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string id)
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

            UserViewModel viewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CostPerHour = user.CostPerHour,
                DepartmentId = user.DepartmentId,
                ManagerId = user.ManagerId,
            };

            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            ViewData["Managers"] = new SelectList(managers, viewModel.Manager);
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
                MyUser user = await _mapper.MapViewModelToUser(viewModel, _userManager);
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
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
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool UserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}

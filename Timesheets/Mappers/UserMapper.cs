using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Models;
using Timesheets.Models.ViewModels;

namespace Timesheets.Mappers
{
    public class UserMapper :IUserMapper
    {
        private readonly ApplicationDbContext _context;

        public UserMapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MyUser> MapViewModelToUser(UserViewModel viewModel, UserManager<MyUser> userManager)
        {
            MyUser user = await _context.Users.FindAsync(viewModel.Id);

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            await userManager.ChangePasswordAsync(user, user.PasswordHash, viewModel.Password);
            user.CostPerHour = viewModel.CostPerHour;
            user.DepartmentId = viewModel.DepartmentId;
            user.Department = await _context.Departments.FindAsync(viewModel.DepartmentId);
            user.ManagerId = viewModel.ManagerId;
            user.Manager = await _context.Users.FindAsync(viewModel.ManagerId);

            return user;
        }
    }
}

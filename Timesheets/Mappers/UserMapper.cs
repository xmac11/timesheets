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
        public async Task<MyUser> MapViewModelToUser(
            UserViewModel viewModel, 
            UserManager<MyUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            MyUser user = await _context.Users.FindAsync(viewModel.Id);

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.CostPerHour = viewModel.CostPerHour;
            user.DepartmentId = viewModel.DepartmentId;
            user.ManagerId = viewModel.ManagerId;
            await userManager.SetEmailAsync(user, viewModel.Email);

            //remove roles and add only the ones from viewmodel
            var roles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, roles.ToArray());
            await userManager.AddToRolesAsync(user, viewModel.Roles);

            return user;
        }
    }
}

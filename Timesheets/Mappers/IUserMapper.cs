using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.ViewModels;

namespace Timesheets.Mappers
{
    public interface IUserMapper
    {
        public Task<MyUser> MapViewModelToUser(UserViewModel viewModel, UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager);
    }
}

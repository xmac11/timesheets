using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data
{
    public class UsersInitializer
    {
        public static void SeedUsers(UserManager<MyUser> userManager) //we call this in configure method in startup
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                MyUser user = new MyUser
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}

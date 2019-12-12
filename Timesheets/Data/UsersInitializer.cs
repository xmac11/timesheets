using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data
{
    public static class UsersInitializer
    {
        public static void SeedUsers(UserManager<MyUser> userManager)
        {
            // admin
            if (userManager.FindByEmailAsync("admin@test.com").Result == null)
            {
                MyUser admin = new MyUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com",
                    EmailConfirmed = true,
                    DepartmentId = 1
                };

                IdentityResult result = userManager.CreateAsync(admin, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }

            // employee
            if (userManager.FindByEmailAsync("c.makrylakis@gmail.com").Result == null)
            {
                MyUser employee = new MyUser
                {
                    UserName = "c.makrylakis@gmail.com",
                    Email = "c.makrylakis@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Charalampos",
                    LastName = "Makrylakis",
                    CostPerHour = 10,
                    DepartmentId = 1,
                    ManagerId = "ca544165-5208-4554-b1ae-5ffb0b11d8ea" // Id of admin
                };

                IdentityResult result = userManager.CreateAsync(employee, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee, "Employee").Wait();
                }
            }
        }
    }
}

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
                    userManager.AddToRoleAsync(admin, "Manager").Wait();
                    userManager.AddToRoleAsync(admin, "Employee").Wait();
                }
            }

            // manager, employee
            if (userManager.FindByEmailAsync("ariskallergis@gmail.com").Result == null)
            {
                MyUser manager = new MyUser
                {
                    UserName = "ariskallergis@gmail.com",
                    Email = "ariskallergis@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Aris",
                    LastName = "Kallergis",
                    CostPerHour = 20,
                    DepartmentId = 1
                };

                IdentityResult result = userManager.CreateAsync(manager, "222222").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(manager, "Manager").Wait();
                    userManager.AddToRoleAsync(manager, "Employee").Wait();
                }
            }

            // manager, employee
            if (userManager.FindByEmailAsync("maryksenou@gmail.com").Result == null)
            {
                MyUser manager = new MyUser
                {
                    UserName = "maryksenou@gmail.com",
                    Email = "maryksenou@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Mary",
                    LastName = "Ksenou",
                    CostPerHour = 20,
                    DepartmentId = 2
                };

                IdentityResult result = userManager.CreateAsync(manager, "333333").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(manager, "Manager").Wait();
                    userManager.AddToRoleAsync(manager, "Employee").Wait();
                }
            }

            // manager, employee
            if (userManager.FindByEmailAsync("manager@gmail.com").Result == null)
            {
                MyUser manager = new MyUser
                {
                    UserName = "manager@gmail.com",
                    Email = "manager@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Nikos",
                    LastName = "Dimitriou",
                    CostPerHour = 20,
                    DepartmentId = 2
                };

                IdentityResult result = userManager.CreateAsync(manager, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(manager, "Manager").Wait();
                    userManager.AddToRoleAsync(manager, "Employee").Wait();
                }
            }

            // employee (with manager Admin)
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
                    ManagerId = userManager.FindByEmailAsync("admin@test.com").Result.Id // Id of admin
                };

                IdentityResult result = userManager.CreateAsync(employee, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee, "Employee").Wait();
                }
            }

            // employee (with manager Mary)
            if (userManager.FindByEmailAsync("kostastask@gmail.com").Result == null)
            {
                MyUser employee = new MyUser
                {
                    UserName = "kostastask@gmail.com",
                    Email = "kostastask@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Kostas",
                    LastName = "Tsak",
                    CostPerHour = 10,
                    DepartmentId = 2,
                    ManagerId = userManager.FindByEmailAsync("maryksenou@gmail.com").Result.Id // Id of Mary
                };

                IdentityResult result = userManager.CreateAsync(employee, "444444").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee, "Employee").Wait();
                }
            }

            // employee (with manager Mary)
            if (userManager.FindByEmailAsync("dimitrispitsios@gmail.com").Result == null)
            {
                MyUser employee = new MyUser
                {
                    UserName = "dimitrispitsios@gmail.com",
                    Email = "dimitrispitsios@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Dimitris",
                    LastName = "Pitsios",
                    CostPerHour = 10,
                    DepartmentId = 2,
                    ManagerId = userManager.FindByEmailAsync("maryksenou@gmail.com").Result.Id // Id of Mary
                };

                IdentityResult result = userManager.CreateAsync(employee, "555555").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee, "Employee").Wait();
                }
            }

            // employee (with manager Nikos)
            if (userManager.FindByEmailAsync("iosifgeme@gmail.com").Result == null)
            {
                MyUser employee = new MyUser
                {
                    UserName = "iosifgeme@gmail.com",
                    Email = "iosifgeme@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Iosif",
                    LastName = "Gemenitzoglou",
                    CostPerHour = 10,
                    DepartmentId = 2,
                    ManagerId = userManager.FindByEmailAsync("manager@gmail.com").Result.Id // Id of Nikos (manager)
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

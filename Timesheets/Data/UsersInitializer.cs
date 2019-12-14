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

                IdentityResult result = userManager.CreateAsync(admin, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                    userManager.AddToRoleAsync(admin, "Manager").Wait();
                    userManager.AddToRoleAsync(admin, "Employee").Wait();
                }
            }

            // manager (IT department - 1), employee
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

                IdentityResult result = userManager.CreateAsync(manager, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(manager, "Manager").Wait();
                    userManager.AddToRoleAsync(manager, "Employee").Wait();
                }
            }

            // manager (R&D department - 2), employee
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

                IdentityResult result = userManager.CreateAsync(manager, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(manager, "Manager").Wait();
                    userManager.AddToRoleAsync(manager, "Employee").Wait();
                }
            }

            // manager (R&D department - 2), employee
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

            // manager (HR department - 3), employee
            if (userManager.FindByEmailAsync("xrysa@gmail.com").Result == null)
            {
                MyUser manager = new MyUser
                {
                    UserName = "xrysa@gmail.com",
                    Email = "xrysa@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Xrysa",
                    LastName = "Xrystopoulou",
                    CostPerHour = 20,
                    DepartmentId = 3
                };

                IdentityResult result = userManager.CreateAsync(manager, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(manager, "Manager").Wait();
                    userManager.AddToRoleAsync(manager, "Employee").Wait();
                }
            }

            // manager (Accounting department - 4), employee
            if (userManager.FindByEmailAsync("mike@gmail.com").Result == null)
            {
                MyUser manager = new MyUser
                {
                    UserName = "mike@gmail.com",
                    Email = "mike@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Mike",
                    LastName = "Scott",
                    CostPerHour = 20,
                    DepartmentId = 4
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
                    ManagerId = userManager.FindByEmailAsync("ariskallergis@gmail.com").Result.Id // Id of Aris
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

                IdentityResult result = userManager.CreateAsync(employee, "111111").Result;

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

                IdentityResult result = userManager.CreateAsync(employee, "111111").Result;

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

            // employee (with manager Aris)
            if (userManager.FindByEmailAsync("eleni@gmail.com").Result == null)
            {
                MyUser employee = new MyUser
                {
                    UserName = "eleni@gmail.com",
                    Email = "eleni@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Eleni",
                    LastName = "Vasileiou",
                    CostPerHour = 10,
                    DepartmentId = 1,
                    ManagerId = userManager.FindByEmailAsync("ariskallergis@gmail.com").Result.Id // Id of Aris 
                };

                IdentityResult result = userManager.CreateAsync(employee, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee, "Employee").Wait();
                }
            }

            // employee (with manager Xrysa)
            if (userManager.FindByEmailAsync("kostis@gmail.com").Result == null)
            {
                MyUser employee = new MyUser
                {
                    UserName = "kostis@gmail.com",
                    Email = "kostis@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Kostis",
                    LastName = "Konstantinou",
                    CostPerHour = 10,
                    DepartmentId = 3,
                    ManagerId = userManager.FindByEmailAsync("xrysa@gmail.com").Result.Id // Id of Xrysa 
                };

                IdentityResult result = userManager.CreateAsync(employee, "111111").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee, "Employee").Wait();
                }
            }

            // employee (with manager Mike)
            if (userManager.FindByEmailAsync("ntinos@gmail.com").Result == null)
            {
                MyUser employee = new MyUser
                {
                    UserName = "ntinos@gmail.com",
                    Email = "ntinos@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Ntinos",
                    LastName = "Sadikis",
                    CostPerHour = 10,
                    DepartmentId = 4,
                    ManagerId = userManager.FindByEmailAsync("mike@gmail.com").Result.Id // Id of Mike 
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
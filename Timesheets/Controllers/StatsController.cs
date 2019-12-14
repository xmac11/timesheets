using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    //[Route("Stats")]
    //[ApiController]
    [Authorize(Roles = "Admin,Manager")]
    public class StatsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<MyUser> _usermanager;
        
        public StatsController(ApplicationDbContext context, UserManager<MyUser> userManager)
        {
            this._context = context;
            this._usermanager = userManager;
        }

        [HttpGet]
        public ActionResult GetCostPerDepartment()
        {

            var department_partialCost = from user in _context.Users
                    join entry in _context.TimesheetEntries on user.Id equals entry.RelatedUser.Id
                    join department in _context.Departments on user.DepartmentId equals department.Id
                    select new { department.Name, Cost = user.CostPerHour * entry.HoursWorked };

            var groupCostByDepartment = from result in department_partialCost
                          group result by result.Name into departments
                          select new { departments.Key, TotalCost = departments.Sum(d => d.Cost) };


            List<string> departmentNames = new List<string>();
            List<double> totalCosts = new List<double>();
            foreach(var element in groupCostByDepartment)
            {
                departmentNames.Add(element.Key);
                totalCosts.Add(element.TotalCost);
            }

            ViewBag.Labels = departmentNames;
            ViewBag.Costs = totalCosts;
            
            
            return View();
        }

        [HttpGet]
        public ActionResult DivideHoursByDepartment()
        {

            var customJoin = from entry in _context.TimesheetEntries
                    join user in _context.Users on entry.RelatedUser.Id equals user.Id
                    join department in _context.Departments on user.DepartmentId equals department.Id
                    select new { UserId = user.Id, DepartmentName = department.Name, ProjectId = entry.RelatedProject.Id, HoursWorked = entry.HoursWorked };

            var groupHoursByDepartment = from result in customJoin
                        group result by result.DepartmentName into departments
                        select new { departments.Key, TotalHours = departments.Sum(d => d.HoursWorked) };

            List<string> departmentNames = new List<string>();
            List<int> totalHours = new List<int>();

            foreach(var element in groupHoursByDepartment)
            {
                departmentNames.Add(element.Key);
                totalHours.Add(element.TotalHours);
            }

            ViewBag.Labels = departmentNames;
            ViewBag.Hours = totalHours;

            return View();
        }

        [HttpGet]
        public ActionResult TotalCostsPerMonth()
        {
            var department_partialCost = from user in _context.Users
                                         join entry in _context.TimesheetEntries on user.Id equals entry.RelatedUser.Id
                                         join department in _context.Departments on user.DepartmentId equals department.Id
                                         select new { EntryDate = entry.DateCreated, Cost = user.CostPerHour * entry.HoursWorked };

            var groupCostByDepartment = (from result in department_partialCost
                                        group result by result.EntryDate.Month into months
                                        select new { MonthIndex = months.Key, TotalCost = months.Sum(d => d.Cost) }) .OrderBy(x => x.MonthIndex);

            double[] costsPerMonth = new double[12];
            foreach(var element in groupCostByDepartment)
            {
                costsPerMonth[element.MonthIndex-1] = element.TotalCost;
            }

            ViewBag.CostsPerMonth = costsPerMonth;

            return View();
        }


    }
}

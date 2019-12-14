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

            //IList<int> n = _context.Users.

            var results = from user in _context.Users
                    join entry in _context.TimesheetEntries on user.Id equals entry.RelatedUser.Id
                    join department in _context.Departments on user.DepartmentId equals department.Id
                    select new { department.Name, Cost = user.CostPerHour * entry.HoursWorked };

            var groupByDepartment = from result in results
                          group result by result.Name into departments
                          select new { departments.Key, TotalCost = departments.Sum(d => d.Cost) };


            List<string> departmentNames = new List<string>();
            List<double> totalCosts = new List<double>();
            foreach(var element in groupByDepartment)
            {
                departmentNames.Add(element.Key);
                totalCosts.Add(element.TotalCost);
            }

            ViewBag.Labels = departmentNames;
            ViewBag.Costs = totalCosts;
            
            
            return View();
        }

        [HttpGet]
        public ActionResult GetProjectsPerTime()
        {
            var pquery = _context.TimesheetEntries;
            /*
            var pquery = _context.TimesheetEntries.GroupBy(
                    p => p.RelatedProject.Name,
                    (project, timesheet) => new
                    {
                        Key = project,
                        Sum = timesheet.Sum(t => t.HoursWorked)
                    }
                );
            */


            return Json(pquery.ToList());

        }
    }
}

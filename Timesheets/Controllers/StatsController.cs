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
    [Route("Stats")]
    [ApiController]
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

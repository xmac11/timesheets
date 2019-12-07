using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    public class TimesheetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimesheetsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TimesheetViewModel timesheetViewModel)
        {
            Timesheet timesheet = new Timesheet();
            timesheet.UserId = timesheetViewModel.EmployeeId;
            timesheet.ProjectId = timesheetViewModel.ProjectId;
            timesheet.DateStarted = timesheetViewModel.DateStarted;
            timesheet.HoursWorked = timesheetViewModel.HoursWorked;

            _context.Timesheets.Add(timesheet);
            _context.SaveChanges();

            return View();
        }
    }
}
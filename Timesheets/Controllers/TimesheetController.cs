using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Timesheets.Data;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    public class TimesheetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimesheetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(TimeSheetViewModel timesheetDTO)
        {

            //try
            //{
            //    _context.Timesheets.Add(timesheetDTO)
            //}
            //var t = new Timesheet();
            //t.TimesheetId = 543; //temporary until auto-generated
            //t.UserId = timesheetDTO.UserId;
            //t.ProjectId = timesheetDTO.ProjectId;
            //t.HoursWorked = timesheetDTO.HoursWorked;
            //t.DateCreated = new DateTime();

            var t = new Timesheet();
            //t.TimesheetId = 543; //temporary until auto-generated
            //t.UserId = timesheetDTO.UserId;
            //t.ProjectId = timesheetDTO.ProjectId;
            t.HoursWorked = timesheetDTO.HoursWorked;
            t.DateCreated = new DateTime();

            _context.Timesheets.Add(t);
            _context.SaveChanges();
            
            return View("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {

            //List<string> lala = new List<string>();
            //lala.Add("asdsada");
            //lala.Add("asdsada");
            //lala.Add("asdsada");


            //ViewBag["lalaDataSource"] = lala.Select(x => new SelectListItem()
            //{
            //    Text = x,
            //    Value = x
            //});

            return View();
        }
    }
}
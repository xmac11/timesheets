using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Models;

namespace Timesheets.Controllers
{
    public class KatiController : Controller
    {
        Kati kati = new Kati(35, "Katitis");
        [Route("/kati")]
        public IActionResult Kati()
        {
            ViewData["Kati_number"] = kati.number;
            ViewData["Kati_text"] = kati.text;
            return View(kati);
        }
    }
}
using IHFF.Enum;
using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class FullScheduleController : Controller
    {
        DbScheduleRepository repository = new DbScheduleRepository();
        // GET: FullSchedule
        public ActionResult Index()
        {
            return RedirectToAction("FullSchedule");
        }

        public ActionResult FullSchedule(DayOfWeek? day)
        {
            if(day == null)
            {
                day = DayOfWeek.Monday;               
            }
            IEnumerable<Voorstelling> voorstellingen = repository.getAllVoorstellingen(day.Value);
           
            return View(voorstellingen);
        }
    }
}
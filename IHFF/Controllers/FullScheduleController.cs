using IHFF.Enum;
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

        public ActionResult FullSchedule(Weekday? day)
        {
            if(day == null)
            {
                day = Enum.Weekday.Maandag;
                ;
            }
            //repository.getAllVoorstellingen(day);
           
            return View();
        }
    }
}
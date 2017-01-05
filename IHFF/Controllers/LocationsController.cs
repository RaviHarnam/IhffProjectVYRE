using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult Index()
        {
            return RedirectToAction("Locations");
        }

        public ActionResult Locations()
        {
            return View();
        }
    }
}
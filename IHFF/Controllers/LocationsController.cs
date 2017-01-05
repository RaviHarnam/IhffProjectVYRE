using IHFF.Models;
using IHFF.Repositories;
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
        private ILocatieRepository db = new dbLocatieRepository();

        public ActionResult Index()
        {
            return RedirectToAction("Locations");
        }

        public ActionResult Locations()
        {
            IEnumerable<Locatie> locaties = db.GetLocaties();
            return View(locaties);
        }
    }
}
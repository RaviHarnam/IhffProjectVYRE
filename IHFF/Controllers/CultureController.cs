using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class CultureController : Controller
    {
        IMuseumRepository dbMuseum = new DbMuseumRepository();
        // GET: Museum
        public ActionResult Index()
        {

            return RedirectToAction("MuseumOverview");
        }

        public ActionResult MuseumOverview()
        {
            List<Museum> musea = dbMuseum.GetAll();

            return View(musea);
        }
        
        public ActionResult MuseumDetailPage(int? museumId)
        {
            if (museumId != null)
            {
                Museum museum = dbMuseum.GetMuseum(museumId);


                return View(museum);
            }

            return RedirectToAction("MuseumOverview");
        }
    }
}
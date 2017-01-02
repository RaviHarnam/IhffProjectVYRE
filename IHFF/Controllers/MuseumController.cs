using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class MuseumController : Controller
    {
        IMuseumRepository dbMuseum = new DbMuseumRepository();
        // GET: Museum
        public ActionResult Index()
        {
            List<Museum> musea = dbMuseum.GetAll();

            return View(musea);
        }
    }
}
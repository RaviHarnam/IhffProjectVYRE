using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class HotelsController : Controller
    {
        // GET: Hotels
        public ActionResult Index()
        {
            return RedirectToAction("HotelsOverview");
        }

        public ActionResult HotelsOverview()
        {


            return View();
        }
    }
}
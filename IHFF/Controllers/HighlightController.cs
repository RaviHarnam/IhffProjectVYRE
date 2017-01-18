using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class HighlightController : Controller
    {
        private IItemRepository db = new DbItemRepository();
        // GET: Highlight
        public ActionResult Index()
        {
            return RedirectToAction("Highlights");
        }

        public ActionResult Highlights()
        {
            IEnumerable<Highlight> items = db.GetAllHighlights();
            return View(items);
        }
    }
}
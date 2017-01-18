using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class HomeController : Controller
    {
        IItemRepository itemRepository = new DbItemRepository();

        public ActionResult Index()
        {
            IEnumerable<Highlight> highlights = itemRepository.GetAllHighlightsBanner();
            
            return View(highlights);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using IHFF.Helpers;
using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class SpecialController : Controller
    {
        private IItemRepository dbSpecial = new DbItemRepository();
        private IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();

        // GET: Special
        public ActionResult Index()
        {
            return RedirectToAction("SpecialOverview");
        }

        public ActionResult SpecialOverviewByDay(int dag)
        {
            IEnumerable<Special> specials = dbSpecial.getSpecialByDay(dag);

            if (!specials.Any())
            {
                return View(); // moet nog een view krijgen
            }
            else
            {
                return View("SpecialOverview", specials); // hier kun je gewoon naar MovieOverview verwijzen
            }

        }
        public ActionResult SpecialOverview()
        {
            IEnumerable<Special> specials = dbSpecial.GetAllSpecials();
            return View(specials);
        }

        [HttpPost]
        public ActionResult SpecialOverview(int? voorstellingId, int Aantal)
        {
            if (ModelState.IsValid)
            {
                Cart cart = new Cart();
                cart.AddItem(voorstellingId, Aantal);
            }
            return RedirectToAction("SpecialOverview");
        }

        public ActionResult SpecialDetailPage(int special_id)
        {
            
            
                Special special = dbSpecial.GetSpecial(special_id); 
                if (special != null)
                {
                    special.Voorstellingen = (dbVoorstelling.GetVoorstellingen(special.ItemID));
                    return View(special);
                }
            
            return RedirectToAction("SpecialOverview");
        }


        [HttpPost]
        public ActionResult SpecialDetailPage(int voorstellingId, int Aantal)
        {
                if (ModelState.IsValid)
                {
                    Cart cart = new Cart();
                    cart.AddItem(voorstellingId, Aantal);
            }
                Special special = dbSpecial.GetSpecialByVoorstellingID(voorstellingId);
                return View(special);
        }
    }
}

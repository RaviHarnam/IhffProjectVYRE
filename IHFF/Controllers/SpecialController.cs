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
        private ISpecialRepository dbSpecial = new DbSpecialRepository();
        IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
     

        // GET: Special
        public ActionResult Index()
        {
            return View("SpecialOverview");
        }

        public ActionResult SpecialOverview()
        {
            IEnumerable<Special> specials = dbSpecial.GetAllSpecials();
            return View(specials);
        }

        [HttpPost]
        public ActionResult SpecialOverview(int? voorstellingId, Special sInput, string button)
        {
            if (ModelState.IsValid)
            {
                MakeEventHelper.MakeEvent(voorstellingId.Value, sInput.Specialbestellinginputmodel.Aantal, button);
            }
            return RedirectToAction("SpecialOverview");
        }

        public ActionResult SpecialDetailPage(int? special_id)
        {
            if (special_id != null)
            {
                Special special = dbSpecial.GetSpecial(special_id.Value); // checkt of de special met het gegeven id wel bestaat
                if (special != null)
                {
                    special.Voorstellingen = (dbVoorstelling.GetVoorstellingen(special.ItemID));
                    return View(special);
                }
            }
            return RedirectToAction("SpecialOverview");
        }


        [HttpPost]
        public ActionResult SpecialDetailPage(int? voorstellingId, Special sInput, string button)
        {
            if (voorstellingId != null)
            {
                if (ModelState.IsValid)
                {
                    MakeEventHelper.MakeEvent(voorstellingId.Value, sInput.Specialbestellinginputmodel.Aantal, button);
                }

                Special s = dbSpecial.GetSpecialByVoorstellingID(voorstellingId.Value);
                return View(s);
            }
            return RedirectToAction("SpecialOverview");
        }
    }
}

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
        MakeEventHelper eventHelper = MakeEventHelper.GetInstance();

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
                eventHelper.MakeEvent(voorstellingId.Value, sInput.Specialbestellinginputmodel.Aantal, button);
            }
            return RedirectToAction("SpecialOverview");
        }

        public ActionResult SpecialDetailPage(int? special_id)
        {
            if (special_id != null)
            {
                Special special = dbSpecial.GetSpecial(special_id.Value);
                if (special != null)
                {
                    special.Voorstellingen = (dbVoorstelling.GetVoorstellingen(special.ItemID));
                    List<SelectListItem> listItems = new List<SelectListItem>();
                    foreach (DateTime datetime in special.Tijden)
                    {
                        SelectListItem item = new SelectListItem();
                        item.Text = datetime.ToString();
                        item.Value = datetime.ToString();
                        listItems.Add(item);
                    }
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
                    eventHelper.MakeEvent(voorstellingId.Value, sInput.Specialbestellinginputmodel.Aantal, button);
                }

                Special s = dbSpecial.GetSpecialByVoorstellingID(voorstellingId.Value);
                return View(s);
            }
            return RedirectToAction("SpecialOverview");
        }
    }
}

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

        public ActionResult SpecialDetailPage(int? special_id)
        {
            if(special_id != null)
            {
                Special special = dbSpecial.GetSpecial(special_id.Value);
                if(special != null)
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
        public ActionResult SpecialOverview(int? voorstellingId, Special special, string aantal, string button)
        {
            if (ModelState.IsValid)
            {
                int amount = 0;
                if (voorstellingId != null && int.TryParse(aantal, out amount) && special != null)
                {
                    if (amount > 0)
                    {
                        Event eventx = special.GetEvent(voorstellingId.Value);
                        eventx.Aantal = amount;
                        if (Session[button] == null)
                            Session[button] = new List<Event>();

                        List<Event> cartlist = (List<Event>)Session[button];
                        cartlist.Add(eventx);
                        Session[button] = cartlist;
                    }
                }
                //special = dbSpecial.GetSpecial(special.ItemID);
                //special.Voorstellingen = dbVoorstelling.GetVoorstellingen(special.ItemID);
            }
            return RedirectToAction("SpecialOverview");
        }



        [HttpPost]
        public ActionResult SpecialDetailPage(Special special, int voorstellingId)
        {
            Event eventx = special.GetEvent(voorstellingId);

            if (Session["cart"] == null)
                Session["cart"] = new List<Event>();

            List<Event> cartlist = (List<Event>)Session["cart"];
            cartlist.Add(eventx);
            Session["cart"] = cartlist;

            special = dbSpecial.GetSpecial(special.ItemID);
            special.Voorstellingen = dbVoorstelling.GetVoorstellingen(special.ItemID);

            return View(special);
        }
    }
}
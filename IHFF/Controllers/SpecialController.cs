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
        public ActionResult SpecialOverview(int? voorstellingId, Special special, string aantal, string button)
        {
            if (ModelState.IsValid)
            {
                int amount = 0;
                if (voorstellingId != null && int.TryParse(aantal, out amount) && special != null)
                {
                    if (amount > 0)
                    {
                        Voorstelling v = dbVoorstelling.GetVoorstelling(voorstellingId.Value);
                        if (v.GereserveerdePlaatsen < v.MaxPlaatsen)
                        {
                            Special s = dbSpecial.GetSpecial(v.ItemID);
                            Event eventx = new Event();
                            eventx.Aantal = amount;
                            eventx.DatumTijd = v.BeginTijd;
                            eventx.Prijs = v.Prijs;
                            eventx.Titel = s.Titel;
                            eventx.VoorstellingID = v.VoorstellingID;

                            if (Session[button] == null)
                                Session[button] = new List<Event>();

                            List<Event> cartlist = (List<Event>)Session[button];
                            cartlist.Add(eventx);
                            Session[button] = cartlist;
                        }
                    }
                }

            }
            return RedirectToAction("SpecialOverview");
        }

        [HttpPost]
        public ActionResult SpecialDetailPage(int? voorstellingId, Special special, string aantal, string button)
        {
            if (ModelState.IsValid)
            {
                int amount = 0;
                if (voorstellingId != null && int.TryParse(aantal, out amount) && special != null)
                {
                    if (amount > 0)
                    {

                        Voorstelling v = dbVoorstelling.GetVoorstelling(voorstellingId.Value);

                        if (v.GereserveerdePlaatsen < v.MaxPlaatsen)
                        {
                            Event eventx = new Event();
                            Special s = dbSpecial.GetSpecial(v.ItemID);
                            eventx.Aantal = amount;
                            eventx.DatumTijd = v.BeginTijd;
                            eventx.Prijs = v.Prijs;
                            eventx.Titel = s.Titel;
                            eventx.VoorstellingID = v.VoorstellingID;
                            //Event eventx = movie.GetEvent(voorstellingId.Value);
                            //eventx.Aantal = amount;
                            if (Session[button] == null)
                                Session[button] = new List<Event>();

                            List<Event> cartlist = (List<Event>)Session[button];
                            cartlist.Add(eventx);
                            Session[button] = cartlist;
                        }

                    }
                }

            }
            special = dbSpecial.GetSpecial(special.ItemID);
            special.Voorstellingen = dbVoorstelling.GetVoorstellingen(special.ItemID);
            return View(special);
        }

        //[HttpPost]
        //public ActionResult SpecialDetailPage(Special special, int voorstellingId)
        //{
        //    Event eventx = special.GetEvent(voorstellingId);

        //    if (Session["cart"] == null)
        //        Session["cart"] = new List<Event>();

        //    List<Event> cartlist = (List<Event>)Session["cart"];
        //    cartlist.Add(eventx);
        //    Session["cart"] = cartlist;

        //    special = dbSpecial.GetSpecial(special.ItemID);
        //    special.Voorstellingen = dbVoorstelling.GetVoorstellingen(special.ItemID);

        //    return View(special);
        //}
    }
}
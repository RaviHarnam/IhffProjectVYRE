using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class ComboDealController : Controller
    {
        private IItemRepository dbItem = new DbItemRepository();
        private IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
        // GET: ComboDeal
        public ActionResult Index()
        {
            return RedirectToAction("ComboDeal");
        }

        public ActionResult ComboDeal()
        {
            IEnumerable<Item> items = dbItem.GetAllItems();

            List<ComboDeal> comboDeals = new List<ComboDeal>();

            for (int i = 0; i < 5; i++)
            {
                comboDeals.Add(new ComboDeal());
            }

            FillCombodeal(comboDeals, items, 0, 19, 0, 17, 0, 31, 0);
            FillCombodeal(comboDeals, items, 1, 7, 0, 24, 0, 32, 0);
            FillCombodeal(comboDeals, items, 2, 2, 1, 21, 0, 34, 0);
            FillCombodeal(comboDeals, items, 3, 15, 1, 1, 1, 37, 0);
            FillCombodeal(comboDeals, items, 4, 20, 1, 3, 2, 39, 0);

            return View(comboDeals);
        }

        private void FillCombodeal(List<ComboDeal> comboDeals, IEnumerable<Item> items, int comboDealIndex, int film1ID, int vId1, int film2ID, int vId2, int specialID, int vId3)
        {
            comboDeals[comboDealIndex].film1 = (Movie)PickItem(items, film1ID);
            comboDeals[comboDealIndex].voorstelling1 = comboDeals[comboDealIndex].film1.ItemVoorstelling[vId1];
            comboDeals[comboDealIndex].film2 = (Movie)PickItem(items, film2ID);
            comboDeals[comboDealIndex].voorstelling2 = comboDeals[comboDealIndex].film2.ItemVoorstelling[vId2];
            comboDeals[comboDealIndex].special = (Special)PickItem(items, specialID);
            comboDeals[comboDealIndex].voorstelling3 = comboDeals[comboDealIndex].special.ItemVoorstelling[vId3];
        }

        private Item PickItem(IEnumerable<Item> items, int Id)
        {
            foreach (Item item in items)
            {
                if (item.ItemID == Id)
                {
                    return item;
                }
            }
            return null;
        }
        [HttpPost]
        public ActionResult ComboDeal(string combo1, string combo2, string combo3, string amount, string button)
        {
            int Number1 = 0;
            int Number2 = 0;
            int Number3 = 0;
            int aantal = 0;
            if (int.TryParse(combo1, out Number1) && int.TryParse(combo2, out Number2) && int.TryParse(combo3, out Number3) && int.TryParse(amount, out aantal))
            {
                Event event1 = new Event();
                event1.Aantal = aantal;
                Voorstelling v1 = dbVoorstelling.GetVoorstelling(Number1);
                Item i1 = dbItem.GetItem(v1.ItemID);
                event1.DatumTijd = v1.BeginTijd;
                event1.Prijs = decimal.Parse("8,75");
                event1.Titel = i1.Titel;

                Event event2 = new Event();
                event2.Aantal = aantal;
                Voorstelling v2 = dbVoorstelling.GetVoorstelling(Number2);
                Item i2 = dbItem.GetItem(v2.ItemID);
                event2.DatumTijd = v2.BeginTijd;
                event2.Prijs = decimal.Parse("8,75");
                event2.Titel = i2.Titel;

                Event event3 = new Event();
                event3.Aantal = aantal;
                Voorstelling v3 = dbVoorstelling.GetVoorstelling(Number3);
                Item i3 = dbItem.GetItem(v3.ItemID);
                event3.DatumTijd = v3.BeginTijd;
                event3.Prijs = 0;
                event3.Titel = i3.Titel;

               
                    if (Session[button] == null)
                        Session[button] = new List<Event>();
                    List<Event> events = (List<Event>)Session[button];
                    events.Add(event1);
                    events.Add(event2);
                    events.Add(event3);

                    Session[button] = events;
                
              
                
            }
            return RedirectToAction("ComboDeal");
        }
    }
}
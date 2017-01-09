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
            foreach(Item item in items)
            {
                if(item.ItemID == Id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
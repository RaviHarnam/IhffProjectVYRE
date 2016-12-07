using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;


namespace IHFF.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            int i = 1;
            List<Event> events = new List<Event>();
            events.Add(new Event());
            events.Add(new Event());
            events.Add(new Event());

            foreach(Event item in events)
            {
                item.Titel = "Test " + i.ToString();
                item.Prijs = i + 100;
                item.Aantal = i + 200;
                item.DatumTijd = DateTime.Now;
                i++;
            }

            return View(events);
        }
    }
}
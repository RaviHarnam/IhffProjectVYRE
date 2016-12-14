using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using System.Web.Security;

namespace IHFF.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Session["cart"] = new List<Event>();
            List<Event> cartlist = (List<Event>)Session["cart"];

            cartlist.Add(new Event());
            cartlist.Add(new Event());
            cartlist.Add(new Event());

            int i = 1;
            foreach(Event item in cartlist)
            {
                item.Titel = "Test " + i.ToString();
                item.Prijs = i + 100;
                item.Aantal = i + 200;
                item.DatumTijd = DateTime.Now;
                i++;
            }

            return View(cartlist);
        }
    }
}
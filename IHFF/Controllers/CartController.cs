using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using System.Web.Security;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class CartController : Controller
    {



        public ActionResult Index()
        {
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            if (Session["cart"] == null)
                Session["cart"] = new List<Event>();

            List<Event> cartList = (List<Event>)Session["cart"];
            decimal totaal = 0;

            decimal korting = 0;
            foreach (Event ev in cartList)
            {
                ev.CartId = cartList.IndexOf(ev);          
                if (ev.EventVoorstelling != null)
                {
                    if (cartList.Where(m => m.EventVoorstelling != null).Count() > 1)
                    {
                        if (ev.Prijs != 0)
                        {
                            korting = decimal.Parse("0.05");
                        }
                    }
                }
                totaal += ev.BerekenTotaalPrijs();                         
            }
            totaal = totaal - (totaal * korting);
            totaal = Math.Round(totaal, 2, MidpointRounding.AwayFromZero);
            Session["cart"] = cartList;
            Session["totaalPrijs"] = totaal;
            return View("Index", cartList);
        }
        [HttpPost]
        public ActionResult Cart(string Email, string Name, string payment, string pickup)
        {
            if (!string.IsNullOrWhiteSpace(Name) && pickup == "1") //Desk
            {
                if (!string.IsNullOrWhiteSpace(payment))
                    return RedirectToAction("Payment", "Payment", new { pickup = "Desk", payment = payment, name = Name });
            }
            else if (!string.IsNullOrWhiteSpace(Email) && pickup == "2") //Send by Email
                if (!string.IsNullOrWhiteSpace(payment))
                    return RedirectToAction("Payment", "Payment", new { pickup = "Email", payment = payment, email = Email });
            return View();
        }
        public ActionResult DeleteCartItem(List<Event> cartList, int? cartId)
        {
            if (cartId != null)
            {
                if (Session["cart"] == null)
                    Session["cart"] = new List<Event>();

                cartList = (List<Event>)Session["cart"];

                Event toRemove = null;

                foreach (Event eventx in cartList)
                    if (eventx.CartId == cartId)
                        toRemove = eventx;

                cartList.Remove(toRemove);

                foreach (Event ev in cartList)
                    ev.CartId = cartList.IndexOf(ev);

                Session["cart"] = cartList;
            }
            return RedirectToAction("Index", cartList);

        }
    }
}
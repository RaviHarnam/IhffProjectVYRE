using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class WishListController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Wishlist");
        }
        
        public ActionResult Wishlist()
        {
            if (Session["wishlist"] == null)
                Session["wishlist"] = new Cart();

            Cart wishList = (Cart) Session["wishlist"];

            foreach (Event eventx in wishList.Events)
                eventx.CartId = wishList.Events.IndexOf(eventx); // assign cartid aan event

            Session["wishlist"] = wishList; // sla hem weer op in de session

            return View("Index", wishList);
        }

        [HttpPost]
        [ActionName("Wishlist")]
        public ActionResult WishlistPost() // post de events uit wishlist naar cart.
        {
            if(Session["cart"] == null)            
                Session["cart"] = new Cart();

            Cart cartEvents = (Cart)Session["cart"];
            if (Session["wishlist"] != null)
            {
                Cart events = (Cart)Session["wishlist"];
                if(events.Events.Count > 0)
                {
                    foreach(Event ev in events.Events)
                    {
                        cartEvents.Events.Add(ev);
                    }
                    Session["cart"] = cartEvents;
                }
            }
            return RedirectToAction("Wishlist");
        }

        public ActionResult DeleteWishItem(Cart wishList, int? wishlistId) // delete een specifieke wishlist item uit de lijst
        {
            if (wishlistId != null)
            {
                wishList = (Cart)Session["wishlist"];

                Event toRemove = null;

                foreach (Event eventx in wishList.Events)
                    if (eventx.CartId == wishlistId)
                        toRemove = eventx;

                wishList.Events.Remove(toRemove);

                foreach (Event ev in wishList.Events)
                    ev.CartId = wishList.Events.IndexOf(ev);

                Session["wishlist"] = wishList;
            }
            return RedirectToAction("Index", wishList);

        }
    }
}
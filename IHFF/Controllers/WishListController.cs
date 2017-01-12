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
                Session["wishlist"] = new List<Event>();

            List<Event> wishList = (List<Event>)Session["wishlist"];

            foreach (Event eventx in wishList)
                eventx.CartId = wishList.IndexOf(eventx); // assign cartid aan event

            Session["wishlist"] = wishList; // sla hem weer op in de session

            return View("Index", wishList);
        }
        [HttpPost]
        [ActionName("Wishlist")]
        public ActionResult WishlistPost()
        {
            if(Session["cart"] == null)            
                Session["cart"] = new List<Event>();

            List<Event> cartEvents = (List<Event>)Session["cart"];
            if (Session["wishlist"] != null)
            {
                List<Event> events = (List<Event>)Session["wishlist"];
                if(events.Count > 0)
                {
                    foreach(Event ev in events)
                    {
                        cartEvents.Add(ev);
                    }
                    Session["cart"] = cartEvents;
                }
            }
            return RedirectToAction("Wishlist");
        }

        public ActionResult DeleteWishItem(List<Event> wishList, int? wishlistId)
        {
            if (wishlistId != null)
            {
                if (Session["wishlist"] == null)
                    Session["wishlist"] = new List<Event>();

                wishList = (List<Event>)Session["wishlist"];

                Event toRemove = null;

                foreach (Event eventx in wishList)
                    if (eventx.CartId == wishlistId)
                        toRemove = eventx;

                wishList.Remove(toRemove);

                foreach (Event ev in wishList)
                    ev.CartId = wishList.IndexOf(ev);

                Session["wishlist"] = wishList;
            }
            return RedirectToAction("Index", wishList);

        }
    }
}
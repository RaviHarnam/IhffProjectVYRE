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
        private IEventRepository repository = new DbEventRepository();

        public ActionResult Index()
        {
            if (Session["cart"] == null)
                Session["cart"] = new List<Event>();

            List<Event> cartList = (List<Event>)Session["cart"];

            foreach (Event ev in cartList)
                ev.CartId = cartList.IndexOf(ev);

            Session["cart"] = cartList;

            return View(cartList);

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
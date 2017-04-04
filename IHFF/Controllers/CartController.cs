using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Models.Input;
using IHFF.Enum;
using IHFF.Helpers;
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
            Cart cart = null;

            if (Session["cart"] == null)
            {
                Session["cart"] = new Cart();
                cart = (Cart)Session["cart"];
            }
            else
            {
                cart = (Cart)Session["cart"];

                cart.BerekenTotaal();
            }


            return View("Index", cart);
        }

        [HttpPost]
        public ActionResult Cart(Cart cart)
        {
            if (ModelState.IsValid)
            { 
                return RedirectToAction("Payment", "Payment", cart);
            }

            return RedirectToAction("Cart");
        }

        public ActionResult DeleteCartItem(int eventId)
        {
            Cart cart = (Cart)Session["cart"];

            Session["cart"] = cart.DeleteItem(eventId);

            return RedirectToAction("Index", cart);
        }
    }
}
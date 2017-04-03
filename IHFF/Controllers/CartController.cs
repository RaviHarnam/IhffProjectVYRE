﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
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
            Cart cart = new Cart();

            if (Session["cart"] == null)
            {
                Session["cart"] = new Cart();
            }
            else
            {
                cart = (Cart)Session["cart"];

                cart.BerekenTotaal();

                Session["cart"] = cart;
            }

            return View("Index", cart);
        }

        [HttpPost]
        public ActionResult Cart(string Email, string Name, string payment, string pickup)
        {
            if (ModelState.IsValid)
            {
                if (pickup == "1") //Desk
                    return RedirectToAction("Payment", "Payment", new { pickup = "Desk", payment = payment, name = Name });

                else if (pickup == "2") //Send by Email
                    return RedirectToAction("Payment", "Payment", new { pickup = "Email", payment = payment, email = Email });
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
using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class PaymentController : Controller
    {
        private IBestellingRepository db = new DbBestellingRepository();
        // GET: Payment
        public ActionResult Index()
        {
            return RedirectToAction("Cart", "Cart");
        }
        
        public ActionResult Payment(string payment, string name, string email, string pickup)
        {
            Session["bestellingInfo"] = new List<string>() //Vullen met bestellingopties
            {
                payment, name, email, pickup
            };
            return View("Payment", model: payment);
        }

        [HttpPost]
        public ActionResult Payment()
        {
            //Maak bestelling
            if(Session["cart"] != null && Session["bestellingInfo"] != null) //Check Session data
            {
                List<Event> events = (List<Event>)Session["cart"]; //Lijst van events
                List<string> info = (List<string>)Session["bestellingInfo"]; //Lijst van aantal bestelling opties
                if(events.Count > 0)
                {
                    db.MaakBestelling(events, info[0], info[1], info[2], info[3]); //Maak bestelling in database    
                    Session["cart"] = null; //Cart legen
                    return RedirectToAction("Done"); //Betaling gelukt
                }
            }
            return RedirectToAction("Cart", "Cart"); //Terug naar cart omdat cart leeg is
        }

        public ActionResult Done()
        {
            return View();
        }
    }
}
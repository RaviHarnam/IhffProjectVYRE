using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class FoodController : Controller
    {
        private IFoodRepository dbFood = new DbFoodRepository();
        IMealRepository dbMeal = new DbMealRepository();

        // GET: Food
        public ActionResult Index()
        {           
            return RedirectToAction("FoodOverview");
        }

        public ActionResult FoodOverview()
        {
            IEnumerable<Restaurant> restaurants = dbFood.GetAllRestaurants();
            return View(restaurants);
        }
        public ActionResult FoodDetailPage(int? food_id)
        {
            if (food_id != null)
            {
                Restaurant restaurant = dbFood.GetRestaurant(food_id.Value);

                return View(restaurant);
            }
            return RedirectToAction("FoodOverview");
        }
        [HttpPost]
        public ActionResult FoodDetailPage(Restaurant r, string aantal, int maaltijdid, int maaltijdUur, string minuten)
        {
            int aantalConverted = 0;
            int minutenConverted = 0;
            Restaurant rst = dbFood.GetRestaurant(r.RestaurantID);
            if (int.TryParse(aantal, out aantalConverted) && int.TryParse(minuten, out minutenConverted))
            {
                Event eventx = new Event();
                eventx.Aantal = aantalConverted;
                Maaltijd m = dbMeal.GetMaaltijd(maaltijdid);
               
                //Uren
                eventx.DatumTijd = m.BeginTijd;
                int verschilUren = eventx.DatumTijd.Hour - maaltijdUur;
                eventx.DatumTijd.AddHours(verschilUren);
                //Minuten
                int verschilMinuten = eventx.DatumTijd.Minute - minutenConverted;
                eventx.DatumTijd.AddMinutes(minutenConverted);
                //Rest
                eventx.Titel = m.MaaltijdRestaurant.Naam;
                eventx.Prijs = m.MaaltijdPrijs;
                eventx.MaaltijdId = m.MaaltijdID;

                if (Session["cart"] == null)
                    Session["cart"] = new List<Event>();

                List<Event> cartlist = (List<Event>)Session["cart"];
                cartlist.Add(eventx);
                Session["cart"] = cartlist;
            }
            return View(rst);
        }

        public ActionResult FillUren(int maaltijdId)
        {
            var uren = dbFood.GetUren(maaltijdId);
            return Json(uren, JsonRequestBehavior.AllowGet);
        }
    }
}
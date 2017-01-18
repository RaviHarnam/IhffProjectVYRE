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
        public ActionResult FoodDetailPage(Restaurant r, int? maaltijdid, int? maaltijdUur) //Cart
        {
            Restaurant rst = dbFood.GetRestaurant(r.RestaurantID);
            if (ModelState.IsValid)
            {
                if (maaltijdid != null && maaltijdUur != null)
                {
                    Event eventx = new Event();
                    eventx.Aantal = r.MaaltijdInputModel.Aantal;
                    Maaltijd m = dbMeal.GetMaaltijd(maaltijdid.Value);

                    //Uren
                    eventx.DatumTijd = m.BeginTijd;
                    eventx.DatumTijd = eventx.DatumTijd - new TimeSpan(eventx.DatumTijd.Hour, 0, 0);
                    eventx.DatumTijd = eventx.DatumTijd + new TimeSpan(maaltijdUur.Value, 0, 0);
                    //Minuten
                    eventx.DatumTijd = eventx.DatumTijd - new TimeSpan(0, eventx.DatumTijd.Minute, 0);
                    eventx.DatumTijd = eventx.DatumTijd + new TimeSpan(0, r.MaaltijdInputModel.minuten, 0);
                    //Rest
                    eventx.Titel = m.MaaltijdRestaurant.Naam;
                    eventx.Prijs = m.MaaltijdPrijs;
                    eventx.MaaltijdID = m.MaaltijdID;
                    eventx.EventEindTijd = m.EindTijd;
                    if (Request.Form["buttoncart"] != null)
                    {
                        if (Session["cart"] == null)
                            Session["cart"] = new List<Event>();

                        List<Event> cartlist = (List<Event>)Session["cart"];
                        cartlist.Add(eventx);
                        Session["cart"] = cartlist;
                    }
                    else if (Request.Form["buttonwish"] != null)
                    {
                        if (Session["wishlist"] == null)
                            Session["wishlist"] = new List<Event>();

                        List<Event> wishlistList = (List<Event>)Session["wishlist"];
                        wishlistList.Add(eventx);
                        Session["wishlist"] = wishlistList;
                    }
                }
            }
            return View(rst);
        }
           

    [HttpPost]
    public ActionResult FoodOverview(string restaurantid, string aantal, int? maaltijdid, int? maaltijdUur, string minuten, Restaurant r) //Cart
    {
        int rstid = 0;
        if (int.TryParse(restaurantid, out rstid) && maaltijdid != null && maaltijdUur != null)
        {
            Restaurant rst = dbFood.GetRestaurant(rstid);
            if (ModelState.IsValid)
            {
                Event eventx = new Event();
                eventx.Aantal = r.MaaltijdInputModel.Aantal;
                Maaltijd m = dbMeal.GetMaaltijd(maaltijdid.Value);

                //Uren
                eventx.DatumTijd = m.BeginTijd;
                eventx.DatumTijd = eventx.DatumTijd - new TimeSpan(eventx.DatumTijd.Hour, 0, 0);
                eventx.DatumTijd = eventx.DatumTijd + new TimeSpan(maaltijdUur.Value, 0, 0);
                //Minuten
                eventx.DatumTijd = eventx.DatumTijd - new TimeSpan(0, eventx.DatumTijd.Minute, 0);
                eventx.DatumTijd = eventx.DatumTijd + new TimeSpan(0, r.MaaltijdInputModel.minuten, 0);
                //Rest
                eventx.Titel = m.MaaltijdRestaurant.Naam;
                eventx.Prijs = m.MaaltijdPrijs;
                eventx.MaaltijdID = m.MaaltijdID;
                if (Request.Form["buttoncart"] != null)
                {
                    if (Session["cart"] == null)
                        Session["cart"] = new List<Event>();

                    List<Event> cartlist = (List<Event>)Session["cart"];
                    cartlist.Add(eventx);
                    Session["cart"] = cartlist;
                }
                else if (Request.Form["buttonwish"] != null)
                {
                    if (Session["wishlist"] == null)
                        Session["wishlist"] = new List<Event>();

                    List<Event> wishlistList = (List<Event>)Session["wishlist"];
                    wishlistList.Add(eventx);
                    Session["wishlist"] = wishlistList;
                }
            }
        }

        return RedirectToAction("FoodOverview");
    }

    public ActionResult FillUren(int maaltijdId)
    {
        var uren = dbFood.GetUren(maaltijdId);
        return Json(uren, JsonRequestBehavior.AllowGet);
    }
}
}
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




    }
}
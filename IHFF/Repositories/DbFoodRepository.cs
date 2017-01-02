using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbFoodRepository : IFoodRepository
    {
        private IhffContext ctx = new IhffContext();

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurants = ctx.RESTAURANTS.ToList();
            // Loop door de lijst heen en vul de afbeeldingen erin.
            foreach (Restaurant rst in restaurants)
            {
                rst.RestaurantAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.RestaurantID == rst.RestaurantID && a.Type == "restaurantoverview");                
            }

            return restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant rst = ctx.RESTAURANTS.SingleOrDefault(i => i.RestaurantID == id);

            rst.RestaurantAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.RestaurantID == rst.RestaurantID && a.Type == "restaurantbanner");

            return rst;
        }
    }
}
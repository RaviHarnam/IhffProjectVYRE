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
                rst.RestaurantMaaltijd = (from m in ctx.MAALTIJD
                                          where m.RestaurantID == rst.RestaurantID
                                          select m).ToList();
            }

            return restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant rst = ctx.RESTAURANTS.SingleOrDefault(i => i.RestaurantID == id);

            rst.RestaurantAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.RestaurantID == rst.RestaurantID && a.Type == "restaurantbanner");
            rst.RestaurantLocatie = ctx.LOCATIES.SingleOrDefault(a => a.LocatieID == rst.LocatieID);
            rst.RestaurantMaaltijd = (from m in ctx.MAALTIJD
                                      where m.RestaurantID == rst.RestaurantID
                                      select m).ToList();
            return rst;
        }

        public IEnumerable<int> GetUren(int maaltijdId)
        {
            DateTime begintijd = (from m in ctx.MAALTIJD where m.MaaltijdID == maaltijdId select m.BeginTijd).SingleOrDefault();
            DateTime eindtijd  = (from m in ctx.MAALTIJD where m.MaaltijdID == maaltijdId select m.EindTijd).SingleOrDefault();

            DateTime tijd = new DateTime();
            tijd = begintijd;
            double Verschil = (eindtijd - begintijd).TotalHours;

            List<int> uren = new List<int>();    
              
            for(int i = 0; i < Verschil; i++)
            {
                tijd = begintijd.AddHours(i);
                uren.Add(tijd.Hour);
            }
            return uren;
        }
    }
}


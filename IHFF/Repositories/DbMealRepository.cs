using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbMealRepository : IMealRepository
    {
        private IhffContext ctx = new IhffContext();
        
        public IEnumerable<Maaltijd> GetAllMaaltijd()
        {
            throw new NotImplementedException();
        }

        public Maaltijd GetMaaltijd(int id)
        {
            Maaltijd maaltijd = ctx.MAALTIJD.SingleOrDefault(m => m.MaaltijdID == id);
            maaltijd.MaaltijdRestaurant = ctx.RESTAURANTS.SingleOrDefault(r => r.RestaurantID == maaltijd.RestaurantID);
            maaltijd.MaaltijdLocatie = ctx.LOCATIES.SingleOrDefault(r => r.LocatieID == maaltijd.MaaltijdRestaurant.LocatieID);
            return maaltijd;
        }
    }
}
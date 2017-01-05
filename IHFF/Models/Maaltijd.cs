using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Maaltijd
    {
        public int MaaltijdID { get; set; }
        public decimal MaaltijdPrijs { get; set; }
        public DateTime BeginTijd { get; set;}
        public DateTime EindTijd { get; set; }
        public int MaxPlaatsen { get; set; }
        public int GereserveerdePlaatsen { get; set; }
        public int RestaurantID { get; set; }

        [NotMapped]
       public virtual Restaurant MaaltijdRestaurant { get; set; }

        public Maaltijd(int maaltijdID, decimal maaltijdPrijs, DateTime beginTijd, DateTime eindTijd, int maxPlaatsen, int gereseveerdePlaatsen, int restaurantID)
        {
            MaaltijdID = maaltijdID;
            MaaltijdPrijs = maaltijdPrijs;
            BeginTijd = beginTijd;
            EindTijd = eindTijd;
            MaxPlaatsen = maxPlaatsen;
            GereserveerdePlaatsen = gereseveerdePlaatsen;            
            RestaurantID = restaurantID;
        }
        public Maaltijd()
        {

        }

    }
}
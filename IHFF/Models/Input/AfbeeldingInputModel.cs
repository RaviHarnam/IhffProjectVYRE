using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class AfbeeldingInputModel
    {
        public int AfbeeldingID { get; set; }
        public int? ItemID { get; set; }
        public string Link { get; set; }
        public int? MuseumID { get; set; }
        public int? RestaurantID { get; set; }
        public string Type { get; set; }

        public AfbeeldingInputModel(int? itemId, int? MuseumId, int? RestaurantId, string link, string type)
        {
            ItemID = itemId;
            MuseumID = MuseumId;
            RestaurantID = RestaurantId;
            Link = link;
            Type = type;
        }
        public AfbeeldingInputModel()
        {

        }


    }
}
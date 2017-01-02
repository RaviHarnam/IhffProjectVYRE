using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class AfbeeldingInputModel
    {
        public int AfbeeldingID { get; set; }
        public int? ItemID { get; set; }
        [Required]
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

        public void ConvertToAfbeeldingInputModel(Afbeelding a)
        {
            AfbeeldingID = a.AfbeeldingID;
            ItemID = a.ItemID;
            RestaurantID = a.RestaurantID;
            Link = a.Link;
            MuseumID = a.MuseumID;
            Type = a.Type;
        }
    }
}
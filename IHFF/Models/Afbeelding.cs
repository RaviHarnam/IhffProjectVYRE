using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Afbeelding
    {
        [Key]   
        public int AfbeeldingID { get; set; }
        [StringLength(100, ErrorMessage = "The Link field has a maximum size of 100.")]
        public string Link { get; set; }
        public int? ItemID { get; set; }
        public int? MuseumID { get; set; }
        public int? RestaurantID { get; set; }
        public int? HotelID { get; set; }
        public string Type { get; set; }

        public Afbeelding()
        {

        }

        public Afbeelding(int? itemId, int? museumId, int? restaurantId, string sourceUrl, string type)
        {
            ItemID = itemId;
            MuseumID = museumId;
            RestaurantID = restaurantId;
            Link = sourceUrl;
            Type = type;
        }
    }
}
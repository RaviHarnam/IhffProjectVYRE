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
        public string Link { get; set; }
        public int? ItemID { get; set; }
        public int? MuseumID { get; set; }
        public int? RestaurantID { get; set; }
        public string Type { get; set; }

        public Afbeelding()
        {

        }

        public Afbeelding(string sourceUrl, string type)
        {
            Link = sourceUrl;
            Type = Type;
        }
    }
}
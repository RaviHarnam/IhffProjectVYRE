using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class EventListRepresentation
    {
        public virtual Item item { get; set; }
        public virtual Restaurant restaurant { get; set; }
        public virtual Museum culture { get; set; }
        public virtual Hotel hotel { get; set; }
        public virtual NewsMessage news { get; set; }
        //public int? ItemID { get; set; }
        //public int? MuseumID { get; set; }
        //public int? RestaurantID { get; set; }
        //public string Titel { get; set; }

        public EventListRepresentation(Item i)
        {
            item = i;
        }

        public EventListRepresentation(Restaurant r)
        {
            restaurant = r;
        }        
        public EventListRepresentation(Museum c)
        {
            culture = c;
        }
        public EventListRepresentation(Hotel h)
        {
            hotel = h;
        }

        public EventListRepresentation(NewsMessage m)
        {
            news = m;
        }

        public EventListRepresentation()
        {

        }
    }
}
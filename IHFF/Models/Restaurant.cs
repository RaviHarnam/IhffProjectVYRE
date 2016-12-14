using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Contact { get; set; }
        public int LocatieID { get; set; }
        [NotMapped]
        public virtual Afbeelding RestaurantAfbeelding {get; set;}
        public Restaurant(string naam, string omschrijving, string contact)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Contact = contact;
        }
        public Restaurant()
        {

        }

    }
}
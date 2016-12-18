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
        public string Telefoon { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int LocatieID { get; set; }
        [NotMapped]
        public virtual Afbeelding RestaurantAfbeelding {get; set;}
        [NotMapped]
        public virtual Locatie RestaurantLocatie { get; set; }

        public Restaurant(string naam, string omschrijving, string telefoon, string email, string website)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Telefoon = telefoon;
            Email = email;
            Website = website;
        }
        public Restaurant()
        {

        }

    }
}
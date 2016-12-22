using IHFF.Models.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        [Display(Name = "Name")]
        public string Naam { get; set; }

        public string Omschrijving { get; set; }
        [Display(Name = "Telephone")]
        public string Telefoon { get; set; }
        [Display(Name = "E-mail")]
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

        public void Edit(Restaurant r)
        {
            Naam = r.Naam;
            Omschrijving = r.Omschrijving;
            Telefoon = r.Telefoon;
            Email = r.Email;
            Website = r.Website;
            RestaurantAfbeelding.Link = r.RestaurantAfbeelding.Link;
            RestaurantLocatie.Straat = r.RestaurantLocatie.Straat;
            RestaurantLocatie.Huisnummer = r.RestaurantLocatie.Huisnummer;
            RestaurantLocatie.Toevoeging = r.RestaurantLocatie.Toevoeging;
            RestaurantLocatie.Postcode = r.RestaurantLocatie.Postcode;
        }
        public void ConvertFromRestaurantInputModel(RestaurantInputModel r)
        {
            Naam = r.Naam;
            Omschrijving = r.Omschrijving;
            Telefoon = r.Telefoon;
            Email = r.Email;
            Website = r.Website;
            RestaurantAfbeelding = r.RestaurantAfbeelding;
            RestaurantLocatie = r.RestaurantLocatie;
            //RestaurantLocatie.Straat = r.RestaurantLocatie.Straat;
            //RestaurantLocatie.Huisnummer = r.RestaurantLocatie.Huisnummer;
            //RestaurantLocatie.Toevoeging = r.RestaurantLocatie.Toevoeging;
            //RestaurantLocatie.Postcode = r.RestaurantLocatie.Postcode;
        }

    }
}
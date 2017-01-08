using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class RestaurantInputModel
    {
        public int RestaurantID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        [Required]
        [Display(Name = "Telephone")]
        public string Telefoon { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        public string Website { get; set; }

        public int LocatieID { get; set; }

        [NotMapped]
        public virtual Afbeelding RestaurantAfbeelding { get; set; }
        [NotMapped]
        public virtual Locatie RestaurantLocatie { get; set; }

        public RestaurantInputModel(string naam, string omschrijving, string telefoon, string email, string website)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Telefoon = telefoon;
            Email = email;
            Website = website;
        }
        public RestaurantInputModel()
        {

        }

        public void ConvertToRestaurantInputModel(Restaurant r)
        {
            RestaurantID = r.RestaurantID;
            Naam = r.Naam;
            Omschrijving = r.Omschrijving;
            Telefoon = r.Telefoon;
            Email = r.Email;
            Website = r.Website;
            LocatieID = r.LocatieID;
            RestaurantLocatie = r.RestaurantLocatie;
            RestaurantAfbeelding = r.RestaurantAfbeelding;
        }
    }
}
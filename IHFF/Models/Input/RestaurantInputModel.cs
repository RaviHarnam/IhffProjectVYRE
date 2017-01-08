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
        [StringLength(400, ErrorMessage = "The Name field has a maximum size of 400.")]
        public string Naam { get; set; }
        [Required]
        [StringLength(3000, ErrorMessage = "The Summary field has a maximum size of 3000.")]
        public string Omschrijving { get; set; }
        [Required]
        [Display(Name = "Telephone")]
        [StringLength(20, ErrorMessage = "The Telephone field has a maximum size of 20.")]
        public string Telefoon { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [StringLength(40, ErrorMessage = "The E-mail field has a maximum size of 40.")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Website field has a maximum size of 100.")]
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
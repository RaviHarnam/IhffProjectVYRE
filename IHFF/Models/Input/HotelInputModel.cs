using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class HotelInputModel
    {
        public int HotelId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [Display(Name = "Name")]
        [StringLength(50,ErrorMessage = "The Name field has a maximum length of 50 characters.")]
        public string Naam { get; set; }

        [Required(ErrorMessage ="The Description field is required.")]
        [StringLength(4000, ErrorMessage = "The Description field has a maximum length of 4000 characters.")]
        [Display(Name = "Description")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        [Display(Name = "Address")]
        [StringLength(4000, ErrorMessage = "The Address field has a maximum of 4000 characters.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "The City field has a maximum of 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "The Postal code field is required.")]
        [StringLength(50, ErrorMessage ="The Postal code field has a maximum of 50 characters.")]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "The Telephone number field is required.")]
        [Display(Name = "Telephone number")]
        [StringLength(50, ErrorMessage = "The Telephone number field has a maximum of 50 characters.")]
        public string TelefoonNummer { get; set; }

        [Required(ErrorMessage = "The Website field is required.")]
        [Display(Name = "Website")]
        [StringLength(4000, ErrorMessage = "The Website field has a maximum of 4000 characters.")]
        public string Website { get; set; }

        [NotMapped]
        public virtual Afbeelding BannerAfbeelding { get; set; }

        [NotMapped]
        public virtual Afbeelding OverviewAfbeelding { get; set; }

        public HotelInputModel(Hotel h)
        {
            HotelId = h.HotelId;
            Naam = h.Naam;
            Omschrijving = h.Omschrijving;
            Adres = h.Adres;
            City = h.City;
            PostalCode = h.PostalCode;
            TelefoonNummer = h.TelefoonNummer;
            Website = h.Website;
            BannerAfbeelding = h.HotelAfbeelding;
            OverviewAfbeelding = h.HotelOverviewAfbeelding;
        }

        public HotelInputModel() { }

    }
}
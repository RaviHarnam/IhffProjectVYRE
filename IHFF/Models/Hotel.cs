using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Display(Name = "Name:")]
        public string Naam { get; set; }
        
        [Display(Name = "Description:")]
        public string Omschrijving { get; set; }

        [Display(Name = "Address:")]
        public string Adres { get; set; }

        [Display(Name = "Postal code:")]
        public string PostalCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name ="Telephone Number:")]
        public string TelefoonNummer { get; set; }

        [Display(Name = "Website:")]
        public string Website { get; set; }

        [NotMapped]
        [Display(Name = "Banner image:")]
        public Afbeelding HotelAfbeelding { get; set; }

        [NotMapped]
        [Display(Name = "Overview image:")]
        public Afbeelding HotelOverviewAfbeelding { get; set; }

        public Hotel() { }
        
        public Hotel(string naam, string omschrijving, string adres, string telefoonNummer, string website)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Adres = adres;
            TelefoonNummer = telefoonNummer;
            Website = website;
        }
    }
}
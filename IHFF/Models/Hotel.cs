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

        [Display(Name = "Name")]
        public string Naam { get; set; }
        
        [Display(Name = "Description")]
        public string Omschrijving { get; set; }

        [Display(Name = "Address")]
        public string Adres { get; set; }

        [Display(Name ="Telephone Number")]
        public string TelefoonNummer { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [NotMapped]
        public Afbeelding HotelAfbeelding { get; set; }

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
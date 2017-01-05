using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IHFF.Models.Input;

namespace IHFF.Models
{
    public class Locatie
    {
        public int LocatieID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Straat { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int Huisnummer { get; set; }

        
        [Display(Name = "Addition")]
        [MaxLength(5)]
        public string Toevoeging { get; set; }

        [Required]
        [Display(Name = "Postal")]
        public string Postcode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string Plaats { get; set; }



        public Locatie(string naam, string straat, int huisnummer, string toevoeging, string postcode, string plaats)
        {
            Naam = naam;
            Straat = straat;
            Huisnummer = huisnummer;
            Toevoeging = toevoeging;
            Postcode = postcode;
            Plaats = plaats;
        }
        public Locatie()
        {

        }

        public void ConvertFromLocatieInputModel(LocatieInputModel l)
        {
            Naam = l.Naam;
            Straat = l.Straat;
            Huisnummer = l.Huisnummer;
            Toevoeging = l.Toevoeging;
            Postcode = l.Postcode;
            Plaats = l.Plaats;
        }
    }
}
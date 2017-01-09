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
         
        [Display(Name = "Name")]        
        public string Naam { get; set; }

        [Required(ErrorMessage = "The field Street is required.")]
        [Display(Name = "Street")]
        [StringLength(100, ErrorMessage = "The Street field has a maximum size of 100.")]
        public string Straat { get; set; }

        [Required(ErrorMessage = "The field Number is required.")]
        [Display(Name = "Number")]  
        public int Huisnummer { get; set; }
 
        [Display(Name = "Addition")]
        [StringLength(5, ErrorMessage = "The Addition field has a maximum size of 5.")]
        public string Toevoeging { get; set; }

        [Required(ErrorMessage = "The Postal field is required.")]
        [Display(Name = "Postal")]
        [StringLength(6, ErrorMessage = "The Postal field has a maximum size of 6.")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        [Display(Name = "City")]
        [StringLength(25, ErrorMessage = "The City field has a maximum size of 25.")]
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
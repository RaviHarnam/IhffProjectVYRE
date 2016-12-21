﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Locatie
    {
        public int LocatieID { get; set; }
        [Display(Name = "Name")]
        public string Naam { get; set; }
        [Display(Name = "Street")]
        public string Straat { get; set; }
        [Display(Name = "Number")]
        public int Huisnummer { get; set; }
        [Display(Name = "Addition")]
        public string Toevoeging { get; set; }
        [Display(Name = "Postal")]
        public string Postcode { get; set; }
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
    }
}
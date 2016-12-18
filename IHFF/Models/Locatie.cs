using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Locatie
    {
        public int LocatieID { get; set; }
        public string Naam { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string Toevoeging { get; set; }
        public string Postcode { get; set; }
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
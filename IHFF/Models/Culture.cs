using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Culture 
    {
        public int CultureID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Contact { get; set; }
        public string Admission { get; set; }
        public int LocatieID { get; set; }

        public Culture()
        {

        }

        public Culture(string naam, string omschrijving, string contact, string admission)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Contact = contact;
            Admission = admission;
        }
    }
}
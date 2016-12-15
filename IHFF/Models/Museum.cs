using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Museum 
    {
        public int MuseumID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Contact { get; set; }
        public string Admission { get; set; }
        public int LocatieID { get; set; }
        public string Openingstijden { get; set; }
        [NotMapped]
        public virtual Afbeelding CultureAfbeelding { get; set; }

        public Museum()
        {

        }

        public Museum(string naam, string omschrijving, string contact, string admission, string openingstijden)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Contact = contact;
            Admission = admission;
            Openingstijden = openingstijden;
        }
    }
}
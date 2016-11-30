using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public class Movies : Activiteit
    {
        public Movies(string titel, string info, string omschrijving, string datumTijd, double prijs) : base(titel, info, omschrijving, datumTijd, prijs)
        {
        }

        public int id { get; set; }
        public DateTime datumTijd { get; set; }
        public int aantalTickets { get; set; }
        
    }
}
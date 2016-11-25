using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public abstract class Activiteit
    {
        public int ActiviteitID { get; set; }
        public string Titel { get; set; }
        public string Info { get; set; }
        public string Omschrijving { get; set; }
        public string DatumTijd { get; set; }
        public double Prijs { get; set; }

        public Activiteit(string titel, string info, string omschrijving, string datumTijd, double prijs)
        {
            Titel = titel;
            Info = Info;
            Omschrijving = Omschrijving;
            DatumTijd = datumTijd;
            Prijs = prijs;
        }

        


    }
}
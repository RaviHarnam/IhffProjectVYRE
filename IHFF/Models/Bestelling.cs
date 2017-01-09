using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public string Status { get; set; }
        public DateTime Datum { get; set; }
        public string OphaalMethode { get; set; }
        public string BetaalMethode { get; set; }
        public int KlantID { get; set; }

        [NotMapped]
        public decimal TotaalPrijs { get; set; }
        [NotMapped]
        public virtual List<Event> Events { get; set; }

        public Bestelling(string ophaalmethode, string betaalmethode)
        {
            OphaalMethode = ophaalmethode;
            BetaalMethode = betaalmethode;
            Status = "In Verwerking";
            Datum = DateTime.Now;
        }
        public Bestelling()
        {
            //Leeg
        }
        public decimal BerekenTotaal()
        {
            //foreach (Event ev in Events)
            //    TotaalPrijs += ev.BerekenPrijs;
            return TotaalPrijs;
        }

    }
}
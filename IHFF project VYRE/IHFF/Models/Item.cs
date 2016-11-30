using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int BestellingId { get; set; }
        public int ActiviteitId { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public DateTime DatumTijd { get; set; }

        public Item(int bestellingId, int activiteitId, double prijs, int aantal, DateTime datumTijd)
        {
            BestellingId = bestellingId;
            ActiviteitId = activiteitId;
            Prijs = prijs;
            Aantal = aantal;
            DatumTijd = datumTijd;
        }

        public double BerekenPrijs()
        {
            return Aantal * Prijs;
        }
    }
}
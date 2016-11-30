using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public string Status { get; set; }
        public DateTime DatumTijd { get; set; }
        public double TotaalPrijs { get; set; }
        public int KlantId { get; set; }
    
        public List<Item> bestellingItems;

        public Bestelling(int klantId)
        {
            KlantId = klantId;
            Status = "Onvoltooid";
            DatumTijd = DateTime.Now;
            TotaalPrijs = 0;
        }

        public double BerekenTotaal()
        {
            foreach(Item bestellingItem in bestellingItems)
            {
                TotaalPrijs += bestellingItem.BerekenPrijs();
            }
            return TotaalPrijs;
        }
    }
}
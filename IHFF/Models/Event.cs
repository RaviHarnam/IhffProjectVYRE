using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Titel { get; set; }
        public int BestellingID { get; set; }
        public int? VoorstellingID { get; set; }
        public decimal Prijs { get; set; }
        public int Aantal { get; set; }
        public DateTime DatumTijd { get; set; }       
        public int? MaaltijdID { get; set; }

        public Event()
        {
        }


        [NotMapped]
        public int CartId { get; set; }
        [NotMapped]
        public int WishListId { get; set; }



        public decimal BerekenTotaalPrijs()
        {
            if (VoorstellingID != null)
                return Prijs * Aantal;
            return Prijs;
        }
    }

}
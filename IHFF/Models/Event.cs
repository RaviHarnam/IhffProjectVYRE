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
        public Event() { }

        public int EventId { get; set; }
        public string Titel { get; set; }
        public int Bestellingid { get; set; }
        public int VoorstellingId { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public DateTime DatumTijd { get; set; }
        [NotMapped]
        public string GeselecteerdeDatumTijd { get; set; }
        public int MaaltijdId { get; set; }
    }

}
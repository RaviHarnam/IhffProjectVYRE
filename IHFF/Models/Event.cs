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
        public int EventId { get; set; }
        [NotMapped]
        public int CartId { get; set; }
        public string Titel { get; set; }
        public int Bestellingid { get; set; }
        public int VoorstellingId { get; set; }
        public decimal Prijs { get; set; }
        public int Aantal { get; set; }
        public DateTime DatumTijd { get; set; }
        [NotMapped]
        public string GeselecteerdeDatumTijd { get; set; }
        public int MaaltijdId { get; set; }
        public Event() { }

        public void MakeEvent(Movie movie, Voorstelling voorstelling)
        {
            Titel = movie.Titel;
            DatumTijd = voorstelling.DatumTijd;
            Aantal = movie.Aantal;
            Prijs = voorstelling.Prijs;
        }

        public void MakeEvent(Special special, Voorstelling voorstelling)
        {
            Titel = special.Titel;
            DatumTijd = voorstelling.DatumTijd;
            Aantal = special.Aantal;

        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class HotelInputModel
    {
        public int HotelId { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Adres { get; set; }
        public string TelefoonNummer { get; set; }
        public string Website { get; set; }
        public Afbeelding HotelAfbeelding { get; set; }

        public HotelInputModel() { }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class HotelInputModel
    {
        public int HotelId { get; set; }
        [StringLength(50)]
        public string Naam { get; set; }
        [StringLength(4000)]
        public string Omschrijving { get; set; }
        [StringLength(4000)]
        public string Adres { get; set; }
        [StringLength(50)]
        public string TelefoonNummer { get; set; }
        [StringLength(50)]
        public string Website { get; set; }
        public Afbeelding HotelAfbeelding { get; set; }

        public HotelInputModel() { }
    }
}
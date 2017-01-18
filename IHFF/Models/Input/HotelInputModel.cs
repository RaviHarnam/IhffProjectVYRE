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
        public string City { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public string TelefoonNummer { get; set; }
        [StringLength(50)]
        public string Website { get; set; }
        public Afbeelding BannerAfbeelding { get; set; }
        public Afbeelding OverviewAfbeelding { get; set; }

        public HotelInputModel(Hotel h)
        {
            HotelId = h.HotelId;
            Naam = h.Naam;
            Omschrijving = h.Omschrijving;
            Adres = h.Adres;
            TelefoonNummer = h.TelefoonNummer;
            Website = h.Website;
            BannerAfbeelding = h.HotelAfbeelding;
            OverviewAfbeelding = h.HotelOverviewAfbeelding;
        }

        public HotelInputModel() { }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Adres { get; set; }
        public string TelefoonNummer { get; set; }
        public string website { get; set; }
        public Afbeelding HotelAfbeelding { get; set; }

        public Hotel() { }
        

    }
}
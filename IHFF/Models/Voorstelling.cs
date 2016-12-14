using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Voorstelling
    {
        public int VoorstellingId { get; set; }
        public int ItemId { get; set; }
        public string Categorie { get; set; }
        public DateTime DatumTijd { get; set; }
        public double Prijs { get; set; }
        public int MaxPlaatsen { get; set; }
        public int GereserveerdePlaatsen { get; set; }
        public int LocatieId { get; set; }
    }
}
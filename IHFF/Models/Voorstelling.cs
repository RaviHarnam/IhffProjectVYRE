using IHFF.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Voorstelling
    {
        public int VoorstellingId { get; set; }
        public int ItemId { get; set; }
        //public string Categorie { get; set; }
        public DateTime DatumTijd { get; set; }
        
        public decimal Prijs { get; set; }
        public int MaxPlaatsen { get; set; }
        public int GereserveerdePlaatsen { get; set; }
        public int LocatieId { get; set; }

        public virtual Locatie VoorstellingLocatie { get; set; }
        public Weekday day;


        public Voorstelling()
        {

        }
    }
}
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
        public DateTime BeginTijd { get; set; }
        public DateTime EindTijd { get; set; }
        public decimal Prijs { get; set; }
        public int MaxPlaatsen { get; set; }
        public int GereserveerdePlaatsen { get; set; }
        public int LocatieId { get; set; }

        [NotMapped]
        public virtual string VoorstellingNaam { get; set; }
        [NotMapped]
        public virtual Locatie VoorstellingLocatie { get; set; }
        [NotMapped]
        public virtual Zaal VoorstellingZaal { get; set; }
        [NotMapped]
        public virtual Item VoorstellingItem { get; set; }

        public int ZaalID { get; set; }
        public Weekday day;


        public Voorstelling()
        {

        }
    }
}
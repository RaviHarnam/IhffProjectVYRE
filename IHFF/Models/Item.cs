using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public abstract class Item
    {        
        public int ItemID { get; set; }
       
        public string Titel { get; set; }

        public string Omschrijving { get; set; }

        public bool Highlight { get; set; }

        [NotMapped]
        public virtual Afbeelding ItemAfbeelding {get; set;}

        [NotMapped]
        public virtual List<Voorstelling> ItemVoorstelling { get; set; }
        [NotMapped]
        public virtual List<Voorstelling> Voorstellingen { get; set; }

        [NotMapped]
        public virtual Afbeelding OverviewAfbeelding { get; set; }

        public Item(string titel, string omschrijving, bool highlight)   
        {           
            Titel = titel;
            Omschrijving = omschrijving;
            Highlight = highlight;
        }

        public Item()
        {

        }
    }
}
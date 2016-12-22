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
        public string Categorie { get; set; }
        public string Titel { get; set; }
       
        [Required]
        [MinLength(2), MaxLength(100)]
        public string Titel { get; set; }

        [Required]
        [MinLength(1), MaxLength(1000)]
        public string Omschrijving { get; set; }

        public bool Highlight { get; set; }

        [NotMapped]
        public virtual Afbeelding ItemAfbeelding {get; set;}

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
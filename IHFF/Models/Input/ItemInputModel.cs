using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public abstract class ItemInputModel
    {
        public int ItemID { get; set; }             
        [Required]        
        public string Titel { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        [Required]
        public bool Highlight { get; set; }

        public virtual Afbeelding ItemAfbeelding { get; set; }

        public ItemInputModel(string titel, string omschrijving, bool highlight)
        {            
            Titel = titel;
            Omschrijving = omschrijving;
            Highlight = highlight;
        }
        public ItemInputModel()
        {

        }
    }
}
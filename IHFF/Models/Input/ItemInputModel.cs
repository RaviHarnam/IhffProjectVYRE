using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public abstract class ItemInputModel
    {
        public int ItemID { get; set; }
        [Required]
        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "The title field has a maximum size of 100.")]
        public string Titel { get; set; }
        [Required]
        [StringLength(4000, ErrorMessage = "The summary field has a maximum size of 4000.")]
        public string Omschrijving { get; set; }
        [Required]
        public bool Highlight { get; set; }

        [NotMapped]
        public virtual Afbeelding ItemAfbeelding {get;set;}
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
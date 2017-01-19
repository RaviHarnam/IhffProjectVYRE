using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class SpecialInputModel : ItemInputModel
    {
        [Required(ErrorMessage = "The Speaker field is required.")]
        [StringLength(50, ErrorMessage = "The Speaker field has a maximum size of 50.")]
        public string Speaker { get; set; }

        [Required(ErrorMessage = "The Spoken Language field is required.")]
        [Display(Name = "Spoken language")]
        [StringLength(50, ErrorMessage = "The Spoken Language field has a maximum size of 50.")]
        public string SpokenLanguage { get; set; }

        public SpecialInputModel(string categorie, string titel, string omschrijving, bool highlight, string speaker, string spokenlanguage) : base(titel, omschrijving, highlight)
        {
            Speaker = speaker;
            SpokenLanguage = spokenlanguage;
        }
        public SpecialInputModel()
        {

        }

        public void ConvertToSpecialInputModel(Special s)
        {
            SpokenLanguage = s.SpokenLanguage;
            Speaker = s.Speaker;
           
            Titel = s.Titel;
            Omschrijving = s.Omschrijving;
            Highlight = s.Highlight;
            ItemID = s.ItemID;
            ItemAfbeelding = s.ItemAfbeelding;
            OverviewAfbeelding = s.OverviewAfbeelding;
        }
    }
}
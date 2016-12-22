using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class SpecialInputModel : ItemInputModel
    {
        [Required]
        public string Speaker { get; set; }
        [Required]
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
        }
    }
}
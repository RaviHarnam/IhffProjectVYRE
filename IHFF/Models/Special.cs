using IHFF.Models;
using IHFF.Models.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Special : Item
    {
        public string Speaker { get; set; }
        [Display(Name = "Spoken Language")]
        public string SpokenLanguage { get; set; }


        public Special(string categorie, string titel, string omschrijving, bool highlight, string speaker, string spokenlanguage) : base(titel, omschrijving, highlight)
        {
            Speaker = speaker;
            SpokenLanguage = spokenlanguage;
        }
        public Special()
        {
        }

        public void Edit(Special spc)
        {
            Titel = spc.Titel;
            Omschrijving = spc.Omschrijving;
            ItemAfbeelding.Link = spc.ItemAfbeelding.Link;
            Highlight = spc.Highlight;
            Speaker = spc.Speaker;
            SpokenLanguage = spc.SpokenLanguage;
        }

        public void ConvertFromSpecialInputModel(SpecialInputModel m)
        {
            SpokenLanguage = m.SpokenLanguage;
            Speaker = m.Speaker;
           
            Titel = m.Titel;
            Omschrijving = m.Omschrijving;
            Highlight = m.Highlight;
            ItemID = m.ItemID;
            ItemAfbeelding = m.ItemAfbeelding;
        }
    }
}
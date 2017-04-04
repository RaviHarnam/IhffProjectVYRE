using IHFF.Models;
using IHFF.Models.Input;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Special : Item
    {
        IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
        ISpecialRepository dbSpecial = new DbSpecialRepository();

        public string Speaker { get; set; }
        [Display(Name = "Spoken Language")]
        public string SpokenLanguage { get; set; }
        [NotMapped]
        public int Aantal { get; set; }
        [NotMapped]
        public virtual List<DateTime> Tijden { get; set; }
        //[NotMapped]
        //public virtual int Aantal { get; set; }
        //[NotMapped]
        //public virtual ItemBestellingInputModel Specialbestellinginputmodel { get; set; }

        

        public Special(string titel, string omschrijving, bool highlight, string speaker, string spokenlanguage) : base(titel, omschrijving, highlight)
        {
            Speaker = speaker;
            SpokenLanguage = spokenlanguage;
        }
        public Special()
        {
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
            OverviewAfbeelding = m.OverviewAfbeelding;
        }
    }
}
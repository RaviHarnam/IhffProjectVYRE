using IHFF.Models;
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


        public Special(string categorie, string titel, string omschrijving, bool highlight, string speaker, string spokenlanguage) : base(categorie, titel, omschrijving, highlight)
        {
            Speaker = speaker;
            SpokenLanguage = spokenlanguage;
        }
        public Special()
        {
        }
    }
}
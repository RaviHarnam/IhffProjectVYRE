using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Special : Item
    {
        public string Speaker { get; set; }
        public string SpokenLanguage { get; set; }


        public Special(int itemid, string categorie, string titel, string omschrijving, bool highlight, string speaker, string spokenlanguage) : base(itemid, categorie, titel, omschrijving, highlight)
        {
            Speaker = speaker;
            SpokenLanguage = spokenlanguage;
        }
        public Special()
        {
        }
    }
}
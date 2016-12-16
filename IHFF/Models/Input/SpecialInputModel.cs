using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class SpecialInputModel : ItemInputModel
    {
        public string Speaker { get; set; }
        public string SpokenLanguage { get; set; }

        public SpecialInputModel(string categorie, string titel, string omschrijving, bool highlight, string speaker, string spokenlanguage) : base(categorie, titel, omschrijving, highlight)
        {
            Speaker = speaker;
            SpokenLanguage = spokenlanguage;
        }
        public SpecialInputModel()
        {

        }
    }
}
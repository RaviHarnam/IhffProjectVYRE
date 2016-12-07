using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public abstract class Item
    {
        public int ItemID { get; set; }
        public string Categorie { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public bool Highlight { get; set; }

        public Item(int itemid, string categorie, string titel, string omschrijving, bool highlight)
            
        {
            ItemID = itemid;
            Categorie = categorie;
            Titel = titel;
            Omschrijving = omschrijving;
            Highlight = highlight;
        }

        public Item()
        {

        }
    }
}
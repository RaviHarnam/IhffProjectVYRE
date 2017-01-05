using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Zaal
    {
        public int ZaalID { get; set; }
        public int LocatieID { get; set; }
        public string ZaalNaam { get; set; }

        public Zaal()
        {

        }
        public Zaal(string zaalnaam)
        {
            ZaalNaam = zaalnaam;
        }
    }
}
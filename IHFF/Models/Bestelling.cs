using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public string status { get; set; }
        public DateTime datumTijd { get; set; }
        public double totaalPrijs { get; set; }
        public int klantID { get; set; }
    
        public List<Activiteit> activiteiten;

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Movie : Item
    {
        public int id { get; set; }
        public DateTime datumTijd { get; set; }
        public int aantalTickets { get; set; }
        public double Prijs { get; set; }
    }
}
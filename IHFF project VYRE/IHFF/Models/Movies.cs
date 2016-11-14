using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public class Movies : Activiteit
    {
        public int id { get; set; }
        public DateTime datumTijd { get; set; }
        public int aantalTickets { get; set; }
        public double Prijs { get; set; }
    }
}
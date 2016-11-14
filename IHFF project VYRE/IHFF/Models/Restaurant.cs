using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public class Restaurant : Activiteit
    {
        public string naam { get; set; }
        public string plaats { get; set; }
        public int prijs { get; set; }
        public DateTime datumTijd { get; set; }
        public int plaatsenBeschikbaar { get; set; }

    }
}
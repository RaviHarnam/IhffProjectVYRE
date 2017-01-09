using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class ComboDeal
    {
        public Movie film1 { get; set; }
        public Voorstelling voorstelling1 { get; set; }
        public Movie film2 { get; set; }
        public Voorstelling voorstelling2 { get; set; }
        public Special special { get; set; }
        public Voorstelling voorstelling3 { get; set; }

        public ComboDeal() { }
    }
}
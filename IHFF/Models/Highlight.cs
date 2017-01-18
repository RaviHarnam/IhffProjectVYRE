using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Highlight
    {
        public virtual Movie MovieHighlight { get; set; }
        public virtual Special SpecialHighlight { get; set; }

        public Highlight(Movie m, Special s)
        {
            MovieHighlight = m;
            SpecialHighlight = s;
        }

        public Highlight()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Afbeelding
    {
        public int AfbeeldingId { get; set; }
        public string Link { get; set; }
        public int ItemId { get; set; }
        public string Type { get; set; }
        public Afbeelding()
        {

        }

        public Afbeelding(string sourceUrl, string type)
        {
            Link = sourceUrl;
            Type = Type;
        }
    }
}
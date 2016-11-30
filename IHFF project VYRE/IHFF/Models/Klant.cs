using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public class Klant
    {
        public int id { get; set; }
        public string email { get; set; }
        public string naam { get; set; }

        public Bestelling KlantID
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
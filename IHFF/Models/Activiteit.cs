using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public abstract class Activiteit
    {
        public int ActiviteitID { get; set; }
        public string Titel { get; set; }
        public string Info { get; set; }
        public string Omschrijving { get; set; }

        public Bestelling Activiteiten
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Medewerker
    {
        public int medewerkerID { get; set; }
        public string inlogNaam { get; set; }
        public string wachtWoord { get; set; }

        public Activiteit Activiteit
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Aanpassen() { }


    }
}
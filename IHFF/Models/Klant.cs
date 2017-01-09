using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Klant
    {
        public int KlantID { get; set; }
        public string Email { get; set; }
        public string Naam { get; set; }

        public Klant(string email, string naam)
        {
            Email = email;
            Naam = naam;
        }
        public Klant()
        {

        }
    }
}
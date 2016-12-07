using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Movie : Item
    {
        public decimal Rating { get; set; }
        public string Director { get; set; }
        public string Stars { get; set; }
        public string Writers { get; set; }


        public Movie(int itemid, string categorie, string titel, string omschrijving, bool highlight, decimal rating, string director, string stars, string writers) : base(itemid, categorie, titel, omschrijving, highlight)
        {
            Rating = rating;
            Director = director;
            Stars = stars;
            Writers = writers;
        }
        public Movie()
        {

        }

    }


}
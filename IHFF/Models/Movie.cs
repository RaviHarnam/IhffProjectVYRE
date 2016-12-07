using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Models
{
    public class Movie : Item
    {
        public Movie(decimal rating, string director, string stars, string writers, string categorie, string titel, string omschrijving, bool highlight) : base(categorie, titel, omschrijving, highlight)
        {
            //MovieId = movieid;
            Rating = rating;
            Director = director;
            Writers = writers;
            
        }
        public Movie()
        {

        }
       
       // public int MovieId { get; set; }
       // public int ItemID { get; set; }
        public decimal Rating { get; set; }
        public string Director { get; set; }
        public string Stars { get; set; }
        public string Writers { get; set; }
        public double Prijs { get; set; }
        public DateTime DatumTijd { get; set; }      
    }
}
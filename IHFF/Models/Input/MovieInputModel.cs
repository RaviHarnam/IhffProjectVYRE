using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class MovieInputModel : ItemInputModel
    {        
        public decimal Rating { get; set; }
        public string Director { get; set; }
        public string Stars { get; set; }
        public string Writers { get; set; }
        
        //public List<DateTime> Tijden { get; set; }

        public MovieInputModel(decimal rating, string director, string stars, string writers, string categorie, string titel, string omschrijving, bool highlight) : base(categorie, titel, omschrijving, highlight)
        {                      
            Rating = rating;
            Director = director;
            Writers = writers;
        }
        public MovieInputModel()
        {

        }

        
        
    }
}
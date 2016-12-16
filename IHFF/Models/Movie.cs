using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using System.ComponentModel.DataAnnotations;

namespace IHFF.Models
{
    public class Movie : Item
    {
        [Required]        
        public string Rating { get; set; }

        [Required]
        [MinLength(5), MaxLength(200)]
        public string Director { get; set; }

        [Required]
        [MinLength(5), MaxLength(200)]
        public string Stars { get; set; }

        [Required]
        [MinLength(5), MaxLength(200)]
        public string Writers { get; set; }

        public List<DateTime> Tijden { get; set; }

        public Movie(string rating, string director, string stars, string writers, string categorie, string titel, string omschrijving, bool highlight) : base(categorie, titel, omschrijving, highlight)
        {
            Rating = rating;
            Director = director;
            Writers = writers;
        }
        public Movie()
        {

        }

        

        //public double Prijs { get; set; }
        //public DateTime DatumTijd { get; set; }    
    }
}
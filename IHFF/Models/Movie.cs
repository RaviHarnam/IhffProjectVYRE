using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

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

        [NotMapped]
        public virtual List<DateTime> Tijden { get; set; }

        [NotMapped]
        public MovieViewModel ViewModel { get; set; }

        [NotMapped]
        public virtual Event movieEvent { get; set; }

        public Movie(string rating, string director, string stars, string writers, string categorie, string titel, string omschrijving, bool highlight) : base(categorie, titel, omschrijving, highlight)
        {
            Rating = rating;
            Director = director;
            Writers = writers;
        }

        public Movie()
        {

        }

        public void MakeViewmodel()
        {
            ViewModel = new MovieViewModel(ItemID);
        }

        public void Edit(Movie mov)
        {
            Titel = mov.Titel;
            Omschrijving = mov.Omschrijving;
            Highlight = mov.Highlight;
            ItemAfbeelding.Link = mov.ItemAfbeelding.Link;
            Rating = mov.Rating;
            Director = mov.Director;
            Stars = mov.Stars;
            Writers = mov.Writers;
        }

        //public double Prijs { get; set; }
        //public DateTime DatumTijd { get; set; }    
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using IHFF.Models.Input;

namespace IHFF.Models
{
    public class Movie : Item
    {            
        public string Rating { get; set; }       
        public string Director { get; set; }       
        public string Stars { get; set; }     
        public string Writers { get; set; }

        [NotMapped]
        public virtual List<DateTime> Tijden { get; set; }

        [NotMapped]
        public MovieViewModel ViewModel { get; set; }

        [NotMapped]
        public virtual Event movieEvent { get; set; }

        public Movie(string rating, string director, string stars, string writers, string categorie, string titel, string omschrijving, bool highlight) : base(titel, omschrijving, highlight)
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

        //public void Edit(Movie mov)
        //{
        //    Titel = mov.Titel;
        //    Omschrijving = mov.Omschrijving;
        //    Highlight = mov.Highlight;
        //    Categorie = mov.Categorie;
        //    ItemAfbeelding.Link = mov.ItemAfbeelding.Link;
        //    Rating = mov.Rating;
        //    Director = mov.Director;
        //    Stars = mov.Stars;
        //    Writers = mov.Writers;
        //}

        public void ConvertFromMovieInputModel(MovieInputModel m)
        {
            Rating = m.Rating;
            Director = m.Director;
            Stars = m.Stars;
            Writers = m.Writers;
           
            Titel = m.Titel;
            Omschrijving = m.Omschrijving;
            Highlight = m.Highlight;
            ItemID = m.ItemID;
            ItemAfbeelding.Link = m.ItemAfbeelding.Link;
        }

        //public double Prijs { get; set; }
        //public DateTime DatumTijd { get; set; }    
    }
}
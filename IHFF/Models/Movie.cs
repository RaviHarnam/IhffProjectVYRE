using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using IHFF.Models.Input;
using IHFF.Repositories;

namespace IHFF.Models
{
    public class Movie : Item
    {
        IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
        IMoviesRepository dbMovie = new DbMovieRepository();

        public string Rating { get; set; }
        public string Director { get; set; }
        public string Stars { get; set; }
        public string Writers { get; set; }
      
        [NotMapped]
        public virtual List<DateTime> Tijden { get; set; }

        //[NotMapped]
        //public virtual List<Voorstelling> Voorstellingen { get; set; }

        [NotMapped]
        public virtual int Aantal { get; set; }

        [NotMapped]
        public virtual ItemBestellingInputModel Moviebestellinginputmodel { get; set; }

        //[NotMapped]
        //public virtual Afbeelding OverviewAfbeelding { get; set; }

        public Movie()
        {

        }

        public Movie(string rating, string director, string stars, string writers, string titel, string omschrijving, bool highlight) : base(titel, omschrijving, highlight)
        {
            Rating = rating;
            Director = director;
            Writers = writers;
        }

       

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
            OverviewAfbeelding.Link = m.OverviewAfbeelding.Link;
        }

        public void ConvertFromAddInputModel(MovieInputModel m)
        {
            Rating = m.Rating;
            Director = m.Director;
            Stars = m.Stars;
            Writers = m.Writers;

            Titel = m.Titel;
            Omschrijving = m.Omschrijving;
            Highlight = m.Highlight;
        }

        //public double Prijs { get; set; }
        //public DateTime DatumTijd { get; set; }    


    }
}
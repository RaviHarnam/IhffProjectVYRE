using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class MovieInputModel : ItemInputModel
    {
        [Required]
        [MinLength(1)]
        public string Rating { get; set; }

        [Required]
        [MinLength(1)]
        public string Director { get; set; }
       
        [Required]
        [MinLength(1)]
        public string Stars { get; set; }

        [Required]
        [MinLength(1)]
        public string Writers { get; set; }

        public MovieInputModel(string rating, string director, string stars, string writers, string titel, string omschrijving, bool highlight) : base(titel, omschrijving, highlight)
        {
            Rating = rating;
            Director = director;
            Writers = writers;
        }
        public MovieInputModel()
        {

        }

        public void ConvertToMovieInputModel(Movie m)
        {
            Rating = m.Rating;
            Director = m.Director;
            Stars = m.Stars;
            Writers = m.Writers;
           
            Titel = m.Titel;
            Omschrijving = m.Omschrijving;
            Highlight = m.Highlight;
            ItemID = m.ItemID;
            ItemAfbeelding = m.ItemAfbeelding;
        }


    }
}
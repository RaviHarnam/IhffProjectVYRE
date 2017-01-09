using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class MovieInputModel : ItemInputModel
    {
        [Required(ErrorMessage = "The Rating field is required.")]
        [StringLength(5, ErrorMessage = "The Rating field has a maximum size of 5.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "The Director field is required.")]
        [StringLength(50, ErrorMessage = "The Director field has a maximum size of 50.")]
        public string Director { get; set; }
       
        [Required(ErrorMessage = "The Stars field is required.")]
        [StringLength(100, ErrorMessage = "The Stars field has a maximum size of 100.")]
        public string Stars { get; set; }

        [Required(ErrorMessage = "The Writers field is required.")]
        [StringLength(50, ErrorMessage = "The Writers field has a maximum size of 50.")]
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
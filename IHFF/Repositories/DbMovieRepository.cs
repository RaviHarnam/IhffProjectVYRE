using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class DbMovieRepository : IMoviesRepository
    {
        private IhffContext ctx = new IhffContext();
        public IEnumerable<Movie> GetAllMovies()
        {
            IEnumerable<Movie> movies = ctx.MOVIES.ToList();
            // Loop door de lijst heen en vul de afbeeldingen erin.
<<<<<<< HEAD
            foreach (Movie mov in movies)
            {
                mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "filmoverview");
                mov.movieEvent = new Event();
            }
=======
            foreach(Movie mov in movies) 
                mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "filmoverview");
>>>>>>> 8f1145b86d5165661538eaea68b4ad1abaf964e4
                        
            return movies;
        }

        public Movie GetMovie(int id)
        {    
            Movie mov = ctx.MOVIES.SingleOrDefault(i => i.ItemID == id);
<<<<<<< HEAD
            mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "filmbanner");
=======
            mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "banner");
            mov.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemId == mov.ItemID select v.DatumTijd).ToList();
>>>>>>> 8f1145b86d5165661538eaea68b4ad1abaf964e4
            return mov;
        }

        public List<DateTime> GetMovieTijden(Movie movie)
        {
            List<DateTime> tijden = new List<DateTime>();

            tijden = (from v in ctx.VOORSTELLINGEN
                      where v.ItemId == movie.ItemID
                      select v.DatumTijd).ToList();

            return tijden;
        }
    }
}


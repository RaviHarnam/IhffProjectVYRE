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
            foreach(Movie mov in movies) 
                mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "filmoverview");
                        
            return movies;
        }

        public Movie GetMovie(int id)
        {    
            Movie mov = ctx.MOVIES.SingleOrDefault(i => i.ItemID == id);
            mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "banner");
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


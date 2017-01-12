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
            // Loop door de lijst heen en vul de afbeeldingen en voorstellingen erin.
            foreach (Movie mov in movies)
            {
                mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "filmoverview");
                mov.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == mov.ItemID select v).ToList();
            }
                        
            return movies;
        }

        public Movie GetMovie(int id)
        {    
            Movie movie = ctx.MOVIES.SingleOrDefault(i => i.ItemID == id);

            movie.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == movie.ItemID && a.Type == "filmbanner");
            movie.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v.BeginTijd).ToList();

            return movie;
        }

        public List<DateTime> GetMovieTijden(Movie movie)
        {
            List<DateTime> tijden = new List<DateTime>();

            tijden = (from v in ctx.VOORSTELLINGEN
                      where v.ItemID == movie.ItemID
                      select v.BeginTijd).ToList();

            return tijden;
        }

        public Movie GetMovieByVoorstellingID (int voorstellingid)
        {
            Movie movie = (from v in ctx.VOORSTELLINGEN
                      from m in ctx.MOVIES
                      where m.ItemID == v.ItemID
                      && v.VoorstellingID == voorstellingid
                      select m).SingleOrDefault();
            movie.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == movie.ItemID && a.Type == "filmbanner");
            movie.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v).ToList();
            return movie;
        }
    }
}


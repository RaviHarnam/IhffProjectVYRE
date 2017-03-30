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
                mov.ItemAfbeelding = HaalItemAfbeeldingOp(mov, "filmoverview", mov.ItemID);
                //mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "filmoverview");
                mov.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == mov.ItemID select v).ToList();
            }
            return movies;
        }

        //haal 1 movie op met een specifieke id.
        public Movie GetMovie(int id)
        {    
            Movie movie = ctx.MOVIES.SingleOrDefault(i => i.ItemID == id);
            movie.ItemAfbeelding = HaalItemAfbeeldingOp(movie,"filmbanner", id);
            //movie.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == movie.ItemID && a.Type == "filmbanner");
            movie.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v.BeginTijd).ToList();

            return movie;
        }

        private Afbeelding HaalItemAfbeeldingOp(Movie movie, string soort, int? movieId)
        {
                return movie.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == movie.ItemID && a.Type == soort);
        }

        //haal de tijden van de movie op
        public List<DateTime> GetMovieTijden(Movie movie)
        {
            List<DateTime> tijden = new List<DateTime>();

            tijden = (from v in ctx.VOORSTELLINGEN
                      where v.ItemID == movie.ItemID
                      select v.BeginTijd).ToList();

            return tijden;
        }

        // hier haal je een movie op op basis van de voorstellingID die deze movie heeft.
        public Movie GetMovieByVoorstellingID (int voorstellingid)
        {
            Movie movie = (from v in ctx.VOORSTELLINGEN
                      from m in ctx.MOVIES
                      where m.ItemID == v.ItemID
                      && v.VoorstellingID == voorstellingid
                      select m).SingleOrDefault();
            movie.ItemAfbeelding = HaalItemAfbeeldingOp(movie, "filmbanner", movie.ItemID);
            //movie.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == movie.ItemID && a.Type == "filmbanner");
            movie.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v).ToList();
            return movie;
        }
    }
}


using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class DbMovieRepository : IMoviesRepository
    {
        private IhffContext ctx = new IhffContext();
        private DateTime IJKDATUM = new DateTime(2017, 4, 30);

        public IEnumerable<Movie> GetAllMovies()
        {
            IEnumerable<Movie> movies = ctx.MOVIES.ToList();
            // Loop door de lijst heen en vul de afbeeldingen en voorstellingen erin.
            foreach (Movie mov in movies)
            {
                HaalItemAfbeeldingOp(mov, "filmoverview", mov.ItemID);
                mov.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == mov.ItemID select v).ToList();
            }
            return movies;
        }

        //haal 1 movie op met een specifieke id.
        public Movie GetMovie(int? id)
        {    
            Movie movie = ctx.MOVIES.SingleOrDefault(i => i.ItemID == id);
            HaalItemAfbeeldingOp(movie,"filmbanner", id);
            movie.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v.BeginTijd).ToList();

            return movie;
        }

        private void HaalItemAfbeeldingOp(Movie movie, string soort, int? movieId)
        {
                movie.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == movie.ItemID && a.Type == soort);
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

        public List <Movie> getMoviesByDay(int dag)
        {
            
            
            List<Movie> moviePerDag = new List<Movie>();
                           
            moviePerDag = (from v in ctx.VOORSTELLINGEN
                           from m in ctx.MOVIES
                           where (DbFunctions.DiffDays(IJKDATUM, v.BeginTijd) % 7 == dag) && v.ItemID == m.ItemID
                           select m).ToList();
            foreach(Movie movie in moviePerDag)
            {
                HaalItemAfbeeldingOp(movie, "filmoverview", movie.ItemID);
                movie.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v).ToList();
            }

            return moviePerDag;
        }
        // hier haal je een movie op op basis van de voorstellingID die deze movie heeft.
        public Movie GetMovieByVoorstellingID (int voorstellingid)
        {
            Movie movie = (from v in ctx.VOORSTELLINGEN
                      from m in ctx.MOVIES
                      where m.ItemID == v.ItemID
                      && v.VoorstellingID == voorstellingid
                      select m).SingleOrDefault();
            HaalItemAfbeeldingOp(movie, "filmbanner", movie.ItemID);
            movie.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v).ToList();
            return movie;
        }

        public void UpdateMovie(Movie movie)
        {
            Movie dbMovie = ctx.MOVIES.SingleOrDefault(m => m.ItemID == movie.ItemID);
            if (dbMovie != null)
            {
                dbMovie.Titel = movie.Titel;
                dbMovie.Writers = movie.Writers;

                dbMovie.Stars = movie.Stars;
                dbMovie.Rating = movie.Rating;
                dbMovie.Omschrijving = movie.Omschrijving;
                dbMovie.ItemAfbeelding.Link = movie.ItemAfbeelding.Link;
                dbMovie.OverviewAfbeelding.Link = movie.OverviewAfbeelding.Link;
                dbMovie.Director = movie.Director;
                dbMovie.Highlight = movie.Highlight;
                ctx.SaveChanges();
            }
        }


    }
}


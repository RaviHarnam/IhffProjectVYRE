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
            var movies = (from m in ctx.MOVIES
                          join a in ctx.AFBEELDINGEN on m.ItemID equals a.ItemID
                          select new
                          {
                              ItemId = m.ItemID,
                              Categorie = m.Categorie,
                              Titel = m.Titel,
                              Omschrijving = m.Omschrijving,
                              Highlight = m.Highlight,
                              Rating = m.Rating,
                              Director = m.Director,
                              Stars = m.Stars,
                              Writers = m.Writers,
                              Afbeeldingen = (from afb in ctx.AFBEELDINGEN
                                              where afb.ItemID == m.ItemID && afb.Type == "banner"
                                              select afb).FirstOrDefault()
                          }).ToList()
                                               .Select(x => new Movie()
                                               {
                                                   ItemID = x.ItemId,
                                                   Categorie = x.Categorie,
                                                   Titel = x.Titel,
                                                   Omschrijving = x.Omschrijving,
                                                   Highlight = x.Highlight,
                                                   Rating = x.Rating,
                                                   Director = x.Director,
                                                   Stars = x.Stars,
                                                   Writers = x.Writers,
                                                   ItemAfbeelding = (from afb in ctx.AFBEELDINGEN
                                                                     where afb.ItemID == x.ItemId && afb.Type == "banner"
                                                                     select afb).FirstOrDefault()
                                               });
            //IEnumerable<Movie> movies = (from m in ctx.MOVIES
            //                             select m).ToList();
            //foreach(Movie mov in movies)
            //{
            //    mov.ItemAfbeelding = (Afbeelding)(from a in ctx.AFBEELDINGEN where a.ItemID == mov.ItemID select a);
            //}
            return movies;
        }

        public Movie GetMovie(int id)
        {
            var movie = (from m in ctx.MOVIES
                         join a in ctx.AFBEELDINGEN on m.ItemID equals a.ItemID
                         select new
                         {
                             ItemId = m.ItemID,
                             Categorie = m.Categorie,
                             Titel = m.Titel,
                             Omschrijving = m.Omschrijving,
                             Highlight = m.Highlight,
                             Rating = m.Rating,
                             Director = m.Director,
                             Stars = m.Stars,
                             Writers = m.Writers,
                             ItemAfbeelding = (from afb in ctx.AFBEELDINGEN
                                               where afb.ItemID == m.ItemID && afb.Type == "banner"
                                               select afb).FirstOrDefault()
                         }).ToList()
                                               .Select(x => new Movie()
                                               {
                                                   ItemID = x.ItemId,
                                                   Categorie = x.Categorie,
                                                   Titel = x.Titel,
                                                   Omschrijving = x.Omschrijving,
                                                   Highlight = x.Highlight,
                                                   Rating = x.Rating,
                                                   Director = x.Director,
                                                   Stars = x.Stars,
                                                   Writers = x.Writers,
                                                   ItemAfbeelding = (from afb in ctx.AFBEELDINGEN
                                                                     where afb.ItemID == x.ItemId && afb.Type == "banner"
                                                                     select afb).FirstOrDefault()
                                               }).SingleOrDefault(m => m.ItemID == id);
            return movie;
        }
    }
}


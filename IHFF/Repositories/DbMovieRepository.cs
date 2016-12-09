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
        public class MovieDTO
        {
            public int ItemID { get; set; }
            public string Categorie { get; set; }
            public string Titel { get; set; }
            public string Omschrijving { get; set; }
            public bool Highlight { get; set; }
            public decimal Rating { get; set; }
            public string Director { get; set; }
            public string Stars { get; set; }
            public string Writers { get; set; }
            public virtual ICollection<Afbeelding> Afbeeldingen { get; set; }
            public MovieDTO()
            {

            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            //IEnumerable<MovieDTO> moviesDTOs = (from i in ctx.Items.AsEnumerable()
            //                                        from m in ctx.Movies.AsEnumerable()
            //                                  //  join m in ctx.Movies on i.ItemID equals m.ItemID
            //                                    where i.ItemID == m.ItemID
            //                                    select new MovieDTO
            //                                    {
            //                                        ItemID = i.ItemID,
            //                                        Categorie = i.Categorie,
            //                                        Titel = i.Titel,
            //                                        Omschrijving = i.Omschrijving,
            //                                        Highlight = i.Highlight,
            //                                        Rating = m.Rating,
            //                                        Director = m.Director,
            //                                        Stars = m.Stars,
            //                                        Writers = m.Writers
            //
            //                                    }).ToList();
            //List<Movie> moviesList = new List<Movie>();
            //    foreach (MovieDTO movie in moviesDTOs)
            //   {
            // Movie m = new Movie(movie.ItemID, movie.Categorie, movie.Titel, movie.Omschrijving, movie.Highlight, movie.Rating, movie.Director, movie.Stars, movie.Writers);
            // moviesList.Add(m);
            // }
            //return (IEnumerable<Movie>)moviesList;

            //IEnumerable<Movie> movies = (from m in ctx.MOVIES
            //                             from a in ctx.AFBEELDINGEN
            //                             where m.ItemID == a.ItemId 
            //                             select m).ToList();
            var movies = (from m in ctx.MOVIES
                          join a in ctx.AFBEELDINGEN on m.ItemID equals a.ItemId
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
                                              where afb.ItemId == m.ItemID
                                              select afb).ToList()
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
                                                   Afbeeldingen = (from afb in ctx.AFBEELDINGEN
                                                                   where afb.ItemId == x.ItemId
                                                                   select afb).ToList()
                                               });
           
            return movies;



        }

    }
}


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

            public MovieDTO()
            {

            }
        }



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

            //                                    }).ToList();
            //List<Movie> moviesList = new List<Movie>();
            //    foreach (MovieDTO movie in moviesDTOs)
            //   {
            // Movie m = new Movie(movie.ItemID, movie.Categorie, movie.Titel, movie.Omschrijving, movie.Highlight, movie.Rating, movie.Director, movie.Stars, movie.Writers);
            // moviesList.Add(m);
            // }
            //return (IEnumerable<Movie>)moviesList;

            IEnumerable<Movie> movies = (from m in ctx.MOVIES.OfType<Movie>() select m).ToList();

            return movies;

        }

    }
}


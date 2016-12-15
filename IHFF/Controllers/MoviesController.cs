
﻿using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;


namespace IHFF.Controllers
{
    public class MoviesController : Controller
    {
        private IMoviesRepository dbMovie = new DbMovieRepository();
        
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MovieOverview()
        {
            IEnumerable<Movie> movies = dbMovie.GetAllMovies();
            return View(movies);
        }

        public ActionResult MovieDetailPage(int movie_id)
        {
            Movie movie = dbMovie.GetMovie(movie_id);
            movie.Tijden = dbMovie.GetMovieTijden(movie);
            if(movie == null)
            {
                return RedirectToAction("MovieOverview");
            }
            return View(movie);
        }
    }
}
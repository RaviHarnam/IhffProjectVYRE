
﻿using IHFF.Models;

﻿
using IHFF.Models;

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
        private IMoviesRepository db = new DbMovieRepository();
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MovieOverview()

        {
            IEnumerable<Movie> movies = db.GetAllMovies();
            return View(movies);
        }
    }
}
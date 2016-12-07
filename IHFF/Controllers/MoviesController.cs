<<<<<<< HEAD
﻿using IHFF.Models;
=======
﻿
using IHFF.Models;
>>>>>>> 77c597045b50a2eab5d0ed65c0bcd6dffb8722f6
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
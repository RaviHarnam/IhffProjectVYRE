using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;


namespace IHFF.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            int i = 0;
            List<Item> movies = new List<Item>();
            movies.Add(new Movie());
            movies.Add(new Movie());
            movies.Add(new Movie());

            foreach(Movie item in movies)
            {
                item.Titel = "titel " + i.ToString();
                item.Prijs = i + 100;
                item.aantalTickets = i + 200;
                item.datumTijd = DateTime.Now;
            }

            return View(movies);
        }
    }
}
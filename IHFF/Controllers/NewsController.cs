using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class NewsController : Controller
    {
        INewsMessageRepository dbNews = new DbNewsMessageRepository();
        // GET: News
        public ActionResult Index()
        {
            List<NewsMessage> news = dbNews.GetAll();

            news.Reverse();

            return View(news);
        }
    }
}
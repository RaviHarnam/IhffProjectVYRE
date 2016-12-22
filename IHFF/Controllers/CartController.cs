using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using System.Web.Security;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class CartController : Controller
    {
        private IEventRepository repository = new DbEventRepository();

        public ActionResult Index()
        {
            if (Session["cart"] == null)
                Session["cart"] = new List<Event>();

            List<Event> cartlist = new List<Event>();

            foreach (Event eventx in (List<Event>)Session["cart"])
            {
                cartlist.Add(eventx);
            }



            return View(cartlist);

        }




    }
}
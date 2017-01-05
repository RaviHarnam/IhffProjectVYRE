using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return RedirectToAction("Contact");
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
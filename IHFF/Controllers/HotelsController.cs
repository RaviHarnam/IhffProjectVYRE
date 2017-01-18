using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class HotelsController : Controller
    {
        IHotelsRepository db = new DbHotelRepository();
        // GET: Hotels
        public ActionResult Index()
        {
            return RedirectToAction("HotelsOverview");
        }

        public ActionResult HotelsOverview()
        {
            List<Hotel> hotels = db.GetAll();

            return View(hotels);
        }

        public ActionResult HotelDetailPage(int? hotelId)
        {
            if (hotelId != null)
            {
                Hotel hotel = db.GetHotel(hotelId.Value);

                return View(hotel);
            }
            return RedirectToAction("HotelsOverview");
        }
    }
}
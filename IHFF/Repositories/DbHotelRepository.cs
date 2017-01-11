using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbHotelRepository : IHotelsRepository
    {
        IhffContext ctx = new IhffContext();

        public void Add(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAll()
        {
            List<Hotel> hotels = ctx.HOTEL.ToList();
            foreach (Hotel h in hotels)
            {
                h.HotelOverviewAfbeelding = (from afb in ctx.AFBEELDINGEN
                                             where afb.HotelID == h.HotelId && afb.Type == "HotelOverview"
                                             select afb).SingleOrDefault();
            }

            return hotels;
        }

        public Hotel GetHotel(int hotelId)
        {
            Hotel h = (from hot in ctx.HOTEL
                       where hot.HotelId == hotelId
                       select hot).SingleOrDefault();

            h.HotelAfbeelding = (from afb in ctx.AFBEELDINGEN
                                 where afb.HotelID == hotelId && afb.Type == "HotelBanner"
                                 select afb).SingleOrDefault();

            return h;

        }

        public void Remove(int hotelId)
        {
            throw new NotImplementedException();
        }
    }
}
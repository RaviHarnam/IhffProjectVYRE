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
            throw new NotImplementedException();
        }

        public Hotel GetHotel(int hotelId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int hotelId)
        {
            throw new NotImplementedException();
        }
    }
}
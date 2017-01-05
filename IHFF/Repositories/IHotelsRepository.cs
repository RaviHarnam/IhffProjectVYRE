using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Repositories
{
    interface IHotelsRepository
    {
        List<Hotel> GetAll();
        Hotel GetHotel(int hotelId);
        void Add(Hotel hotel);
        void Remove(int hotelId);
    }
}

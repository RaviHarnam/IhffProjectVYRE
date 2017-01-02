using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHFF.Repositories
{
    interface IFoodRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurant(int id);
        IEnumerable<int> GetUren(int dagId);
    }
}

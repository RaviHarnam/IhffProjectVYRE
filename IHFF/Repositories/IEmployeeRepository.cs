using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Repositories
{
   public interface IEmployeeRepository
    {
        bool EmployeeExist(Employee emp);
        IEnumerable<EventListRepresentation> GetAllEvents();
        Item GetItem(int id);
        Museum GetCultureEvent(int id);
        Restaurant GetRestaurant(int id);
        Movie GetMovie(int id);
        Special GetSpecial(int id);
        void UpdateMovie(Movie movie);
        void UpdateSpecial(Special special);
        void UpdateRestaurant(Restaurant restaurant);
        void UpdateMuseum(Museum museum);
    }
}

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
        //Inloggen
        bool EmployeeExist(Employee emp);
        //Lijst van evenementen
        IEnumerable<EventListRepresentation> GetAllEvents();

        //Ophalen enkele item
        Item GetItem(int id);
        Museum GetMuseum(int id);
        Restaurant GetRestaurant(int id);
        Movie GetMovie(int id);
        Special GetSpecial(int id);

        //Updaten van een item
        void UpdateMovie(Movie movie);
        void UpdateSpecial(Special special);
        void UpdateRestaurant(Restaurant restaurant);
        void UpdateMuseum(Museum museum);

        //Deleten van een item
        void DeleteMuseum(int museumid);
        void DeleteMovie(int movieid);
        void DeleteSpecial(int specialid);
        void DeleteRestaurant(int restaurantid);

        //Toevoegen van een item
        void AddMovie(Movie m);
        void AddSpecial(Special s);
        void AddMuseum(Museum m);
        void AddRestaurant(Restaurant r);
    }
}

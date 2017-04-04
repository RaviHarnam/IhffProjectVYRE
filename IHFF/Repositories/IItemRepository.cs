using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Repositories
{
    interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(int itemid);
        IEnumerable<Highlight> GetAllHighlights();
        IEnumerable<Highlight> GetAllHighlightsBanner();

        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(int id);
        //List<DateTime> GetMovieTijden(Movie movie);
        List<Movie> getMoviesByDay(int dag);
        Movie GetMovieByVoorstellingID(int voorstellingid);
        void UpdateMovie(Movie movie);

        IEnumerable<Special> GetAllSpecials();
        Special GetSpecial(int id);
        Special GetSpecialByVoorstellingID(int voorstellingid);
        List<Special> getSpecialByDay(int dag);
    }
}

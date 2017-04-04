using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHFF.Repositories
{
    interface IMoviesRepository
    {

        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(int? id);
        List<DateTime> GetMovieTijden(Movie movie);
        Movie GetMovieByVoorstellingID(int voorstellingid);
        List<Movie> getMoviesByDay(int dag);
        void UpdateMovie(Movie movie);
    }
}

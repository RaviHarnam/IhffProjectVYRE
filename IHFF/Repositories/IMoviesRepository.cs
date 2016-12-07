using IHFF.Models;
using Ihff_project.Models;
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
    }
}

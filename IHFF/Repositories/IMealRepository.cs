using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHFF.Repositories
{
    interface IMealRepository
    {
        IEnumerable<Maaltijd> GetAllMaaltijd();
        Maaltijd GetMaaltijd(int id);
    }
}

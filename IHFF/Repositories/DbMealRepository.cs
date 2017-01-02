using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbMealRepository : IMealRepository
    {
        public IEnumerable<Maaltijd> GetAllMaaltijd()
        {
            throw new NotImplementedException();
        }

        public Maaltijd GetMaaltijd(int id)
        {
            throw new NotImplementedException();
        }
    }
}
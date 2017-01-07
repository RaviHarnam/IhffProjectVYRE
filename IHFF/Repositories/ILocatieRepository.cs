using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    interface ILocatieRepository
    {
        IEnumerable<Locatie> GetLocaties();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Repositories
{
    interface IMuseumRepository
    {
        List<Museum> GetAll();
        void AddMuseum(Museum museum);
        void DeleteMuseum(Museum museum);
        Museum GetMuseum(int? museumId);
    }
}

using System.Collections.Generic;
using IHFF.Models;

namespace IHFF.Repositories
{
    public interface ISpecialRepository
    {
        IEnumerable<Special> GetAllSpecials();
        Special GetSpecial(int id);
    }
}
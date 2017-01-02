using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbMuseumRepository : IMuseumRepository
    {
        IhffContext ctx = new IhffContext();

        public void AddMuseum(Museum museum)
        {
            throw new NotImplementedException();
        }

        public void DeleteMuseum(Museum museum)
        {
            throw new NotImplementedException();
        }

        public List<Museum> GetAll()
        {
            return ctx.MUSEA.ToList();
        }
    }
}
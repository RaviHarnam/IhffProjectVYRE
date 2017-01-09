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
            List<Museum> museumLijst = ctx.MUSEA.ToList();

            foreach(Museum m in museumLijst)
            {
                m.MuseumAfbeelding = new Afbeelding();
                m.MuseumAfbeelding.MuseumID = m.MuseumID;
                m.MuseumAfbeelding.Link = (from afbeelding in ctx.AFBEELDINGEN
                                           where afbeelding.MuseumID == m.MuseumID && afbeelding.Type == "museumoverview"
                                           select afbeelding.Link).SingleOrDefault();
            }

            return museumLijst;
        }

        public Museum GetMuseum(int? museumId)
        {
            Museum museum = (from m in ctx.MUSEA
                             where m.MuseumID == museumId
                             select m).SingleOrDefault();

            museum.MuseumAfbeelding = new Afbeelding();
            museum.MuseumAfbeelding.MuseumID = museum.MuseumID;
            museum.MuseumAfbeelding.Link = (from afb in ctx.AFBEELDINGEN
                                            where afb.MuseumID == museumId && afb.Type == "museumbanner"
                                            select afb.Link).SingleOrDefault();
            museum.MuseumLocatie = (from loc in ctx.LOCATIES
                                    where loc.LocatieID == museum.LocatieID
                                    select loc).SingleOrDefault();

            return museum;
        }
    }
}
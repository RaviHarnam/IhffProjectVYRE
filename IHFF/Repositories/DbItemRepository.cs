using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbItemRepository : IItemRepository
    {
        private IhffContext ctx = new IhffContext();
        public IEnumerable<Item> GetAllItems()
        {
            IEnumerable<Item> items = ctx.ITEMS.ToList();
            foreach (Item item in items)
                item.ItemVoorstelling = (from v in ctx.VOORSTELLINGEN
                                         where v.ItemID == item.ItemID
                                         select v).ToList();
            return items;
        }

        public Item GetItem(int itemid)
        {
            Item itm = ctx.ITEMS.SingleOrDefault(i => i.ItemID == itemid);
            return itm;
        }

        public IEnumerable<Highlight> GetAllHighlights()
        {
            List<Highlight> highlights = new List<Highlight>();
            IEnumerable<Movie> movies =      (from i in ctx.MOVIES
                                             where i.Highlight
                                             select i).ToList();
            IEnumerable<Special> specials = (from s in ctx.SPECIALS
                                             where s.Highlight
                                             select s).ToList();
            foreach(Movie m in movies)
            {
                m.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == m.ItemID && a.Type.Contains("overview"));                
                m.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == m.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(m, null));
            }
            foreach(Special s in specials)
            {
                s.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == s.ItemID && a.Type.Contains("overview"));
                s.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == s.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(null, s));
            }
            return highlights;
        }


        public IEnumerable<Highlight> GetAllHighlightsBanner()
        {
            List<Highlight> highlights = new List<Highlight>();
            IEnumerable<Movie> movies = (from i in ctx.MOVIES
                                         where i.Highlight
                                         select i).ToList();
            IEnumerable<Special> specials = (from s in ctx.SPECIALS
                                             where s.Highlight
                                             select s).ToList();
            foreach (Movie m in movies)
            {
                m.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == m.ItemID && a.Type.Contains("filmbanner"));
                m.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == m.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(m, null));
            }
            foreach (Special s in specials)
            {
                s.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == s.ItemID && a.Type.Contains("specialbanner"));
                s.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == s.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(null, s));
            }
            return highlights;
        }
    }
}
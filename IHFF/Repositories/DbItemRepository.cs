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
    }
}
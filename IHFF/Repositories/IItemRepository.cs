using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Repositories
{
    interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(int itemid);
        IEnumerable<Highlight> GetAllHighlights();
        IEnumerable<Highlight> GetAllHighlightsBanner();
    }
}

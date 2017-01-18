using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHFF.Repositories
{
    interface INewsMessageRepository
    {
        List<NewsMessage> GetAll();
        NewsMessage GetMessage(int id);
    }
}

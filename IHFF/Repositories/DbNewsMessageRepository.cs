using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbNewsMessageRepository : INewsMessageRepository
    {
        IhffContext ctx = new IhffContext();

        public List<NewsMessage> GetAll()
        {
            List<NewsMessage> news = ctx.NEWSMESSAGE.ToList();
            return news;
        }

        public NewsMessage GetMessage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class TestDbConnection : ITestRepository
    {
        private IhffContext ctx = new IhffContext();

        public IEnumerable<Test> GetAllTests()
        {
            IEnumerable<Test> list = ctx.Tests;
            return list;
        }
    }
}
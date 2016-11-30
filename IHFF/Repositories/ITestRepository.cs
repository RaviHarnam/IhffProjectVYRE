using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAllTests();
    }
}
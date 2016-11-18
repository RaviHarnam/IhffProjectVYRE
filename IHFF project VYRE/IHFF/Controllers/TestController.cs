using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Models;
namespace IHFF.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        private ITestRepository repos = new TestDbConnection();
        public ActionResult Index()
        {
            IEnumerable<Test> tests = repos.GetAllTests();
            return View(tests);
        }
        public ActionResult Master()
        {
            return new FilePathResult("~/Views/Shared/Master.cshtml", "text/html");
        }
    }
}
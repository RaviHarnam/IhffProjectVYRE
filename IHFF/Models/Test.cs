using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Movie { get; set; }
        public string Special { get; set; }
        public string Vyre { get; set; }

        public Test(int id, string movie, string special, string vyre)
        {
            Id = id;
            Movie = movie;
            Special = special;
            Vyre = vyre;
        }
        public Test()
        {

        }
    }
}
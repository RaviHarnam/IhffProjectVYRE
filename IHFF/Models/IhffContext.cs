using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class IhffContext : DbContext
    {
        public IhffContext()  : base("IhffConnection")
        {
            // LEEG
        }

   

        // Database sets
        public DbSet<Item> Items { get; set; }
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Special> Specials { get; set;}
        
    }
}
<<<<<<< HEAD
﻿using IHFF.Models;
using System;
=======
﻿using System;
>>>>>>> 77c597045b50a2eab5d0ed65c0bcd6dffb8722f6
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Models
{
    public class IhffContext : DbContext
    {
        public IhffContext()  : base("IhffConnection")
        {
            // LEEG
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("MOVIE");
     

            base.OnModelCreating(modelBuilder);
        }

        // Database sets
        public DbSet<Item> Items { get; set; }
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Special> Specials { get; set;}
        
    }
}
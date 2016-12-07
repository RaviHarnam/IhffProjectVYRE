
﻿using IHFF.Models;
using System;

﻿
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("ITEM");
            modelBuilder.Entity<Movie>().ToTable("MOVIE");
            modelBuilder.Entity<Special>().ToTable("SPECIAL");
            modelBuilder.Entity<Event>().ToTable("EVENT");
           
        }

        // Database sets
        public DbSet<Item> ITEMS { get; set; }
        public DbSet<Movie> MOVIES { get; set;}
        public DbSet<Special> SPECIALS { get; set;}
        public DbSet<Event> EVENTS { get; set; }
    }
}
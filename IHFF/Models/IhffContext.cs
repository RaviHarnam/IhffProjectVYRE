
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
            // ECHT F*CKING LEEG
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("ITEM");
            modelBuilder.Entity<Movie>().ToTable("MOVIE");
            modelBuilder.Entity<Special>().ToTable("SPECIAL");
            modelBuilder.Entity<Event>().ToTable("EVENT");
            modelBuilder.Entity<Afbeelding>().ToTable("AFBEELDING");
            modelBuilder.Entity<Employee>().ToTable("MEDEWERKER");
            modelBuilder.Entity<Voorstelling>().ToTable("VOORSTELLING");
            modelBuilder.Entity<Restaurant>().ToTable("RESTAURANT");
            modelBuilder.Entity<Museum>().ToTable("MUSEUM");
            modelBuilder.Entity<Locatie>().ToTable("LOCATIE");
        }

        // Database sets
        public DbSet<Item> ITEMS { get; set; }
        public DbSet<Movie> MOVIES { get; set;}
        public DbSet<Special> SPECIALS { get; set;}
        public DbSet<Event> EVENTS { get; set; }
        public DbSet<Afbeelding> AFBEELDINGEN { get; set; }
        public DbSet<Employee> EMPLOYEES { get; set; }
        public DbSet<Voorstelling> VOORSTELLINGEN { get; set; }
        public DbSet<Restaurant> RESTAURANTS { get; set; }
        public DbSet<Museum> MUSEA { get; set; }
        public DbSet<Locatie> LOCATIES { get; set; }
    }
}
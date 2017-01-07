
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
            modelBuilder.Entity<Hotel>().ToTable("HOTEL");
            modelBuilder.Entity<Event>().ToTable("EVENT");
            modelBuilder.Entity<Afbeelding>().ToTable("AFBEELDING");
            modelBuilder.Entity<Employee>().ToTable("MEDEWERKER");
            modelBuilder.Entity<Voorstelling>().ToTable("VOORSTELLING");
            modelBuilder.Entity<Restaurant>().ToTable("RESTAURANT");
            modelBuilder.Entity<Museum>().ToTable("MUSEUM");
            modelBuilder.Entity<Locatie>().ToTable("LOCATIE");
            modelBuilder.Entity<Maaltijd>().ToTable("MAALTIJD");
            modelBuilder.Entity<Zaal>().ToTable("ZAAL");
        }

        // Database sets
        public DbSet<Item> ITEMS { get; set; }
        public DbSet<Movie> MOVIES { get; set;}
        public DbSet<Special> SPECIALS { get; set;}
        public DbSet<Hotel> HOTEL { get; set; }
        public DbSet<Event> EVENTS { get; set; }
        public DbSet<Afbeelding> AFBEELDINGEN { get; set; }
        public DbSet<Employee> EMPLOYEES { get; set; }
        public DbSet<Voorstelling> VOORSTELLINGEN { get; set; }
        public DbSet<Restaurant> RESTAURANTS { get; set; }
        public DbSet<Museum> MUSEA { get; set; }
        public DbSet<Locatie> LOCATIES { get; set; }
        public DbSet<Maaltijd> MAALTIJD { get; set; }
        public DbSet<Zaal> ZALEN { get; set; }
    }
}
﻿using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;


namespace IHFF.Helpers
{
    public class MakeEventHelper
    {
        private IMoviesRepository dbMovie = new DbMovieRepository();
        private IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
        private IItemRepository dbItemRespository = new DbItemRepository();

        private static MakeEventHelper uniqueInstance;

        private MakeEventHelper() { }

        public static MakeEventHelper GetInstance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new MakeEventHelper();

            return uniqueInstance;
        }

        public void MakeEvent(int voorstellingId, int aantal, string button)
        {
            bool eventAlInCart = false;
            Voorstelling v = dbVoorstelling.GetVoorstelling(voorstellingId);
            if (v.GereserveerdePlaatsen < v.MaxPlaatsen)
            {

                Event eventx = new Event();
                Item i = dbItemRespository.GetItem(v.ItemID);
                eventx.Aantal = aantal;
                eventx.DatumTijd = v.BeginTijd;
                eventx.Prijs = v.Prijs;
                eventx.Titel = i.Titel;
                eventx.VoorstellingID = v.VoorstellingID;
                if (HttpContext.Current.Session[button] == null)
                    HttpContext.Current.Session[button] = new List<Event>();

                List<Event> cartlist = (List<Event>)HttpContext.Current.Session[button]; // als er al een lijst met events bestaat voeg alle events toe aan de lijst waarmee gewerkt kan worden 

                foreach (Event ev in cartlist) {
                    if (ev.VoorstellingID == v.VoorstellingID)
                    {
                        ev.Aantal += eventx.Aantal;
                        eventAlInCart = true;
                    }
                }
                if(!eventAlInCart)
                {
                    cartlist.Add(eventx);
                }
                
                HttpContext.Current.Session[button] = cartlist;
            }
        }
    }
}
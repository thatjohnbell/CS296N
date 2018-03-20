﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyOurTShirts.Models;

namespace BuyOurTShirts.Repositories
{
    public class ShowRepo : IShowRepository
    {

        private readonly BotsDbContext context;

        public ShowRepo(BotsDbContext ctx)
        {
            context = ctx;
        }

        public int Add(Show show)
        {
            context.Show.Add(show);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var show = context.Show.FirstOrDefault(a => a.ID == id);
            context.Show.Remove(show);
            return context.SaveChanges();
        }

       public int Edit(Show show)
        {
            context.Show.Update(show);
            return context.SaveChanges();
        }

        public List<Show> GetAllShows()
        {
            List<Show> shows = context.Show.Where(a=>a.date>DateTime.Now).ToList();
             foreach (Show sh in shows) sh.venue = GetShowVenue(sh.VenueID);
            return shows;
        }
        public List<ShowType> GetAllShowTypes() => new List<ShowType> { ShowType.Private, ShowType.Public };

        public Show GetShowById(int id) {
            var show = context.Show.FirstOrDefault(a => a.ID == id);
            show.venue = GetShowVenue(show.VenueID);
            return show;
         }

        public List<Show> GetShowsByVenue(int id) => context.Show.Where(a => a.VenueID == id && a.date>DateTime.Now).ToList();
        

        private Venue GetShowVenue(int id) => context.Venue.FirstOrDefault(a => a.ID == id);
        
    }
}
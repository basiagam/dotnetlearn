using Gadzet.Models.CMS;
using Gadzet.Models.Sklep;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gadzet.Models
{
    public class GadzetContext : IdentityDbContext<ApplicationUser>
    {
        public GadzetContext() : base("name=GadzetContext") { } 

        public static GadzetContext Create()
        {
            return new GadzetContext();
        }

        public DbSet<Aktualnosc> Aktualnosci { get; set; }

        public DbSet<Towar> Towary { get; set; }
        public DbSet<TowarStan> TowarStany { get; set; }
        public DbSet<TowarZdjecie> TowarZdjecia { get; set; }

        public DbSet<Handlowiec> Handlowcy { get; set; }
    }
}
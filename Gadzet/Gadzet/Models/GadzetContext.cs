using Gadzet.Models.CMS;
using Gadzet.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gadzet.Models
{
    public class GadzetContext : DbContext
    {
        public GadzetContext() : base("name=GadzetContext") { }

        public DbSet<Aktualnosc> Aktualnosci { get; set; }

        public DbSet<Towar> Towary { get; set; }
        public DbSet<TowarStan> TowarStany { get; set; }
        public DbSet<TowarZdjecie> TowarZdjecia { get; set; }
    }
}
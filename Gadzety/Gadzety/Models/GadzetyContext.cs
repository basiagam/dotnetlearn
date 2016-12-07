using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gadzety.Models
{
    public class GadzetyContext : IdentityDbContext
    {
        public GadzetyContext()
            : base("name=GadzetyContext")
        {
        }

        public static GadzetyContext Create()
        {
            return new GadzetyContext();
        }

        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Towar> Towary { get; set; }
        public DbSet<TowarStan> TowarStany { get; set; }
        public DbSet<TowarZdjecie> TowarZdjecia { get; set; }
    }
}
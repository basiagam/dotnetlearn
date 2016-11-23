using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gadzety.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

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
        public DbSet<Towar_Kategoria> Towar_Kategoria { get; set; }
        public DbSet<Towar> Towary { get; set; }
        public DbSet<TowarStan> TowarStany { get; set; }
        public DbSet<TowarZdjecie> TowarZdjecia { get; set; }
    }
}
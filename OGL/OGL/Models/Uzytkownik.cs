using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OGL.Models
{
    // Dane profilu dla użytkownika można dodać, dodając więcej właściwości do własnej klasy Uzytkownik. Więcej informacji można znaleźć na stronie http://go.microsoft.com/fwlink/?LinkID=317594.
    public class Uzytkownik : IdentityUser
    {
        public Uzytkownik()
        {
            this.Ogloszenia = new HashSet<Ogloszenie>;
        }

        // Klucz podstawowy odziedziczony po klasie IdentityUser
        // Dodajemy pola Imie i Nazwisko
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        #region dodatkowe pole notmapped
        [NotMapped] // using System.ComponentModel.DataAnnotations.Schema;
        [Display(Name = "Pan/Pani:")]
        public string PelneNazwisko
        {
            get { return Imie + " " + Nazwisko; }
        } 
        #endregion

        public ICollection<Ogloszenie> Ogloszenia { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }
}
using Gadzet.Models.CMS;
using Gadzet.Models.Sklep;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gadzet.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<GadzetContext>
    {
        protected override void Seed(GadzetContext context)
        {
            #region ROLE
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var rolaAdmin = new IdentityRole { Name = "Admin" };
            roleManager.Create(rolaAdmin);

            var rolaHandlowiec = new IdentityRole { Name = "Handlowiec" };
            roleManager.Create(rolaHandlowiec);
            context.SaveChanges();
            #endregion

            #region Konto Administratora
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            string haslo = "piab123";
            string email = "asp.mvc@piab.com";
            ApplicationUser uzytkownik = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
            };
            if (userManager.Create(uzytkownik, haslo).Succeeded)
            {
                userManager.AddToRole(uzytkownik.Id, "Admin");
                Handlowiec handlowiec = new Handlowiec()
                {
                    Email = uzytkownik.Email,
                    Imie = "Admin",
                    Nazwisko = "PIAB",
                    UserId = uzytkownik.Id
                };
                context.Handlowcy.Add(handlowiec);
                context.SaveChanges();
            }
            context.SaveChanges();
            #endregion


            var aktualnosci = new List<Aktualnosc>
            {
                new Aktualnosc {Tytul = "Tytuł aktualności 1", Tresc = "Treśćaktualnosci 1", Pozycja = 1 },
                new Aktualnosc {Tytul = "Tytuł aktualności 2", Tresc = "Treśćaktualności 2", Pozycja = 2 },
                new Aktualnosc {Tytul = "Tytuł aktualności 3", Tresc = "Treśćaktualności 3", Pozycja = 3 },
                new Aktualnosc {Tytul = "Tytuł aktualności 4", Tresc = "Treśćaktualności 4", Pozycja = 4 },
                new Aktualnosc {Tytul = "Tytuł aktualności 5", Tresc = "Treśćaktualności 5", Pozycja = 5 },
            };
            foreach (var a in aktualnosci)
            {
                context.Aktualnosci.Add(a);
            }
            var towary = new List<Towar>
            {
                new Towar { Nazwa = "Towar 1", Opis = "Opis towaru 1", VIPTowar
                = false, TowarPromocyjny = true, Cena = 1 },
                new Towar { Nazwa = "Towar 2 VIP", Opis = "Opis towaru 2 VIP",
                VIPTowar = true, TowarPromocyjny = false , Cena = 2 },
                new Towar { Nazwa = "Towar 3", Opis = "Opis towaru 3", VIPTowar
                = false, TowarPromocyjny = true, Cena = 3 },
                new Towar { Nazwa = "Towar 4", Opis = "Opis towaru 4", VIPTowar
                = false, TowarPromocyjny = false, Cena = 4 },
                new Towar { Nazwa = "Towar 5", Opis = "Opis towaru 5", VIPTowar
                = false, TowarPromocyjny = false, Cena = 5 },
                new Towar { Nazwa = "Towar 6", Opis = "Opis towaru 6", VIPTowar
                = false, TowarPromocyjny = false, Cena = 6 },
                new Towar { Nazwa = "Towar 7", Opis = "Opis towaru 7", VIPTowar
                = false, TowarPromocyjny = false, Cena = 7 },
                new Towar { Nazwa = "Towar 8", Opis = "Opis towaru 8", VIPTowar
                = false, TowarPromocyjny = false, Cena = 8 },
                new Towar { Nazwa = "Towar 9", Opis = "Opis towaru 9", VIPTowar
                = false, TowarPromocyjny = false, Cena = 9 },
                new Towar { Nazwa = "Towar 10", Opis = "Opis towaru 10",
                VIPTowar = false, TowarPromocyjny = false, Cena = 10 },
            };
            foreach (var t in towary)
            {
                context.Towary.Add(t);
            }
            var towarZdjecia = new List<TowarZdjecie>
            {
                new TowarZdjecie { IdTowar = 1,
                Url="/Content/Images/image1.jpg" },
                new TowarZdjecie { IdTowar = 2,
                Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 3,
                Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 4,
                Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 5,
                Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 6,
                Url="/Content/Images/image1.jpg" },
                new TowarZdjecie { IdTowar = 7,
                Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 8,
                Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 9,
                Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 10,
                Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 1,
                Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 2,
                Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 3,
                Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 4,
                Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 5,
                Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 6,
                Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 7,
                Url="/Content/Images/image1.jpg" },
                new TowarZdjecie { IdTowar = 8,
                Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 9,
                Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 10,
                Url="/Content/Images/image1.jpg" },
                };
            foreach (var z in towarZdjecia)
            {
                context.TowarZdjecia.Add(z);
            }
            var towarStany = new List<TowarStan>
            {
                new TowarStan {IdTowar = 1, Stan = 11, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 2, Stan = 12, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 3, Stan = 13, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 4, Stan = 14, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 5, Stan = 15, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 6, Stan = 16, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 7, Stan = 17, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 8, Stan = 18, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 9, Stan = 19, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 10, Stan = 20, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 1,Stan = 101, DataDodania =
                DateTime.Now },
                new TowarStan {IdTowar = 2,Stan = 102, DataDodania =
                DateTime.Now },
                };
            foreach (var s in towarStany)
            {
                context.TowarStany.Add(s);
            }
        }
    }
}
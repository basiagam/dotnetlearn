using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gadzety.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<GadzetyContext>
    {
        protected override void Seed(GadzetyContext context)
        {
            var Towary = new List<Towar>
            {
                new Towar {Nazwa = "Towar 1", Opis="Opis towaru", Cena = 1, TowarPolecany = true, TowarPromocyjny = false },
                new Towar {Nazwa = "Towar 2", Opis="Opis towaru", Cena = 2, TowarPolecany = false, TowarPromocyjny = false },
                new Towar {Nazwa = "Towar 3", Opis="Opis towaru", Cena = 3, TowarPolecany = true, TowarPromocyjny = true },
                new Towar {Nazwa = "Towar 4", Opis="Opis towaru", Cena = 4, TowarPolecany = true, TowarPromocyjny = false },
                new Towar {Nazwa = "Towar 5", Opis="Opis towaru", Cena = 5, TowarPolecany = true, TowarPromocyjny = true },
            };

            foreach (var t in Towary)
            {
                context.Towary.Add(t);
            }

            var Kategorie = new List<Kategoria>
            {
                new Kategoria {Nazwa="Męskie" },
                new Kategoria {Nazwa="Damskie" },
                new Kategoria {Nazwa="Dla dzieci" },
                new Kategoria {Nazwa="Kawalerski" },
                new Kategoria {Nazwa="Panieński" },
                new Kategoria {Nazwa="Dla mamy" },
            };

            foreach (var k in Kategorie)
            {
                context.Kategorie.Add(k);
            }

            var towarZdjecia = new List<TowarZdjecie>
            {
                new TowarZdjecie { IdTowar = 1,Url="/Content/Images/image1.jpg" },
                new TowarZdjecie { IdTowar = 2,Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 3,Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 4,Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 5,Url="/Content/Images/image5.jpg" },
            };

            foreach (var z in towarZdjecia)
            {
                context.TowarZdjecia.Add(z);
            }

            var towarStany = new List<TowarStan>
            {
            new TowarStan {IdTowar = 1, Stan = 11, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 2, Stan = 12, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 3, Stan = 13, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 4, Stan = 14, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 5, Stan = 15, DataDodania = DateTime.Now },
            };

            foreach (var s in towarStany)
            {
                context.TowarStany.Add(s);
            }
        }
    }
}
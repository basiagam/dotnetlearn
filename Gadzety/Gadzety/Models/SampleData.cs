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

            var Kategorie = new List<Kategoria>
            {
                new Kategoria {Nazwa="Męskie"},
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

            var Towary = new List<Towar>
            {
                new Towar {Nazwa = "Towar 1", Opis="Opis towaru", Cena = 1, TowarPolecany = true, TowarPromocyjny = false,IdKategoria = 1 },
                new Towar {Nazwa = "Towar 2", Opis="Opis towaru", Cena = 2, TowarPolecany = false, TowarPromocyjny = false,IdKategoria = 2 },
                new Towar {Nazwa = "Towar 3", Opis="Opis towaru", Cena = 3, TowarPolecany = true, TowarPromocyjny = true,IdKategoria = 3 },
                new Towar {Nazwa = "Towar 4", Opis="Opis towaru", Cena = 4, TowarPolecany = true, TowarPromocyjny = false,IdKategoria = 4 },
                new Towar {Nazwa = "Towar 5", Opis="Opis towaru", Cena = 5, TowarPolecany = true, TowarPromocyjny = true,IdKategoria = 5 },
                new Towar {Nazwa = "Towar 6", Opis="Opis towaru", Cena = 6, TowarPolecany = true, TowarPromocyjny = false,IdKategoria = 2 },
                new Towar {Nazwa = "Towar 7", Opis="Opis towaru", Cena = 7, TowarPolecany = false, TowarPromocyjny = false,IdKategoria = 1 },
                new Towar {Nazwa = "Towar 8", Opis="Opis towaru", Cena = 8, TowarPolecany = true, TowarPromocyjny = true,IdKategoria = 3 },
                new Towar {Nazwa = "Towar 9", Opis="Opis towaru", Cena = 9, TowarPolecany = true, TowarPromocyjny = false,IdKategoria = 4 },
                new Towar {Nazwa = "Towar 10", Opis="Opis towaru", Cena = 10, TowarPolecany = true, TowarPromocyjny = true,IdKategoria = 5 },
            };

            foreach (var t in Towary)
            {
                context.Towary.Add(t);
            }

            var towarZdjecia = new List<TowarZdjecie>
            {
                new TowarZdjecie { IdTowar = 1,Url="/Content/Images/image1.jpg" },
                new TowarZdjecie { IdTowar = 2,Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 3,Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 4,Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 5,Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 6,Url="/Content/Images/image1.jpg" },
                new TowarZdjecie { IdTowar = 7,Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 8,Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 9,Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 10,Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 1,Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 2,Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 3,Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 4,Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 5,Url="/Content/Images/image1.jpg" },
                new TowarZdjecie { IdTowar = 6,Url="/Content/Images/image5.jpg" },
                new TowarZdjecie { IdTowar = 7,Url="/Content/Images/image4.jpg" },
                new TowarZdjecie { IdTowar = 8,Url="/Content/Images/image3.jpg" },
                new TowarZdjecie { IdTowar = 9,Url="/Content/Images/image2.jpg" },
                new TowarZdjecie { IdTowar = 10,Url="/Content/Images/image1.jpg" },
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
            new TowarStan {IdTowar = 6, Stan = 11, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 7, Stan = 12, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 8, Stan = 13, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 9, Stan = 14, DataDodania = DateTime.Now },
            new TowarStan {IdTowar = 10, Stan = 15, DataDodania = DateTime.Now },
            };

            foreach (var s in towarStany)
            {
                context.TowarStany.Add(s);
            }
        }
    }
}
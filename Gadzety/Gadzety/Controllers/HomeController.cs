using Gadzety.Models;
using Gadzety.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gadzety.Controllers
{
    public class HomeController : Controller
    {
        private GadzetyContext db = new GadzetyContext();

        public ActionResult Index()
        {
            ViewBag.Tytul = "Strona główna";
            return View();
        }

        public ActionResult _Polecane()
        {
            var polecaneTowary = (from t in db.Towary
                                  where t.TowarPolecany == true
                                          select new TowarViewModel
                                          {
                                              Nazwa = t.Nazwa,
                                              Opis = t.Opis,
                                              TowarPromocyjny = t.TowarPromocyjny,
                                              TowarPolecany = t.TowarPolecany,
                                              IdKategoria = t.IdKategoria,
                                              Kategoria = t.Kategoria,
                                              Cena = t.Cena,
                                              IdTowar = t.IdTowar,
                                              Zdjecia = t.TowarZdjecia.Select(x => x.Url),
                                              AktualnyStan = t.TowarStany.Sum(x => x.Stan)
                                          }).Take(10).ToList();
 
            return PartialView(polecaneTowary);
        }

        public ActionResult _Kategorie()
        {
            List<Kategoria> kategorie = db.Kategorie.ToList();
            return PartialView(kategorie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
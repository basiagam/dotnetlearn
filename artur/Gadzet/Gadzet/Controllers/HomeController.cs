using Gadzet.Models;
using Gadzet.Models.CMS;
using Gadzet.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gadzet.Controllers
{
    public class HomeController : Controller
    {
        public GadzetContext db = new GadzetContext();

        public ActionResult _Aktualnosci()
        {
            List<Aktualnosc> listaAktualnosci = db.Aktualnosci.OrderBy(x => x.Pozycja).ToList();
            return PartialView(listaAktualnosci);
        }

        public ActionResult _TowaryPromocyjne()
        {
            List<Towar> towaryPromocyjne = (from promocja in db.Towary
                                            where
                                            promocja.TowarPromocyjny == true
                                            select promocja).Take(4).ToList();
            return PartialView(towaryPromocyjne);
        }
        public ActionResult Index()
        {
            return View();
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
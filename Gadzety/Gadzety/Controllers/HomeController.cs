using Gadzety.Models;
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
            return View();
        }

        public ActionResult _Polecane()
        {
            List<Towar> polecaneTowary = db.Towary.Where(x => x.TowarPolecany == true).Take(9).ToList();
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
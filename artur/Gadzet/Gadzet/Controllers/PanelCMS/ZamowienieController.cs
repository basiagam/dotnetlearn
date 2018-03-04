using Gadzet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gadzet.Controllers.PanelCMS
{
    public class ZamowienieController : Controller
    {
        // GET: Zamowienie
        private GadzetContext db = new GadzetContext();

        public ActionResult Index()
        {
            var zamowienia = db.Zamowienia.ToList();
            return View(zamowienia);
        }
        public ActionResult Szczegoly(int id)
        {
            var zamowienie = db.Zamowienia.FirstOrDefault(x => x.IdZamowienie == id);
            if (zamowienie == null)
                return HttpNotFound();
            return View(zamowienie);
        }
    }
}
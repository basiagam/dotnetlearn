using Gadzet.Models;
using Gadzet.Models.BusinessLogic;
using Gadzet.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gadzet.Controllers
{
    public class TowarController : Controller
    {
        public GadzetContext db = new GadzetContext();

        // GET: Towar
        public ActionResult Index()
        {
            return View(db.Towary.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            TowarBL towarBL = new TowarBL();
            ViewBag.AktualnyStan = towarBL.AktualnyStanTowaru(id.Value);
            return View(towar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="IdTowar,Nazwa,Opis,Cena,VIPTowar,TowarPromocyjny")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(towar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TowarBL towarBL = new TowarBL();
            ViewBag.AktualnyStan = towarBL.AktualnyStanTowaru(towar.IdTowar);
            return View(towar);
        }

        public ActionResult ZwiekszStanTowaru(int id, int stan)
        {
            if (db.Towary.Any(x => x.IdTowar == id))
            {
                TowarStan nowyStan = new TowarStan
                {
                    DataDodania = DateTime.Now,
                    IdTowar = id,
                    Stan = stan,
                };
                db.TowarStany.Add(nowyStan);
                db.SaveChanges();
                TowarBL towarBL = new TowarBL();
                int aktualnyStan = towarBL.AktualnyStanTowaru(id);
                return Json(new
                {
                    stan = aktualnyStan,
                    wiadomosc = "Zwiększono stan towaru" });
                }
            return Json(new { stan = -1, wiadomosc = "Brak towaru o podanym id" },
            JsonRequestBehavior.AllowGet);
            }

        public ActionResult _ListaTowarow(string szukaj, string sort)
        {
            var towary = from t in db.Towary
                         select t;
            if (!string.IsNullOrEmpty(szukaj))
            {
                towary = (from t in towary
                          where
                          t.Nazwa.Contains(szukaj)
                          select t);
            }
            string[] tablicaSort = new string[5];
            tablicaSort[0] = "Nazwa";
            tablicaSort[1] = "Opis";
            tablicaSort[2] = "Cena";
            tablicaSort[3] = "VIPTowar";
            tablicaSort[4] = "Promocyjny";
            switch (sort)
            {
                case "Nazwa":
                    towary = towary.OrderBy(x => x.Nazwa);
                    tablicaSort[0] = "Nazwa_desc";
                    break;
                case "Nazwa_desc":
                    towary = towary.OrderByDescending(x => x.Nazwa);
                    tablicaSort[0] = "Nazwa";
                    break;
                case "Opis":
                    towary = towary.OrderBy(x => x.Opis);
                    tablicaSort[1] = "Opis_desc";
                    break;
                case "Opis_desc":
                    towary = towary.OrderByDescending(x => x.Opis);
                    tablicaSort[1] = "Opis";
                    break;
                case "Cena":
                    towary = towary.OrderBy(x => x.Cena);
                    tablicaSort[2] = "Cena_desc";
                    break;
                case "Cena_desc":
                    towary = towary.OrderByDescending(x => x.Cena);
                    tablicaSort[2] = "Cena";
                    break;
                case "VIPTowar":
                    towary = towary.OrderBy(x => x.VIPTowar);
                    tablicaSort[3] = "VIPTowar_desc";
                    break;
                case "VIPTowar_desc":
                    towary = towary.OrderByDescending(x => x.VIPTowar);
                    tablicaSort[3] = "VIPTowar";
                    break;
                case "Promocyjny":
                    towary = towary.OrderBy(x => x.TowarPromocyjny);
                    tablicaSort[4] = "Promocyjny_desc";
                    break;
                case "Promocyjny_desc":
                    towary = towary.OrderByDescending(x => x.TowarPromocyjny);
                    tablicaSort[4] = "Promocyjny";
                    break;
            }
            ViewBag.TablicaSort = tablicaSort;
            ViewBag.Szukaj = szukaj;
            return PartialView(towary.ToList());
        }

        // GET: Towar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Towar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTowar,Nazwa,Opis,Cena,VIPTowar,TowarPromocyjny")] Towar towar, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
            {
                ModelState.AddModelError("BladPliku", "Zdjęcie jest wymagane.");
            }
            if (ModelState.IsValid)
            {
                var rozszerzeniePliku = Path.GetExtension(file.FileName);//Pobieramy rozszerzenie pliku
            //Tworzymynlosową nazwę pliku i dodajemy do niej rozszerzenie
            //Guid tworzynam unikatowy identyfikator, który ma bardzo niskie prawdopodobieństwo powtórzenia.
            var nowaNazwaPliku = Guid.NewGuid() + rozszerzeniePliku;
                //Zdjęcia będą dodawane do folderu Images
                var lokalizacjaDlaPliku =
                Path.Combine(Server.MapPath("~/Content/Images/"), nowaNazwaPliku);
                file.SaveAs(lokalizacjaDlaPliku);
                TowarZdjecie zdjecie = new TowarZdjecie
                {
                    Towar = towar,
                    Url = "/Content/Images/" + nowaNazwaPliku,
                };
                TowarStan stan = new TowarStan
                {
                    DataDodania = DateTime.Now,
                    Stan = 0,
                    Towar = towar,
                };
                db.Entry(towar).State = EntityState.Added;
                db.Entry(zdjecie).State = EntityState.Added;
                db.Entry(stan).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(towar);
        }

        public ActionResult DodajZdjecia(int id)
        {
            Towar towar = db.Towary.FirstOrDefault(x => x.IdTowar == id);
            if (towar == null)
                return HttpNotFound();
            ViewBag.IdTowar = id;
            return View();
        }

        [HttpPost]
        public ActionResult ZapiszZdjecia(int id)
        {
            Towar towar = db.Towary.FirstOrDefault(x => x.IdTowar == id);
            if (towar == null)
                return HttpNotFound();
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                var rozszerzeniePliku = Path.GetExtension(file.FileName);
                var nowaNazwaPliku = Guid.NewGuid() + rozszerzeniePliku;
                var lokalizacjaDlaPliku =
                Path.Combine(Server.MapPath("~/Content/Images/"), nowaNazwaPliku);
                if (file != null && file.ContentLength > 0)
                {
                    var towarZdjecie = new TowarZdjecie
                    {
                        IdTowar = towar.IdTowar,
                        Url = "/Content/Images/" + nowaNazwaPliku,
                    };
                    file.SaveAs(lokalizacjaDlaPliku);
                    db.TowarZdjecia.Add(towarZdjecie);
                }
            }
            db.SaveChanges();
            return Json(new { Message = "ok", JsonRequestBehavior.AllowGet });
        }

        // GET: Aktualnosc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // POST: Aktualnosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Towar towar = db.Towary.Find(id);
            db.Aktualnosci.Remove(towar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gadzety.Models;

namespace Gadzety.Controllers
{
    public class TowarController : Controller
    {
        private GadzetyContext db = new GadzetyContext();

        public ActionResult PokazKategorie(int id)
        {
            ViewBag.NazwaKategorii = (db.Kategorie.Where(x => x.IdKategoria == id).FirstOrDefault().Nazwa);
            return View(db.Towary.Where(x => x.IdKategoria == id).ToList());
        }

        // GET: Towar
        public ActionResult Index()
        {
            return View(db.Towary.ToList());
        }

        // GET: Towar/Details/5
        public ActionResult Details(int? id)
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

        // GET: Towar/Create
        public ActionResult Create()
        {
            ViewBag.ListaKategori = new SelectList(db.Kategorie, "IdKategoria", "Nazwa");
            return View();
        }

        // POST: Towar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTowar,Nazwa,Opis,Cena,TowarPromocyjny,TowarPolecany")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Towary.Add(towar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListaKategori = new SelectList(db.Kategorie, "IdKategoria", "Nazwa");
            return View(towar);
        }

        // GET: Towar/Edit/5
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
            ViewBag.ListaKategori = new SelectList(db.Kategorie, "IdKategoria", "Nazwa");
            return View(towar);
        }

        // POST: Towar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTowar,Nazwa,Opis,Cena,TowarPromocyjny,TowarPolecany")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(towar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListaKategori = new SelectList(db.Kategorie, "IdKategoria", "Nazwa");
            return View(towar);
        }

        // GET: Towar/Delete/5
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

        // POST: Towar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Towar towar = db.Towary.Find(id);
            db.Towary.Remove(towar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

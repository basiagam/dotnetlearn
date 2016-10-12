using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gadzet.Models;
using Gadzet.Models.CMS;

namespace Gadzet.Controllers.PanelCMS
{
    public class AktualnoscController : Controller
    {
        private GadzetContext db = new GadzetContext();

        // GET: Aktualnosc
        public ActionResult Index()
        {
            return View(db.Aktualnosci.ToList());
        }

        // GET: Aktualnosc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktualnosc aktualnosc = db.Aktualnosci.Find(id);
            if (aktualnosc == null)
            {
                return HttpNotFound();
            }
            return View(aktualnosc);
        }

        // GET: Aktualnosc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aktualnosc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAktualnosc,Tytul,Tresc,Pozycja")] Aktualnosc aktualnosc)
        {
            if (ModelState.IsValid)
            {
                db.Aktualnosci.Add(aktualnosc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aktualnosc);
        }

        // GET: Aktualnosc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktualnosc aktualnosc = db.Aktualnosci.Find(id);
            if (aktualnosc == null)
            {
                return HttpNotFound();
            }
            return View(aktualnosc);
        }

        // POST: Aktualnosc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAktualnosc,Tytul,Tresc,Pozycja")] Aktualnosc aktualnosc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aktualnosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aktualnosc);
        }

        // GET: Aktualnosc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktualnosc aktualnosc = db.Aktualnosci.Find(id);
            if (aktualnosc == null)
            {
                return HttpNotFound();
            }
            return View(aktualnosc);
        }

        // POST: Aktualnosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aktualnosc aktualnosc = db.Aktualnosci.Find(id);
            db.Aktualnosci.Remove(aktualnosc);
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

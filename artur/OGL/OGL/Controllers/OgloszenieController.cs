﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using Repozytorium.Repo;
using Repozytorium.IRepo;
using Microsoft.AspNet.Identity;
using PagedList;

namespace OGL.Controllers
{
    public class OgloszenieController : Controller
    {
        private readonly IOgloszenieRepo _repo;

        public OgloszenieController(IOgloszenieRepo repo)
        {
            _repo = repo;
        } 

        // GET: Ogloszenie
        public ActionResult Index(int? page)
        {
            int currentPage = page ?? 1;
            int naStronie = 3;
            var ogloszenia = _repo.PobierzOgloszenia();
            ogloszenia = ogloszenia.OrderByDescending(d => d.DataDodania);
            return View(ogloszenia.ToPagedList<Ogloszenie>(currentPage,naStronie));
        }

        [OutputCache(Duration = 1000)]
        public ActionResult MojeOgloszenia(int? page)
        {
            int currentPage = page ?? 1;
            int naStronie = 3;
            string userId = User.Identity.GetUserId();
            var ogloszenia = _repo.PobierzOgloszenia();
            ogloszenia = ogloszenia.OrderByDescending(d => d.DataDodania).Where(o => o.UzytkownikId == userId );
            return View(ogloszenia.ToPagedList<Ogloszenie>(currentPage, naStronie));
        }

        // GET: Ogloszenie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //rzutujemy int? na int
            Ogloszenie ogloszenie = _repo.GetOgloszenieById((int) id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenie);
        }

        // GET: Ogloszenie/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogloszenie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tresc,Tytul")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                ogloszenie.UzytkownikId = User.Identity.GetUserId();
                ogloszenie.DataDodania = DateTime.Now;
                _repo.Dodaj(ogloszenie);
                try
                {
                    _repo.SaveChanges();
                    return RedirectToAction("MojeOgloszenia");
                }
                catch
                {
                    return View(ogloszenie);
                }
                return RedirectToAction("Index");
            }
            return View(ogloszenie);
        }

        // GET: Ogloszenie/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = _repo.GetOgloszenieById((int)id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            else if(ogloszenie.UzytkownikId != User.Identity.GetUserId() && !(User.IsInRole("Admin") || User.IsInRole("Pracownik")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(ogloszenie);
        }

        // POST: Ogloszenie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tresc,Tytul,DataDodania,UzytkownikId")] Ogloszenie ogloszenie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Aktualizuj(ogloszenie);
                    _repo.SaveChanges();
                }
                catch
                {
                    ViewBag.Blad = true;
                    return View(ogloszenie);
                }
            }
            ViewBag.Blad = false;
            return View(ogloszenie);
        }

        // GET: Ogloszenie/Delete/5
        [Authorize]
        public ActionResult Delete(int? id,bool? blad)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenie ogloszenie = _repo.GetOgloszenieById((int)id);
            if (ogloszenie == null)
            {
                return HttpNotFound();
            }
            else if (ogloszenie.UzytkownikId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (blad != null)
                ViewBag.blad = true;
            return View(ogloszenie);
        }

        // POST: Ogloszenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.UsunOgloszenie(id);
            try
            {
                _repo.SaveChanges();
            } 
            catch
            {
                return RedirectToAction("Delete", new { id = id, blad = true });
            }
            return RedirectToAction("Index");
        }

        //protected override void dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.dispose();
        //    }
        //    base.dispose(disposing);
        //}

        public ActionResult Partial(int? page)
        {
            int currentPage = page ?? 1;
            int naStronie = 3;
            var ogloszenia = _repo.PobierzOgloszenia();
            ogloszenia = ogloszenia.OrderByDescending(d=>d.DataDodania);
            return PartialView("Index", ogloszenia.ToPagedList<Ogloszenie>(currentPage, naStronie));
        }
    }
}

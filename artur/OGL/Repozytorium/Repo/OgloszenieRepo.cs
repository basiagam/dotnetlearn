﻿using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    public class OgloszenieRepo : IOgloszenieRepo
    {
        private readonly IOglContext _db;

        public OgloszenieRepo(IOglContext db)
        {
            _db = db;
        }

        public IQueryable<Ogloszenie> PobierzOgloszenia()
        {
            var ogloszenia = _db.Ogloszenia.AsNoTracking();
            return ogloszenia;
        }

        public Ogloszenie GetOgloszenieById(int id)
        {
            Ogloszenie ogloszenie = _db.Ogloszenia.Find(id);
            return ogloszenie;
        }

        public bool UsunOgloszenie(int id)
        {
            UsunPowiazaneOgloszenieKategoria(id);
            Ogloszenie ogloszenie = _db.Ogloszenia.Find(id);
            _db.Ogloszenia.Remove(ogloszenie);
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private void UsunPowiazaneOgloszenieKategoria(int idOgloszenia)
        {
            var list = _db.Ogloszenie_Kategoria.Where(o => o.Id == idOgloszenia);
            foreach(var el in list)
            {
                _db.Ogloszenie_Kategoria.Remove(el);
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dodaj(Ogloszenie ogloszenie)
        {
            _db.Ogloszenia.Add(ogloszenie);
        }

        public void Aktualizuj(Ogloszenie ogloszenie)
        {
            _db.Entry(ogloszenie).State = EntityState.Modified;
        }

        public IQueryable<Ogloszenie> PobierzStrone(int? page =1, int? pageSize =10)
        {
            var ogloszenia = _db.Ogloszenia
                .OrderByDescending(o => o.DataDodania)
                .Skip((page.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);
            return ogloszenia;
                
        }
    }
}
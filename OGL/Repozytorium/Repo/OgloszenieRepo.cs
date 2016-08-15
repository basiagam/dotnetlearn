using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
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

    }
}
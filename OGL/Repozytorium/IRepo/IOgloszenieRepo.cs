﻿using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    public interface IOgloszenieRepo
    {
        IQueryable<Ogloszenie> PobierzOgloszenia();
        Ogloszenie GetOgloszenieById(int id);
        bool UsunOgloszenie(int id);
        void SaveChanges();
    }
}
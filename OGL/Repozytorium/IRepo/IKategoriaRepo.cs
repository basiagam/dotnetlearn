using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    public interface IKategoriaRepo
    {
        IQueryable<Kategoria> PobierzKategorie();
        object PobierzOgloszeniaZKategorii(int id);
    }
}
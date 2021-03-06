﻿using Gadzet.Models;
using Gadzet.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;

namespace Gadzet.Controllers
{
    [Authorize(Roles ="Admin,Handlowcy")]
    public class SklepController : Controller
    {
        private GadzetContext db = new GadzetContext();

        // GET: Sklep
        public ActionResult Index(int page = 1, int sortowanie = 1)
        {
            int pageSize = 8;
            var towary = (from t in db.Towary
                          select new TowarViewModel
                          {
                              Nazwa = t.Nazwa,
                              Opis = t.Opis,
                              VIPTowar = t.VIPTowar,
                              TowarPromocyjny = t.TowarPromocyjny,
                              Cena = t.Cena,
                              IdTowar = t.IdTowar,
                              Zdjecia = t.TowarZdjecia.Select(x => x.Url),
                              AktualnyStan = t.TowarStany.Sum(x => x.Stan)
                          }).ToList() ;

            int liczbaZamowionych = 0;
            foreach (var t in towary)
            {
                if (db.ZamowieniePozycje.Any(x => x.IdTowar == t.IdTowar))
                {
                    liczbaZamowionych = (from z in db.ZamowieniePozycje
                                         where
                                         z.IdTowar == t.IdTowar
                                         select z.Ilosc).Sum();
                    t.AktualnyStan = t.AktualnyStan - liczbaZamowionych;
                }
            }

            string userId = User.Identity.GetUserId();

            bool handlowiecVIP = (from h in db.Handlowcy
                                  where
                                  h.UserId == userId
                                  select h.HandlowiecVIP).FirstOrDefault();

            if (handlowiecVIP == false)
            {
                towary = towary.Where(x => x.VIPTowar == false).ToList();
            }

            List<SelectListItem> sortowanieLista = new List<SelectListItem>
            {
            new SelectListItem {Text = "Nazwy A-Z", Value = "1", Selected =
            (sortowanie == 1? true : false) },
            new SelectListItem {Text = "Nazwy Z-A", Value = "2", Selected =
            (sortowanie == 2? true : false) },
            new SelectListItem {Text = "Ceny rosnąco", Value = "3", Selected =
            (sortowanie == 3? true : false) },
            new SelectListItem {Text = "Ceny malejąco", Value = "4", Selected =
            (sortowanie == 4? true : false) },
            };
            ViewBag.Sortowanie = sortowanie;
            ViewBag.SortowanieLista = sortowanieLista;
            switch (sortowanie)
            {
                case 1:
                    towary = towary.OrderBy(x => x.Nazwa).ToList();
                    break;
                case 2:
                    towary = towary.OrderByDescending(x => x.Nazwa).ToList();
                    break;
                case 3:
                    towary = towary.OrderBy(x => x.Cena).ToList();
                    break;
                case 4:
                    towary = towary.OrderByDescending(x => x.Cena).ToList();
                    break;
            }

            return View(towary.ToPagedList(page,pageSize));
        }

        public ActionResult Szczegoly(int id)
        {
            TowarViewModel towar = (from t in db.Towary
                                    where
                                    t.IdTowar == id
                                    select new TowarViewModel
                                    {
                                        Nazwa = t.Nazwa,
                                        Opis = t.Opis,
                                        VIPTowar = t.VIPTowar,
                                        TowarPromocyjny = t.TowarPromocyjny,
                                        Cena = t.Cena,
                                        IdTowar = t.IdTowar,
                                        Zdjecia = t.TowarZdjecia.Select(x => x.Url),
                                        AktualnyStan = t.TowarStany.Sum(x => x.Stan)
                                    }).FirstOrDefault();

            if (towar == null) //nie znaleziono towary
                return HttpNotFound();

            int liczbaZamowionych = 0;
            if (db.ZamowieniePozycje.Any(x => x.IdTowar == towar.IdTowar))
            {
                liczbaZamowionych = (from z in db.ZamowieniePozycje
                                     where
                                     z.IdTowar == towar.IdTowar
                                     select z.Ilosc).Sum();
            }
            towar.AktualnyStan = towar.AktualnyStan - liczbaZamowionych;

            return View(towar);
        }
    }
}
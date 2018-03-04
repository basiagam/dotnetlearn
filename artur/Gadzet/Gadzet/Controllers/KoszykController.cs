using Gadzet.Models;
using Gadzet.Models.Sklep;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gadzet.Controllers
{
    [Authorize(Roles = "Admin, Handlowcy")]
    public class KoszykController : Controller
    {
        // GET: Koszyk

        private GadzetContext db = new GadzetContext();
        private const string koszykSesjaKlucz = "koszykSesja";

        public ActionResult Index()
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            //Sprawdzamy czy mamy pozycje koszyka w sesji
            if (Session[koszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[koszykSesjaKlucz] as
                List<KoszykPozycja>;//Pobieramy elementy z sesji
            }
            return View(pozycjeKoszyka);
        }

        [HttpPost]
        public ActionResult DodajPozycjeDoKoszyka(int idTowar, int iloscTowaru)
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            if (Session[koszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[koszykSesjaKlucz] as List<KoszykPozycja>;
            }
            if (pozycjeKoszyka.Any(x => x.Towar.IdTowar == idTowar))
            {
                KoszykPozycja pozycjaWKoszyku = pozycjeKoszyka.Find(x =>
                x.Towar.IdTowar == idTowar);
                int stanTowary = pozycjaWKoszyku.Towar.TowarStany.Sum(x => x.Stan);
                if (stanTowary >= (pozycjaWKoszyku.Ilosc + iloscTowaru))
                {
                    pozycjaWKoszyku.Ilosc += iloscTowaru;
                    pozycjaWKoszyku.KwotaRazem = pozycjaWKoszyku.Ilosc *
                    pozycjaWKoszyku.Towar.Cena;
                }
            }
            else
            {
                Towar towar = db.Towary.FirstOrDefault(x => x.IdTowar == idTowar);
                if (towar == null)
                    return HttpNotFound();
                int stanTowary = towar.TowarStany.Sum(x => x.Stan);
                if (stanTowary >= iloscTowaru)
                {
                    KoszykPozycja nowaPozycja = new KoszykPozycja
                    {
                        Ilosc = iloscTowaru,
                        KwotaRazem = towar.Cena * iloscTowaru,
                        Towar = towar
                    };
                    pozycjeKoszyka.Add(nowaPozycja);
                }
            }
            Session[koszykSesjaKlucz] = pozycjeKoszyka;
            return RedirectToAction("Index");
        }

        public ActionResult UsunPozycjeZKoszyka(int idTowar)
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            if (Session[koszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[koszykSesjaKlucz] as List<KoszykPozycja>;
            }
            pozycjeKoszyka = pozycjeKoszyka.Where(x => x.Towar.IdTowar !=
            idTowar).ToList();
            Session[koszykSesjaKlucz] = pozycjeKoszyka;

            return RedirectToAction("Index");
        }

        public ActionResult DaneZamowienia()
        {
            string userId = User.Identity.GetUserId();
            Handlowiec handlowiec = (from h in db.Handlowcy
                                     where
                                     h.UserId == userId
                                     select h).FirstOrDefault();
            Zamowienie zamowienie = new Zamowienie();
            zamowienie.Email = handlowiec.Email;
            zamowienie.Imie = handlowiec.Imie;
            zamowienie.Nazwisko = handlowiec.Nazwisko;
            return View(zamowienie);
        }

        [HttpPost]
        public ActionResult DaneZamowienia(Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
                if (Session[koszykSesjaKlucz] != null)
                {
                    pozycjeKoszyka = Session[koszykSesjaKlucz] as List<KoszykPozycja>;
                }
                List<ZamowieniePozycja> pozycjeZamowienia = new List<ZamowieniePozycja>();
                foreach (var pozycja in pozycjeKoszyka)
                {
                    pozycjeZamowienia.Add(new ZamowieniePozycja
                    {
                        Cena = pozycja.Towar.Cena,
                        IdTowar = pozycja.Towar.IdTowar,
                        Ilosc = pozycja.Ilosc,
                        Wartosc = pozycja.Ilosc * pozycja.Towar.Cena,
                    });
                }
                string userId = User.Identity.GetUserId();
                Handlowiec handlowiec = (from h in db.Handlowcy
                                         where
                                         h.UserId == userId
                                         select h).FirstOrDefault();
                zamowienie.DataZamowienia = DateTime.Now;
                zamowienie.IdHandlowiec = handlowiec.IdHandlowiec;
                zamowienie.ZamowieniePozycja = pozycjeZamowienia;
                db.Zamowienia.Add(zamowienie);
                db.SaveChanges();
                Session[koszykSesjaKlucz] = null;
                return RedirectToAction("PotwierdzenieZamowienia");
            }
            return View(zamowienie);
        }

        public ActionResult PotwierdzenieZamowienia()
        {
            return View();
        }

        public ActionResult _MiniKoszyk()
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            //Sprawdzamy czy mamy pozycje koszyka w sesji
            if (Session[koszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[koszykSesjaKlucz] as
                List<KoszykPozycja>;//Pobieramy elementy z sesji
            }
            decimal wartoscKoszyka = 0;
            if (pozycjeKoszyka != null && pozycjeKoszyka.Count > 0)
            {
                wartoscKoszyka = pozycjeKoszyka.Sum(x => x.KwotaRazem);
            }
            ViewBag.WartoscKoszyka = wartoscKoszyka;
            return PartialView();
        }
    }
}
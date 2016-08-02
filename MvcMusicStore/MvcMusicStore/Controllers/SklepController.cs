using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class SklepController : Controller
    {
        MusicStoreEntities StoreDb = new MusicStoreEntities();

        // GET: Store
        public ActionResult Index()
        {
            var genres = StoreDb.Genres.ToList();
            return View(genres);
        }
        // GET: Store/Browse
        public ActionResult Browse(string genre)
        {
            var genreModel = StoreDb.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }
        // GET: Store/Details
        public ActionResult Details(int id)
        {
            var album = StoreDb.Albums.Find(id);
            return View(album);
        }
    }
}